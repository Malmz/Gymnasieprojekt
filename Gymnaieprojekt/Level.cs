using System.Collections.Generic;
using Gymnaieprojekt.Collision;
using Gymnaieprojekt.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt
{
    public abstract class Level : GameStateBase, IGameState, ICollisionStatic
    {
        private TiledMapRenderer mapRenderer;
        private TiledMap map;
        private CollisionSystem collisionController;
        private List<int> collideTiles;
        private Dictionary<Rectangle, int> boundingBoxCache;

        public Level(Context context, string levelName, List<int> collideTiles = null) : base(context)
        {
            collisionController = new CollisionSystem();
            collisionController.AddWorld(this);
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            this.collideTiles = collideTiles;
            map = Content.Load<TiledMap>(levelName);
        }

        public Dictionary<Rectangle, int> Tiles
        {
            get
            {
                if (boundingBoxCache == null)
                {
                    boundingBoxCache = new Dictionary<Rectangle, int>();
                    foreach (var tileLayer in map.TileLayers)
                    {
                        if (collideTiles != null)
                        {
                            for (int i = 0; i < tileLayer.Tiles.Count; i++)
                            {
                                if (collideTiles.Contains(tileLayer.Tiles[i].GlobalIdentifier))
                                {
                                    var rect = new Rectangle(i % tileLayer.Width * tileLayer.TileWidth, i / tileLayer.Width * tileLayer.TileHeight, tileLayer.TileWidth, tileLayer.TileHeight);
                                    boundingBoxCache.Add(rect, tileLayer.Tiles[i].GlobalIdentifier);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < tileLayer.Tiles.Count; i++)
                            {
                                if (tileLayer.Tiles[i].GlobalIdentifier != 0)
                                {
                                    var rect = new Rectangle(i % tileLayer.Width * tileLayer.TileWidth, i / tileLayer.Width * tileLayer.TileHeight, tileLayer.TileWidth, tileLayer.TileHeight);
                                    boundingBoxCache.Add(rect, tileLayer.Tiles[i].GlobalIdentifier);
                                }
                            }
                        }

                    }
                }
                return boundingBoxCache;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Context.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            var viewMatrix = Context.Camera.GetViewMatrix();
            var projectionMatrix = Matrix.CreateOrthographicOffCenter(0, Context.GraphicsDevice.Viewport.Width, Context.GraphicsDevice.Viewport.Height, 0, 0f, -1f);
            mapRenderer.Draw(map, ref viewMatrix, ref projectionMatrix);
            InnerDraw(gameTime, spriteBatch);
        }

        protected abstract void InnerDraw(GameTime gameTime, SpriteBatch spriteBatch);

        public new void ManageDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Context.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(transformMatrix: Context.Camera.GetViewMatrix());

            Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            collisionController.Collide();
            mapRenderer.Update(map, gameTime);
            InnerUpdate(gameTime, stateManager);
        }

        protected abstract void InnerUpdate(GameTime gameTime, GameStateManager stateManager);
    }
}
