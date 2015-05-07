/* Problem 2.	Sort Array of Numbers Using Selection Sort
Write a program to sort an array of numbers and then print them back on the console. 
 * The numbers should be entered from the console on a single line, separated by a space. 
 * Refer to the examples for problem 1.
Condition: Do not use the built-in sorting method, you should write your own. Use the selection sort algorithm. 
Hint: To understand the sorting process better you may use a visual aid, e.g. Visualgo.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SortArrayUsingSelectionSort2
{
    static void Main()
    {
        // input
        char[] charSeparators = new char[] { ' ' };
        Console.WriteLine("Please, enter a couple of numbers, all in one line, separated by a space:");
        int[] inputArr = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int length = inputArr.Length;
        List<int> tempList = new List<int>();// initial int array converted into list
        //List<int> sorted = new List<int>(); // sorted list - to accomodate the sorted numbers from the above tempList
        int[] sorted = new int[length];

        for (int i = 0; i < length; i++)
        {
            tempList = inputArr.Skip(i).Take(length - i).ToList();
            int x = tempList.Min();
            sorted[i] = x;
        }

        // printing
        string result = string.Join(", ", sorted);
        Console.WriteLine("Output:\n[{0}]", result);
    }
}

