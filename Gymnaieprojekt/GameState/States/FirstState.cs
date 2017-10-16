using Gymnaieprojekt.Sprites;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnaieprojekt.GameState.States
{
    public class FirstState : GameStateBase, IGameState
    {
        private AnimatedSprite test;
        private Sprite dot;

        public FirstState(Context context) : base(context)
        {
            dot =  new Sprite(Context.Content.Load<Texture2D>("Pixel"), new Vector2(100, 100), new Vector2(1,1));
            test = new AnimatedSprite(new Vector2(100, 100), new Vector2(50, 50));

            test.AddAnimation(new Animation(Context.Content.Load<Texture2D>("spr_tree_animated"), Context.GraphicsDevice, 39, 1, 10, true), "default");
            test.ChangeAnimation("default");

            test.Center();
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new SecondState(Context));
            }
            if (InputManager.IsKeyDown(Keys.Space))
            {
                test.Rotation += (float)Math.PI / 72;
            }

            test.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test.Draw(spriteBatch);
            dot.Draw(spriteBatch);
        }
    }
}
