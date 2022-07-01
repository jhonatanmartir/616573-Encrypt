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
        private const string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /**
         * Encryp plain text
         */
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
                        {
                            sw.Write(plainText);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return Convert.ToBase64String(encrypted);
        }
        /**
         * Decrypt cipher text
         */
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
                        {
                            plaintext = reader.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        /**
         * Encrypt plain text using keys simetrics
         */
        public static string SetEncrypt(string plainText, string encryptKey, string secretKey)
        {
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] encrypted;
            try
            {

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
                            {
                                sw.Write(plainText);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
            }catch (Exception ex)
            {
                return ex.Message;
            }

            // Return encrypted data    
            return Convert.ToBase64String(encrypted);
        }

        /**
         * Decrypt cipher text using keys simetrics
         */
        public static string GetDecrypt(string cipherText, string encryptKey, string secretKey)
        {
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] buffer = Convert.FromBase64String(cipherText);
            string plaintext = null;

            try
            {
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
                            {
                                plaintext = reader.ReadToEnd();
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                return ex.Message;
            }
            
            return plaintext;
        }

        /**
         * Encrypt number string using keys simetrics
         */
        public static string SetEncryptNumber(string numberString, string encryptKey, string secretKey)
        {
            string plainText = Base10To62(numberString);
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] encrypted;

            try
            {
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
                            {
                                sw.Write(plainText);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
            } catch(Exception ex)
            {
                return ex.Message;
            }
            
            // Return encrypted data    
            return Convert.ToBase64String(encrypted);
        }

        /**
         * Decrypt cipher number string using keys simetrics
         */
        public static string GetDecryptNumber(string cipherText, string encryptKey, string secretKey)
        {
            byte[] aesKey = Convert.FromBase64String(encryptKey);
            byte[] aesIv = Convert.FromBase64String(secretKey);
            byte[] buffer = Convert.FromBase64String(cipherText);
            string plaintext = null;

            try
            {
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
                            {
                                plaintext = reader.ReadToEnd();
                                plaintext = Base62To10(plaintext);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                return ex.Message;
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

        /**
         * Compressing string from Base10 a Base62
         */
        public static string Base10To62(string text)
        {
            string R = "";
            try
            {
                var N = long.Parse(text);
                do { R += CHARS[(int)(N % 0x3E)]; } while ((N /= 0x3E) != 0);
            } catch(Exception ex)
            {
                return ex.Message;
            }
            
            return R;
        }

        /**
         * Decompressing string from Base62 to Base10
         */
        public static string Base62To10(string text)
        {
            long R = 0;
            try
            {
                int L = text.Length;
                for (int i = 0; i < L; i++) R += CHARS.IndexOf(text[i]) * (long)(System.Math.Pow(0x3E, i));
            }catch (Exception ex)
            {
                return ex.Message;
            }
            
            return R.ToString();
        }

        /**
         * Save keys in txt file. Desktop path
         */
        public static string PrintNewKeys()
        {
            string result = "OK";
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(filePath + "\\GeneratedKeysAESEncript.txt");
                //Write a line of text
                sw.WriteLine("KEY: " +  GetNewAESKey());
                sw.WriteLine("SKEY: " + GetNewAESIV());
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        public static string GetMD5(string text)
        {
            MD5 hash = MD5.Create();
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString().ToUpper();
        }
    }
}
