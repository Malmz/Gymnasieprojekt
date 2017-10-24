using System;
using System.Collections.Generic;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gymnaieprojekt.Collision;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

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

        private Rectangle oldRect;

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
            oldRect = new Rectangle((int)sprite.X, (int)sprite.Y, (int)sprite.Width, (int)sprite.Height);
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
            var playerBottom = sprite.Y + sprite.Height;
            var tileBottom = info.BoundingBox.Y + info.BoundingBox.Height;
            var playerRight = sprite.X + sprite.Width;
            var tileRight = info.BoundingBox.X + info.BoundingBox.Width;

            var bottomCollis = tileBottom - sprite.Y;
            var topCollis = playerBottom - info.BoundingBox.Y;
            var leftCollis = playerRight - info.BoundingBox.X;
            var rightCollis = tileRight - sprite.X;

            if (topCollis < bottomCollis && topCollis < leftCollis && topCollis < rightCollis)
            {
                //Top collision (player ontop object)
                OnTopCollision(info);
                onGround = true;
            }
            if (bottomCollis < topCollis && bottomCollis < leftCollis && bottomCollis < rightCollis)
            {
                //Bottom collision (player below object)
                OnBottomCollision(info);
            }
            if (leftCollis < rightCollis && leftCollis < topCollis && leftCollis < bottomCollis)
            {
                //Left collision (player left of object)
                OnLeftCollision(info);
            }
            if (rightCollis < leftCollis && rightCollis < topCollis && rightCollis < bottomCollis)
            {
                //Right collision (player right of object)
                OnRightCollision(info);
            }
        }

        private void OnTopCollision(CollisionInfo info)
        {
            //Top collision (player ontop)
            sprite.Y -= yVelocity;
            yVelocity = 0;
            onGround = true;
        }

        private void OnBottomCollision(CollisionInfo info)
        {
            //Bottom collision (player below)
            sprite.Y -= yVelocity;
            yVelocity = 0;
        }

        private void OnLeftCollision(CollisionInfo info)
        {
            //Left collision (player left of object)
            if(yVelocity > 0 ) sprite.X -= xVelocity;
            else if (yVelocity < 0) sprite.X += xVelocity;
            xVelocity = 0;
        }

        private void OnRightCollision(CollisionInfo info)
        {
            //Right collision (player right of object)
            if (yVelocity > 0) sprite.X += xVelocity;
            else if (yVelocity < 0) sprite.X -= xVelocity;
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


        public void CenterCameraOnPlayer(Camera2D camera, GraphicsDevice graphicsDevice)
        {
            camera.Position = new Vector2(
                MathHelper.Clamp(sprite.X - sprite.Width / 2f - graphicsDevice.Viewport.Width / 2f, 0f, (float)double.MaxValue),
                camera.Position.Y);
        }
    }
}
