namespace P3FDOAtomIDE
{
    partial class frmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtPacket = new System.Windows.Forms.TextBox();
            this.pgPacket = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.pgSelAtom = new System.Windows.Forms.PropertyGrid();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pgFDO = new System.Windows.Forms.PropertyGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1178, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 217);
            this.button1.TabIndex = 0;
            this.button1.Text = "Parse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPacket
            // 
            this.txtPacket.Location = new System.Drawing.Point(12, 11);
            this.txtPacket.Multiline = true;
            this.txtPacket.Name = "txtPacket";
            this.txtPacket.Size = new System.Drawing.Size(1160, 84);
            this.txtPacket.TabIndex = 1;
            // 
            // pgPacket
            // 
            this.pgPacket.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pgPacket.Location = new System.Drawing.Point(4, 231);
            this.pgPacket.Name = "pgPacket";
            this.pgPacket.Size = new System.Drawing.Size(313, 434);
            this.pgPacket.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Packet Data";
            // 
            // pgSelAtom
            // 
            this.pgSelAtom.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pgSelAtom.Location = new System.Drawing.Point(960, 229);
            this.pgSelAtom.Name = "pgSelAtom";
            this.pgSelAtom.Size = new System.Drawing.Size(290, 436);
            this.pgSelAtom.TabIndex = 4;
            this.pgSelAtom.Click += new System.EventHandler(this.pgSelAtom_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(626, 256);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(328, 409);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Atoms";
            // 
            // pgFDO
            // 
            this.pgFDO.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pgFDO.Location = new System.Drawing.Point(323, 229);
            this.pgFDO.Name = "pgFDO";
            this.pgFDO.Size = new System.Drawing.Size(297, 436);
            this.pgFDO.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "FDO";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(12, 105);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(1160, 64);
            this.listBox2.TabIndex = 8;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 666);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.pgFDO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pgSelAtom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgPacket);
            this.Controls.Add(this.txtPacket);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "P3 Packet Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox txtPacket;
        private PropertyGrid pgPacket;
        private Label label1;
        private PropertyGrid pgSelAtom;
        private ListBox listBox1;
        private Label label2;
        private PropertyGrid pgFDO;
        private Label label3;
        private ListBox listBox2;
    }
}