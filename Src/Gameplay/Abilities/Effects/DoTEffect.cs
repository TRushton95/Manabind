using Manabind.Src.Gameplay.Abilities.Ticks;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using System;

namespace Manabind.Src.Gameplay.Abilities.Effects
{
    public class DoTEffect : BaseEffect
    {
        #region Constructors

        public DoTEffect(int value, int duration, TargetType targetType, Unit caster)
            : base(targetType, caster)
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

        public Unit Target
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
                if (tick.GetType() == typeof(DamageTick))
                {
                    //TO-DO Replace this with a proper UI message
                    Console.WriteLine("Target already has a DamageTick");
                    return;
                }
            }

            targetTile.Occupant.Ticks.Add(
                new DamageTick(Value, Duration, target));
        }

        public override string GetDescription()
        {
            return $"Deals {this.Value} damage per turn for {this.Duration} turns.";
        }

        #endregion
    }
}
