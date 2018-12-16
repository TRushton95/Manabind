using Manabind.Src.Gameplay.Abilities.Effects;
using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.Gameplay.Templates;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Abilities
{
    public class Ability : IIconable
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public List<BaseEffect> Effects
        {
            get;
            set;
        }

        public TargetType TargetType
        {
            get;
            set;
        }

        public ITemplate Template
        {
            get;
            set;
        }

        //TO-DO WRONG!!!!!!!
        public Unit Caster
        {
            get;
            set;
        }

        public Icon Icon
        {
            get;
            set;
        }

        #endregion
    }
}
