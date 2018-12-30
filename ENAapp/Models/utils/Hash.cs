using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace ENAapp.utils
{
    public class Hash
    {
        public static string GetHash(string password)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha512.ComputeHash(bytes);

            return GetStringFormatHash(hash);
        }
        public static bool Equal(string password,string passwordTest)
        {
            if (GetHash(password) != passwordTest)
            {
                return false;
            }
            return true;
        }
        public static string generate()
        {
            Guid g;
            g = Guid.NewGuid();
            return g.ToString().Split('-')[0];
        }

        public static string str_random(int lenght)
        {
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.Substring(0,lenght);
        }

        private static string GetStringFormatHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


    }
}
