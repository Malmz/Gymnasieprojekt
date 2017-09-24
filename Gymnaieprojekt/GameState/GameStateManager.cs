using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.GameState
{
    public class GameStateManager
    {
        private IGameState currentGameState;
        private IGameState previousGameState;

        private bool isPaused;

        public GameStateManager(IGameState startState)
        {
            currentGameState = startState;
        }

        public void ChangeState(IGameState changeToState)
        {
            previousGameState = currentGameState;
            currentGameState = changeToState;
        }

        public void RevertState()
        {
            if (previousGameState == null) return;
            var temp = currentGameState;
            currentGameState = previousGameState;
            previousGameState = temp;
        }

        public void Pause()
        {
            isPaused = true;
        }

        public void Resume()
        {
            isPaused = false;
        }

        public void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (isPaused) return;

            InputManager.Update(gameTime);

            currentGameState.Update(gameTime, stateManager);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isPaused) return;

            currentGameState.Draw(gameTime, spriteBatch);
        }
    }
}
