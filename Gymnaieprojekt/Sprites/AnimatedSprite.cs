using System;
using System.Collections.Generic;
using Gymnaieprojekt.Exceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Sprites
{
    public class AnimatedSprite : Sprite
    {
        private Dictionary<string, Animation> animations { get; set; }
        private string currentAnimation = "";

        public AnimatedSprite(Dictionary<string, Animation> animations, Rectangle srcRect, Vector2 position, Vector2 size, Color? color = null) : base(position, srcRect, color)
        {
            this.animations = animations;
        }

        public void AddAnimation(Animation anim, string name)
        {
            try
            {
                animations.Add(name, anim);
            }
            catch (Exception e)
            {
                throw new AnimationAlreadyExistsException();
            }
        }

        public void Update(GameTime gameTime)
        {
            animations[currentAnimation].Update(gameTime);
        }

        public void ChangeAnimation(string name)
        {
            currentAnimation = name;
        }

        private void Draw(SpriteBatch spriteBatch)
        {
            var texture = animations[currentAnimation].GetTexture();

            spriteBatch.Draw(
                texture: texture,
                position: position,
                scale: scale,
                sourceRectangle: srcRect,
                color: Color.White,
                rotation: 0,
                origin: Vector2.Zero,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }
    }
}
