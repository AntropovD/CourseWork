using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    class BattleSimulator
    {
        private readonly bool isDebug;
        private BaseVisualiser Visualiser { get; }
        private Battle Battle { get;  }

        public BattleSimulator(Battle battle, bool isDebug = false)
        {
            Battle = battle;
            Visualiser = new ConsoleVisualiser();
            this.isDebug = isDebug;
        }

        public int Execute()
        {
            int fitnessValue = 0;
            while (!Battle.IsOver)
            {
                Battle.MakeStep(ref fitnessValue);
                if (isDebug)
                {
                    Visualiser.Visualise(Battle.Map);
                }
            }
            return fitnessValue;
        }
    }
}


/*
private void MakeStep(string command)
{
    Coord nextCoord = Map.Tank.NextStep(command);
    if (IsPossible(nextCoord))
    {
        Map.Tank.Coord = nextCoord;
    }

//            foreach (var enemy in Map.Enemies)
//            {
//                enemy.NextStep();
//            }
}

private bool IsPossible(Coord nextCoord)
{
    return true;
}*/
/* while (index < strategy.commands.Count)
            {
                if (StrategiesGenerator.IsTerminal(commands[index]))
                {
                    MakeStep(commands[index]);
                    if (isDebug)
                        visualiser.Visualise(Map);
                    if (Map.Tank.Coord == Map.FinishCoord)
                    {
                        result += 1000;
                        return result;
                    }
                    result++;
                }
                if (StrategiesGenerator.IsFunction(commands[index]))
                {
                    tankFunctions.CheckFunction(commands, ref index);
                }
                if (StrategiesGenerator.IsFunctionEnd(commands[index]))
                {
                    
                }
                Console.WriteLine($"Step#{index} - {commands[index]}");
                index++;
             //   Console.ReadKey();
            }*/
