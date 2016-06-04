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
            Content.RootDirectory = "Content";
            FieldBuilder = new FieldBuilder();
            fightStat = new FightStat();
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
            textFont = Content.Load<SpriteFont>("Text");
            messageFont = Content.Load<SpriteFont>("Message");
            song = Content.Load<Song>("music");
            boomSound = Content.Load<SoundEffect>("bomb");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);

            var texture = Content.Load<Texture2D>("atlas");
            Painter = new Painter(texture, 16, 25);
            FieldCommands = SetupCommands();
        }

        private Dictionary<char, Action<SpriteBatch, Vector2>> SetupCommands()
        {
            return new Dictionary<char, Action<SpriteBatch, Vector2>>
            {
                {'#', Painter.DrawBrick },
                {' ', Painter.DrawGround },
                {'*', Painter.DrawBomb },
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
            Content.Unload();
        }
        
        protected override void Update(GameTime gameTime)
        {
            HandleKeyboard();
            if (stopwatch.ElapsedMilliseconds > currentSpeed)
            {
                if (!battle.IsOver)
                    battle.MakeStep(fightStat);
                stopwatch.Restart();
            }
            base.Update(gameTime);
        }

        private void HandleKeyboard()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            PresentKey = Keyboard.GetState();
            if (PresentKey.IsKeyDown(Keys.OemMinus) && PastKey.IsKeyUp(Keys.OemMinus))
                DecreaseSpeed();
            if (PresentKey.IsKeyDown(Keys.OemPlus) && PastKey.IsKeyUp(Keys.OemPlus))
                IncreaseSpeed();
            PastKey = PresentKey;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            DrawField(spriteBatch);
            DrawMessages(spriteBatch);
            DrawStatistics(spriteBatch);
            base.Draw(gameTime);
        }

        private void DrawStatistics(SpriteBatch spriteBatch1)
        {

            int stringHeight = height;
            fightStat.UpdateResult(battle);
            string statString = $"Score: {fightStat.Result} " +
                                $"Tank kills: {fightStat.Killed} " +
                                $"Enemies killed each other: {fightStat.EnemiesKilledByEnemies} " +
                                $"Step: {fightStat.Steps} " +
                                $"Tanks left: {battle.Map.AllTanks.Count} " +
                                $"Current speed: {currentSpeed}";


            spriteBatch.Begin();
            spriteBatch.DrawString(textFont, statString, new Vector2(10, stringHeight), Color.Green);
            spriteBatch.End();
        }

        private void DrawMessages(SpriteBatch batch)
        {
            DrawDeadMessages(batch);
            DrawFinishMessage(batch);
        }

        private void DrawFinishMessage(SpriteBatch batch)
        {
            if (battle.hasTankReachFinish)
            {
                spriteBatch.Begin();
                string message = "Tank reaches finish";
                spriteBatch.DrawString(messageFont, message,
                        new Vector2((float)(height * 0.5 - 100), (float)(100)), Color.Red);
                spriteBatch.End();
            }
        }

        private void DrawDeadMessages(SpriteBatch batch)
        {
            if (!battle.Map.Tank.IsAlive)
            {
                spriteBatch.Begin();
                string message = battle.Map.Tank.Strategy.strategyOver ? "Strategy Was Over" : "Tank was killed";
                spriteBatch.DrawString(messageFont, message,
                        new Vector2((float)(height * 0.5 - 100), (float)(100)), Color.Red);
                spriteBatch.End();
            }
        }

        private void DrawField(SpriteBatch batch)
        {
            var field = FieldBuilder.GetField(battle.Map);
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    var location = new Vector2(j*spriteMultiplier, i*spriteMultiplier);
                    FieldCommands[field[i, j]](batch, location);
                    if (field[i, j] == '*')
                        boomSound.Play(1, 0, 0);
                }
            }
        }

        private void DecreaseSpeed()
        {
            currentSpeed = Math.Max(50, currentSpeed - 50);
        }

        private void IncreaseSpeed()
        {
            currentSpeed = Math.Min(1000, currentSpeed + 50);
        }

        private const int spriteMultiplier = 24;
        private long currentSpeed = 500;

        public KeyboardState PastKey { get; set; }
        public KeyboardState PresentKey { get; set; }
        static Painter Painter { get; set; }
        Battle battle { get; }
        FieldBuilder FieldBuilder { get; }

        private GraphicsDeviceManager graphics;
        private Dictionary<char, Action<SpriteBatch, Vector2>> FieldCommands;
        private SpriteBatch spriteBatch;
        private Stopwatch stopwatch;
        private FightStat fightStat;
        private SpriteFont textFont;
        private SpriteFont messageFont;
        private Song song;
        private SoundEffect boomSound;
        private int width;
        private int height;
    }
}
