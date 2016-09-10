using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextBalancing
{
    class Program
    {
        static void Main(string[] args)
        {
            TextBalancing textBalancing = new TextBalancing();            
            Console.WriteLine(textBalancing.IsBalanced("(1 + 2) * 3 + (5 / 4) = 0_0' "));
        }
    }
}
