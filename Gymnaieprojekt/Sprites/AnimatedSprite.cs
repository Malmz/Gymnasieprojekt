using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Sprites
{
    public class AnimatedSprite : BaseSprite
    {
        private Dictionary<string, Animation> Animations { get; }
        private Vector2 scale;
        private Vector2 size;
        private Animation currentAnimation;

        public AnimatedSprite(Vector2 position, Vector2 size, float rotation = 0, Vector2? origin = null,  Color? color = null) : base(position, color, rotation, null, origin)
        {
            this.size = size;
            Animations = new Dictionary<string, Animation>();
            currentAnimation = null;
        }

        public void AddAnimation(Animation anim, string name)
        {
                if (name == "") throw new Exception();
                Animations.Add(name, anim);
        }

        public void ChangeAnimation(string name, string animToPlayWhenDone = "")
        {
            currentAnimation = Animations[name];
            Size = size;
            if (animToPlayWhenDone == "") return;
            currentAnimation.ToPlayWhenDone = Animations[animToPlayWhenDone];
        }

        public override void Center()
        {
            var texture = currentAnimation.GetFrame().Texture;

            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

        public override void Update(GameTime gameTime)
        {
            //if (string.IsNullOrEmpty(currentAnimation) || animations.Count <= 0) return;
            currentAnimation.Update(gameTime);
            if (currentAnimation.Done && currentAnimation.ToPlayWhenDone == null)
            {
                currentAnimation = currentAnimation.ToPlayWhenDone;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var frame = currentAnimation.GetFrame();

            spriteBatch.Draw(
                texture: frame.Texture,
                position: position,
                scale: scale,
                sourceRectangle: null,
                color: color,
                rotation: rotation,
                origin: origin + frame.Origin,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }

        public override Vector2 Size
        {
            get { return scale * currentAnimation.GetFrame().Texture.Bounds.Size.ToVector2(); }
            set { scale = value / currentAnimation.GetFrame().Texture.Bounds.Size.ToVector2(); }
        }
        public override float Width
        {
            get { return scale.X * currentAnimation.GetFrame().Texture.Width; }
            set { scale.X = value / currentAnimation.GetFrame().Texture.Width; }
        }
        public override float Height
        {
            get { return scale.Y * currentAnimation.GetFrame().Texture.Height; }
            set { scale.Y = value / currentAnimation.GetFrame().Texture.Height; }
        }
    }
}
