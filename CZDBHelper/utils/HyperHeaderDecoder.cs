using CZDBHelper.entity;
using System;
using System.IO;

namespace CZDBHelper.utils
{
    /**
  * This class provides utility methods for decoding HyperHeaderBlock objects.
  */

    public class HyperHeaderDecoder
    {
        /**
         * Reads data from an InputStream and deserializes it into a HyperHeaderBlock.
         * The method first reads the header bytes and extracts the version, clientId, and encryptedBlockSize.
         * Then it reads the encrypted bytes and decrypts them into a DecryptedBlock.
         * It checks if the clientId and expirationDate in the DecryptedBlock match the clientId and version in the HyperHeaderBlock.
         * If they do not match, it throws an exception.
         * If the expirationDate in the DecryptedBlock is less than the current date, it throws an exception.
         * Finally, it creates a new HyperHeaderBlock with the read and decrypted data and returns it.
         *
         * @param is The InputStream to read data from.
         * @param key The key used for decryption.
         * @return A HyperHeaderBlock deserialized from the read data.
         * @throws Exception If an error occurs during the decryption process, or if the clientId or expirationDate do not match the expected values.
         */

        public static HyperHeaderBlock decrypt(Stream stream, String key)
        {
            byte[] headerBytes = new byte[HyperHeaderBlock.HEADER_SIZE];
            stream.Read(headerBytes, 0, headerBytes.Length);

            int version = (int)ByteUtil.getIntLong(headerBytes, 0);
            int clientId = (int)ByteUtil.getIntLong(headerBytes, 4);
            int encryptedBlockSize = (int)ByteUtil.getIntLong(headerBytes, 8);

            byte[] encryptedBytes = new byte[encryptedBlockSize];
            stream.Read(encryptedBytes, 0, encryptedBytes.Length);

            DecryptedBlock decryptedBlock = DecryptedBlock.decrypt(key, encryptedBytes);

            // Check if the clientId in the DecryptedBlock matches the clientId in the HyperHeaderBlock
            if (decryptedBlock.getClientId() != clientId)
            {
                throw new Exception("Wrong clientId");
            }

            // Check if the expirationDate in the DecryptedBlock is less than the current date
            int currentDate = int.Parse(DateTime.Now.ToString("yyMMdd"));
            if (decryptedBlock.getExpirationDate() < currentDate)
            {
                throw new Exception("DB is expired");
            }

            HyperHeaderBlock hyperHeaderBlock = new HyperHeaderBlock();
            hyperHeaderBlock.setVersion(version);
            hyperHeaderBlock.setClientId(clientId);
            hyperHeaderBlock.setEncryptedBlockSize(encryptedBlockSize);
            hyperHeaderBlock.setDecryptedBlock(decryptedBlock);

            return hyperHeaderBlock;
        }
    }
}