using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleVisualiser.Modules
{
    class Painter
    {
        public Painter(Texture2D texture, int rows, int columns)
        {
            TextureAtlas = new TextureAtlas(texture, rows, columns);
        }

        public void DrawGround(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 3, 19);
        }

        public void DrawBrick(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 0, 16);
        }

        public void DrawWall(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 1, 16);
        }

        public void DrawTankUp(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 7, 0);
        }

        public void DrawTankLeft(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 7, 2);
        }

        public void DrawTankDown(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 7, 4);
        }

        public void DrawTankRight(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 7, 6);
        }

        public void DrawEnemyUp(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 8, 8);
        }

        public void DrawEnemyLeft(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 8, 10);
        }

        public void DrawEnemyDown(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 8, 12);
        }

        public void DrawEnemyRight(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 8, 14);
        }

        public void DrawStart(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 2, 18);
        }

        public void DrawFinish(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 2, 19);
        }
        public void DrawBomb(SpriteBatch spriteBatch, Vector2 location)
        {
            TextureAtlas.Draw(spriteBatch, location, 8, 18);
        }

        private TextureAtlas TextureAtlas { get; }
    }
}
