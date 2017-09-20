using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Sprites
{
    public class Animation
    {
        public string ToPlayWhenDone { get; set; }
        public bool Done { get; private set; }

        private List<Frame> frames;
        private int animationSpeed = 5;
        private int frameIndex;
        private int counter;
        public bool Looping; 

        public Animation(List<Frame> frames, bool looping)
        {
            this.frames = frames;
            Looping = looping;
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
            if (++counter >= animationSpeed)
            {
                if (++frameIndex >= frames.Count)
                {
                    frameIndex = 0;
                    if(!Looping)
                        Done = true;
                }
            }
        }

        public Texture2D GetTexture()
        {
            return frames[frameIndex].Texture;
        }
    }
}
