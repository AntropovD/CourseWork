using GeneticProgramming.Genetic;

namespace Tests.GeneticTests
{
    public static class ConfigurationFactory
    {
        public static GeneticConfig GetConfigForTesting()
        {
            return new GeneticConfig
            {
                PopulationSize = 64,
                MaxStrategySize = 128,
                CrossoverProb = 0.9,
                MutationProb = 0.05,
                PanmixiaRatio = 0.4,
                InbreedRatio = 0.3,
                OutbreedRatio = 0.4
            };
        }
    }
}