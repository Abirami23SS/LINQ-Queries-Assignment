using System;
using System.Collections.Generic;
using System.Linq;

class Program{
    public static void Main(string[] args)
    {
        List<string> names=new List<string> {"abi","abirami","mittu","kalai","bb","sanjay","sudhan"};
        var sorted=names.OrderBy(name=>name.Length);
        foreach(var item in sorted)
        {
            System.Console.WriteLine(item);
        }
    }
}