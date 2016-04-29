using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic
{
    public class Population
    {
        private readonly GeneticConfiguration configuraion;

        public List<PanzerAlgorithm> Species { get; set; }

        public Population(GeneticConfiguration configuration)
        {
            configuraion = configuration;
            InitiatePopulation();
        }

        public void InitiatePopulation()
        {
            Species = new List<PanzerAlgorithm>();
            Species.AddRange(Enumerable.Range(0, configuraion.InitialPopulationSize)
                .Select(i => GenerateRandomProgram()));
        }

        private PanzerAlgorithm GenerateRandomProgram()
        {
            var commands = Enum.GetValues(typeof (Command));
            var random = new Random(Guid.NewGuid().GetHashCode());
            return new PanzerAlgorithm(Enumerable
                .Range(0, configuraion.InitialPopulationSize)
                .Select(i => (Command) commands.GetValue(random.Next(commands.Length)))
                .ToList());
        }
    }
}
