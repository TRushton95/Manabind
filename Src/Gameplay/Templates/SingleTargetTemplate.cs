using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Templates
{
    public class SingleTargetTemplate : BaseTemplate
    {
        #region Constructors

        public SingleTargetTemplate(int range)
            : base(range)
        {
        }

        public override TemplateType TemplateType => TemplateType.SingleTarget;

        #endregion
    }
}
