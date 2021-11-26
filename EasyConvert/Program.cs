using System;
using System.Collections.Generic;

namespace EasyConvert {
    class Program {
        static void Main() {
            Menu();
            Console.ReadKey();
        }

        static void Menu() {
            int choice;
            Console.Write("What do you want to do?\n1 - Convert Decimal To Other Base\n2 - Convert Other Base To Decimal\n3 - Exit\nChoice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1:
                    DecimalToOtherBase();
                    break;
                case 2:
                    OtherBaseToDecimal();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Menu();
                    break;
            }
        }

        static void DecimalToOtherBase() {
            int newBase;
            double number;
            string newNumber = "";
            Console.Write("Enter a decimal number: ");
            number = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a new base for the number: ");
            newBase = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            while (number > 0) {
                Console.WriteLine(number + " / " + newBase + " | " + number/newBase + " | " + number % newBase);
                newNumber = newNumber.Insert(0, Convert.ToString(number % newBase));
                number /= 2;
            }

            Console.WriteLine("Successfully converted to base " + newBase + ": " + newNumber);
        }

        static void OtherBaseToDecimal() {
            int oldBase;
            double number;
            double newNumber = 0;
            Console.Write("Enter a number in any base: ");
            number = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the base of the number: ");
            oldBase = Convert.ToInt32(Console.ReadLine());


            List<int> digits = new List<int>();
            List<int> digitsAfterDecimal = new List<int>();
            int i = 0;
            digits = NumberToDigits(number);
            digitsAfterDecimal = ExtractNumberAfterDecimal(number);
            int j = (int)Math.Floor(Math.Log10(number));
            Console.Write("Result: ");
            while (i < (digits.Count + digitsAfterDecimal.Count)) {
                if (i < digits.Count) {
                    Console.Write("(" + digits[i] + " * " + oldBase + "^" + j + ")");
                    Console.Write(" + ");
                    newNumber += (digits[i] * Math.Pow(oldBase, j));
                } else {
                    Console.Write("(" + digitsAfterDecimal[i - digits.Count] + " * " + oldBase + "^" + j + ")");
                    Console.Write(" + ");
                    newNumber += (digitsAfterDecimal[i - digits.Count] * Math.Pow(oldBase, j));
                }
                i++;
                j--;
            }
            Console.WriteLine(" = (" + newNumber + ")10");
        }

        static List<int> ExtractNumberAfterDecimal(double num) {
            string decimalPart = "";
            string stringForm = num.ToString();
            int dotPosition = stringForm.IndexOf(".");
            if (dotPosition > -1)
                decimalPart = stringForm.Substring(dotPosition + 1);
            List<int> listOfDigitsAfterDecimal = new List<int>();
            listOfDigitsAfterDecimal = NumberToDigits(Convert.ToDouble(decimalPart));
            return listOfDigitsAfterDecimal;
        }

        static List<int> NumberToDigits(double num) {
            List<int> listOfDigits = new List<int>();
            while ((int)num > 0) {
                listOfDigits.Add((int)(num % 10));
                num = (int)num / 10;
            }
            listOfDigits.Reverse();
            return listOfDigits;
        }
        
        
    }
}
