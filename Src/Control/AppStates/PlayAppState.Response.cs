using Manabind.Src.Gameplay;
using Manabind.Src.Gameplay.Abilities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.Gameplay.PlayerStates;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using System.Collections.Generic;

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

        public void UnitSelected(Unit selectedUnit)
        {
            List<IIconable> iconables = new List<IIconable>();

            if (selectedUnit != null && selectedUnit.Abilities?.Count > 0)
            {
                foreach (Ability ability in selectedUnit.Abilities)
                {
                    iconables.Add(ability);
                }
            }

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ChangeTools), iconables));
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
