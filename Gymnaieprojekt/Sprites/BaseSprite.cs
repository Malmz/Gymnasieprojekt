using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.Sprites
{
    public abstract class BaseSprite
    {
        protected Vector2 position;
        protected Rectangle? srcRect;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;

        public BaseSprite(Vector2 position, Color? color = null, float rotation = 0, Rectangle? srcRect = null, Vector2? origin = null )
        {
            this.position = position;
            this.color = color ?? Color.White;
            this.origin = origin ?? Vector2.Zero;
            this.rotation = rotation;
            this.srcRect = srcRect;
        }


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public abstract Vector2 Size { get; set; }
        public abstract float Width { get; set; }
        public abstract float Height { get; set; }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public abstract void Center();

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
