using Gymnaieprojekt.Collision;
using Gymnaieprojekt.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt
{
    class Level : GameStateBase
    {
        protected TiledMapRenderer mapRenderer;
        protected TiledMap map;
        protected CollisionWorld collisionController;

        protected Level(Context context) : base(context)
        {

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
