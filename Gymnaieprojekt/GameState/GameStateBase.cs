using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Gymnaieprojekt.GameState
{
    public abstract class GameStateBase: IGameState
    {
        protected Context Context { get; }
        protected ContentManager Content => Context.Content;
        protected GraphicsDevice GraphicsDevice => Context.GraphicsDevice;
        protected Camera2D Camera => Context.Camera;

        protected GameStateBase(Context context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime, GameStateManager stateManager);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void ManageDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Context.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
