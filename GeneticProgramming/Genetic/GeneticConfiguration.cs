using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProgramming.Genetic
{
    public class GeneticConfiguration
    {
        public int InitialPopulationSize = 16;
        public int MaximumPopulationSize = 64;
        public int MaximumProgramSize = 128;

        public double CrossoverProb = 0.90;
        public double MutationProb = 0.05;

        public double PanmixiaRatio = 0.40;
        public double InbreedRatio = 0.30;
        public double OutbreedRatio = 0.30;
    }
}
