using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Auxillary;
using GeneticProgramming.Genetic.GeneticEngine;
using Ninject.Modules;

namespace GeneticProgramming.NInject
{
    class BindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRandom>().To<MyRandom>();

            Bind<IGeneticEngine>().To<BaseGeneticEngine>();
        }
    }
}
