using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public class GameStateManager
    {
        private IGameState _currentGameState;
        private IGameState _previousGameState;

        private bool _isPaused;

        public GameStateManager(IGameState startState)
        {
            _currentGameState = startState;
        }

        public void ChangeState(IGameState changeToState)
        {
            _previousGameState = _currentGameState;
            _currentGameState = changeToState;
        }

        public void RevertState()
        {
            var temp = _currentGameState;
            _currentGameState = _previousGameState;
            _previousGameState = temp;
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

            _currentGameState.Update(gameTime, stateManager);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_isPaused) return;

            _currentGameState.Draw(gameTime, spriteBatch);
        }
    }
}
