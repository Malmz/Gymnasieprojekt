using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gymnaieprojekt.GameState.States
{
    public class SecondState : GameStateBase, IGameState
    {
        private Sprite test2;

        public SecondState(GraphicsDeviceManager device, ContentManager content) : base(device, content) 
        {
            test2 = new Sprite(Content.Load<Texture2D>("Asteroid"), new Vector2(200, 200), new Vector2(48, 48));
        }

        public new void Update(GameTime gameTime, GameStateManager stateManager)
        {
            test2.Y += 2;

            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new FirstState(GraphicsDevice, Content));
            }
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test2.Draw(spriteBatch);
        }
    }
}
