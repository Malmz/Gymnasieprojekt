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

        public abstract void Update(GameTime gameTime, GameStateManager stateManager);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void ManageDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
