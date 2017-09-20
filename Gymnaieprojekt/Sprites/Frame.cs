using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.Sprites
{
    public class Frame
    {
        public Texture2D Texture { get; set; }
        public Vector2 Origin { get; set; }

        public Frame(Texture2D texture)
        {
            Texture = texture;
            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
        }
    }
}
