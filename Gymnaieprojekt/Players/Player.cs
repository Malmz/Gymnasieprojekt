using System;
using System.Collections.Generic;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gymnaieprojekt.Collision;
using Microsoft.Xna.Framework.Input;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Players
{
    public class Player : ICollisionObject
    {
        private readonly AnimatedSprite sprite;
        private readonly List<PlayerSubSprite> sprites;

        private const float playerSpeed = 5;
        private const float jumpStartVelocity = 12.0f;
        private const float cancelJumpVelocity = 6.0f;
        private bool onGround;

        private float yVelocity;
        private float xVelocity;

        private Keys JumpKey = Keys.Space;
        private Keys LeftKey = Keys.Left;
        private Keys RightKey = Keys.Right;

        public Player(AnimatedSprite sprite)
        {
            sprites = new List<PlayerSubSprite>();
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {

            if (InputManager.IsKeyDown(RightKey) && xVelocity <= playerSpeed) xVelocity = playerSpeed;
            else if (InputManager.IsKeyDown(LeftKey) && xVelocity >= -playerSpeed) xVelocity = -playerSpeed;

            if (InputManager.IsKeyPressed(JumpKey)) Jump();
            if (InputManager.WasKeyReleased(JumpKey)) EndJump();

            yVelocity += GlobalConstants.YGravConst;

            if (xVelocity + GlobalConstants.XGravConst < 0) xVelocity += GlobalConstants.XGravConst;
            else if (xVelocity - GlobalConstants.XGravConst > 0) xVelocity -= GlobalConstants.XGravConst;
            else xVelocity = 0;

            sprite.X += xVelocity;
            sprite.Y += yVelocity;

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
            //todo
        }

        private bool IsFirstCloser(double value, double first, double second)
        {
            var firstValue = Math.Abs(value - first);
            var secondValue = Math.Abs(value - second);

            return firstValue > secondValue;
        }

        private void OnTopCollision(CollisionInfo info)
        {
            //Top collision (player ontop)
            sprite.Y = info.BoundingBox.Y - sprite.Height;
            yVelocity = 0;
            onGround = true;
        }

        private void OnBottomCollision(CollisionInfo info)
        {
            //Bottom collision (player below)
            sprite.Y = info.BoundingBox.Y + info.BoundingBox.Height;
            yVelocity = 0;
        }

        private void OnLeftCollision(CollisionInfo info)
        {
            //Left collision (player left of object)
            sprite.X = info.BoundingBox.X - sprite.Width;
            xVelocity = 0;
        }

        private void OnRightCollision(CollisionInfo info)
        {
            //Right collision (player right of object)
            sprite.X = info.BoundingBox.X + info.BoundingBox.Right;
            xVelocity = 0;
        }

        private void Jump()
        {
            if (onGround)
            {
                yVelocity -= jumpStartVelocity;
                onGround = false;
            }
        }

        private void EndJump()
        {
            if (yVelocity < -cancelJumpVelocity) yVelocity = -cancelJumpVelocity;
        }
    }
}
