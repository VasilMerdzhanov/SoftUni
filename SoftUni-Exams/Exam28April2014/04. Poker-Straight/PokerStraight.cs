/* Problem 4 – Poker Straight
The classical playing cards have face and suit. Card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A. Cards suits are: 
 * Clubs (C), Diamonds (D), Hearts (H) and Spades (S). We denote a card in short as card face + card suit letter, 
 * e.g. 5C (Five Clubs), 10S (Ten Spades), AH (Ace Hearts), 2D (Two Diamonds).
In some poker games, we have a hand called "straight" which consists of a sequence of five cards of increasing sequential rank. The card ranks are as follows: 
 * A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A. Note that the Ace (A) is a special card: it works both as the smallest and as the biggest card.
Examples of "straight": (AC 2H 3H 4C 5H), (2H 3S 4H 5H 6D), (5C 6C 7C 8C 9C), (7C 8D 9S 10S JS), (9C 10H JD QD KD), (10D JD QS KH AH). 
 * The following hands are not "straight": (9D JD QS KH AH) – not sequential; (10C 7C 9D 8S JS) – sequential, but not ordered; (9H 8S 7H 6H 5D) 
 * – sequential, but incorrectly ordered.
Card faces have the following weights: A  1 (as first card) or 14 (as last card); 
 * 2  2; 3  3; 4  4; 5  5; 6  6; 7  7; 8  8; 9  9; 10  10; J  11; Q  12; K 13. Card suits have the following weights: Clubs  1; 
 * Diamonds  2; Hearts  3; Spades  4. Hands weight is calculated as follows:
10 * weight(first card face) + weight(first card suit) +
20 * weight(second card face) + weight(second card suit) +
30 * weight(third card face) + weight(third card suit) +
40 * weight(fourth card face) + weight(fourth card suit) +
50 * weight(fifth card face) + weight(fifth card suit)
Examples of straight hands and their weights:
•	weight(AC 2H 3H 4C 5S) = (10*1 + 1) + (20*2 + 3) + (30*3 + 3) + (40*4 + 1) + (50*5 + 4) = 562
•	weight(10H JS QD KS AD) = (10*10 + 3) + (20*11 + 4) + (30*12 + 2) + (40*13 + 4) + (50*14 + 2) = 1915
Your task is to write a program that calculates the number of straight hands that have given weight w.
Input
The input data should be read from the console. It holds a single number w (the target weight). 
 * The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
Print on the console the number of straight hands of given weight w.
Constraints
•	The number w is an integer in the range [0…5000].
 */

using System;

class PokerStraight
{
    static void Main()
    {
        //bool isConsecutive = !myIntList.Select((i, j) => i - j).Distinct().Skip(1).Any();
    }
}

