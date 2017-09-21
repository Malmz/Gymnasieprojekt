using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public abstract class GameStateBase: IGameState
    {
        protected GameStateBase(Tuple<GraphicsDeviceManager, ContentManager> mTuple)
        {
            Content = mTuple.Item2;
            GraphicsDevice = mTuple.Item1;
            this.mTuple = mTuple;
        }

        public Tuple<GraphicsDeviceManager, ContentManager> mTuple { get; }
        public ContentManager Content { get; }
        public GraphicsDeviceManager GraphicsDevice { get; }

        public void Update(GameTime gameTime, GameStateManager stateManager)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
