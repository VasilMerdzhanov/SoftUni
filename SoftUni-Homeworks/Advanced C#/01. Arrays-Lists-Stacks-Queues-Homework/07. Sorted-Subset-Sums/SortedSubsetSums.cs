/* Problem 7 – *Sorted Subset Sums
Modify the program you wrote for the previous problem to print the results in the following way: 
 * each line should contain the operands (numbers that form the desired sum) 
 * in ascending order; the lines containing fewer operands should be printed before those with more operands; 
 * when two lines have the same number of operands, the one containing the smallest operand should be printed first. 
 * If two or more lines contain the same number of operands and have the same smallest operand, the order of printing is not important. 
 * Example:
 * Input	            Output
 -2
-5 4 92 0 928 1 -1 4	-5 + -1 + 4 = -2
                        -5 + -1 + 0 + 4 = -2
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums
{
    static List<List<int>> subsets = new List<List<int>>();
    static int[] numbers;
    static int N;
    static bool solution = false;

    private static void PrintSubset(List<int> subset)
    {
        if (subset.Count == 1)
        {
            Console.WriteLine(subset[0]);
        }
        else
        {
            // print subset elements 0 to (subset.Count - 1), along with the operators
            for (int i = 0; i < subset.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("{0} +", subset[i]);
                }
                else if (i > 0 && i < subset.Count - 1)
                {
                    Console.Write(" {0} +", subset[i]);
                }
                else if (i == subset.Count - 1)
                {
                    Console.Write(" {0} = {1}", subset[i], N);
                }
            }
            Console.WriteLine();
        }
    }

    private static int CalculateSum(List<int> subset)
    {
        int sum = 0;
        for (int i = 0; i < subset.Count; i++)
            sum += subset[i]; 
        return sum; 
    }

    // when calling the method, we set the start index
    // this is why there is no value for index in the method itself
    static void MakeSubset(int index, List<int> subset)
    {
        int sum = CalculateSum(subset); 
        if (sum == N) // if subset sum = N, store subset list in the subsets list of lists
        {
            subsets.Add(new List<int>(subset));

            solution = true; // set solution to true, and we will not be printing that there is no solution
        }

        if (subset.Count == numbers.Length) // if susbset size = input array size
            return; // there is nothing more to be done, return

        for (int i = index; i < numbers.Length; i++)
        {
            subset.Add(numbers[i]); 
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
        Console.WriteLine("Please, enter a sequence of numbers, separated by a space: ");
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine("\nOutput:");

        // logic: make subsets, calculate their sums
        List<int> subset = new List<int>();
        MakeSubset(0, subset);

        // sorted collected subsets of sum N
        for (int i = 0; i < subsets.Count; i++)
        {
            subsets[i].Sort();
        }
        // remove duplicate subsets
        var finalList = subsets.GroupBy(x => String.Join(",", x))
     .Select(x => x.First().ToList())
     .ToList();

        // sort by subset count and value of frst element
        // the subset count determines the number of necessary operands
        var sorted = finalList.OrderBy(list => list.Count).ThenBy(list => list[0]);

        // print the subsets
        foreach (var list in sorted)
        {
            PrintSubset(list);
        }

        // if no sum matches N
        if (!solution)
            Console.WriteLine("No matching subsets.");
    }
}

