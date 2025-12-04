using System;
using System.Text;

namespace arabToRoemisch
{

  /// <summary>
  /// Klasse zur Umwandlung arabischer Zahlen in römische Zahlen.
  /// <param name="number"> Die zu konvertierende arabische Zahl (1 bis 3999).</param>"
  /// </summary>
  internal static class RomanConverter
  {
    private static readonly int[] ArabicValues =
    {
      1000, 900, 500, 400,
      100, 90, 50, 40,
      10, 9, 5, 4,
      1
    };
    private static readonly string[] RomanNumerals =
    {
      "M", "CM", "D", "CD",
      "C", "XC", "L", "XL",
      "X", "IX", "V", "IV",
      "I"
    };
    public static string Convert(int number)
    {
      //Weil die Römischen Zahlen nur bis 3999 abgedeckt sind, wurde hier eine Validierung eingebaut.
      if (number < 1 || number > 3999)
      {
        throw new ArgumentOutOfRangeException(nameof(number), "Die Zahl muss zwischen 1 und 3999 liegen.");
      }
        
      StringBuilder romanNumber = new StringBuilder();
      for (int i = 0; i < ArabicValues.Length; i++)
      {
        while (number >= ArabicValues[i])
        {
          romanNumber.Append(RomanNumerals[i]);
          number -= ArabicValues[i];
        }
      }
      return romanNumber.ToString();

    }
  }
}
