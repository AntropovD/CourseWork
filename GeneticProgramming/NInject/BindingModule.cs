using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Randomizer;
using Ninject.Modules;

namespace GeneticProgramming.NInject
{
    class BindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGeneticEngine>().To<BaseGeneticEngine>();
            Bind<IRandom>().To<GuidRandom>();
        }
    }
}
