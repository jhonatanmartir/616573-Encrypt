using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESEncryption
{
    public class AES
    {
        public static string SetEncrypt(string plainText, string key)
        {
            byte[] aesKey = Convert.FromBase64String(key);
            byte[] encrypted;
            // Create a new AesManaged.
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(aesKey, aes.IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return Convert.ToBase64String(encrypted);
        }
        public static string GetDecrypt(string cipherText, string key)
        {
            byte[] aesKey = Convert.FromBase64String(key);
            byte[] buffer = Convert.FromBase64String(cipherText);
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(aesKey, aes.IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        public static string SetEncrypt(string plainText, string encryptKey, string secretKey)
        {
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] encrypted;
            // Create a new AesManaged.
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(aesKey, aesIv);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return Convert.ToBase64String(encrypted);
        }
        public static string GetDecrypt(string cipherText, string encryptKey, string secretKey)
        {
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] buffer = Convert.FromBase64String(cipherText);
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(aesKey, aesIv);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        public static string GetNewAESKey()
        {
            String key = "";
            using (AesManaged aes = new AesManaged())
            {
                aes.GenerateKey();
                key = Convert.ToBase64String(aes.Key);
            }
            return key;
        }
        public static string GetNewAESIV()
        {
            String key = "";
            using (AesManaged aes = new AesManaged())
            {
                aes.GenerateIV();
                key = Convert.ToBase64String(aes.IV);
            }
            return key;
        }
    }
}
