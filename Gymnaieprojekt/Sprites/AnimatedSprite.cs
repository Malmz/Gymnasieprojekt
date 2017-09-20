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
                if (name == "") throw new Exception();
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
            if (animations[currentAnimation].Done && animations[currentAnimation].ToPlayWhenDone != "")
            {
                currentAnimation = animations[currentAnimation].ToPlayWhenDone;
            }
                
        }

        public void ChangeAnimation(string name, string animToPlayWhenDone = "")
        {
            currentAnimation = name;
            if (animToPlayWhenDone == "") return;
            animations[currentAnimation].ToPlayWhenDone = animToPlayWhenDone;
        }

        public new void Draw(SpriteBatch spriteBatch)
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
