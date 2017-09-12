using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnaieprojekt.GameState.States
{
    public class SecondState : GameStateBase, IGameState
    {
        public SecondState(ContentManager cMan) :base(cMan) 
        {
            test2 = new Sprite(Content.Load<Texture2D>("Asteroid"), new Vector2(200, 200), new Vector2(48, 48));
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            test2.Move(0, 2);

            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.G))
            {
                stateManager.ChangeState(new FirstState(Content));
            }
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test2.Draw(spriteBatch);
        }

        private KeyboardState keyboard;
        private Sprite test2;
    }
}
