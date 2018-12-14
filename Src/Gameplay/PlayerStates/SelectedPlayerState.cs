using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;

namespace Manabind.Src.Gameplay.PlayerStates
{
    public class SelectedPlayerState : IPlayerState
    {
        #region Fields

        private readonly int team;
        private readonly Unit selectedUnit;

        #endregion

        #region Constructors

        public SelectedPlayerState(int team, Unit selectedUnit)
        {
            this.team = team;
            this.selectedUnit = selectedUnit;
        }

        #endregion

        #region Methods

        public IPlayerState TileClick(BaseTile tile)
        {
            if (tile.Occupant == null)
            {
                return new UnselectedPlayerState(team);
            }

            if (tile.Occupant.Team == team)
            {
                return new SelectedPlayerState(team, tile.Occupant);
            }

            return null;
        }

        public void OnEnter()
        {
            EventManager.PushEvent(
                new UIEvent(new EventDetails("player-state", EventType.UnitSelected), selectedUnit));
        }

        public void OnLeave()
        {
        }

        #endregion
    }
}
