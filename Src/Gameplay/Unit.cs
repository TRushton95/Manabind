using Manabind.Src.Gameplay.Abilities;
using Manabind.Src.Gameplay.Abilities.Ticks;
using Manabind.Src.Gameplay.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay
{
    public class Unit : BaseEntity
    {
        #region Fields

        public static int Diameter = 50;

        #endregion
        
        #region Constructors

        public Unit(int team, int maxHealth, int maxEnergy, int posX, int posY, int canvasX, int canvasY, Texture2D texture)
            : base(EntityNames.Unit, posX, posY, canvasX, canvasY, texture)
        {
            this.Team = team;
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.MaxEnergy = maxEnergy;
            this.MaxEnergy = maxEnergy;
            this.Texture = texture;

            this.Abilities = new List<Ability>();
        }

        #endregion

        #region Properties

        public int Team
        {
            get;
            set;
        }

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

        public List<Ability> Abilities
        {
            get;
            set;
        }
        
        public List<BaseTick> Ticks
        {
            get;
            set;
        }

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

        public Vector2 GetCoordinates()
        {
            return new Vector2(this.CanvasX, this.CanvasY);
        }

        public Vector2 GetSize()
        {
            return new Vector2(Unit.Diameter, Unit.Diameter);
        }


        public Rectangle GetBounds()
        {
            return new Rectangle(this.CanvasX, this.CanvasY, Unit.Diameter, Unit.Diameter);
        }

        #endregion
    }
}
