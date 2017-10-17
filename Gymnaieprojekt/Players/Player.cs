using System.Collections.Generic;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gymnaieprojekt.Collision;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Players
{
    public class Player : ICollisionObject
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
            sprite.Y += 3;
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

        public void AddSubSprite(BaseSprite subSprite, Vector2? offset = null, bool isVisible = true)
        {
            var off = Vector2.Zero;
            if (offset != null) off = offset.Value;

            sprites.Add(new PlayerSubSprite(subSprite, off, isVisible));
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle(sprite.Position.ToPoint(), sprite.Size.ToPoint());
        }

        public void OnCollision(CollisionInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}
