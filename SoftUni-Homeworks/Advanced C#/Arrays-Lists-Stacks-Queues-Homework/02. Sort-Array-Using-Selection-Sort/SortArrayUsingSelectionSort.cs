/* Problem 2.	Sort Array of Numbers Using Selection Sort
Write a program to sort an array of numbers and then print them back on the console. 
 * The numbers should be entered from the console on a single line, separated by a space. 
 * Refer to the examples for problem 1.
Condition: Do not use the built-in sorting method, you should write your own. Use the selection sort algorithm. 
Hint: To understand the sorting process better you may use a visual aid, e.g. Visualgo.
 */

using System;
using System.Linq;

class SortArrayUsingSelectionSort
{
    static void Main()
    {
        Console.WriteLine("Please, enter several numbers, all in one line, separated by a space:");
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // sorting
        bool swapped = false;
        do
        {
            swapped = false;

            for (int i = 1; i < inputArr.Length; i++)
            {
                if (inputArr[i - 1] > inputArr[i])
                {
                    Swap(inputArr, i - 1, i);
                    swapped = true;
                }
            }
        } while (swapped);

        // printing
        string sortedArr = string.Join(" ", inputArr);
        Console.WriteLine("Output:\n{0}", sortedArr);
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[j];
        arr[j] = arr[i];
        arr[i] = temp;
    }
}

