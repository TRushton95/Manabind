using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Services
{
    public static class TargetValidatorService
    {
        public static bool Validate(Unit caster, BaseTile targetTile, TargetType targetType)
        {
            bool result = false;

            switch (targetType)
            {
                case TargetType.Any:
                    result = true;
                    break;

                case TargetType.EmptyTile:
                    result = ValidateEmptyTile(caster, targetTile);
                    break;

                case TargetType.Unit:
                    result = ValidateUnit(caster, targetTile);
                    break;

                case TargetType.Self:
                    result = ValidateSelf(caster, targetTile);
                    break;

                case TargetType.Enemy:
                    result = ValidateEnemy(caster, targetTile);
                    break;

                case TargetType.Ally:
                    result = ValidateAlly(caster, targetTile);
                    break;
            }

            return result;
        }

        private static bool ValidateEmptyTile(Unit caster, BaseTile targetTile)
        {
            if (targetTile.Occupant == null)
            {
                return true;
            }

            return false;
        }

        private static bool ValidateUnit(Unit caster, BaseTile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant.GetType() == typeof(Unit))
            {
                return true;
            }

            return false;
        }

        private static bool ValidateSelf(Unit caster, BaseTile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant == caster)
            {
                return true;
            }

            return false;
        }

        private static bool ValidateEnemy(Unit caster, BaseTile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant.Team != caster.Team)
            {
                return true;
            }

            return false;
        }

        private static bool ValidateAlly(Unit caster, BaseTile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant.Team == caster.Team)
            {
                return true;
            }

            return false;
        }
    }
}
