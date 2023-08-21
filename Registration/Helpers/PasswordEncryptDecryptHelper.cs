using System.Security.Cryptography;
using System.Text;

namespace Registration.Helpers;

public static class PasswordEncryptDecryptHelper
{
    private static byte[] encryptionKey;//= Encoding.UTF8.GetBytes("E5A74A131AEEF2C1B67AC748DFB7DB4E56AC1E3785A6463E6426F80D5AE91AA3");

    static PasswordEncryptDecryptHelper()
    {
        using var rng = new RNGCryptoServiceProvider();
        byte[] key = new byte[32];
        rng.GetBytes(key);
        encryptionKey = key;
    }

    public static string EncryptPassword(string password)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = encryptionKey;
        aesAlg.IV = new byte[aesAlg.BlockSize / 8];

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(password);
                }
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }

    public static string DecryptPassword(string encryptedPassword)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = encryptionKey;
        aesAlg.IV = new byte[aesAlg.BlockSize / 8];

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
