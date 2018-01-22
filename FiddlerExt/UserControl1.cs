using System;
using System.Windows.Forms;
using Fiddler;

namespace onSoft
{
    public partial class UserControl1 : UserControl
    {
        private Session _sessionData;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            _sessionData = ((Session[]) e.Data.GetData("Fiddler.Session[]"))[0];
            dfsUrl.Text = _sessionData.fullUrl;
            dfsInputClass.Text = "InputClass";
            dfsOutputClass.Text = "OutputClass";
            GenerateCode();
        }

        private void GenerateCode()
        {
            var cg = new CodeGen();


            if (_sessionData != null)
            {
                dfsInputClass.Enabled = _sessionData.RequestMethod != "GET";
                cg.InputClass = dfsInputClass.Text;
                cg.OutputClass = dfsOutputClass.Text;
                cg.Url = dfsUrl.Text;
                txtcode.Text =
                    cg.MakeRestSharpCode(
                        _sessionData); 
            }
        }

        private void UserControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void UserControl1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtcode.Text);
        }

        private void dfsOutputClass_Leave(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void dfsInputClass_Leave(object sender, EventArgs e)
        {
            GenerateCode();
        }

        private void dfsUrl_Leave(object sender, EventArgs e)
        {
            GenerateCode();
        }
    }
}