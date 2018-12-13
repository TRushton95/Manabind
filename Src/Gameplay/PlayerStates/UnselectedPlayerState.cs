using Manabind.Src.Gameplay.Entities.Tiles;

namespace Manabind.Src.Gameplay.PlayerStates
{
    public class UnselectedPlayerState : IPlayerState
    {
        #region Fields

        private readonly int team;

        #endregion

        #region Constructors

        public UnselectedPlayerState(int team)
        {
            this.team = team;
        }

        #endregion

        #region Methods

        public IPlayerState TileClick(BaseTile tile)
        {
            if (tile.Occupant?.Team == team)
            {
                return new SelectedPlayerState(team, tile.Occupant);
            }

            return null;
        }

        public void OnEnter()
        {
        }

        public void OnLeave()
        {
        }

        #endregion
    }
}
