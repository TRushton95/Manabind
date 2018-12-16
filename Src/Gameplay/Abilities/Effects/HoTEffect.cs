using Manabind.Src.Gameplay.Abilities.Ticks;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using System;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class HoTEffect : BaseEffect
    {
        #region Constructors

        public HoTEffect(int value, int duration, TargetType targetType, Unit caster)
            :base(targetType, caster)
        {
            this.Value = value;
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Execute(Unit caster, BaseTile targetTile)
        {
            if (!ValidateTarget(targetTile))
            {
                return;
            }

            Unit target = targetTile.Occupant;

            foreach (BaseTick tick in target.Ticks)
            {
                if (tick.GetType() == typeof(HealTick))
                {
                    //TO-DO Replace this with real UI message
                    Console.WriteLine("Target already has a HealTick");
                    return;
                }
            }

            targetTile.Occupant.Ticks.Add(
                new HealTick(Value, Duration, target));
        }

        public override string GetDescription()
        {
            return $"Heals {this.Value} health per turn for {this.Duration} turns.";
        }

        #endregion
    }
}
