using MiniEditor.Collections;
using MiniEditor.Models;

namespace MiniEditor
{
    public partial class Form1 : Form
    {
        private HistoryList<DocState> history;
        private const int HISTORY_CAPACITY = 50;

        public Form1()
        {
            InitializeComponent();
            InitializeHistory();
            WireEvents();
            UpdateButtons();
        }
        private void InitializeHistory()
        {
            history = new HistoryList<DocState>(HISTORY_CAPACITY);

            var initial = new DocState(string.Empty);
            history.Push(initial);
            txtEditor.Text = initial.Text;
        }
        private void WireEvents()
        {
            btnGuardar.Click += BtnGuardar_Click;
            btnUndo.Click += BtnUndo_Click;
            btnRedo.Click += BtnRedo_Click;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var snapshot = new DocState(txtEditor.Text ?? string.Empty);
            history.Push(snapshot);
            UpdateButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var current = history.UndoOrDefault(new DocState(txtEditor.Text ?? string.Empty));
            txtEditor.Text = current.Text;
            UpdateButtons();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            var current = history.RedoOrDefault(new DocState(txtEditor.Text ?? string.Empty));
            txtEditor.Text = current.Text;
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            btnUndo.Enabled = history.CanUndo;
            btnRedo.Enabled = history.CanRedo;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                BtnGuardar_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                if (btnUndo.Enabled) BtnUndo_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                if (btnRedo.Enabled) btnRedo_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var snapshot = new DocState(txtEditor.Text ?? string.Empty);
            history.Push(snapshot);
            UpdateButtons();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            var current = history.UndoOrDefault(new DocState(txtEditor.Text ?? string.Empty));
            txtEditor.Text = current.Text;
            UpdateButtons();
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            var current = history.RedoOrDefault(new DocState(txtEditor.Text ?? string.Empty));
            txtEditor.Text = current.Text;
            UpdateButtons();
        }
    }
}


