using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.Sprites
{
    public class Animation
    {
        public Animation ToPlayWhenDone { get; set; } = null;
        public bool Done { get; private set; }
        public int AnimationSpeed { get; set; } = 5;

        private List<Frame> frames;
        private int frameIndex;
        private int counter;
        public bool looping; 

        public Animation(List<Frame> frames, bool looping)
        {
            this.frames = frames;
            this.looping = looping;
        }

        public Animation(Texture2D spriteSheet, GraphicsDevice graphics, int horizontalCount, int verticalCount, int speed, bool looping, bool[][] skipThese = null)
        {
            AnimationSpeed = speed;
            List<Texture2D> textures = new List<Texture2D>();

            var width = spriteSheet.Width / horizontalCount;
            var height = spriteSheet.Height / verticalCount;

            this.looping = looping;
                
            for (int i = 0; i < horizontalCount; i++)
            {
                for (int j = 0; j < verticalCount; j++)
                {
                    if (skipThese?[i][j] == true) continue;

                    Rectangle sourceRectangle = new Rectangle(i * width, j * height, width, height);
                    var cropTexture = new Texture2D(graphics, sourceRectangle.Width,
                        sourceRectangle.Height);

                    Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];

                    spriteSheet.GetData(0, sourceRectangle, data, 0, data.Length);
                    cropTexture.SetData(data);

                    textures.Add(cropTexture);
                }
            }

            var tempFrames = new List<Frame>();

            foreach (var texture in textures)
            {
                tempFrames.Add(new Frame(texture));
            }
            frames = tempFrames;
        }

        public Animation(List<Texture2D> frames, bool looping)
        {
            this.looping = looping;

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
                    if(!looping)
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
