using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;

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
            EventManager.PushEvent(
                new UIEvent(new EventDetails("player-state", EventType.UnitSelected), null));
        }

        public void OnLeave()
        {
        }

        #endregion
    }
}
