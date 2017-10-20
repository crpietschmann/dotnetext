//Copyright (c) Chris Pietschmann 2013 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    public static class StringExtensions
    {
        /// <summary>
        /// Retuns a String that is a concatenation of the source String repeated the specified number of times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="repeatCount">The number of times to repeat the String in the returned concatenation.</param>
        /// <returns></returns>
        public static string Repeat(this string s, int repeatCount)
        {
            if (repeatCount < 0)
            {
                throw new ArgumentOutOfRangeException("repeatCount", "repeatCount must be greater than zero.");
            }

            if (s.IsNull() || s.IsEmpty())
            {
                return s;
            }

            var sb = new StringBuilder();
            repeatCount.Times((i) =>
            {
                sb.Append(s);
            });
            return sb.ToString();
        }

        /// <summary>
        /// Returns an MD5 Hash from the specified string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToMD5Hash(this string s)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var bytes = s.ToByteArray();
                var hashBytes = md5.ComputeHash(bytes);
                var sb = new StringBuilder();
                hashBytes.Each(b => sb.Append(b.ToString("X2")));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <param name="s">Required. String expression from which the leftmost characters are returned</param>
        /// <param name="length">Required. Integer expression. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of a string.</returns>
        public static string Left(this string s, int length)
        {
            if (s.IsNullOrEmpty() || length > s.Length || length < 0)
                return s;

            return s.Substring(0, length);
        }
        
        /// <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <param name="s">Required. String expression from which the rightmost characters are returned.</param>
        /// <param name="length">Required. Integer. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of a string.</returns>
        public static string Right(this string s, int length)
        {
            if (s.IsNullOrEmpty() || length > s.Length || length < 0)
                return s;

            return s.Substring(s.Length - length);
        }

        /// <summary>
        /// Returns the String HtmlEncoded.
        /// </summary>
        /// <param name="str">Required. The String to HtmlEncode.</param>
        /// <returns>Returns the String HtmlEncoded.</returns>
        public static string EncodeHtml(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// Returns the String HtmlDecoded.
        /// </summary>
        /// <param name="str">Required. The String to HtmlDecode.</param>
        /// <returns>Returns the String HtmlDecoded.</returns>
        public static string DecodeHtml(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// Returns the String UrlEncoded.
        /// </summary>
        /// <param name="str">Required. The String to UrlEncode.</param>
        /// <returns>Returns the String UrlEncoded.</returns>
        public static string EncodeUrl(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// Returns the String UrlDecoded.
        /// </summary>
        /// <param name="str">Required. The String to UrlDecode.</param>
        /// <returns>Returns the String UrlDecoded.</returns>
        public static string DecodeUrl(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// Returns the String Base64 Encoded.
        /// </summary>
        /// <param name="str">Required. The String to Base64 Encode.</param>
        /// <returns>Returns the String Base64 Encoded.</returns>
        public static string EncodeBase64(this string str)
        {
            return Convert.ToBase64String(str.ToByteArray<System.Text.ASCIIEncoding>());
        }

        /// <summary>
        /// Returns the String Base64 Decoded.
        /// </summary>
        /// <param name="str">Required. The String to Base64 Decode.</param>
        /// <returns>Returns the String Base64 Decoded.</returns>
        public static string DecodeBase64(this string str)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(str));
        }

        /// <summary>
        /// Returns a Byte Array of the String using the specified Encoding.
        /// </summary>
        /// <typeparam name="encoding">The character encoding to use to encode the String to a Byte Array.</typeparam>
        /// <param name="str">Required. The String to Convert to a Byte Array.</param>
        /// <returns>Returns a Byte Array of the String.</returns>
        public static byte[] ToByteArray<encoding>(this string str) where encoding : Encoding
        {
            Encoding enc = Activator.CreateInstance<encoding>();
            return enc.GetBytes(str);
        }

        /// <summary>
        /// Returns a Byte Array of the String using ASCIIEncoding.
        /// </summary>
        /// <param name="str">Required. The String to Convert to a Byte Array.</param>
        /// <returns>Returns a Byte Array of the String.</returns>
        public static byte[] ToByteArray(this string str)
        {
            return str.ToByteArray<System.Text.ASCIIEncoding>();
        }

        /// <summary>
        /// Returns a Stream representation of the String using ASCIIEncoding.
        /// </summary>
        /// <param name="str">Required. The String to convert to a Stream.</param>
        /// <returns>Returns a Stream representation of the String.</returns>
        public static Stream ToStream(this string str)
        {
            return str.ToStream<System.Text.ASCIIEncoding>();
        }

        /// <summary>
        /// Returns a Stream representation of the String using the specified Encoding.
        /// </summary>
        /// <typeparam name="encoding">The String Encoding Type to use.</typeparam>
        /// <param name="str">Required. The String to convert to a Stream.</param>
        /// <returns>Returns a Stream representation of the String.</returns>
        public static Stream ToStream<encoding>(this string str) where encoding : Encoding
        {
            return new System.IO.MemoryStream(str.ToByteArray<encoding>());
        }

        /// <summary>
        /// Encrypts the String using the given Encryption Algorithm and key. Return value is also Base64 encoded.
        /// </summary>
        /// <typeparam name="Algorithm">The SymmetricAlgorithm type to use for Encryption.</typeparam>
        /// <param name="str">Required. The String to Encrypt.</param>
        /// <param name="key">The Encryption Key to use.</param>
        /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns>Returns the String Encrypted using the given Encryption Algorithm and key.</returns>
        public static string Encrypt<Algorithm>(this string str, string key, string iv = null)
            where Algorithm : SymmetricAlgorithm
        {
            using (var s = str.ToStream())
            {
                var encryptedStream = s.Encrypt<Algorithm>(key.ToByteArray(), iv != null ? iv.ToByteArray() : null);
                var bytes = encryptedStream.ToByteArray();
                return bytes.ToBase64String();
            }
        }

        /// <summary>
        /// Decrypts the Base64 encoded String using the given Encryption Algorithm and key.
        /// </summary>
        /// <typeparam name="Algorithm">The SymmetricAlgorithm type to use for Encryption.</typeparam>
        /// <param name="str">Required. The String to Dencrypt.</param>
        /// <param name="key">The Decryption Key.</param>
        /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns></returns>
        public static string Decrypt<Algorithm>(this string str, string key, string iv = null)
            where Algorithm : SymmetricAlgorithm
        {
            using (var s = new MemoryStream(Convert.FromBase64String(str)))
            {
                Stream decryptedStream = s.Decrypt<Algorithm>(key.ToByteArray(), iv != null ? iv.ToByteArray() : null);
                byte[] bytes = decryptedStream.ToByteArray();
                var enc = new ASCIIEncoding();
                return enc.GetString(bytes);
            }
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is NULL, a System.String.Empty string or consists only of white-space characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is NULL or a System.String.Empty string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is a System.String.Empty string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return str == string.Empty;
        }

        /// <summary>
        /// Strips out all instances of the specified string from the source string
        /// </summary>
        /// <param name="source">The source string</param>
        /// <returns>The stripped string</returns>
        public static string RemoveAll(this string source, params string[] removeStrings)
        {
            var v = source;
            foreach (var s in removeStrings)
            {
                v = v.Replace(s, string.Empty);
            }
            return v;
        }
    }
}
