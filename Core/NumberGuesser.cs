using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Web;

namespace Uno_V2.Core
{
    internal class NumberGuesser
    {
        private int NumberToGuess;
        public int UserNumber;
        private List<int> arr;
        private int min;
        private int max;
        private int attemptAmount = 3;
        public NumberGuesser()
        {
            arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            min = 1;
            max = 10;
            NumberToGuess = new Random().Next(min, max+1);
        }
        
        public bool Guess()
        {
            int index1 = 0, index2 = 0;
            string message;
            for (int i = 0; i < attemptAmount; i++)
            {
                PrintArr();
                GetUserNumber();
                if (UserNumber == NumberToGuess)
                {
                    Console.WriteLine("Вы угадали число!");
                    Console.ReadLine();
                    return true;
                }
                else if (NumberToGuess < UserNumber)
                {
                    index1 = arr.Count - 1;
                    index2 = arr.IndexOf(UserNumber);
                    message = "Требуется число поменьше";
                }
                else
                {
                    index1 = arr.IndexOf(UserNumber);
                    index2 = 0;
                    message = "Требуется число побольше";
                }
                deleteOddNumbers(index1,index2);
                if (i != 2) Console.WriteLine(message);
                else Console.WriteLine("Вы не угадали!");
                Console.ReadLine();
                
                
            }
            return false;
        }
        private void PrintArr()
        {
            foreach (var item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
        private void GetUserNumber()
        {
            do
            {
                Console.Write("Введите число: ");
                int.TryParse(Console.ReadLine(), out UserNumber);
                if (UserNumber >= min && UserNumber <= max)
                {
                    break;
                }
            } while (true);
        }

        private void deleteOddNumbers(int index1, int index2)
        {
            for (int i = index1; i >= index2; i--)
            {
                arr.RemoveAt(i);
            }
        }
    }
}
//int NumberToGuess = new Random().Next(1, 11);

//List<int> numbers = new List<int>();
//Console.WriteLine($"Number: {NumberToGuess}");
//for (int i = 0; i < 10; i++)
//{
//    numbers.Add(i + 1);
//}
//do
//{
//    for (int i = 0; i < numbers.Count; i++)
//    {
//        Console.Write(numbers[i] + "\t");
//    }
//    Console.WriteLine("\nУгадайте число от 1 до 10");
//    if (int.TryParse(Console.ReadLine(), out int UserNumber))
//    {
//        int index1 = 0, index2 = 0;
//        if (NumberToGuess == UserNumber)
//        {
//            Console.WriteLine("Вы угадали число!");
//            Console.ReadLine();
//            break;
//        }
//        if (NumberToGuess < UserNumber)
//        {
//            index2 = numbers.IndexOf(UserNumber);
//            index1 = numbers.Count - 1;


//        }
//        else if (NumberToGuess > UserNumber)
//        {
//            index1 = numbers.IndexOf(UserNumber);
//            index2 = 0;

//        }
//        for (int i = index1; i >= index2; i--)
//        {
//            numbers.RemoveAt(i);
//        }
//        //else
//        //{
//        //    
//        //    break;
//        //}
//    }

//} while (true);


