using System;
using Text_Analysis.Classes;

namespace Text_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter you text");
            var text = Console.ReadLine();
            TextAnalysis document = new TextAnalysis(text);
            Console.WriteLine(document.Text);
        }
    }
}
