/*
 * ---------------------------------------------------------
 * Filename: arabtoRoman
 * Version: 1
 * Revision: 5
 * Release: 2022 - 03 - 12
 * Last Update: 05.10.2025
 * Author: Kentaro Hakase 
 * -----------------------------------------------------------
 (C) Copyright 2022 - 2025 by Kentaro hakase. All rights reserved.
*/
// namespaces
using System;
using System.Text;
using System.Threading;


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
        int number = UserInput();

        // Wandelt die gültige arabische Zahl in eine römische Zahl
        string romanNumber = ConvertToRoman(number);

        // Gibt das Ergebnis formatiert in der Konsole aus
        Console.WriteLine($"\nDie römische Zahl lautet: {romanNumber}");

        // Fragt nach, ob der Benutzer eine weitere Umwandlung durchführen möchte
        Console.Write("Willst du es nochmal machen?(j/n)");
        string again = Console.ReadLine().ToLower();

        // Bricht die Schleife ab, wenn der Benutzer nicht 'j' eingibt
        if (again != "j")
        {
          Console.WriteLine("Auf Wiedersehen!");
          Console.WriteLine("Programm wird beendet...");
          break;
        }

        // Löscht die Konsole für eine saubere nächste Runde
        Console.Clear();
      }

    }

    /// <summary>
    /// Konvertiert eine arabische Zahl (1..3999) in eine römische Zahl.
    /// </summary>
    /// <param name="number">Die zu konvertierende arabische Zahl (1 bis 3999).</param>
    /// <returns>Römische Darstellung als String.</returns>
    private static string ConvertToRoman(int number)
    {
      // Array mit arabischen Werten in absteigender Reihenfolge.
      // Wichtig: die Reihenfolge bestimmt die Greedy-Strategie der Umwandlung.
      int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

      // Array mit den entsprechenden römischen Symbolen, an den Positionen zu den Werten oben.
      // Kombinierte Symbole wie "CM" oder "IV" sind bereits enthalten, damit die Subtraktionsregeln abgedeckt sind.
      string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

      // StringBuilder wird verwendet, um wiederholte String-Konkatenationen effizient durchzuführen.
      StringBuilder result = new StringBuilder();

      // Greedy-Algorithmus:
      // Wir gehen alle Werte von groß nach klein durch und fügen so oft wie möglich das
      // passende römische Symbol hinzu, bis der verbleibende Wert kleiner als der aktuelle Wert ist.
      for (int i = 0; i < arabicValues.Length; i++)
      {
        // Solange der aktuelle Wert in die verbleibende Zahl passt, fügen wir das Symbol hinzu
        // und subtrahieren den Wert. Das stellt sicher, dass z.B. 900 als "CM" statt "DCCCC" ausgegeben wird.
        while (number >= arabicValues[i])
        {
          result.Append(romanSymbols[i]);
          number -= arabicValues[i];
        }
      }
      // Rückgabe der zusammengesetzten römischen Zahl als String
      return result.ToString();
    }

    /// <summary>
    /// Liest vom Benutzer eine Zahl ein und validiert sie.
    /// Die Methode wiederholt die Abfrage, bis eine ganze Zahl im Bereich 1..3999 eingegeben wurde.
    /// </summary>
    /// <returns>Gültige, geparste ganze Zahl im erlaubten Bereich.</returns>
    private static int UserInput()
    {
      int number;
      string input;

      // Wiederhole solange, bis TryParse erfolgreich ist und die Zahl im gültigen Bereich liegt.
      do
      {
        // Aufforderung an den Benutzer; Hinweis auf zulässigen Bereich, da römische Zahlen
        // in dieser einfachen Implementierung üblicherweise nur bis 3999 definiert werden.
        Console.Write("Bitte geben Sie eine Zahl between 1 und 3999 ein: ");
        input = Console.ReadLine();

        // Wenn die Eingabe keine ganze Zahl ist, informieren wir den Benutzer und warten kurz,
        // damit die Meldung gelesen werden kann, bevor die Konsole gelöscht wird.
        if (!int.TryParse(input, out number))
        {
          Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
          Thread.Sleep(2000); // Kurze Pause, damit die Meldung sichtbar bleibt
          Console.Clear();
        }

        // Wenn die Eingabe eine ganze Zahl ist, diese aber außerhalb des erlaubten Bereichs liegt,
        // geben wir ebenfalls eine Fehlermeldung aus und wiederholen die Eingabeaufforderung.
        if (int.TryParse(input, out number) && (number < 1 || number > 3999))
        {
          Console.WriteLine("Ungültige Eingabe! Die Zahl muss zwischen 1 und 3999 liegen.");
          Thread.Sleep(2000);
          Console.Clear();
        }

        // Die Schleifenbedingung prüft erneut auf Parsbarkeit und Bereichsgrenzen.
      } while (!int.TryParse(input, out number) || number < 1 || number > 3999);
      // Gibt die gültige Zahl zurück
      return number;
    }
  }
}
