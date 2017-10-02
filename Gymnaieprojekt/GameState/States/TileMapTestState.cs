
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt.GameState.States
{
    class TileMapTestState : GameStateBase, IGameState
    {
        private TiledMapRenderer mapRenderer;
        private TiledMap map;

        public TileMapTestState(GraphicsDeviceManager device, ContentManager content) : base (device, content)
        {
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            map = Content.Load<TiledMap>("testmap");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            mapRenderer.Draw(map);
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            mapRenderer.Update(map, gameTime);
        }
    }
}
