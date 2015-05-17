/* Problem 9.	 ** Semantic HTML
This problem is originally from the PHP Basics Exam (31 August 2014). You may check your solution here.
You are given an HTML code, written in the old non-semantic style using tags like <div id="header">, <div class="section">, etc. 
 * Your task is to write a program that converts this HTML to semantic HTML by changing tags like <div id="header"> to their semantic equivalent like <header>.
The non-semantic tags that should be converted are always <div>s and have either id or class with one of the following values: 
 * "main", "header", "nav", "article", "section", "aside" or "footer". Their corresponding closing tags are always 
 * followed by a comment like <!-- header -->, <!-- nav -->, etc. staying at the same line, after the tag.
Input
The input will be read from the console. It will contain a variable number of lines and will end with the keyword "END".
Output
The output is the semantic version of the input HTML. In all converted tags you should replace multiple spaces 
 * (like <header      style="color:red">) with a single space and remove excessive spaces at the end (like <footer      >). See the examples.
Constraints
•	Each line from the input holds either an HTML opening tag or an HTML closing tag or HTML text content.
•	There will be no tags that span several lines and no lines that hold multiple tags.
•	Attributes values will always be enclosed in double quotes ".
•	Tags will never have id and class at the same time.
•	The HTML will be valid. Opening and closing tags will match correctly.
•	Whitespace may occur between attribute names, values and around comments (see the examples).
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
Examples
Input	
<div id="header">
</div> <!-- header -->
END	
 * 
Output
<header>
</header>
 */

using System;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        // input
        string inputLine;
        StringBuilder sb = new StringBuilder();
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            sb.Append(inputLine);
        }
        string text = sb.ToString();

        string patternOpeningTags = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";
        Regex users = new Regex(patternOpeningTags);
        MatchCollection matches = users.Matches(text);

        foreach (Match match in matches)
        {
            string attrName = match.Groups[1].Value;
            string attrValue = match.Groups[3].Value;
            string replaceTag = Regex.Replace(match.ToString(), "div", word => attrValue);
            replaceTag = Regex.Replace(replaceTag, attrName, "");
            replaceTag = Regex.Replace(replaceTag, "\\s*>", ">");
            replaceTag = Regex.Replace(replaceTag, "\\s{2,}", " ");
            Console.WriteLine(replaceTag);
        }
    }
}

