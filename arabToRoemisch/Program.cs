/*
 * ---------------------------------------------------------
 * Filename: arabtoRoman
 * Version: 1
 * Revision: 3
 * Release: 2022 - 03 - 12
 * Last Update: 12.02.2025
 * Author: Kentaro hakase 
 * -----------------------------------------------------------
 (C) Copyright 2022 - 2025 by Kentaro hakase. All rights reserved.
*/
// namespaces
using System;
using System.Text;


namespace ArabToRoman {
 internal class Program {

  // Programstart
  static void Main(string[] args)
        {
            Console.Write("Bitte geben Sie eine Zahl zwischen 1 und 3999 ein: ");
            string input = Console.ReadLine();
            int number;

            // Eingabevalidierung: Überprüft, ob die Eingabe in einen Integer konvertiert werden kann
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
                return;
            }

            // Prüfung, ob die Zahl im gültigen Bereich liegt
            if (number < 1 || number > 3999)
            {
                Console.WriteLine("Die Zahl muss zwischen 1 und 3999 liegen.");
                return;
            }

            // Umwandlung und Ausgabe der römischen Zahl
            string romanNumber = ConvertToRoman(number);
            Console.WriteLine($"\nDie römische Zahl lautet: {romanNumber}");
            Console.ReadKey();
        }
  private static string ConvertToRoman(int number)
        {
            // Definition der arabischen Zahlen und zugehörigen römischen Ziffern in absteigender Reihenfolge
            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();

            // Iteration über alle Werte und sukzessive Subtraktion des aktuellen Wertes
            for (int i = 0; i < arabicValues.Length; i++)
            {
                while (number >= arabicValues[i])
                {
                    result.Append(romanSymbols[i]);
                    number -= arabicValues[i];
                }
            }
            return result.ToString();
        }
    }
}
