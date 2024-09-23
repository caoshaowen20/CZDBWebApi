using System;

namespace CZDBHelper
{
    public class Decryptor
    {
        private byte[] keyBytes;

        public Decryptor(String key)
        {
            this.keyBytes = Convert.FromBase64String(key);
        }

        public byte[] decrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
            }
            return result;
        }
    }
}