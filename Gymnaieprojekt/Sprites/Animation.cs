using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Sprites
{
    public class Animation
    {
        private List<Frame> frames;
        private int animationSpeed;
        private int frameIndex;
        private int counter;
        private bool looping;

        public Animation(List<Frame> frames)
        {
            this.frames = frames;
        }

        public Animation(List<Texture2D> frames)
        {
            var tempFrames = new List<Frame>();

            foreach (var frame in frames)
            {
                tempFrames.Add(new Frame(frame));
            }
            this.frames = tempFrames;
        }

        public void Update(GameTime gameTime)
        {
            if (counter++ >= animationSpeed)
                if (frameIndex++ >= frames.Count)
                    frameIndex = 0;
        }

        public Texture2D GetTexture()
        {
            return frames[frameIndex].Texture;
        }
    }
}
