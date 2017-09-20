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
        public int AnimationSpeed { get; set; } = 5;

        private List<Frame> frames;
        private int frameIndex;
        private int counter;
        public bool Looping; 

        public Animation(List<Frame> frames, bool looping)
        {
            this.frames = frames;
            Looping = looping;
        }

        public Animation(Texture2D spriteSheet, int horizontalCount, int verticalCount, bool looping, int[][] skipThese = null)
        {
            //todo
            //Texture2D originalTexture = Content.Load<Texture2D>("myTexture");
            //Rectangle sourceRectangle = new Rectangle(10, 10, originalTexture.Width - 20, originalTexture.Height - 20);

            //Texture2D cropTexture = new Texture2D(GraphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
            //Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
            //originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
            //cropTexture.SetData(data);
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
            if (++counter >= AnimationSpeed)
            {
                if (++frameIndex >= frames.Count)
                {
                    frameIndex = 0;
                    if(!Looping)
                        Done = true;
                }
                counter = 0;
            }
        }

        public Frame GetFrame()
        {
            return frames[frameIndex];
        }
    }
}
