//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Data.SqlClient;

namespace dotNetExt
{
    public static class Transient
    {
        const int defaultRetryCount = 2;

        #region Retry
        
        /// <summary>
        /// Execute the specified Action and retry (up to 2 times) if an Exception is encountered.
        /// </summary>
        /// <param name="codeBlockToTry">The Action ("code block") to execute.</param>
        public static void Retry(Action codeBlockToTry)
        {
            Retry<Exception>(codeBlockToTry);
        }

        /// <summary>
        /// Execute the specified Action and retry (up to the specified number of times) if an Exception is encountered.
        /// </summary>
        /// <param name="maxRetryCount">The maximum number of times to retry if Exception is encountered.</param>
        /// <param name="codeBlockToTry">The Action ("code block") to execute.</param>
        public static void Retry(int maxRetryCount, Action codeBlockToTry)
        {
            Retry<Exception>(maxRetryCount, codeBlockToTry);
        }

        /// <summary>
        /// Execute the specified Action and retry (up to 2 times) if specified generic Exception Type is encountered.
        /// </summary>
        /// <typeparam name="TException">The Exception Type to retry if encountered.</typeparam>
        /// <param name="codeBlockToTry">The Action ("code block") to execute.</param>
        public static void Retry<TException>(Action codeBlockToTry)
            where TException : Exception
        {
            Retry<TException>(defaultRetryCount, codeBlockToTry);
        }

        /// <summary>
        /// Execute the specified Action and retry (up to the specified number of times) if an Exception is encountered.
        /// </summary>
        /// <typeparam name="TException">The Exception Type to retry if encountered.</typeparam>
        /// <param name="maxRetryCount">The maximum number of times to retry if Exception is encountered.</param>
        /// <param name="codeBlockToTry">The Action ("code block") to execute.</param>
        /// <param name="catchExceptionBeforeRetry">The Action ("code block") to call before each retry attempt.</param>
        /// <param name="catchExceptionAfterFinalRetryAttempt">The Action ("code block") to call after the final retry attempt.</param>
        public static void Retry<TException>(int maxRetryCount, Action codeBlockToTry,
            Func<TException, int, bool> catchExceptionBeforeRetry = null,
            Action<TException, int> catchExceptionAfterFinalRetryAttempt = null
            )
            where TException : Exception
        {
            codeBlockToTry.RequireArgument("codeBlockToTry").NotNull();

            int retryCount = 0;
            TryAgain:
            try
            {
                codeBlockToTry();
            }
            catch (TException ex)
            {
                if (retryCount < maxRetryCount){
                    retryCount++;
                    
                    var shouldRetry = true;
                    if (catchExceptionBeforeRetry != null)
                    {
                        shouldRetry = catchExceptionBeforeRetry(ex, retryCount);
                    }

                    if (shouldRetry)
                    {
                        goto TryAgain;
                    }
                }

                if (catchExceptionAfterFinalRetryAttempt != null)
                {
                    catchExceptionAfterFinalRetryAttempt(ex, retryCount);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion

        #region "SqlRetry"

        public static void SqlRetry(Action codeBlockToTry)
        {
            SqlRetry(defaultRetryCount, codeBlockToTry);
        }

        public static void SqlRetry(int maxRetryCount, Action codeBlockToTry)
        {
            SqlRetry(maxRetryCount, codeBlockToTry, null);
        }

        public static void SqlRetry(int maxRetryCount, Action codeBlockToTry, Func<SqlException, int, bool> catchExceptionBeforeRetry,
            Action<SqlException, int> catchExceptionAfterFinalRetryAttempt = null
            )
        {
            Retry<SqlException>(maxRetryCount, codeBlockToTry,
                (ex, i) => // Before Retry
                {
                    var retry = true;
                    if (catchExceptionBeforeRetry != null)
                    {
                        retry = catchExceptionBeforeRetry(ex, i);
                    }
                    else
                    {
                        retry = IsSqlTransientException(ex);
                    }
                    return retry;
                },
                (ex, i) => // After final Retry
                {
                    if (catchExceptionAfterFinalRetryAttempt != null)
                    {
                        catchExceptionAfterFinalRetryAttempt(ex, i);
                    }
                });
        }

        private static bool IsSqlTransientException(SqlException ex)
        {
            switch (ex.Number)
            {
                case -2:    // Timeout Expired. The timeout period elapsed prior to completion of the operation or the server is not responding
                case 20:    // The instance of SQL Server you attempted to connect to does not support encryption
                case 64:    // A connection was successfully established with the server, but then an error occurred during the login process
                case 233:   // The client was unable to establish a connection because of an error during connection initialization process before login
                case 10053: // A transport-level error has occurred when receiving results from the server
                case 10054: // A transport-level error has occurred when sending the request to the server.
                case 10060: // A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible
                case 40143: // The service has encountered an error processing your request. Please try again.
                case 40197: // The service has encountered an error processing your request. Please try again.
                case 40501: // The service is currently busy. Retry the request after 10 seconds.
                case 40613: // Database '%.*ls' on server '%.*ls' is not currently available. Please retry the connection later.

                    return true;

                default:
                    return false;
            }
        }

        #endregion
    }
}
