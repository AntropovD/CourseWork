using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.NInject;
using Ninject;

namespace GeneticProgramming
{
    public class Program
    {
        public static IKernel AppKernel;

        public static void Main()
        {
            AppKernel = new StandardKernel(new BindingModule());
            Console.WriteLine("Hello genetic algorithms!");
        }
    }
}
