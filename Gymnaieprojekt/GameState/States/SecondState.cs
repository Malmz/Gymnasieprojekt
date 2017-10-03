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

        public SecondState(Context context) : base(context) 
        {
            test2 = new Sprite(Context.Content.Load<Texture2D>("Asteroid"), new Vector2(200, 200), new Vector2(48, 48));
        }

        public override void Update(GameTime gameTime, GameStateManager stateManager)
        {
            test2.Y += 2;

            if (InputManager.IsKeyPressed(Keys.G))
            {
                stateManager.ChangeState(new FirstState(Context));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            test2.Draw(spriteBatch);
        }
    }
}
