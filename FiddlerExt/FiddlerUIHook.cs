using System.Windows.Forms;
using Fiddler;

[assembly: RequiredVersion("2.3.5.0")]

namespace onSoft
{
    public class FiddlerUIHook : IFiddlerExtension
    {
        public void OnLoad()
        {
            var oPage = new TabPage("Rest#") {ImageIndex = (int) SessionIcons.Script};
            //This sets the Icon image used in the tab
            var oView = new UserControl1 {Dock = DockStyle.Fill}; //UserControl1 is a Windows Forms UserControl class
            oPage.Controls.Add(oView);
            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);
        }

        public void OnBeforeUnload()
        {
           
        }
    }
}