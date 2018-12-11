using Manabind.Src.Gameplay.Abilities;
using Manabind.Src.Gameplay.Entities;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay
{
    public class Unit : BaseEntity
    {
        #region Fields

        public static int Diameter = 25;

        #endregion
        
        #region Constructors

        public Unit()
            : base(EntityNames.Unit, 0, 0, 0, 0, null)
        {
        }

        #endregion

        #region Properties
        
        public int MaxHealth
        {
            get;
            set;
        }

        public int CurrentHealth
        {
            get;
            set;
        }

        public int MaxEnergy
        {
            get;
            set;
        }

        public int CurrentEnergy
        {
            get;
            set;
        }

        public int Team
        {
            get;
            set;
        }

        public List<Ability> Abilities
        {
            get;
            set;
        }

        /*
        public List<BaseTick> Ticks
        {
            get;
            set;
        }
        */

        #endregion

        #region Methods

        /*
        public void CastAbility(Tile targetTile, int abilitySlot)
        {
            if (Abilities[abilitySlot] != null)
            {
                Abilities[abilitySlot].Execute(targetTile);
            }
        }
        */

        #endregion
    }
}
