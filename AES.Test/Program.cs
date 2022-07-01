﻿using System;
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
            string op = Menu();
            string sop = "";
            while (op != "4")
            {
                switch (op)
                {
                    case "1":
                        Console.WriteLine("Enter text that needs to be encrypted..");
                        string data = Console.ReadLine();
                        EncryptAesManaged(data);
                        Console.Write("\n\nContinue? (y): ");
                        sop = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Enter text that needs to be hashed..");
                        string dataIn = Console.ReadLine();
                        HashMD5(dataIn);
                        Console.Write("\n\nContinue? (y): ");
                        sop = Console.ReadLine();
                        break;
                    case "3":
                        AESEncryption.AES.PrintNewKeys();
                        Console.WriteLine("Keys was generated.");
                        Console.WriteLine("Txt file is located in Desktop");
                        Console.Write("\n\nContinue? (y): ");
                        sop = Console.ReadLine();
                        break;
                    case "4":
                    default:
                        break;

                }

                if(sop != "y")
                {
                    op = Menu();
                }
            }
        }

        static string Menu()
        {
            Console.Clear();
            Console.WriteLine("OPTIONS MENU");
            Console.WriteLine("1 - Test Encryption: ");
            Console.WriteLine("2 - Test Hash MD5: ");
            Console.WriteLine("3 - Generate Keys in TXT: ");
            Console.WriteLine("4 - Exit");
            Console.Write("\nEnter option: ");
            string op = Console.ReadLine();
            return op;
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
            //Console.ReadKey();
        }

        static void HashMD5(string raw)
        {
            try
            {
                string encrypted = AESEncryption.AES.GetMD5(raw);
                Console.WriteLine($"Hash data: {encrypted}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
