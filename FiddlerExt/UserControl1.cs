using System;
using System.IO;
using System.Windows.Forms;
using Fiddler;

namespace onSoft
{
    public partial class UserControl1 : UserControl
    {
        private Session[] _sessionsData;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            _sessionsData = ((Session[]) e.Data.GetData("Fiddler.Session[]"));
            var rootDir = Path.Combine(Application.StartupPath,"RestSharp");
            if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir);
            treeFiles.Nodes[0].Text = rootDir;
            foreach (var oneSession in _sessionsData)
            {
                dfsUrl.Text = oneSession.fullUrl;
                dfsInputClass.Text = "InputClass";
                dfsOutputClass.Text = "OutputClass";
                var code = GenerateCode(oneSession);
                File.WriteAllText($"{oneSession.id}.cs", code);
                treeFiles.Nodes[0].Nodes.Add($"{oneSession.id}.cs");

            }
            treeFiles.Nodes[0].ExpandAll();

        }

        private string GenerateCode(Session inputsession)
        {
            var cg = new CodeGen();


            if (inputsession != null)
            {
                dfsInputClass.Enabled = inputsession.RequestMethod != "GET";
                cg.InputClass = dfsInputClass.Text;
                cg.OutputClass = dfsOutputClass.Text;
                cg.Url = dfsUrl.Text;
                return 
                    cg.MakeRestSharpCode(
                        inputsession); 
            }

            return string.Empty;
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
            //GenerateCode();
        }

        private void dfsInputClass_Leave(object sender, EventArgs e)
        {
            //GenerateCode();
        }

        private void dfsUrl_Leave(object sender, EventArgs e)
        {
            //GenerateCode();
        }

        private void treeFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (File.Exists($"{e.Node.Text}"))
            txtcode.Text = File.ReadAllText($"{e.Node.Text}");
        }
    }
}