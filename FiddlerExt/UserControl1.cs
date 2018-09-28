using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
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
            if (File.Exists(@"Scripts\BaseTemplate.cs"))
                lblBaseTemplate.Text = @"Scripts\BaseTemplate.cs" + " Exists";
            else
                lblBaseTemplate.Text = @"Scripts\BaseTemplate.cs" + " Missing";

            if (File.Exists(@"Scripts\GetTemplate.cs"))
                lblGetTemplate.Text = @"Scripts\GetTemplate.cs" + " Exists";
            else
                lblGetTemplate.Text = @"Scripts\GetTemplate.cs" + " Missing";

            if (File.Exists(@"Scripts\PostTemplate.cs"))
                lblPostTemplate.Text = @"Scripts\PostTemplate.cs" + " Exists";
            else
                lblPostTemplate.Text = @"Scripts\PostTemplate.cs" + " Missing";

            
        }



        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            var cg = new CodeGen();
            _sessionsData = ((Session[]) e.Data.GetData("Fiddler.Session[]"));
            var rootDir = Path.Combine(Application.StartupPath,"RestSharp");
            if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir);
            treeFiles.Nodes[0].Text = rootDir;
            AddBaseClass();
            foreach (var oneSession in _sessionsData)
            {
                var code = GenerateCode(oneSession);
                File.WriteAllText($"{oneSession.RequestMethod}{oneSession.id}.cs", code);
                treeFiles.Nodes[0].Nodes.Add($"{oneSession.RequestMethod}{oneSession.id}.cs");

            }
            AddRunAll(_sessionsData);
            treeFiles.Nodes[0].ExpandAll();

        }

        private void AddRunAll(Session[] sessionsData)
        {
            var sbDeclarations = new StringBuilder();
            var sbBody = new StringBuilder();
            foreach (var oneSession in _sessionsData)
            {
                sbDeclarations.AppendLine( $"{oneSession.RequestMethod}{oneSession.id} {oneSession.RequestMethod.ToLower()}{oneSession.id} = new {oneSession.RequestMethod}{oneSession.id}();");


                sbBody.AppendLine($"commObject.Url = \"{oneSession.fullUrl}\";");
                if (oneSession.RequestMethod == "POST")
                    sbBody.AppendLine($"commObject = {oneSession.RequestMethod.ToLower()}{oneSession.id}.Execute(commObject, new Object());");
                else if (oneSession.RequestMethod == "GET")
                    sbBody.AppendLine($"commObject = {oneSession.RequestMethod.ToLower()}{oneSession.id}.Execute(commObject);");


            }

            if (File.Exists("Scripts\\RunTemplate.cs"))
            {
                var code = new StringBuilder( File.ReadAllText("Scripts\\RunTemplate.cs"));
                code.Replace("//{declarations}", sbDeclarations.ToString());
                code.Replace("//{body}", sbBody.ToString());
                File.WriteAllText($"ExecuteAll.cs", code.ToString());
                treeFiles.Nodes[0].Nodes.Add($"ExecuteAll.cs");
            }


        }

        private void AddBaseClass()
        {
            //if the second node is the base class then ignore
            if (treeFiles.Nodes[0].FirstNode == null || treeFiles.Nodes[0].FirstNode.Text != "onHttpBase.cs")
            {
                if (File.Exists("Scripts\\BaseTemplate.cs"))
                {
                    string baseTemplate = File.ReadAllText("Scripts\\BaseTemplate.cs");
                    File.WriteAllText("onHttpBase.cs", baseTemplate);
                    treeFiles.Nodes[0].Nodes.Add("onHttpBase.cs");
                }

            }
        }

        private string GenerateCode(Session inputsession)
        {
            var cg = new CodeGen();
            return cg.GenerateCode(inputsession);
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
            foreach (TreeNode node in treeFiles.Nodes[0].Nodes)
            {
                File.Copy(node.Text, Path.Combine(dfsNewPath.Text , node.Text),true);
            }
        }


        private void treeFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (File.Exists($"{e.Node.Text}"))
            txtcode.Text = File.ReadAllText($"{e.Node.Text}");
        }
    }
}