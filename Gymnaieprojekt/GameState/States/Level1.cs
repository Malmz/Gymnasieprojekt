using System.Collections.Generic;
using Gymnaieprojekt.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;

namespace Gymnaieprojekt.GameState.States
{
    public class Level1 : Level
    {
        public Level1(Context context) : base(context, "Levels/Level1")
        {

        }

        protected override void InnerDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        protected override void InnerUpdate(GameTime gameTime, GameStateManager stateManager)
        {
            throw new System.NotImplementedException();
        }
    }
}
