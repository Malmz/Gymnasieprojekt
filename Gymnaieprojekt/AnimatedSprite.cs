using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt
{
    public class AnimatedSprite
    {
        private Dictionary<string, Animation> animations { get; set; }
        private string currentAnimation = "";

        public void Update(GameTime gameTime)
        {
            foreach (var animation in animations)
            {
                animation.Value.Update(gameTime);
            }
        }

        private void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
