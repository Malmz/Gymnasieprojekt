using System.Collections.Generic;
using Gymnaieprojekt.Collision;
using Gymnaieprojekt.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt
{
    class Level : GameStateBase, ICollisionStatic
    {
        protected TiledMapRenderer mapRenderer;
        protected TiledMap map;
        protected CollisionSystem collisionController;
        protected List<int> collideTiles;
        private List<Rectangle> boundingBoxCache;

        public Level(Context context, string levelName, List<int> collideTiles = null) : base(context)
        {
            collisionController = new CollisionSystem();
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            this.collideTiles = collideTiles;
            map = Content.Load<TiledMap>(levelName);
        }

        public List<Rectangle> BoundingBoxes()
        {
            if (boundingBoxCache == null)
            {
                boundingBoxCache = new List<Rectangle>();
                foreach (var tileLayer in map.TileLayers)
                {
                    if (collideTiles != null)
                    {
                        for (int i = 0; i < tileLayer.Tiles.Count; i++)
                        {
                            if (collideTiles.Contains(tileLayer.Tiles[i].GlobalIdentifier))
                            {
                                var rect = new Rectangle(i % tileLayer.Width, i / tileLayer.Width, tileLayer.TileWidth, tileLayer.TileHeight);
                                boundingBoxCache.Add(rect);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < tileLayer.Tiles.Count; i++)
                        {
                            if (tileLayer.Tiles[i].GlobalIdentifier != 0)
                            {
                                var rect = new Rectangle(i % tileLayer.Width, i / tileLayer.Width, tileLayer.TileWidth, tileLayer.TileHeight);
                                boundingBoxCache.Add(rect);
                            }
                        }
                    }

                }
            }
            return boundingBoxCache;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Context.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            var viewMatrix = Context.Camera.GetViewMatrix();
            var projectionMatrix = Matrix.CreateOrthographicOffCenter(0, Context.GraphicsDevice.Viewport.Width, Context.GraphicsDevice.Viewport.Height, 0, 0f, -1f);
            mapRenderer.Draw(map, ref viewMatrix, ref projectionMatrix);
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            collisionController.Collide();
            mapRenderer.Update(map, gameTime);
        }
    }
}
