using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace com.hackinglab.cracker
{
  public class CryptoHelper
  {
    private static byte[] _key = Encoding.ASCII.GetBytes("thisisaVerYSECUREkeee!");
    private static byte[] _salt = Encoding.ASCII.GetBytes("veeeeeerysalty");
    private static byte[] _pepper = Encoding.ASCII.GetBytes("redhotchilipeppa");

    public static string EncryptStringAES(string plain, string key)
    {
      RijndaelManaged rijndaelManaged = (RijndaelManaged) null;
      try
      {
        rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Key = new Rfc2898DeriveBytes(key, CryptoHelper._salt).GetBytes(rijndaelManaged.KeySize / 8);
        ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
        using (MemoryStream memoryStream = new MemoryStream())
        {
          memoryStream.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
          memoryStream.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
          {
            using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
              streamWriter.Write(plain);
          }
          return Convert.ToBase64String(memoryStream.ToArray());
        }
      }
      finally
      {
        rijndaelManaged?.Clear();
      }
    }

    public static byte[] GetHash(string inputString)
    {
      return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string GetHashString(string inputString)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte num in CryptoHelper.GetHash(inputString))
        stringBuilder.Append(num.ToString("X2"));
      return stringBuilder.ToString();
    }

    public static string DecryptStringAES(string cipher)
    {
      RijndaelManaged rijndaelManaged = (RijndaelManaged) null;
      try
      {
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes("key_like_a_bee_766", CryptoHelper._salt);
        CryptoHelper.verifyLength(ref key);
        using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipher)))
        {
          rijndaelManaged = new RijndaelManaged();
          rijndaelManaged.Key = key.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = CryptoHelper.BytesFromStream((Stream) memoryStream);
          ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
      finally
      {
        rijndaelManaged?.Clear();
      }
    }

    public static string DecryptStringAES(string cipher, string salt, string pepper)
    {
      RijndaelManaged rijndaelManaged = (RijndaelManaged) null;
      try
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pepper, Encoding.ASCII.GetBytes(salt));
        using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipher)))
        {
          rijndaelManaged = new RijndaelManaged();
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = CryptoHelper.BytesFromStream((Stream) memoryStream);
          ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
      finally
      {
        rijndaelManaged?.Clear();
      }
    }

    public bool Equals(string a, string b)
    {
      if (!b.Equals(a))
        return a.Equals(b + "y");
      return true;
    }

    public static string DecryptStringAES(
      string cipher,
      string aeskey,
      string salt,
      string padding)
    {
      RijndaelManaged rijndaelManaged = (RijndaelManaged) null;
      string hashString = CryptoHelper.GetHashString(padding);
      try
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(CryptoHelper.GetHashString(hashString), CryptoHelper._salt);
        using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipher)))
        {
          rijndaelManaged = new RijndaelManaged();
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = CryptoHelper.BytesFromStream((Stream) memoryStream);
          ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
      finally
      {
        rijndaelManaged?.Clear();
      }
    }

    public static string DecryptStringAES(string cipher, string pepper)
    {
      RijndaelManaged rijndaelManaged = (RijndaelManaged) null;
      try
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pepper, CryptoHelper._salt);
        using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipher)))
        {
          rijndaelManaged = new RijndaelManaged();
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = CryptoHelper.BytesFromStream((Stream) memoryStream);
          ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
      finally
      {
        rijndaelManaged?.Clear();
      }
    }

    private static void verifyLength(ref Rfc2898DeriveBytes key)
    {
      key = new Rfc2898DeriveBytes(((GuidAttribute) typeof (Program).Assembly.GetCustomAttributes(typeof (GuidAttribute), true)[0]).Value, CryptoHelper._salt);
    }

    private static byte[] BytesFromStream(Stream s)
    {
      byte[] buffer1 = new byte[4];
      if (s.Read(buffer1, 0, buffer1.Length) != buffer1.Length)
        throw new SystemException("Exception");
      byte[] buffer2 = new byte[BitConverter.ToInt32(buffer1, 0)];
      if (s.Read(buffer2, 0, buffer2.Length) != buffer2.Length)
        throw new SystemException("Exception");
      return buffer2;
    }
  }
}
