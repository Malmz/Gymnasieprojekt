using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public abstract class GameStateBase: IGameState
    {
        public ContentManager Content { get; }
        public GraphicsDeviceManager GraphicsDeviceManager { get; }
        public GraphicsDevice GraphicsDevice { get; }

        protected GameStateBase(GraphicsDeviceManager device, ContentManager content)
        {
            Content = content;
            GraphicsDeviceManager = device;
            GraphicsDevice = device.GraphicsDevice;
        }

        public void Update(GameTime gameTime, GameStateManager stateManager) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
