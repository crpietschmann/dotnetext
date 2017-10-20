//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System.Collections;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace TestProject
{
    public enum SqlExceptionNumber : int
    {
        TimeoutExpired = -2,                    // Timeout Expired. The timeout period elapsed prior to completion of the operation or the server is not responding
        EncryptionNotSupported = 20,            // The instance of SQL Server you attempted to connect to does not support encryption
        LoginError = 64,                        // A connection was successfully established with the server, but then an error occurred during the login process
        ConnectionInitialization = 233,         // The client was unable to establish a connection because of an error during connection initialization process before login
        TransportLevelReceiving = 10053,        // A transport-level error has occurred when receiving results from the server
        TransportLevelSending = 10054,          // A transport-level error has occurred when sending the request to the server.
        EstablishingConnection = 10060,         // A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible
        ProcessingRequest = 40143,              // The service has encountered an error processing your request. Please try again.
        ServiceBudy = 40501,                    // The service is currently busy. Retry the request after 10 seconds.
        DatabaseOrServerNotAvailable = 40613    // Database '%.*ls' on server '%.*ls' is not currently available. Please retry the connection later.
    }

    public class SqlExceptionHelper
    {
        public static SqlException Generate(SqlExceptionNumber errorNumber)
        {
            return SqlExceptionHelper.Generate((int)errorNumber);
        }

        public static SqlException Generate(int errorNumber)
        {
            var ex = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

            var errors = GenerateSqlErrorCollection(errorNumber);
            SetPrivateFieldValue(ex, "_errors", errors);

            return ex;
        }

        private static SqlErrorCollection GenerateSqlErrorCollection(int errorNumber)
        {
            var t = typeof(SqlErrorCollection);

            var col = (SqlErrorCollection)FormatterServices.GetUninitializedObject(t);
            
            SetPrivateFieldValue(col, "errors", new ArrayList());

            var sqlError = GenerateSqlError(errorNumber);
            var method = t.GetMethod(
                "Add",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                );        
            method.Invoke(col, new object[] { sqlError });

            return col;
        }

        private static SqlError GenerateSqlError(int errorNumber)
        {
            var sqlError = (SqlError)FormatterServices.GetUninitializedObject(typeof(SqlError));

            SetPrivateFieldValue(sqlError, "number", errorNumber);
            SetPrivateFieldValue(sqlError, "message", string.Empty);
            SetPrivateFieldValue(sqlError, "procedure", string.Empty);
            SetPrivateFieldValue(sqlError, "server", string.Empty);
            SetPrivateFieldValue(sqlError, "source", string.Empty);

            return sqlError;
        }

        private static void SetPrivateFieldValue(object obj, string field, object val)
        {
            var member = obj.GetType().GetField(
                field,
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                );
            member.SetValue(obj, val);
        }
    }
}
