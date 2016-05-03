using GeneticProgramming.Genetic;

namespace Tests.GeneticTests
{
    public static class ConfigurationFactory
    {
        public static GeneticConfiguration GetConfigForTesting()
        {
            return new GeneticConfiguration
            {
                InitialPopulationSize = 16,
                MaximumPopulationSize = 64,
                MaximumProgramSize = 128,
                CrossoverProb = 0.9,
                MutationProb = 0.05,
                PanmixiaRatio = 0.4,
                InbreedRatio = 0.3,
                OutbreedRatio = 0.4
            };
        }
    }
}