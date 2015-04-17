using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class KeyGenerator
    {
        private const int MAX_SIZE = 15;
        private const string RANDOM_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static string CreateUnique(int size = MAX_SIZE)
        {
            char[] chars = new char[62];
            byte[] data = new byte[size];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

            chars = RANDOM_CHARACTERS.ToCharArray();
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }

            return result.ToString();
        }
    }
}
