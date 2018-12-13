using Manabind.Src.Gameplay.Entities.Tiles;

namespace Manabind.Src.Gameplay.PlayerStates
{
    public interface IPlayerState
    {
        IPlayerState TileClick(BaseTile tile);

        void OnEnter();

        void OnLeave();
    }
}
