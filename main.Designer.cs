namespace apartment
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            form1ToolStripMenuItem = new ToolStripMenuItem();
            form3ToolStripMenuItem = new ToolStripMenuItem();
            คนหาหองพกชำระคาเชาToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { form1ToolStripMenuItem, form3ToolStripMenuItem, คนหาหองพกชำระคาเชาToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // form1ToolStripMenuItem
            // 
            form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            form1ToolStripMenuItem.Size = new Size(216, 24);
            form1ToolStripMenuItem.Text = "[ หน้าเพิ่มข้อมูล / การจ่ายค่าเช่า ]";
            form1ToolStripMenuItem.Click += form1ToolStripMenuItem_Click;
            // 
            // form3ToolStripMenuItem
            // 
            form3ToolStripMenuItem.Name = "form3ToolStripMenuItem";
            form3ToolStripMenuItem.Size = new Size(142, 24);
            form3ToolStripMenuItem.Text = "[ จัดการข้อมูลต่างๆ ]";
            form3ToolStripMenuItem.Click += form3ToolStripMenuItem_Click;
            // 
            // คนหาหองพกชำระคาเชาToolStripMenuItem
            // 
            คนหาหองพกชำระคาเชาToolStripMenuItem.Name = "คนหาหองพกชำระคาเชาToolStripMenuItem";
            คนหาหองพกชำระคาเชาToolStripMenuItem.Size = new Size(202, 24);
            คนหาหองพกชำระคาเชาToolStripMenuItem.Text = "[ ค้นหาห้องพัก /  ชำระค่าเช่า ] ";
            คนหาหองพกชำระคาเชาToolStripMenuItem.Click += คนหาหองพกชำระคาเชาToolStripMenuItem_Click;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "main";
            Text = "main";
            WindowState = FormWindowState.Maximized;
            Load += main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem form1ToolStripMenuItem;
        private ToolStripMenuItem form3ToolStripMenuItem;
        private ToolStripMenuItem คนหาหองพกชำระคาเชาToolStripMenuItem;
    }
}