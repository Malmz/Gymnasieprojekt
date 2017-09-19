using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt
{
    public class Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 scale;
        private Rectangle srcRect;
        private Color color;

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

        public void Move(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture,
                position: position,
                scale: scale,
                sourceRectangle: srcRect,
                color: Color.White,
                rotation: 0,
                origin: Vector2.Zero,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }
    }
}
