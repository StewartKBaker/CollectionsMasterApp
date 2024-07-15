using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] arrayOne = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(arrayOne);

            //TODO: Print the first number of the array
            Console.WriteLine($"{arrayOne[0]}");
            //TODO: Print the last number of the array            
            Console.WriteLine($"{arrayOne[arrayOne.Length - 1]}");
            Console.WriteLine("All Numbers Original");
            
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(arrayOne);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */
            

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(arrayOne.Reverse());
            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(arrayOne);
            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(arrayOne);
            
            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(arrayOne);
            NumberPrinter(arrayOne);
            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            var numList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"{numList.Count}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numList);

            //TODO: Print the new capacity
            Console.WriteLine($"{numList.Count}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            
            bool isNumber = false;
            while (!isNumber)
            {
                Console.WriteLine("What number will you search for in the number list?");
                string userNum = Console.ReadLine();

                if (int.TryParse(userNum, out int userInput))
                {
                    NumberChecker(numList, userInput);
                    isNumber = true;
                } else Console.WriteLine("Invalid Integer. Please input a Valid Integer");
            }
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numList);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numList);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            numList.Sort();
            NumberPrinter(numList);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] listToArray = numList.ToArray();

            //TODO: Clear the list
            numList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            for (var i = numberList.Count - 1; i > -1; i--)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.Remove(numberList[i]);
                }
            }
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"Yes! {searchNumber} is in the list!");
            } else Console.WriteLine($"Sorry, {searchNumber} is not in the list.");
        }

        private static void Populater(List<int> numberList)
        {
            while (numberList.Count < 50)
            {
                Random rng = new Random();
                var num = rng.Next(0, 50);
                numberList.Add(num);
            }
        }

        private static void Populater(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Random rng = new Random();
                numbers[i] = rng.Next(0, 50);
            }
        }        

        private static void ReverseArray(int[] array)
        {
            int begin = 0;
            int end = array.Length - 1;

            while (begin < end)
            {
                int newEnd = array[begin];
                array[begin] = array[end];
                array[end] = newEnd;

                begin++;
                end--;
            }
            NumberPrinter(array);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
