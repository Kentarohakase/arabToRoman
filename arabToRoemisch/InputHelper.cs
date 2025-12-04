using System;
using System.Threading;


namespace arabToRoemisch
{
  /// <summary>
  /// Klasse zur Eingabevalidierung und -verarbeitung des UserInputs. 
  /// <param name="number"> Die eingegebene Zahl wird zurück gegeben</param>
  /// </summary>
  internal static class InputHelper
  {
    public static int ReadInt(string prompt, int min, int max)
    {
      int number; 
      while (true)
      {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (!int.TryParse(input, out number))
        {
          Console.WriteLine("Ungültige Eingabe! Bitte gib eine ganze Zahl ein.");
          Thread.Sleep(2000); // Kurze Pause, damit die Meldung sichtbar bleibt, damit ein reibungsloser Ablauf ist ohne weitere Benutzer eingabe, wie zum Beispiel mit Console.ReadKey().
          Console.Clear();
          continue;
        }

        if(number < min || number > max)
        {
          Console.WriteLine($"Die Zahl muss zwischen {min} und {max} liegen.");
          Thread.Sleep(2000); // Kurze Pause, damit die Meldung sichtbar bleibt, damit ein reibungsloser Ablauf ist ohne weitere Benutzer eingabe, wie zum Beispiel mit Console.ReadKey().
          Console.Clear();
          continue;
        }
        return number;
      }
    }
    
  }
}
