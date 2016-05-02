using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.Methods
{
    public class MutationMethods
    {
        public IEnumerable<PanzerAlgorithm> GetMutatedSpecies(List<PanzerAlgorithm> basePopulation, int mutationCount)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var commands = Enum.GetValues(typeof(Command));

            for (int i = 0; i < mutationCount; i++)
            {
                var rndAlgorithm = basePopulation[random.Next(basePopulation.Count)];
                int changesCount = random.Next(rndAlgorithm.commands.Count);

                for (int j = 0; j < changesCount; j++)
                {
                    int index = random.Next(rndAlgorithm.commands.Count);
                    Command cmd = (Command)commands.GetValue(random.Next(commands.Length));
                    rndAlgorithm.commands[index] = cmd;
                }
                yield return rndAlgorithm;
            }
        }
    }
}
