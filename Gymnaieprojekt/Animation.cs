using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt
{
    class Animation
    {
        private List<Texture2D> frames;
        private int animationSpeed;
        private int frameIndex = 0;
        private int counter;

        public Animation(List<Texture2D> frames)
        {
            this.frames = frames;
        }

        public void Update(GameTime gameTime)
        {
            if (counter++ >= animationSpeed)
                if (frameIndex++ >= frames.Count)
                    frameIndex = 0;
        }

        public Texture2D GetTexture()
        {
            return frames[frameIndex];
        }
    }
}
