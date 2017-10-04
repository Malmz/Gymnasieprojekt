using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt.GameState.States
{
    class Level1 : GameStateBase
    {
        private TiledMapRenderer mapRenderer;
        private TiledMap map;

        protected Level1(Context context) : base(context)
        {
            mapRenderer = new TiledMapRenderer(Context.GraphicsDevice);
            map = Context.Content.Load<TiledMap>("testmap");
            foreach (var val in map.ImageLayers)
            {
                val.
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            throw new System.NotImplementedException();
        }
    }
}
