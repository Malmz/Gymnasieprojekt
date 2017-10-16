using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.Sprites
{
    class Sprite : BaseSprite
    {
        private Texture2D texture;
        private Vector2 scale;

        public Sprite(Texture2D texture, Vector2 position, Vector2 size, Color? color = null, float rotation = 0, Rectangle? srcRect = null, Vector2? origin = null) : base(position, color, rotation, srcRect, origin)
        {
            this.texture = texture;
            scale = size / texture.Bounds.Size.ToVector2();
            this.srcRect = srcRect ?? texture.Bounds;
        }

        public override void Update(GameTime gameTime) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture,
                position: position,
                scale: scale,
                sourceRectangle: srcRect,
                color: color,
                rotation: rotation,
                origin: origin,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }

        public override Vector2 Size
        {
            get { return scale * texture.Bounds.Size.ToVector2(); }
            set { scale = value / texture.Bounds.Size.ToVector2(); }
        }
        public override float Width
        {
            get { return scale.X * texture.Width; }
            set { scale.X = value / texture.Width; }
        }
        public override float Height
        {
            get { return scale.Y * texture.Height; }
            set { scale.Y = value / texture.Height; }
        }

        public override void Center()
        {
            origin = texture.Bounds.Size.ToVector2() / 2;
        }
    }
}
