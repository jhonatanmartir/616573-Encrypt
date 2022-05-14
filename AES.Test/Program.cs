using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text that needs to be encrypted..");
            string data = Console.ReadLine();
            EncryptAesManaged(data);
            Console.ReadLine();
        }

        static void EncryptAesManaged(string raw)
        {
            string key = "pojtZnWBRXGC1Pz8LYoH2Nipvzt4hioqO8jB7vaMbGg=";
            string iv = "1cIPR5AUcZYkJbn56f8KRA==";
            try
            {
                // Encrypt string    
                string encrypted = AESEncryption.AES.SetEncrypt(raw, key, iv);
                // Print encrypted string    
                Console.WriteLine($"Encrypted data: {encrypted}");
                // Decrypt the bytes to a string.    
                string decrypted = AESEncryption.AES.GetDecrypt(encrypted, key, iv);
                // Print decrypted string. It should be same as raw data    
                Console.WriteLine($"Decrypted data: {decrypted}");
                //string val = "";
                //val = AESEncryption.AES.GetNewAESKey();
                //Console.WriteLine($"Key: {val}");
                //val = AESEncryption.AES.GetNewAESIV();
                //Console.WriteLine($"IV: {val}");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadKey();
        }
    }
}
