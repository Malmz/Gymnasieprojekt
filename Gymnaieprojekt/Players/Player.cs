using System.Collections.Generic;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Players
{
    public class Player
    {
        private readonly AnimatedSprite sprite;
        private readonly List<PlayerSubSprite> sprites;

        public Player(AnimatedSprite sprite)
        {
            sprites = new List<PlayerSubSprite>();
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            foreach (var subSprite in sprites)
            {
                subSprite.Update(gameTime);
                subSprite.X(sprite.X + subSprite.offset.X);
                subSprite.Y(sprite.Y + subSprite.offset.Y);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            foreach (var subSprite in sprites)
            {
                if (!subSprite.isVisible) return;
                subSprite.Draw(spriteBatch);
            }
        }

        public void AddSubSprite(Sprite subSprite, Vector2? offset = null, bool isVisible = true)
        {
            var off = Vector2.Zero;
            if (offset != null) off = offset.Value;

            sprites.Add(new PlayerSubSprite(subSprite, off, isVisible));
        }
    }
}
