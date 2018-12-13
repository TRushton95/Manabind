using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.PlayerStates;

namespace Manabind.Src.Control.AppStates
{
    partial class PlayAppState
    {
        #region Methods

        public void TileClick(BaseTile tile)
        {
            IPlayerState newState = playerState.TileClick(tile);
            ProcessState(newState);
        }

        private void ProcessState(IPlayerState newState)
        {
            if (newState != null)
            {
                playerState.OnLeave();
                playerState = newState;
                playerState.OnEnter();
            }
        }

        #endregion
    }
}
