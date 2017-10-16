using System.Collections.Generic;
using Gymnaieprojekt.Collision;
using Gymnaieprojekt.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;
using Gymnaieprojekt.Players;
using Gymnaieprojekt.Sprites;

namespace Gymnaieprojekt
{
    class Level : GameStateBase, ICollisionStatic
    {
        protected TiledMapRenderer mapRenderer;
        protected TiledMap map;
        protected CollisionSystem collisionController;
        protected List<int> collideTiles;
        private Dictionary<Rectangle, int> boundingBoxCache;
        protected Player player;

        public Level(Context context, string levelName, List<int> collideTiles = null) : base(context)
        {
            collisionController = new CollisionSystem();
            collisionController.AddWorld(this);
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            this.collideTiles = collideTiles;
            map = Content.Load<TiledMap>(levelName);
            var playerSprite = new AnimatedSprite(new Vector2(100, 50), new Vector2(50, 50));
            var animation = new Animation(Content.Load<Texture2D>("ship0TextureSheet"), GraphicsDevice, 3, 1, 50, true);
            playerSprite.AddAnimation(animation, "default");
            playerSprite.ChangeAnimation("default");
            playerSprite.Center();
            player = new Player(playerSprite);
            collisionController.AddObject(player);
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
                                    var rect = new Rectangle(i % tileLayer.Width, i / tileLayer.Width, tileLayer.TileWidth, tileLayer.TileHeight);
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
                                    var rect = new Rectangle(i % tileLayer.Width, i / tileLayer.Width, tileLayer.TileWidth, tileLayer.TileHeight);
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
            player.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            collisionController.Collide();
            player.Update(gameTime);
            mapRenderer.Update(map, gameTime);
        }
    }
}
