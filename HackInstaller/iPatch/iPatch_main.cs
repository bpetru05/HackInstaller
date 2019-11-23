using System;
using Microsoft.Graph;
namespace iPatch
{
    class iPatch_main
    {
        public static void main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Utilities utilities = new Utilities();
            MSGraphCrap Graph = new MSGraphCrap();
            var KextRepo = Graph.GetKextRepo(utilities.does_string_contain(args,"debug"));
        }
    }
}
