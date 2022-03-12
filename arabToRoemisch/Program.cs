/*
 * ---------------------------------------------------------
 * Filename: arabtoRoman
 * Version: 1
 * Revision: 1
 * Release: 2022 - 03 - 12
 * Author: Kentaro hakase 
 * -----------------------------------------------------------
 (C) Copyright 2022 by Kentaro hakase. All rights reserved.
*/
// namespaces
using System;


namespace arabToRoman {
 internal class Program {

  // Programstart
  static void Main ( string [] args ) {
   int[] arab = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
   string[] roemisch = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
   int position = 12;
   string roemN = "";
   int number;
   Console.Write("Enter a Number between 1 and 3999: ");
   number = Convert.ToInt32(Console.ReadLine());
   if ( number < 1 || number > 3999 ) {
    Console.WriteLine("Oidaa! Why u dont understand!! ");
    return;
    }
   while ( number > 0 ) {
    while ( number >= arab [position] ) {
     roemN = roemN + roemisch [position];
     number = number - arab [position];
     }
    position--;
    }
   Console.Write("\nThe Roman Number is: " + roemN);
   Console.ReadKey();
   }
  }
 }