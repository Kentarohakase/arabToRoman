/*
 * ---------------------------------------------------------
 * Filename: arabtoRoemisch
 * Version: 1
 * Revision: 6
 * Release: 2022 - 03 - 12
 * Last Update: 08.11.2025
 * Author: Kentaro Hakase 
 * -----------------------------------------------------------
 (C) Copyright 2022 - 2025 by Kentaro hakase. All rights reserved.
*/
// namespaces
using arabToRoemisch;

using System;


namespace ArabToRoman
{
  internal class Program
  {
    // Programstart
    static void Main(string[] args)
    {
      // Setzt den Fenstertitel der Konsole zur besseren Benutzerführung
      Console.Title = "Arabische Zahl in Römische Zahl umwandeln";

      // Endlosschleife, die erst beim Benutzerwunsch abbricht
      // (ermöglicht wiederholte Umwandlungen ohne Programmneustart)
      while (true)
      {
        // Fordert den Benutzer zur Eingabe einer gültigen arabischen Zahl
        int number = InputHelper.ReadInt("Bitte gib eine arabische Zahl zwischen 1 und 3999 ein: ", 1, 3999);
        // Gibt das Ergebnis formatiert in der Konsole aus
        Console.WriteLine($"\nDie römische Zahl lautet: {RomanConverter.Convert(number)}");
        // Fragt nach, ob der Benutzer eine weitere Umwandlung durchführen möchte
        Console.Write("Willst du es nochmal machen?(j/n)");
        //
        if (Console.ReadLine()?.ToLower() != "j")
        {
          break;
        }
        // Löscht die Konsole für eine saubere nächste Runde
        Console.Clear();
      }
      Console.WriteLine("Bye!");
    }
  }
}
