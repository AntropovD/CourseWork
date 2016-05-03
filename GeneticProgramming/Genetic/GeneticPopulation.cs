using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic
{
    public class GeneticPopulation
    {
        private readonly GeneticConfiguration configuraion;

        public List<TankStrategy> Species { get; set; }

        public GeneticPopulation(GeneticConfiguration configuration)
        {
            configuraion = configuration;
            InitiatePopulation();
        }
        
        public void InitiatePopulation()
        {
            Species = new List<TankStrategy>();
            Species.AddRange(Enumerable.Range(0, configuraion.InitialPopulationSize)
                .Select(i => GenerateRandomProgram()));
        }

        private TankStrategy GenerateRandomProgram()
        {
            var commands = Enum.GetValues(typeof (Command));
            var random = new Random(Guid.NewGuid().GetHashCode());

            return new TankStrategy(Enumerable
                .Range(0, configuraion.InitialPopulationSize)
                .Select(i => (Command) commands.GetValue(random.Next(commands.Length)))
                .ToList());
        }
    }
}
