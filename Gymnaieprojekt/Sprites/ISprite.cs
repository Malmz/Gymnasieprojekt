using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.Sprites
{
    public interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
