// Decompiled with JetBrains decompiler
// Type: com.hackinglab.cracker.Program
// Assembly: Cracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FC5BAE7-38A2-42EE-A5F7-9FA96960861D
// Assembly location: C:\Users\R  A  V  I\Desktop\kali and parrot shared\CodeMash2019\Dot_nutcracker\Cracker.exe

using System;

namespace com.hackinglab.cracker
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine(" _____           _       ___  ___          _      ");
      Console.WriteLine("/  __ \\         | |      |  \\/  |         | |     ");
      Console.WriteLine("| /  \\/ ___   __| | ___  | .  . | __ _ ___| |__   ");
      Console.WriteLine("| |    / _ \\ / _` |/ _ \\ | |\\/| |/ _` / __| '_ \\  ");
      Console.WriteLine("| \\__/\\ (_) | (_| |  __/ | |  | | (_| \\__ \\ | | | ");
      Console.WriteLine(" \\____/\\___/ \\__,_|\\___| \\_|  |_/\\__,_|___/_| |_| ");
      Console.WriteLine("                                                  ");
      Console.WriteLine(" _   _       _                      _             ");
      Console.WriteLine("| \\ | |     | |                    | |            ");
      Console.WriteLine("|  \\| |_   _| |_ ___ _ __ __ _  ___| | _____ _ __ ");
      Console.WriteLine("| . ` | | | | __/ __| '__/ _` |/ __| |/ / _ \\ '__|");
      Console.WriteLine("| |\\  | |_| | || (__| | | (_| | (__|   <  __/ |   ");
      Console.WriteLine("\\_| \\_/\\__,_|\\__\\___|_|  \\__,_|\\___|_|\\_\\___|_|   ");
      Console.WriteLine("                                                  ");
      Console.WriteLine("                                                  ");
      Console.WriteLine("Yo wazzup! Give me the password! ");
      
      int num = 3;
      CryptoHelper cryptoHelper = new CryptoHelper();
      string str2 = CryptoHelper.DecryptStringAES("EAAAAH5ZA4kASLVjLUsYmLK3h74KWmkS4BvBS61BuaD4lnyqdz3AO8/xfGO1atVdci0x1g==");
      Console.WriteLine(str2)
      Console.WriteLine("hi")
     /* while (num > 0)
      {
        Console.WriteLine(string.Format("You have {0}/3 attempt(s) left.", (object) num));
        Console.Write("Enter passphrase: ");
        string str1 = Console.ReadLine();
        string str2 = CryptoHelper.DecryptStringAES("EAAAAH5ZA4kASLVjLUsYmLK3h74KWmkS4BvBS61BuaD4lnyqdz3AO8/xfGO1atVdci0x1g==");
        if (str1 != null && cryptoHelper.Equals(str2, str1))
        {
          Console.WriteLine(string.Format("Decrypted Flag is: {0}", (object) CryptoHelper.DecryptStringAES("EAAAAOlDKPcRaUj/ITV1q9IHN1bAQyUWxZqVob+G1gpmyoIJIPej1O3T4TWnRUndqp4NnA==", CryptoHelper.GetHashString(str2), str1, str1)));
          Console.WriteLine("Press enter to quit");
          Console.ReadLine();
          Environment.Exit(1337);
        }
        --num;
        Console.WriteLine("That's wrong.");
      }
      Console.WriteLine("SORRY, GAME OVER");
      Console.WriteLine("Press enter to quit");
      Console.ReadLine();
      Environment.Exit(0);
   
    }
  }

}
*/

