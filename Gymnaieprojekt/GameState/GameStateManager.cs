using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt.GameState
{
    public class GameStateManager
    {
        private IGameState currentGameState;
        private IGameState previousGameState;

        private bool _isPaused;

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
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public void Update(GameTime gameTime, GameStateManager stateManager)
        {
            if (_isPaused) return;

            currentGameState.Update(gameTime, stateManager);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_isPaused) return;

            currentGameState.Draw(gameTime, spriteBatch);
        }
    }
}
