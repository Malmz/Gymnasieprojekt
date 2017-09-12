using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt.GameState
{
    public class GameStateManager
    {
        private IGameState _currentGameState;
        private IGameState _previousGameState;

        private bool _isPause;

        public GameStateManager(IGameState startState)
        {
            _currentGameState = startState;
        }

        public void ChangeState(IGameState changeToState)
        {
            _previousGameState = _currentGameState;
            _currentGameState = changeToState;
        }

        public void Pause()
        {
            _isPause = true;
        }

        public void Resume()
        {
            _isPause = false;
        }

        public void Update(GameTime gameTime, GameStateManager stateManager)
        {
            _currentGameState.Update(gameTime, stateManager);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _currentGameState.Draw(gameTime, spriteBatch);
        }
    }
}
