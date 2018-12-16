using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Templates
{
    public abstract class BaseTemplate
    {
        #region Constructors

        public BaseTemplate(int range)
        {
            this.Range = range;
        }

        #endregion

        #region Properties

        public int Range
        {
            get;
            set;
        }

        public abstract TemplateType TemplateType
        {
            get;
        }

        #endregion
    }
}
