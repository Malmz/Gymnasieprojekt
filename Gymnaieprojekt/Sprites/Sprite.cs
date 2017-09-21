using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt
{
    public class Sprite
    {
        private Texture2D texture;
        protected Vector2 position;
        protected Vector2 scale;
        protected Rectangle srcRect;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;

        public Sprite(Texture2D texture, Vector2 position, Vector2 size, Color? color = null, Rectangle? srcRect = null)
        {
            this.texture = texture;
            this.position = position;
            scale = size/texture.Bounds.Size.ToVector2();
            if (srcRect != null)
            {
                this.srcRect = (Rectangle)srcRect;
            }
            else
            {
                this.srcRect = texture.Bounds;
            }
            if (color != null)
            {
                this.color = (Color)color;
            }
            else
            {
                this.color = Color.White;
            }
        }

        protected Sprite(Vector2 position, Rectangle srcRect, Color? color = null, float rotation = 0, Vector2? origin = null)
        {
            scale = new Vector2(1 , 1);
            this.position = position;
            this.srcRect = srcRect;
            if (color != null)
            {
                this.color = (Color)color;
            }
            else
            {
                this.color = Color.White;
            }
            this.rotation = rotation;
            this.origin = origin ?? Vector2.Zero;
        }

        public void Move(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void SetPosition(float x, float y) { SetPosition(new Vector2(x, y)); }
        public void SetPosition(Vector2 pos) { position = pos; }

        public void Rotate(float rot)
        {
            rotation += rot;
        }

        public void Center()
        {
            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture,
                position: position,
                scale: scale,
                sourceRectangle: srcRect,
                color: Color.White,
                rotation: rotation,
                origin: origin,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }
    }
}
