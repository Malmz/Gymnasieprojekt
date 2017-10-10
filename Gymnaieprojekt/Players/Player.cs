using System;
using System.Collections.Generic;
using Gymnaieprojekt.Players.SubItems;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Players
{
    public class Player
    {
        private readonly AnimatedSprite sprite;
        private readonly List<Tuple<string, Vector2, ISubItem>> sprites;

        public Player(AnimatedSprite sprite)
        {
            sprites = new List<Tuple<string, Vector2, ISubItem>>();
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            foreach (var subSprite in sprites)
            {
                subSprite.Item3.Update(gameTime);
                subSprite.Item3.X = sprite.X + subSprite.Item2.X;
                subSprite.Item3.Y = sprite.Y + subSprite.Item2.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            foreach (var subSprite in sprites)
            {
                if (!subSprite.Item3.IsVisible) return;
                subSprite.Item3.Draw(spriteBatch);
            }
        }

        public void AddSubSprite(string namn, ISubItem subSprite, Vector2? offset = null)
        {
            var off = Vector2.Zero;
            if (offset != null) off = offset.Value;

            sprites.Add(new Tuple<string, Vector2, ISubItem>(namn, off, subSprite));
        }
    }
}
