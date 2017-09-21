using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public interface IGameState
    {
        ContentManager Content { get; }
        GraphicsDeviceManager GraphicsDevice { get; }
        Tuple<GraphicsDeviceManager, ContentManager> mTuple { get; }

        void Update(GameTime gameTime, GameStateManager stateManager);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
