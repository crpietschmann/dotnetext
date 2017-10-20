//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetExt;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.Serialization;

namespace TestProject
{
    [TestClass]
    public class TransientTest
    {
        public class RetryTestException : Exception
        { }

        [TestMethod]
        public void RetryTest_001()
        {
            var i = 0;
            Transient.Retry(() =>
            {
                i++;
            });
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void RetryTest_002()
        {
            var i = 0;
            Transient.Retry(() =>
            {
                i++;
                if (i < 3) throw new Exception();
            });
            Assert.AreEqual(3, i);
        }

        [TestMethod]
        public void RetryTest_003()
        {
            var i = 0;
            Transient.Retry(4, () =>
            {
                i++;
                if (i < 5) throw new Exception();
            });
            Assert.AreEqual(5, i);
        }

        [TestMethod, ExpectedException(typeof(RetryTestException))]
        public void RetryTest_004()
        {
            Transient.Retry(() =>
            {
                throw new RetryTestException();
            });
        }

        [TestMethod, ExpectedException(typeof(RetryTestException))]
        public void RetryTest_005()
        {
            Transient.Retry(5, () =>
            {
                throw new RetryTestException();
            });
        }

        [TestMethod]
        public void RetryTest_006()
        {
            var i = 0;
            Transient.Retry<Exception>(() =>
            {
                i++;
            });
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void RetryTest_007()
        {
            var i = 0;
            Transient.Retry<Exception>(() =>
            {
                i++;
                if (i < 3) throw new Exception();
            });
            Assert.AreEqual(3, i);
        }

        [TestMethod]
        public void RetryTest_008()
        {
            var i = 0;
            Transient.Retry<Exception>(4, () =>
            {
                i++;
                if (i < 5) throw new Exception();
            });
            Assert.AreEqual(5, i);
        }

        [TestMethod, ExpectedException(typeof(RetryTestException))]
        public void RetryTest_009()
        {
            Transient.Retry<RetryTestException>(() =>
            {
                throw new RetryTestException();
            });
        }

        [TestMethod, ExpectedException(typeof(RetryTestException))]
        public void RetryTest_010()
        {
            Transient.Retry<RetryTestException>(5, () =>
            {
                throw new RetryTestException();
            });
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void RetryTest_011()
        {
            Transient.Retry<RetryTestException>(() =>
            {
                throw new Exception();
            });
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void RetryTest_012()
        {
            var retries = 0;
            Transient.Retry<RetryTestException>(() =>
            {
                Assert.AreEqual(0, retries);
                retries++;
                throw new Exception();
            });
        }

        [TestMethod]
        public void RetryTest_013()
        {
            var retries = 0;
            var beforeRetryCount = 0;
            Transient.Retry<Exception>(4,
            () => // Code Block to Try
            {
                retries++;
                if (retries <= 4) throw new Exception();
            },
            (ex, i) => // Catch Exception Before Retry
            {
                beforeRetryCount++;
                Assert.AreEqual(i, beforeRetryCount);
                return true; // Yes Retry
            },
            (ex, i) => // Catch Exception After Final Retry
            {
                Assert.AreEqual(5, i);
            }
            );

            Assert.AreEqual(5, retries);
        }

        [TestMethod]
        public void RetryTest_014()
        {
            var retries = 0;
            var beforeRetryCount = 0;
            Transient.Retry<Exception>(4,
            () => // Code Block to Try
            {
                retries++;
                if (retries <= 4) throw new Exception();
            },
            (ex, i) => // Catch Exception Before Retry
            {
                beforeRetryCount++;
                Assert.AreEqual(i, beforeRetryCount);
                return true; // Yes Retry
            }
            );

            Assert.AreEqual(5, retries);
        }

        [TestMethod]
        public void RetryTest_015()
        {
            var retries = 0;
            var beforeRetryCount = 0;
            Transient.Retry<Exception>(4,
            () => // Code Block to Try
            {
                retries++;
                if (retries <= 4) throw new Exception();
            },
            catchExceptionBeforeRetry: (ex, i) => // Catch Exception Before Retry
            {
                beforeRetryCount++;
                Assert.AreEqual(i, beforeRetryCount);
                return true; // Yes Retry
            }
            );

            Assert.AreEqual(5, retries);
        }

        [TestMethod]
        public void RetryTest_016()
        {
            var retries = 0;
            var beforeRetryCount = 0;
            Transient.Retry<Exception>(4,
            () => // Code Block to Try
            {
                retries++;
                if (retries <= 4) throw new Exception();
            },
            catchExceptionBeforeRetry: (ex, i) => // Catch Exception Before Retry
            {
                beforeRetryCount++;
                Assert.AreEqual(i, beforeRetryCount);
                return true; // Yes Retry
            },
            catchExceptionAfterFinalRetryAttempt: (ex, i) => // Catch Exception After Final Retry
            {
                Assert.AreEqual(5, i);
            }
            );

            Assert.AreEqual(5, retries);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void RetryTest_017()
        {
            Transient.Retry<Exception>(4, () => // Code Block to Try
            { 
                throw new Exception();
            },
            (ex, i) => // Catch Exception Before Retry
            {
                return false; // No, Do Not Retry
            }
            );
        }

        [TestMethod]
        public void SqlRetryTest_001()
        {
            var tries = 0;
            Transient.SqlRetry(() => {
                tries++;
            });
            Assert.AreEqual(1, tries);
        }

        [TestMethod]
        public void SqlRetryTest_002()
        {
            var tries = 0;
            Transient.SqlRetry(() =>
            {
                tries++;
                if (tries < 2) throw SqlExceptionHelper.Generate(SqlExceptionNumber.TimeoutExpired);
            });
            Assert.AreEqual(2, tries);
        }

        [TestMethod]
        public void SqlRetryTest_003()
        {
            var tries = 0;
            Transient.SqlRetry(() =>
            {
                tries++;
                if (tries < 2) throw SqlExceptionHelper.Generate(SqlExceptionNumber.TransportLevelReceiving);
            });
            Assert.AreEqual(2, tries);
        }

        [TestMethod]
        public void SqlRetryTest_004()
        {
            var tries = 0;
            Transient.SqlRetry(() =>
            {
                tries++;
                if (tries < 2) throw SqlExceptionHelper.Generate(SqlExceptionNumber.TransportLevelSending);
            });
            Assert.AreEqual(2, tries);
        }

        [TestMethod, ExpectedException(typeof(RetryTestException))]
        public void SqlRetryTest_005()
        {
            var tries = 0;
            Transient.SqlRetry(() =>
            {
                tries++;
                Assert.AreEqual(1, tries);
                throw new RetryTestException();
            });
        }

        [TestMethod]
        public void SqlRetryTest_006()
        {
            var tries = 0;
            Transient.SqlRetry(() =>
            {
                tries++;
                if (tries < 2) throw SqlExceptionHelper.Generate(500000);
            });
            // only 1 is expected since it's not a Transient SqlException error number
            Assert.AreEqual(1, tries);
        }

        [TestMethod]
        public void SqlRetryTest_007()
        {
            var catchExceptionBeforeRetryCalled = false;

            var tries = 0;
            Transient.SqlRetry(5, () =>
            {
                tries++;
                if (tries < 5) throw SqlExceptionHelper.Generate(SqlExceptionNumber.TimeoutExpired);
            }, (ex, i) =>
            {
                Assert.IsNotNull(ex);
                Assert.IsInstanceOfType(ex, typeof(SqlException));
                catchExceptionBeforeRetryCalled = true;
                return false;
            });
            Assert.AreEqual(1, tries);
            Assert.IsTrue(catchExceptionBeforeRetryCalled);
        }

        [TestMethod]
        public void SqlRetryTest_008()
        {
            var catchExceptionBeforeRetryCalled = false;
            var catchExceptionAfterFinalRetryAttemptCalled = false;

            var tries = 0;
            Transient.SqlRetry(5, () =>
            {
                tries++;
                throw SqlExceptionHelper.Generate(SqlExceptionNumber.TimeoutExpired);
            }, (ex, i) =>
            {
                Assert.IsNotNull(ex);
                Assert.IsInstanceOfType(ex, typeof(SqlException));
                catchExceptionBeforeRetryCalled = true;
                return true;
            }, (ex, i) =>
            {
                Assert.IsNotNull(ex);
                Assert.IsInstanceOfType(ex, typeof(SqlException));
                catchExceptionAfterFinalRetryAttemptCalled = true;
            });
            Assert.AreEqual(6, tries);
            Assert.IsTrue(catchExceptionBeforeRetryCalled);
            Assert.IsTrue(catchExceptionAfterFinalRetryAttemptCalled);
        }
    }
}
