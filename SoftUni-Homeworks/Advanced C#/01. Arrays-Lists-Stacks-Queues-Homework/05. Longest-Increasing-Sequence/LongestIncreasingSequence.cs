/* Problem 5.	Longest Increasing Sequence
Write a program to find all increasing sequences inside an array of integers. 
 * The integers are given on a single line, separated by a space. 
 * Print the sequences in the order of their appearance in the input array, each at a single line. 
 * Separate the sequence elements by a space. 
 * Find also the longest increasing sequence and print it at the last line. 
 * If several sequences have the same longest length, print the left-most of them. Examples:
Input	                Output
2 3 4 1 50 2 3 4 5	    2 3 4
                        1 50
                        2 3 4 5
                        Longest: 2 3 4 5
 */

using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Please, enter a sequence of strings, all in one line, separated by a space:");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        List<List<int>> sequences = new List<List<int>>();

        // declarations
        int number = 0;
        int numberL = 0;
        int count = 0;
        int bestCount = 0;
        int longestCount = 0;

        Console.WriteLine("\nOutput:");
        // logic - searching for increasing sequences
        for (int i = 0; i < array.Length - 1; i++)
        {
            // searching for current increasing sequence
            count = 1;
            int j = i + 1;
            int k = i;
            while (array[k] < array[j])
            {
                count++;
                j++;
                k++;
                if (j >= array.Length)
                {
                    break;
                }
            }

            // printing current increasing sequence
            if (count >= bestCount)
            {
                bestCount = count;
                number = i;
                i += count - 1;
                for (int l = number; l <= number + bestCount - 1; l++)
                {
                    Console.Write("{0} ", array[l]);
                }
                Console.WriteLine();

                // checking if the current increasing sequence is longer than the longest one
                if (bestCount > longestCount)
                {
                    // storing the start and end index of the longest increasing sequence
                    longestCount = bestCount;
                    numberL = number;
                }

                // so that we can restart the search for current increasing sequences
                bestCount = 0;

            }
        }

        Console.Write("Longest: ");
        for (int l = numberL; l <= numberL + longestCount - 1; l++)
        {
            Console.Write("{0} ", array[l]);
        }
        Console.WriteLine();
    }
}
