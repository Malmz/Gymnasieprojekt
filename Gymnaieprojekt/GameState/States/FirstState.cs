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
        public FirstState(Tuple<GraphicsDeviceManager, ContentManager> mTuple) : base(mTuple)
        {

            var testFrames = new List<Frame>();

            var list = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(Content.Load<Texture2D>("ship0Texture" + i));
            }

            test = new AnimatedSprite(new Dictionary<string, Animation>(), new Rectangle(0,0,100,100), new Vector2(100, 100), new Vector2(100, 100));

            var animation = new Animation(list);
            animation.Looping = true;
            test.AddAnimation(animation, "default");



            test.ChangeAnimation("default");
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new SecondState(mTuple));
            }
            if(InputManager.IsKeyPressed(Keys.Space))
                test.Move(-50, 0);
            test.Update(gameTime);
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test.Draw(spriteBatch);
        }
    }
}
