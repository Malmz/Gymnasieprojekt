using System.Collections.Generic;
using Gymnaieprojekt.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt.GameState.States
{
    public class Level1 : GameStateBase, ICollisionWorld
    {
        private TiledMapRenderer mapRenderer;
        private TiledMap map;

        public Level1(Context context) : base(context)
        {
            mapRenderer = new TiledMapRenderer(Context.GraphicsDevice);
            map = Context.Content.Load<TiledMap>("Levels\\Level1");
            foreach (var item in map.TileLayers)
            {
                item.Tiles
            } 
        }

        public List<Rectangle> BoundingBoxes()
        {
            List<Rectangle> boxes = new List<Rectangle>();
            foreach (var item in map.ObjectLayers)
            {
                foreach (var inner in item.Objects)
                {
                    var size = new Vector2(inner.Size.Width, inner.Size.Height);
                    boxes.Add(new Rectangle(inner.Position.ToPoint(), size.ToPoint()));
                }
            }
            return boxes;
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
            if (InputManager.IsKeyDown(Keys.R))
                Context.Camera.ZoomIn(2 * gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            if (InputManager.IsKeyDown(Keys.F))
                Context.Camera.ZoomOut(2 * gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            mapRenderer.Update(map, gameTime);
        }
    }
}
