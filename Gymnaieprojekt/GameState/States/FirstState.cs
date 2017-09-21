using System.Collections.Generic;
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

        public FirstState(Tuple<GraphicsDeviceManager, ContentManager> mTuple) : base(mTuple)
        {
            dot =  new Sprite(Content.Load<Texture2D>("Pixel"), new Vector2(100, 100), new Vector2(1,1));

            var testFrames = new List<Frame>();

            //var list = new List<Texture2D>();
            //for (int i = 0; i < 3; i++)
            //{
            //    list.Add(Content.Load<Texture2D>("ship0Texture" + i));
            //}

            test = new AnimatedSprite(new Dictionary<string, Animation>(), new Rectangle(0,0,100,100), new Vector2(100, 100), new Vector2(100, 100));

            //var animation = new Animation(list);
            var animation = new Animation(Content.Load<Texture2D>("ship0TextureSheet"), GraphicsDevice, 3, 1, true);
            animation.Looping = true;
            test.AddAnimation(animation, "default");

            test.ChangeAnimation("default");

            test.Center();
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new SecondState(mTuple));
            }
            if(InputManager.IsKeyDown(Keys.Space))
                test.Rotate((float)Math.PI / 72);
            test.Update(gameTime);
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test.Draw(spriteBatch);
            dot.Draw(spriteBatch);
        }
    }
}
