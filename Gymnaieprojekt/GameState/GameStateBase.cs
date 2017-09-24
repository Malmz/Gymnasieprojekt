using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public abstract class GameStateBase: IGameState
    {
        public ContentManager Content { get; }
        public GraphicsDeviceManager GraphicsDevice { get; }

        protected GameStateBase(GraphicsDeviceManager device, ContentManager content)
        {
            Content = content;
            GraphicsDevice = device;
        }

        public void Update(GameTime gameTime, GameStateManager stateManager) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
