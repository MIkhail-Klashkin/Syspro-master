using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogicDLL;
using System.IO;

namespace MainForm
{
    public partial class MainForm : Form, IView
    {
        public event EventHandler AnalyzerButtonEvent;
        public event EventHandler Calc_Click;
        public event EventHandler OpenFile_Click;
        public event EventHandler SaveFile_Click;
        public event EventHandler AddFile_Click;
        public event EventHandler DeleteFile_Click;
        public event EventHandler EditFile_Click;
        public string Log { set => logTextBox.AppendText($"[{DateTime.Now}]  {value} \n"); }
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }
        public int Result { get; set; }
        public string InputAnalyzeLines { get; set; }
        public string AnalyzerResult { get; set; }
        public int Index { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string ServerType { get; set; }
        public string Path { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }
        private void CalcButton_Click(object sender, EventArgs e)
        {
            Arg1 = (int)arg1.Value;
            Arg2 = (int)arg2.Value;
            Calc_Click?.Invoke(this, EventArgs.Empty);
            textBoxResult.Text = Result.ToString();            
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            InputAnalyzeLines = analyzeTextBox.Text;
            AnalyzerButtonEvent?.Invoke(this, EventArgs.Empty);
            analyzeLabel.Text = AnalyzerResult;
            }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                Path = openFileDialog.FileName;
                fileGridView.Rows.Clear();
                OpenFile_Click?.Invoke(this, EventArgs.Empty);
                
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = "PlainTextFile"
                
            };
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Path = saveFile.FileName;
                SaveFile_Click?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile_Click?.Invoke(this, EventArgs.Empty);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileGridView.Rows.Count != 1)
            {
                Index = fileGridView.CurrentRow.Index;
                DeleteFile_Click?.Invoke(this, EventArgs.Empty);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Index = fileGridView.CurrentRow.Index;
            List<DataGridViewCellCollection> cells = new List<DataGridViewCellCollection>
            {
                fileGridView.CurrentRow.Cells
            };
            Address = cells[0][0].EditedFormattedValue.ToString();
            Int32.TryParse(cells[0][1].EditedFormattedValue.ToString(), out int port);
            Port = port;
            ServerType = cells[0][2].EditedFormattedValue.ToString();
            EditFile_Click?.Invoke(this, EventArgs.Empty);
        }
        public void UpdateTable_Handler(LinkedList<INote> notes)
        {
            fileGridView.Rows.Clear();
            if(notes.First!=null)
            {
                LinkedListNode<INote> node = notes.First;
                fileGridView.Rows.Add(node.Value.Address.ToString(), node.Value.Port.ToString(), node.Value.ServerType.ToString());
                while (node.Next!=null)
                {
                    node = node.Next;
                    fileGridView.Rows.Add(node.Value.Address.ToString(), node.Value.Port.ToString(), node.Value.ServerType.ToString());                 
                }
            }
        }
    }
}
