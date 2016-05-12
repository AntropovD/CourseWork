using System;

namespace GeneticProgramming.Configurations.PartialConfigs
{
    [Serializable]
    public class StrategyGeneratorConfig
    {
        public double CloseBracketCoefficient { get; set; }
        public double NewFunctionCoefficient { get; set; }
    }
}
