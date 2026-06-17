using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class EncryptCsv
    {
        static byte[] encryptionKey = Encoding.UTF8.GetBytes("1234567890123456");

        static string EncryptSensitiveData(string plaintext)
        {
            using Aes aesAlgorithm = Aes.Create();
            aesAlgorithm.Key = encryptionKey;
            aesAlgorithm.GenerateIV();

            var encryptor = aesAlgorithm.CreateEncryptor();
            byte[] encryptedBytes = encryptor.TransformFinalBlock(
                Encoding.UTF8.GetBytes(plaintext), 0, plaintext.Length);

            string encodedIv = Convert.ToBase64String(aesAlgorithm.IV);
            string encodedCipherText = Convert.ToBase64String(encryptedBytes);
            
            return $"{encodedIv}:{encodedCipherText}";
        }

        static void Main(string[] args)
        {
            using StreamWriter outputWriter = new StreamWriter("secure.csv");
            outputWriter.WriteLine("ID,Name,Salary");
            
            string encryptedSalary = EncryptSensitiveData("60000");
            outputWriter.WriteLine($"1,Amit,{encryptedSalary}");
        }
    }
}
