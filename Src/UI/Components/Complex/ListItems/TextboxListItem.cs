namespace Manabind.Src.UI.Components.Complex.ListItems
{
    public class TextboxListItem : Textbox
    {
        #region Constructors

        public TextboxListItem()
        {
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

            //TO-DO Dodgy way to extend the switch statement?
            switch (action)
            {
                case "scroll-selection":
                    this.Text = (string)content;
                    this.Refresh();
                    break;
            }
        }

        #endregion
    }
}
