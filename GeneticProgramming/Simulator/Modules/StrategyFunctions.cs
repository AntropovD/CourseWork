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
            { "If_Enemy_In_Visible_Area{", AreaChecking.CheckEnemyInVisibleArea },
            { "If_Enemy_In_Fire_Area{", AreaChecking.CheckEnemyInFireArea },
            { "If_Enemy_Front{", EnemiesChecking.CheckEnemyFront },
            { "If_Enemy_Left{", EnemiesChecking.CheckEnemyLeft },
            { "If_Enemy_Right{", EnemiesChecking.CheckEnemyRight },
            { "If_Ememy_Back{", EnemiesChecking.CheckEnemyBack },
            { "If_Obstacle_Front{", ObstaclesChecking.CheckObstacleFront },
            { "If_Obstacle_Back{", ObstaclesChecking.CheckObstacleBack },
            { "If_Obstacle_Right{", ObstaclesChecking.CheckObstacleRight },
            { "If_Obstacle_Left{",  ObstaclesChecking.CheckObstacleLeft }
        };
    }
}
