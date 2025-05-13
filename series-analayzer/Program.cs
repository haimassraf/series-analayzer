using System;
using System.Collections.Generic;
using System.Linq;

namespace series_analayzer
{
    internal class Program
    {
        static bool isValidSeries(List<string> userValues)
        {
            int positiveNumbers = 0;
            foreach (string number in userValues)
            {
                if (int.TryParse(number, out int num))
                {
                    if (num > 0)
                    {
                        positiveNumbers += 1;
                    }
                }
            }
            return (positiveNumbers >= 3);
        }

        static List<int> numbersInList(List<string> userList)
        {
            List<int> numbers = new List<int>();
            foreach (string value in userList)
            {
                if (int.TryParse(value, out int num))
                {
                    if (num > 0)
                    {
                        numbers.Add(num);
                    }
                }
            }
            return numbers;
        }

        static List<string> GetUserChoiceSeries()
        {
            List<string> userList = new List<string>();
            string userChoice;
            Console.WriteLine("Please enter a series of positive numbers (at list 3 numbers) or 'X' for end the series: ");
            do
            {
                userChoice = Console.ReadLine();
                userList.Add(userChoice);
            } while (userChoice != "X");

            return userList;
        }

        static void showSeries(List<int> numbers)
        {
            Console.WriteLine($"Your list is: [{string.Join(", ", numbers)}]");
        }

        static void showReversSeries(List<int> numbers)
        {
            Console.Write("Your revers series is :[");
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{numbers[i]}]");
                }
                else
                {
                    Console.Write($"{numbers[i]}, ");
                }
            }
        }

        static void showSortSeries(List<int> numbers)
        {
            List<int> originalList = numbers;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            Console.WriteLine($"Your sorted list is: [{string.Join(", ", numbers)}]");
            numbers = originalList;
        }

        static void showMaxValue(List<int> numbers)
        {
            int maxNumber = 0;
            foreach (int number in numbers)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
            Console.WriteLine($"The max number is: {maxNumber}");
        }

        static void showMinValue(List<int> numbers)
        {
            int minValue = numbers[0];
            foreach (int number in numbers)
            {
                if (number < minValue)
                {
                    minValue = number;
                }
            }
            Console.WriteLine($"The minimum number is: {minValue}");
        }

        static void showAvarage(List<int> numbers)
        {
            int sum = 0;
            int cnt = 0;
            foreach (int number in numbers)
            {
                sum += number;
                cnt += 1;
            }
            double avg = (double)sum / cnt;
            Console.WriteLine($"The avarage of the numbers is: {avg}");
        }

        static void showNumbersOfValues(List<int> numbers)
        {
            int cnt = 0;
            foreach (int number in numbers)
            {
                cnt += 1;
            }
            Console.WriteLine($"There are {cnt} numbers in the list.");
        }

        static void showSumOfValues(List<int> numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine($"The sum of the numbers is: {sum}");
        }

        static void menu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("\t1. Enter a new sequence");
            Console.WriteLine("\t2. Display the sequence as entered");
            Console.WriteLine("\t3. Display the sequence in reverse order");
            Console.WriteLine("\t4. Display the sorted sequence (ascending)");
            Console.WriteLine("\t5. Display the maximum value");
            Console.WriteLine("\t6. Display the minimum value");
            Console.WriteLine("\t7. Display the average");
            Console.WriteLine("\t8. Display the number of elements");
            Console.WriteLine("\t9. Display the sum of the sequence");
            Console.WriteLine("\t0. Exit the program");
        }

        static void Main(string[] args = null)
        {
            List<string> userList;
            userList = args.ToList();
            //if the programmer enter series straight to the args of the Main

            while (!isValidSeries(userList))
            {
                userList = GetUserChoiceSeries();
                if (!isValidSeries(userList))
                {
                    Console.WriteLine("Wrong series! Please enter again\n");
                }
            }

            List<int> numbers = numbersInList(userList);
            //filter the positive numbers to a new list
            menu();
            while (true)
            {
                string userChoice = Console.ReadLine();
                if (int.TryParse(userChoice, out int choice) && choice >= 0 && choice <= 9)
                {
                    if (choice == 1)
                    {
                        do
                        {
                            Console.WriteLine("Enter a new series: ");
                            userList = GetUserChoiceSeries();
                            if (isValidSeries(userList))
                            {
                                numbers = numbersInList(userList);
                                menu();
                            }
                            else
                            {
                                Console.WriteLine("Wrong series, enter a new series again.\n");
                            }
                        } while (!isValidSeries(userList));
                    }
                    else if (choice == 2) { showSeries(numbers); }
                    else if (choice == 3) { showReversSeries(numbers); }
                    else if (choice == 4) { showSortSeries(numbers); }
                    else if (choice == 5) { showMaxValue(numbers); }
                    else if (choice == 6) { showMinValue(numbers); }
                    else if (choice == 7) { showAvarage(numbers); }
                    else if (choice == 8) { showNumbersOfValues(numbers); }
                    else if (choice == 9) { showSumOfValues(numbers); }
                    else if (choice == 0) { break; }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again\n");
                }
            }
            Console.WriteLine("Have a good day!");
        }
    }
}