/* Problem 5.	Reverse Number
Write a method that reverses the digits of a given floating-point number.
Input	    Output
256         652
123.45      54.321
0.12	    21
 */

using System;

class ReverseNumber
{
    static void Main()
    {
        // input
        Console.Write("Please, enter floating-point number: ");
        string input = Console.ReadLine();

        double reversed = ReverseNum(input);
        Console.WriteLine(reversed);
    }
    private static double ReverseNum(string input)
    {
        char[] digits = new char[input.Length]; ;
        // extract the input number digits in reversed order
        for (int i = 0, j = input.Length - 1; j >= 0; i++, j--)
        {
            digits[i] = input[j];
        }
        string result = string.Join("", digits);
        return double.Parse(result);
    }
}
