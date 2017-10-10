using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

// ReSharper disable CollectionNeverQueried.Local

namespace Gymnaieprojekt.Backgrounds
{
    public class Background
    {
        private readonly List<Sprite> layers;
        private Vector2 basePos;
        private int paralaxFactor;

        public Background(int paralaxConst)
        {
            this.paralaxFactor = paralaxConst;
            layers = new List<Sprite>();
        }
        public void AddLayer(Texture2D texture)
        {
            layers.Add(new Sprite(texture, Vector2.Zero, new Vector2(texture.Width, texture.Height)));
        }

        public void Update(GameTime gameTime, RectangleF boundingRect)
        {
            for (var i = 0; i < layers.Count; i++)
            {
                Sprite sprite = layers[i];

                var length = boundingRect.X - basePos.X;
                var distance = length * i * paralaxFactor;
                distance = distance % sprite.Width;
                sprite.X = distance;
                if (i != 0) sprite.X *= -1;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, RectangleF boundingRect)
        {
            foreach (var sprite in layers)
            {

                while (true)
                {
                    if (sprite.X < boundingRect.X) break;
                    sprite.X -= sprite.Width;
                }

                sprite.Draw(spriteBatch);

                var orig = sprite.X;
                while (true)
                {
                    sprite.X += sprite.Width;
                    if (sprite.X > boundingRect.X + boundingRect.Width) break;
                    sprite.Draw(spriteBatch);
                }
                sprite.X = orig;
            }
        }
    }
}
