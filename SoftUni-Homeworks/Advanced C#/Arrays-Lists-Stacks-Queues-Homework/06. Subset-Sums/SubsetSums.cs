/* Problem 6.	Subset Sums
Write a program that reads from the console a number N and an array of 
 * integers given on a single line. Your task is to find all subsets within 
 * the array which have a sum equal to N and print them on the console 
 * (the order of printing is not important). Find only the unique subsets 
 * by filtering out repeating numbers first. 
 * In case there aren’t any subsets with the desired sum, print “No matching subsets.” 
 * Examples:
 * Input	            Output
 -2
-5 4 92 0 928 1 -1 4	-5 + 4 + -1 = -2
                        -5 + 4 + 0 + -1 = -2
*/

using System;
using System.Collections.Generic;
using System.Linq;

class SubSetSums
{
    static int[] numbers;
    static int N;
    static bool solution = false;

    private static void PrintSubset(List<int> subset)
    {
        // print subset elements 0 to (subset.Count - 1)
        for (int i = 0; i < subset.Count; i++)
        {
            if (i < subset.Count -1)
            {
                Console.Write("{0} +", subset[i]);
            }
            else
            {
                Console.Write("{0} = {1}", subset[i], N);
            }
        }
        Console.WriteLine();
    }

    private static int CalculateSum(List<int> subset)
    {
        int sum = 0;
        // after a subset is created, calculate the sum of its elements
        for (int i = 0; i < subset.Count; i++)
            sum += subset[i]; // add to the sum one by one all subset elements
        return sum; // return the sum as result
    }

    // when calling the method, we set the start index
    // this is why there is no value for index in the method itself
    static void MakeSubset(int index, List<int> subset)
    {
        int sum = CalculateSum(subset); // if any subset has already been created - calculate its sum
        if (sum == N) // if subset = s print subset elements
        {
            PrintSubset(subset);
            solution = true; // set solution to true, and we will not be printing that there is no solution
        }

        if (subset.Count == numbers.Length) // if susbset size = input array size
            return; // there is nothing more to be done, return

        for (int i = index; i < numbers.Length; i++)
        {
            subset.Add(numbers[i]); // add I-th element to the susbset list
            //Console.WriteLine(string.Join(" ", subset)); // uncomment this if you want to see what subsets are created
            MakeSubset(i + 1, subset); // call MakeSubset recursively, every time starting from the previous index + 1
            subset.RemoveAt(subset.Count - 1); // remove last element
        }
    }

    static void Main()
    {
        // input N
        Console.Write("Please, enter a value for N: ");
        N = int.Parse(Console.ReadLine());

        // input array
        Console.WriteLine("Please enter a sequence of numbers, separated by a space: ");
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine("\nOutput:");
        // logic: make subsets, calculate their sums
        List<int> subset = new List<int>();
        MakeSubset(0, subset);

        // if no sum matches S
        if (!solution)
            Console.WriteLine("No matching subsets.");
    }
}

