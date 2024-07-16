using System.Diagnostics;
using System.IO;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            sourceFileDialog.ShowDialog();
            txtSourcePath.Text = sourceFileDialog.FileName;
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            DialogResult result = destinationFolderPathDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestinationPath.Text = destinationFolderPathDialog.SelectedPath;
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            string sourceFile = txtSourcePath.Text;
            string destinationPath = txtDestinationPath.Text;

            var models = txtModels.Text.Split("\n");

            foreach (var model in models)
            {
                FileInfo file = new FileInfo(sourceFile);
                var fileName = file.Name.Replace("dummy", model);
                var destinationFile = Path.Combine(destinationPath, fileName);
                File.Copy(sourceFile, destinationFile, true);

                string fileContent = File.ReadAllText(destinationFile);
                fileContent = fileContent.Replace("dummy", model.ToLower());
                fileContent = fileContent.Replace("Dummy", model);

                File.WriteAllText(destinationFile, fileContent);
                
                lnkDestinationFolder.Visible = true;
                lblGeneratedFolder.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            string newPath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));
            string generatedPath = Path.Combine(newPath, "generated-code");
            Directory.CreateDirectory(generatedPath);

            txtModels.Text = "Customer\nOrder\nProduct";
            txtDestinationPath.Text = generatedPath;
            lnkDestinationFolder.Text = generatedPath;
            txtSourcePath.Text = Path.Combine(newPath, "dummyApiClass.cs");
        }

        private void lnkDestinationFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string explorerPath = "explorer.exe";
            string arguments = lnkDestinationFolder.Text;
            Process.Start(explorerPath, arguments);
        }
    }
}

