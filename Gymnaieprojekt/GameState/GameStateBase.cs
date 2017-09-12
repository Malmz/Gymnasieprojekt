using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public abstract class GameStateBase: IGameState
    {
        protected GameStateBase(ContentManager contentManager)
        {
            Content = contentManager;
        }

        public ContentManager Content { get; }

        public void Update(GameTime gameTime, GameStateManager stateManager)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
