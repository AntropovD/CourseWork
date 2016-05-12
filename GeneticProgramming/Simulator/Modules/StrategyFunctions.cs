using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Modules
{
    class StrategyFunctions
    {
        public StrategyFunctions(Map map, Tank tank)
        {
            
        }

        public void CheckFunction(string[] commands, ref int index)
        {
            if (Rules[commands[index]](null, null))
            {
                index++;
                return;
            }
            while (!(StrategiesGenerator.IsFunctionEnd(commands[index]) || index == commands.Length))
            {
                index++;
            }
        }

        private Dictionary<string, Func<Map, Tank, bool>> Rules = new Dictionary<string, Func<Map, Tank, bool>>
        {
           /* { "If_Enemy_In_Visible_Area{", CheckEnemyInVisibleArea },
            { "If_Enemy_In_Fire_Area{", CheckEnemyInFireArea },
            { "If_Enemy_Up{", CheckEnemyUp },
            { "If_Enemy_Left{", CheckEnemyLeft },
            { "If_Enemy_Right{", CheckEnemyRight },
            { "If_Ememy_Down{", CheckEnemyDown },*/
            { "If_Obstacle_Forward{", CheckObstacleForward },
            { "If_Obstacle_Backward{", CheckObstacleBackward },
            { "If_Obstacle_Right{", CheckObstacleRight },
            { "If_Obstacle_Left{",  CheckObstacleLeft }
        };

        private static bool CheckObstacleLeft(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckObstacleRight(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckObstacleBackward(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckObstacleForward(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyDown(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyRight(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyLeft(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyUp(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyInFireArea(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }

        private static bool CheckEnemyInVisibleArea(Map map, Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
