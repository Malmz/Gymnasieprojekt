using Gymnaieprojekt.Players;
using Gymnaieprojekt.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState.States
{
    public class Level1 : Level
    {
        private Player player;
        public Level1(Context context) : base(context, "Levels/Level1")
        {
            var playerAnimation = new AnimatedSprite(
                new Vector2(100, 100),
                new Vector2(100, 100));
            playerAnimation.AddAnimation(new Animation(Content.Load<Texture2D>("ship1TextureSheet"), GraphicsDevice, 3, 1, 10, true), "default");
            playerAnimation.ChangeAnimation("default");
            player = new Player(playerAnimation);

            AddCollisionObject(player);
        }

        protected override void InnerUpdate(GameTime gameTime, GameStateManager stateManager)
        {
            player.Update(gameTime);
            player.CenterCameraOnPlayer(Camera, GraphicsDevice);
        }

        protected override void InnerDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
