using System.Collections.Generic;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnaieprojekt.GameState.States
{
    public class FirstState : GameStateBase, IGameState
    {
        private KeyboardState keyboard;
        private AnimatedSprite test;


        public FirstState(ContentManager cMan) : base(cMan)
        {

            var testFrames = new List<Frame>();

            var list = new List<Texture2D>();
            for (int i = 1; i <= 8; i++)
            {
                list.Add(Content.Load<Texture2D>("asteroid" + i));
            }

            test = new AnimatedSprite(new Dictionary<string, Animation>(), new Rectangle(0,0,100,100), new Vector2(100, 100), new Vector2(100, 100));

            var animation = new Animation(list);
            animation.Looping = true;
            test.AddAnimation(animation, "default");



            test.ChangeAnimation("default");
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.G))
            {
                stateManager.ChangeState(new SecondState(Content));
            }
            test.Update(gameTime);
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test.Draw(spriteBatch);
        }
    }
}
