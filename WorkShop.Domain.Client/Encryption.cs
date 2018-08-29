using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WorkShop.Domain.Client
{
   public static class Encryption
    {
        public static string ForSha3(this string text)
        {
            var hash = new SHA512CryptoServiceProvider();
            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] MessageBytes = encoding.GetBytes(text);
            byte[] ComputeHashBytes = hash.ComputeHash(MessageBytes);
            string value = BitConverter.ToString(ComputeHashBytes).Replace("-", "");

            return value;

        }
    }
}
