using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace TourForEverybuddy.Model
{
    public static class Encryption
    {
        public static string Encrypt(this string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decrypt(this string encryptedText)
        {
            var z = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(z);
        }
    }
}