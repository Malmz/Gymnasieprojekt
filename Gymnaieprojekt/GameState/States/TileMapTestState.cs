
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt.GameState.States
{
    class TileMapTestState : GameStateBase, IGameState
    {
        private TiledMapRenderer mapRenderer;
        private TiledMap map;

        public TileMapTestState(Context context) : base (context)
        {
            mapRenderer = new TiledMapRenderer(Context.GraphicsDevice);
            map = Context.Content.Load<TiledMap>("testmap");
            Context.Camera.LookAt(new Vector2(map.WidthInPixels, map.HeightInPixels) / 2);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Context.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            //Context.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            var viewMatrix = Context.Camera.GetViewMatrix();
            var projectionMatrix = Matrix.CreateOrthographicOffCenter(0, Context.GraphicsDevice.Viewport.Width, Context.GraphicsDevice.Viewport.Height, 0, 0f, -1f);
            mapRenderer.Draw(map, ref viewMatrix, ref projectionMatrix);
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (InputManager.IsKeyDown(Keys.R))
                Context.Camera.ZoomIn(2 * gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            if (InputManager.IsKeyDown(Keys.F))
                Context.Camera.ZoomOut(2 * gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            mapRenderer.Update(map, gameTime);
        }
    }
}
