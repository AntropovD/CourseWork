using System;

namespace GeneticProgramming.Configurations.PartialConfigs
{
    [Serializable]
    public class GeneticConfig
    {
        public int PopulationSize { get; set; }

        public double CrossoverProb { get; set; }
        public double MutationProb { get; set; }

        public double PanmixiaRatio { get; set; }
        public double InbreedRatio { get; set; }
        public double OutbreedRatio { get; set; }

        public int MaxStrategySize { get; set; }
    }
}