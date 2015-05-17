/*
 *  Console Based Snake Game
 *  Date of completion          [19/11/06]
 *  By                          Jack Cheney - jecheney@gmail.com
 *  http://www.x-rev.net 
 *  Free for use, but please leave credit and send me feedback.
*/


using System.Collections.Generic;
using System;
using System.IO;

namespace LevelEditor
{

    public struct MazePoint
    {
        /*
         *  This struct stores information on the level maze points.
         *  x = x coordinate
         *  y = y coordinate
         *  type = displayed maze character : + - |
        */

        public int x;
        public int y;
        public char type;
    }

    public class LevelEditor
    {
        private static string LevelName;
        private static int LevelScore;

        private static List<MazePoint> MazePoints = new List<MazePoint>();

        private static void DrawBorder()
        {
            /*
             *  Draw the game area borders
            */

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            Console.SetCursorPosition(79, 0);
            Console.Write("+");
            Console.SetCursorPosition(79, 24);
            Console.Write("+");
            Console.SetCursorPosition(0, 24);
            Console.Write("+");

            for (int i = 1; i < 79; i++)
            {
                if (i == 40)
                    i++;
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }

            for (int i = 1; i < 24; i++)
            {
                if (i == 12)
                    i++;
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }

            for (int i = 1; i < 24; i++)
            {
                if (i == 12)
                    i++;
                Console.SetCursorPosition(79, i);
                Console.Write("|");
            }

            for (int i = 1; i < 79; i++)
            {
                if (i == 40)
                    i++;
                Console.SetCursorPosition(i, 24);
                Console.Write("-");
            }


            // Status Bar

            for (int i = 1; i < 79; i++)
            {
                if (i == 40)
                    i++;

                Console.SetCursorPosition(i, 22);
                Console.Write("-");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(3, 23);
            Console.Write("Quit: (Q)  Save: (S)");
            Console.SetCursorPosition(43, 23);
            Console.Write("Points: (+ | -) Erase: (BackSpace)");
            Console.ResetColor();

            Console.SetCursorPosition(39, 23);
            Console.Write("|");
            Console.SetCursorPosition(41, 23);
            Console.Write("|");


            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Red;






            Console.ResetColor();



        }

        public static void SaveLevel()
        {
            /*
             *  Save out the level to a .snk file in the ./CustomLevels Directory
             *  .snk line starting '#' - Level Name
             *  .snk line starting '=' - Target Score
            */

            FileStream file = new FileStream("./CustomLevels/" + LevelName + ".snk", FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(file);

            for (int i = 0; i < MazePoints.Count; i++)
            {
                sr.WriteLine("{0},{1},{2}", MazePoints[i].x.ToString(), MazePoints[i].y.ToString(), MazePoints[i].type.ToString());
            }

            sr.WriteLine("#LEVEL {0}", LevelName);
            sr.WriteLine("={0}", LevelScore);

            sr.Close();
            file.Close();

        }

        public static void StartMazeDesign()
        {
            /*
             *  Begin level design
             *  Process input -> fill maze list with valid points
            */


            Console.SetCursorPosition(40, 18);
            Console.Write("X"); // Entry mark of snake
            Console.SetCursorPosition(40, 18);

            // Point Coordinates
            int x = 40;
            int y = 18;

            MazePoint mztmp;    // Tempory MazePoint Struct to be entered into the list array


            // Process keyboard input -> insert maze position into the list array

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                    switch (keyinfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (y > 1)
                            {
                                y--;
                                Console.SetCursorPosition(x, y);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (y <= 20)
                            {
                                y++;
                                Console.SetCursorPosition(x, y);
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 1)
                            {
                                x--;
                                Console.SetCursorPosition(x, y);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (x <= 77)
                            {
                                x++;
                                Console.SetCursorPosition(x, y);
                            }
                            break;
                        case ConsoleKey.OemMinus:
                            Console.Write("-");
                            mztmp.x = x;
                            mztmp.y = y;
                            mztmp.type = '-';
                            MazePoints.Add(mztmp);
                            Console.SetCursorPosition(x, y);
                            break;
                        case ConsoleKey.Oem5:
                            Console.Write("|");
                            mztmp.x = x;
                            mztmp.y = y;
                            mztmp.type = '|';
                            MazePoints.Add(mztmp);
                            Console.SetCursorPosition(x, y);
                            break;
                        case ConsoleKey.OemPlus:
                            Console.Write("+");
                            mztmp.x = x;
                            mztmp.y = y;
                            mztmp.type = '+';
                            MazePoints.Add(mztmp);
                            Console.SetCursorPosition(x, y);
                            break;
                        case ConsoleKey.Backspace:
                            Console.Write(" ");
                            Console.SetCursorPosition(x, y);
                            for (int i = 0; i < MazePoints.Count; i++)
                            {
                                if (MazePoints[i].x == x && MazePoints[i].y == y)
                                {
                                    MazePoints.Remove(MazePoints[i]);
                                }
                            }
                            break;
                        case ConsoleKey.S:
                            SaveLevel();
                            Console.Beep();
                            break;
                        case ConsoleKey.Q:
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                            break;
                        default:
                            continue;
                    }



                }
            }


        }

        public LevelEditor()
        {
            /*
             *  LevelEditor Constructor
             *  Set up options for level design
             *  Start Level Design
            */

            bool valid_input = false;

            do
            {
                Console.Clear();

                Console.WriteLine("SNAKE LEVEL DESIGNER:");
                Console.Write("=====================\n\n");

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter Level Name: ");
                LevelName = Console.ReadLine();


                Console.Write("Enter Level Target Score: ");

                try
                {
                    LevelScore = Int32.Parse(Console.ReadLine());
                    valid_input = true;
                }
                catch
                {
                    valid_input = false;
                }

            } while (valid_input != true);

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nYou may use the following keys for maze points: | + -\n");
            Console.WriteLine("To save the level press S, to quit press Q.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPress any key to begin level design...");
            Console.ReadKey();


            Console.Clear();

            DrawBorder();
            StartMazeDesign();
        }
    }

}
