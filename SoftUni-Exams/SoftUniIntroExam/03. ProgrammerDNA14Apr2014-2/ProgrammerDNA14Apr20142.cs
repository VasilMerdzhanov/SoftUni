﻿/* Problem 3 – Programmer DNA
The secret scientists from the institute of Bizarre Artificial Neurobiology or B.A.N 
 * have tried for years to find the DNA markers of the perfect programmer. 
 * The work is going well but after an incident with the printer in the institute it is impossible to print the latest discovery. 
 * That is why they have asked you to help them.
Your task is to make a program that can print simple DNA chains of various lengths. Simple DNA chains consist of sequence of diamond blocks 
 * containing only letters from A to G (see the example on the right).
Letters are chained alphabetically: A is followed by B, then C, D, E, F, G, then again A and so on. Each DNA block is with size 7.
Input
The input data should be read from the console.
•	On the first line an integer number N specifying the length of the DNA chain will be given.
•	On the second line the starting letter of the chain will be given (capital letter from A to G).
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output should be printed on the console. Following the examples below print exactly N lines of the programmer's DNA. 
 * Use only capital letters from A to G and “.” for the empty space.
 */

using System;
using System.Text;

class ProgrammerDNA14Apr20142
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string letter = Console.ReadLine();

        string[] letters = { "A", "B", "C", "D", "E", "F", "G" };
        StringBuilder text = new StringBuilder();
        int L = letters.Length;
        int index = Array.IndexOf(letters, letter);
        int codeLength = 0;

        string dots;
        string code = "";
        do
        {
            if (codeLength < 7)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (N == 0)
                    {
                        return;
                    }
                    dots = new string('.', 3 - i);
                    codeLength = (1 + 2 * i);

                    for (int j  = index; j < index + codeLength; j++)
			        {
			            text.Append(letters[j % 7]);
			        }
                    code = text.ToString();
                    
                    Console.WriteLine("{0}{1}{0}", dots, code);
                    text.Clear();
                    index = (index + codeLength) % 7;
                    N--;
                }
            }
            if (codeLength >= 7)
            {
                for (int k = 2; k >= 0; k--)
                {
                    if (N == 0)
                    {
                        return;
                    }
                    dots = new string('.', 3 - k);
                    codeLength = (1 + 2 * k);
                    for (int l = index; l < index + codeLength; l++)
                    {
                        text.Append(letters[l % 7]);
                    }
                    code = text.ToString();
                    Console.WriteLine("{0}{1}{0}", dots, code);
                    text.Clear();
                    index = (index + codeLength) % 7;
                    N--;
                }
            }
        } while (N > 0);    
    }
}

