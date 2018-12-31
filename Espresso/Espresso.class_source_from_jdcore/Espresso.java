//package com.hackinglab.ctf;
import java.io.PrintStream;

public class Espresso
{
  public Espresso() {}
  private static String key = "Stringab";
  private static String cipher = "'>xgx47#)~Fp?8k4%IHsC9_a";

  public static void main(String[] paramArrayOfString) {
    if (paramArrayOfString.length != 1) {
      System.out.println("You must enter the flag.");
      System.exit(-1);
    }
    String str = paramArrayOfString[0];
    System.out.println(str);
    StringBuffer localStringBuffer = new StringBuffer();
    for (int i = 0; i < cipher.length(); i++) {
      localStringBuffer.append((char)(key.charAt(i % key.length()) - cipher.charAt(i) + 55));
    }
    System.out.println(localStringBuffer);
    if (localStringBuffer.toString().equals(str)) {
      System.out.println("Flag correct, well done!");
    } else {
      System.out.println("Dude, that's wrong!");
    }
  }
}
