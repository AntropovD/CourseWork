using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Modules
{
    public class StrategyFunctions
    {
        public static Dictionary<string, Func<Map, Tank, bool>> Rules = new Dictionary<string, Func<Map, Tank, bool>>
        {
       /*     { "If_Enemy_In_Visible_Area{", CheckEnemyInVisibleArea },
            { "If_Enemy_In_Fire_Area{", CheckEnemyInFireArea },*/
            { "If_Enemy_Front{", StrategyEnemiesChecking.CheckEnemyFront },
            { "If_Enemy_Left{", StrategyEnemiesChecking.CheckEnemyLeft },
            { "If_Enemy_Right{", StrategyEnemiesChecking.CheckEnemyRight },
            { "If_Ememy_Back{", StrategyEnemiesChecking.CheckEnemyBack },
            { "If_Obstacle_Front{", StrategyObstaclesChecking.CheckObstacleFront },
            { "If_Obstacle_Back{", StrategyObstaclesChecking.CheckObstacleBack },
            { "If_Obstacle_Right{", StrategyObstaclesChecking.CheckObstacleRight },
            { "If_Obstacle_Left{",  StrategyObstaclesChecking.CheckObstacleLeft }
        };
    }
}
