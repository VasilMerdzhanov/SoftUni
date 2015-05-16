using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceAHrefTagFromFile
{
    static void Main()
    {
        // read file HTML-AHref.txt saved in same folder as the project .cs file
        string html = File.ReadAllText(@"..\..\HTML-AHref.txt");

        string pattern = @"<a(.*href=(.|\n)*?(?=>))>((.|\n)*?(?=<))<\/a>";

        // create new file
        using (StreamWriter URL = new StreamWriter(@"..\..\HTML-URL.txt"))
        {
            // write on the new file, the URL-replaced string
            URL.WriteLine(Regex.Replace(html, pattern, @"[URL$1$2]$3[/URL]"));
        }

        // print output file to the console
        string fileContents = File.ReadAllText(@"..\..\HTML-URL.txt");
        Console.WriteLine(fileContents);
    }
}

