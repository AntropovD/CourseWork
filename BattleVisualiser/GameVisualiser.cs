using System;
using System.Collections.Generic;
using System.Diagnostics;
using BattleVisualiser.Modules;
using GeneticProgramming.Simulator;
using GeneticProgramming.Visualiser;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattleVisualiser
{
    class GameVisualiser : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private const int spriteMultiplier = 24;

        public GameVisualiser(Battle battle)
        {
            int width = (battle.Map.Width+2) * spriteMultiplier;
            int height = (battle.Map.Height+2) * spriteMultiplier;

            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height + 50,
                IsFullScreen = false
            };

            Battle = battle;
            FieldBuilder = new FieldBuilder();
            Content.RootDirectory = "Content";

            
            
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            var texture = Content.Load<Texture2D>("atlas");
            Painter = new Painter(texture, 16, 25);

           FieldCommands = new Dictionary<char, Action<SpriteBatch, Vector2>>
           {
               {'#', Painter.DrawBrick },
               {' ', Painter.DrawGround },
               {'2', Painter.DrawTankDown },
               {'4', Painter.DrawTankLeft },
               {'8', Painter.DrawTankUp },
               {'6', Painter.DrawTankRight },
               {'K', Painter.DrawEnemyDown },
               {'J', Painter.DrawEnemyLeft },
               {'I', Painter.DrawEnemyUp },
               {'L', Painter.DrawEnemyRight },
               {'S', Painter.DrawStart },
               {'F', Painter.DrawFinish }
            };
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            int fv = 0;
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                Battle.MakeStep(ref fv);
                stopwatch.Restart();
            }
                
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            var field = FieldBuilder.GetField(Battle.Map);
            int h = field.GetLength(0);
            int w = field.GetLength(1);
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    var location = new Vector2(j * spriteMultiplier, i * spriteMultiplier);
                    FieldCommands[field[i, j]](spriteBatch, location);
                }
            base.Draw(gameTime);
        }

        private Dictionary<char, Action<SpriteBatch, Vector2>> FieldCommands;
        private Stopwatch stopwatch;
        static Painter Painter { get; set; }
        Battle Battle { get; }
        FieldBuilder FieldBuilder { get; }
    }

    /* public class Battle : Microsoft.Xna.Framework.Game
     {
         GraphicsDeviceManager graphics;
         SpriteBatch spriteBatch;
         ParticleEngine particleEngine;

         public Battle()
         {
             graphics = new GraphicsDeviceManager(this);
             Content.RootDirectory = "Content";
         }

         protected override void Initialize()
         {
             base.Initialize();
         }

         protected override void LoadContent()
         {
             spriteBatch = new SpriteBatch(GraphicsDevice);

             List<Texture2D> textures = new List<Texture2D>();
             textures.Add(Content.Load<Texture2D>("circle"));
             textures.Add(Content.Load<Texture2D>("star"));
             textures.Add(Content.Load<Texture2D>("diamond"));
             particleEngine = new ParticleEngine(textures, new Vector2(400, 240));
             Components.Add(new FrameRateCounter(this));
         }

         protected override void UnloadContent()
         {
         }

         protected override void Update(GameTime gameTime)
         {
             // Allows the game to exit
             if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                 this.Exit();

             particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
             particleEngine.Update();

             base.Update(gameTime);
         }

         protected override void Draw(GameTime gameTime)
         {
             GraphicsDevice.Clear(Color.Black);

             particleEngine.Draw(spriteBatch);

             base.Draw(gameTime);
         }
     }*/
}
