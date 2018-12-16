using Manabind.Src.Gameplay.Abilities.Effects;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.Gameplay.Services;
using Manabind.Src.Gameplay.Templates;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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

        List<BaseEffect> Effects
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public TargetType TargetType
        {
            get;
            set;
        }

        public BaseTemplate Template
        {
            get;
            set;
        }

        public Icon Icon
        {
            get;
            set;
        }

        public Unit Caster
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public bool ValidateTarget(BaseTile targetTile)
        {
            return TargetValidatorService.Validate(this.Caster, targetTile, this.TargetType);
        }

        public bool Execute(BaseTile targetTile)
        {
            if (ValidateTarget(targetTile))
            {
                //TO-DO Give this a proper UI message
                Console.WriteLine("Cannot execute ability on that target");

                return false;
            }

            List<BaseTile> affectedTiles = Template.GetAffectedTiles(targetTile);
            foreach (BaseTile tile in affectedTiles)
            {
                foreach (BaseEffect effect in Effects)
                {
                    effect.Execute(this.Caster, targetTile);
                }
            }

            //TO-DO Give this a proper UI message
            Console.WriteLine("Ability executed");

            return true;
        }

        public string GetProfile()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Cost: {this.Cost}");

            foreach (BaseEffect effect in Effects)
            {
                sb.AppendLine(effect.GetDescription());
            }

            return sb.ToString();
        }

        #endregion
    }
}
