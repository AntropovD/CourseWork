using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleVisualiser.Modules
{
    class TextureAtlas
    {
        private Texture2D Texture { get; }
        private int Rows { get; }
        private int Columns { get; }
        
        public TextureAtlas(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, int row, int column)
        {
            var width = Texture.Width/Columns;
            var height = Texture.Height/Rows;

            var sourceRectangle = new Rectangle(width * column, height * row, width, height);
            var destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();   
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
