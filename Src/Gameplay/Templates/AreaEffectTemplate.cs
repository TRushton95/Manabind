using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Templates
{
    public class AreaEffectTemplate : BaseTemplate
    {
        #region Constructors

        public AreaEffectTemplate(int range, int radius)
            : base(range)
        {
            this.Radius = radius;
        }


        #endregion

        #region Properties

        public override TemplateType TemplateType => TemplateType.AreaAffect;

        public int Radius
        {
            get;
            set;
        }

        #endregion
    }
}
