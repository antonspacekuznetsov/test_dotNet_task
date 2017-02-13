using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNet_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Procces proc = new Procces();
            proc.AddCategory("Products");
            proc.AddCategory("Boxes");
            proc.AddCategory("Flowers");
            proc.AddCategory("Products");

            proc.AddPost("Как найти нужный товар быстро", 10, 1, "И так речь пойдет о...");

        }
    }
}
