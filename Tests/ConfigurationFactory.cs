using GeneticProgramming;
using GeneticProgramming.Configurations;

namespace Tests
{
    public static class ConfigurationFactory
    {
        public static Configuration Configuration = new Configuration
            {
                GeneticConfig = new GeneticConfig
                {
                    PopulationSize = 100,
                    MaxStrategySize = 500,
                    CrossoverProb = 0.90,
                    MutationProb = 0.05,
                    PanmixiaRatio = 0.4,
                    InbreedRatio = 0.3,
                    OutbreedRatio = 0.3
                },
                MapConfig = new MapConfig
                {
                    Height = 20,
                    Width = 20,
                    EnemiesCount = 10,
                    ObstaclesCount = 50
                },
                TankConfig = new TankConfig
                {
                    Ammunition = 20,
                    FireArea = 2,
                    ViewArea = 4
                }
            };
    }
}
