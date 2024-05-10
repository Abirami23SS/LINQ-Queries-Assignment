using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program{
    

    public static void Main(string[] args)
    {
        // int[] numbers=new int[] {23,19,44,34,99,45};
        // IEnumerable<int> numb=
        // from number in numbers
        // where number > 50
        // select number;

        // //print the query
        // foreach(var i in numb)
        // {
        //     System.Console.WriteLine(i + " ");
        // }
        // Console.WriteLine();

        string[] names=new string[] {"AbI","Kalai","Mittu","AnI","Brindha"};
        //List<string> names=new List<string> {"AbI","AnI","Mittu"};
        char startChar = 'A';
        char endChar = 'I';
        var result=names.Where(name=> name.StartsWith(startChar.ToString()) &&  name.EndsWith(endChar.ToString()));
        if(result.Any())
        {
            System.Console.WriteLine($"The names starting with {startChar} and ending with {endChar} is: {string.Join(",",result)}");
        } 
        else
        {
            System.Console.WriteLine("No names start with A and end with I");
        }
    }
}