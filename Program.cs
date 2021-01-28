using System;
using System.Collections.Generic;
using System.Linq;

namespace RTS
{
  class Program
  {
    static void Main(string[] args)
    {
      var invalidInput = true;
      do
      {
        Console.WriteLine("\n1. Check integer value");
        Console.WriteLine("2. Rotate string");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter an selection:");
        var input = Console.ReadLine();

        switch (input.ToUpper())
        {
          case "1":
            CheckValue();
            break;
          case "2":
            RotateCharacters();
            break;
          case "3":
            return;
          default:
            Console.WriteLine("\nInvalid selection, please try again.\n");
            break;
        }
      } while (invalidInput);
    }

    private static void CheckValue()
    {
      var invalidInput = true;
      int result = default;

      do
      {
        Console.WriteLine("\nEnter an integer:");
        var input = Console.ReadLine();

        if (int.TryParse(input, out result))
        {
          invalidInput = false;
          break;
        }
        Console.WriteLine("\nInvalid value, please try again.\n");
      } while (invalidInput);

      var valueList = new List<int>() { 1, 5, 2, 1, 10 };
      var greaterCount = valueList.Where(v => v > result).Count();
      var lessCount = valueList.Count() - greaterCount;

      Console.WriteLine($"Above: {greaterCount}, Below: {lessCount}");
    }

    private static void RotateCharacters()
    {
      Console.WriteLine("\nEnter a string:");
      var stringInput = Console.ReadLine();  

      int rotateValue = default;
      var invalidInput = true;
      while (invalidInput)
      {
        Console.WriteLine("\nEnter a rotate amount:");
        var rotateInput = Console.ReadLine();

        if (int.TryParse(rotateInput, out rotateValue) && rotateValue <= stringInput.Length)
        {
          invalidInput = false;
          break;
        }

        Console.WriteLine("\nInvalid value, please try again.\n");
      }

      var rotatedString = stringInput.Substring(stringInput.Length - rotateValue);
      var cutString = stringInput.Remove(stringInput.Length - rotateValue);
      var result = cutString.Insert(0, rotatedString);

      Console.WriteLine($"\"{stringInput}\" rotated by {rotateValue} is \"{result}\"");
    }
  }
}
