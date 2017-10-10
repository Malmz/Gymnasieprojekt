using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public interface IGameState
    {
        void Update(GameTime gameTime, GameStateManager stateManager);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void ManageDraw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
