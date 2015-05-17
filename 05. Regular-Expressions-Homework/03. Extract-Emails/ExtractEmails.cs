/* Problem 3.	Extract Emails
Write a program to extract all email addresses from a given text. The text comes at the only input line. Print the emails on the console, 
 * each at a separate line. Emails are considered to be in format <user>@<host>, where: 
•	<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them. Examples of valid users: "stephan", 
 * "mike03", "s.johnson", "st_steward", "softuni-bulgaria", "12345". Examples of invalid users: ''--123", ".....", "nakov_-", "_steve", ".info". 
•	<host> is a sequence of at least two words, separated by dots '.'. Each word is sequence of letters and can have hyphens '-' between the letters. 
 * Examples of hosts: "softuni.bg", "software-university.com", "intoprogramming.info", "mail.softuni.org". Examples of invalid hosts: "helloworld", 
 * ".unknown.soft.", "invalid-host-", "invalid-". 
•	Examples of valid emails: info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net, info-bg@software-university.software.academy. 
•	Examples of invalid emails: --123@gmail.com, …@mail.bg, .info@info.info, _steve@yahoo.cn, mike@helloworld, mike@.unknown.soft., s.johnson@invalid-.
Examples:
Input	Output
Please contact us at: support@github.com.	support@github.com
Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information.	s.miller@mit.edu
j.hopking@york.ac.uk
Many users @ SoftUni confuse email addresses. We @ Softuni.BG provide high-quality training @ home or @ class. –- steve.parker@softuni.de.	steve.parker@softuni.de
 */

using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        // input
        string text = Console.ReadLine();

        // logic
        string pattern = @"(?<=\s|^)([A-Za-z0-9]+[_.-]*?\w+@(\w+[-]*?\w+\.)+\w+[-]*?\w+)\b";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);

        // create new file
        using (StreamWriter URL = new StreamWriter(@"..\..\emails.html"))
        {
            foreach (Match email in matches)
            {           
                URL.WriteLine(String.Format("<i>"+email.Groups[1]+"</i>"));
                URL.WriteLine("<br>");
            }
        }
        // open html file with results
        System.Diagnostics.Process.Start(@"..\..\emails.html");
    }
}

