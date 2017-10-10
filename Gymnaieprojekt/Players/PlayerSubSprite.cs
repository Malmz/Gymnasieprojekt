using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Players
{
    public class PlayerSubSprite
    {
        private readonly ISprite sprite;
        public Vector2 offset;
        public bool isVisible;

        public PlayerSubSprite(ISprite sprite, Vector2 offset, bool isVisible = true)
        {
            this.sprite = sprite;
            this.offset = offset;
            this.isVisible = isVisible;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void X(float x)
        {
            sprite.X(x);
        }

        public void Y(float y)
        {
            sprite.Y(y);
        }
    }
}
