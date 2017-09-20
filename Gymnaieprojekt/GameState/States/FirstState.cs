using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnaieprojekt.GameState.States
{
    public class FirstState : GameStateBase, IGameState
    {
        private Sprite test;

        public FirstState(Tuple<GraphicsDeviceManager, ContentManager> mTuple) : base(mTuple)
        {
            test = new Sprite(Content.Load<Texture2D>("Pixel"), new Vector2(100, 100), new Vector2(30, 30));
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            test.Move(2, 0);

            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new SecondState(mTuple));
            }
            if(InputManager.IsKeyPressed(Keys.Space))
                test.Move(-50, 0);
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test.Draw(spriteBatch);
        }
    }
}
