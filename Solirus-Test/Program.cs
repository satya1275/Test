using System;
using System.Collections.Generic;
using System.Linq;

namespace Solirus
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddString(new string[] { "","1,2","4,5,6" });
            //AddString(new string[] { "", "\n1,2", "4\n5,6" });
            NumberAddition.AddString(new string[] { "1\n,2", "4\n5,6" });
            Console.ReadLine();
        }

        
    }
}
