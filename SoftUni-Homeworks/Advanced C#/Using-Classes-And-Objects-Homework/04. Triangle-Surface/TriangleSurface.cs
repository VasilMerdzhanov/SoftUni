// Problem 4. Triangle surface

/* Write methods that calculate the surface of a triangle by given:
        Side and an altitude to it;
        Three sides;
        Two sides and an angle between them;
    Use System.Math.
 */


﻿using System;
/*Problem 4. Triangle surface
----------------------------------------------------------------
Write methods that calculate the surface of a triangle by given:
Side and an altitude to it;
Three sides;
Two sides and an angle between them;
Use System.Math.
*/
class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine("This is a program that calculate the surface of a triangle by given:");

        Console.WriteLine("1) Three sides");
        Console.WriteLine("2) Side and an altitude to it");
        Console.WriteLine("3) Two sides and an angle between them");
        Console.WriteLine("Please choose an option: 1, 2 or 3!");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: CalcSurfaceByThreeSides(); break;
            case 2: CalcSurfaceBySideAndAltitude(); break;
            case 3: CalcSurfaceByTwoSidesAndAngle(); break;
        }
    }

    private static void CalcSurfaceByThreeSides()
    {
        // input
        Console.Write("Enter a real number for the first side: ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("Enter a real number for the second side: ");
        decimal b = decimal.Parse(Console.ReadLine());
        Console.Write("Enter a real number for the third side: ");
        decimal c = decimal.Parse(Console.ReadLine());

        // creating triangle object
        TriangleSides firstTriangle = new TriangleSides(a, b, c);
        // calling the area calculation method on the above triangle object
        Console.WriteLine("The triangle area, \ncalculated with 3 sides, is: {0:F2}", firstTriangle.AreaSides);
    }

    private static void CalcSurfaceBySideAndAltitude()
    {
        // input
        Console.Write("Enter a real number for the side: ");
        decimal side = decimal.Parse(Console.ReadLine());
        Console.Write("Enter a real number for the altitude: ");
        decimal altitude = decimal.Parse(Console.ReadLine());

        // creating triangle object
        TriangleBH secondTriangle = new TriangleBH(side, altitude);
        // calling the area calculation method on the above triangle object
        Console.WriteLine("The triangle area, \ncalculated with base and respective height, is: {0:F2}", secondTriangle.AreaBH);
    }

    private static void CalcSurfaceByTwoSidesAndAngle()
    {
        // input
        Console.Write("Enter a real number for the first side: ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("Enter a real number for the second side: ");
        decimal b = decimal.Parse(Console.ReadLine());
        Console.Write("Enter a real number for the angle between two sides in degrees: ");
        decimal angleAB = decimal.Parse(Console.ReadLine());

        // creating triangle object
        TriangleABAngle thirdTriangle = new TriangleABAngle(a, b, angleAB);
        // calling the area calculation method on the above triangle object
        Console.WriteLine("The triangle area, \ncalculated with 2 sides and angle between them, \nis: {0:F2}", thirdTriangle.AreaABAngle);
    }
}

