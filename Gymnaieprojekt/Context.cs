using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Gymnaieprojekt
{
    public class Context
    {
        public ContentManager Content { get; }
        public GraphicsDevice GraphicsDevice { get; }
        public Camera2D Camera { get; }
        public ViewportAdapter Viewport { get; }

        public Context(ContentManager content, GraphicsDevice graphicsDevice, Camera2D camera, ViewportAdapter viewport)
        {
            Content = content;
            Camera = camera;
            Viewport = viewport;
            GraphicsDevice = graphicsDevice;
        }
    }
}
