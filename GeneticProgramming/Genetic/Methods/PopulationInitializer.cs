using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.Methods
{
    public class PopulationInitializer
    {
        public List<TankStrategy> Initiate(int populationSize, int maxStrategySize)
        {
            return Enumerable.Range(0, populationSize)
                .Select(i => GenerateRandomProgram(maxStrategySize)).ToList();
        }
        
        private TankStrategy GenerateRandomProgram(int maxStrategySize)
        {
            var commands = Enum.GetValues(typeof(Command));
            var random = new Random(Guid.NewGuid().GetHashCode());
        
            return new TankStrategy(Enumerable.Range(0, random.Next(maxStrategySize))
                .Select(i => (Command)commands.GetValue(random.Next(commands.Length)))
                .ToList());
        }
    }
}
