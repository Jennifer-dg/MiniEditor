namespace MiniEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuardar = new Button();
            txtEditor = new TextBox();
            btnUndo = new Button();
            btnRedo = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(385, 554);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(273, 48);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Estado";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += button1_Click;
            // 
            // txtEditor
            // 
            txtEditor.Location = new Point(24, 112);
            txtEditor.Multiline = true;
            txtEditor.Name = "txtEditor";
            txtEditor.Size = new Size(983, 411);
            txtEditor.TabIndex = 3;
            txtEditor.TextChanged += textBox1_TextChanged;
            // 
            // btnUndo
            // 
            btnUndo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUndo.Location = new Point(24, 554);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(273, 48);
            btnUndo.TabIndex = 4;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += button2_Click;
            // 
            // btnRedo
            // 
            btnRedo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRedo.Location = new Point(734, 554);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(273, 48);
            btnRedo.TabIndex = 5;
            btnRedo.Text = "Redo";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 41);
            label1.Name = "label1";
            label1.Size = new Size(290, 44);
            label1.TabIndex = 6;
            label1.Text = "Editor De Texto";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 637);
            Controls.Add(label1);
            Controls.Add(btnRedo);
            Controls.Add(btnUndo);
            Controls.Add(txtEditor);
            Controls.Add(btnGuardar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private TextBox txtEditor;
        private Button btnUndo;
        private Button btnRedo;
        private Label label1;
    }
}
