using System;
using System.Collections.Generic;
using System.Diagnostics;
using BattleVisualiser.Modules;
using GeneticProgramming.Simulator;
using GeneticProgramming.Visualiser;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BattleVisualiser
{
    class GameVisualiser : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private const int spriteMultiplier = 24;

        public GameVisualiser(Battle battle)
        {
            width = (battle.Map.Width+2) * spriteMultiplier;
            height = (battle.Map.Height+2) * spriteMultiplier;

            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Math.Max(width, 700),
                PreferredBackBufferHeight = height + 50,
                IsFullScreen = false
            };

            this.battle = battle;
            FieldBuilder = new FieldBuilder();
            FightStat = new FightStat();
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
            textFont = Content.Load<SpriteFont>("Text");
            messageFont = Content.Load<SpriteFont>("Message");
            song = Content.Load<SoundEffect>("music");
            boomSound = Content.Load<SoundEffect>("bomb");
            song.Play();
            

            
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

            PresentKey = Keyboard.GetState();
            if (PresentKey.IsKeyDown(Keys.OemMinus) && PastKey.IsKeyUp(Keys.OemMinus))
                DecreaseSpeed();
            if (PresentKey.IsKeyDown(Keys.OemPlus) && PastKey.IsKeyUp(Keys.OemPlus))
                IncreaseSpeed();
            PastKey = PresentKey;
            
            if (stopwatch.ElapsedMilliseconds > currentSpeed)
            {
                if (!battle.IsOver)
                    battle.MakeStep(FightStat);
                stopwatch.Restart();
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            var field = FieldBuilder.GetField(battle.Map);
            int h = field.GetLength(0);
            int w = field.GetLength(1);

            
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    var location = new Vector2(j*spriteMultiplier, i*spriteMultiplier);
                    FieldCommands[field[i, j]](spriteBatch, location);
                }

            if (!battle.Map.Tank.IsAlive)
            {
                spriteBatch.Begin();
                string message = battle.Map.Tank.Strategy.strategyOver ? "Strategy Was Over" : "Tank was killed";
                spriteBatch.DrawString(messageFont, message, 
                        new Vector2((float) (height*0.5-100), (float) (100)), Color.Red);
                spriteBatch.End();
            }
            if (battle.isTankReachFinish)
            {
                spriteBatch.Begin();
                string message = "Tank reaches finish";
                spriteBatch.DrawString(messageFont, message,
                        new Vector2((float)(height * 0.5 - 100), (float)(100)), Color.Red);
                spriteBatch.End();
            }

            int stringHeight = spriteMultiplier*h;
            FightStat.UpdateResult(battle);
            string statString = $"Score: {FightStat.Result} " +
                                $"Tank kills: {FightStat.Killed} " +
                                $"Enemies killed each other: {FightStat.EnemiesKilledByEnemies} " +
                                $"Step: {FightStat.Steps} " +
                                $"Tanks left: {battle.Map.AllTanks.Count} " +
                                $"Current speed: {currentSpeed}";


            spriteBatch.Begin();
            spriteBatch.DrawString(textFont, statString, new Vector2(10, stringHeight), Color.Green);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private Dictionary<char, Action<SpriteBatch, Vector2>> FieldCommands;
        private Stopwatch stopwatch;
        private FightStat FightStat;
        private SpriteFont textFont;
        private SpriteFont messageFont;
        private long currentSpeed = 500;
        private SoundEffect song;
        private SoundEffect boomSound;
        private int width;
        private int height;

        private void DecreaseSpeed()
        {
            currentSpeed = Math.Max(50, currentSpeed - 50);
        }

        private void IncreaseSpeed()
        {
            currentSpeed = Math.Min(1000, currentSpeed + 50);
        }
        
        public KeyboardState PastKey { get; set; }
        public KeyboardState PresentKey { get; set; }
        static Painter Painter { get; set; }
        Battle battle { get; }
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
