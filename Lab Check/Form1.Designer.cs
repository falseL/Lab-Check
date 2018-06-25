namespace Lab_Check
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.sCon = new System.Windows.Forms.SplitContainer();
            this.btnSoftwareCheck = new System.Windows.Forms.Button();
            this.rBtnOpenSelected = new System.Windows.Forms.RadioButton();
            this.rBtnOpenAll = new System.Windows.Forms.RadioButton();
            this.btnOpenSoftware = new System.Windows.Forms.Button();
            this.listSoftware = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sCon)).BeginInit();
            this.sCon.Panel1.SuspendLayout();
            this.sCon.Panel2.SuspendLayout();
            this.sCon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(25, 83);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(25, 42);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(112, 35);
            this.btnGetFiles.TabIndex = 1;
            this.btnGetFiles.Text = "Get Files";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // sCon
            // 
            this.sCon.Location = new System.Drawing.Point(12, 12);
            this.sCon.Name = "sCon";
            // 
            // sCon.Panel1
            // 
            this.sCon.Panel1.Controls.Add(this.btnSoftwareCheck);
            this.sCon.Panel1.Controls.Add(this.btnGetFiles);
            this.sCon.Panel1.Controls.Add(this.btnStart);
            // 
            // sCon.Panel2
            // 
            this.sCon.Panel2.Controls.Add(this.rBtnOpenSelected);
            this.sCon.Panel2.Controls.Add(this.rBtnOpenAll);
            this.sCon.Panel2.Controls.Add(this.btnOpenSoftware);
            this.sCon.Panel2.Controls.Add(this.listSoftware);
            this.sCon.Size = new System.Drawing.Size(476, 282);
            this.sCon.SplitterDistance = 158;
            this.sCon.TabIndex = 2;
            // 
            // btnSoftwareCheck
            // 
            this.btnSoftwareCheck.Location = new System.Drawing.Point(25, 124);
            this.btnSoftwareCheck.Name = "btnSoftwareCheck";
            this.btnSoftwareCheck.Size = new System.Drawing.Size(112, 35);
            this.btnSoftwareCheck.TabIndex = 2;
            this.btnSoftwareCheck.Text = "Software Check";
            this.btnSoftwareCheck.UseVisualStyleBackColor = true;
            // 
            // rBtnOpenSelected
            // 
            this.rBtnOpenSelected.AutoSize = true;
            this.rBtnOpenSelected.Checked = true;
            this.rBtnOpenSelected.Location = new System.Drawing.Point(170, 197);
            this.rBtnOpenSelected.Name = "rBtnOpenSelected";
            this.rBtnOpenSelected.Size = new System.Drawing.Size(137, 17);
            this.rBtnOpenSelected.TabIndex = 5;
            this.rBtnOpenSelected.TabStop = true;
            this.rBtnOpenSelected.Text = "Open selected software";
            this.rBtnOpenSelected.UseVisualStyleBackColor = true;
            // 
            // rBtnOpenAll
            // 
            this.rBtnOpenAll.AutoSize = true;
            this.rBtnOpenAll.Location = new System.Drawing.Point(170, 174);
            this.rBtnOpenAll.Name = "rBtnOpenAll";
            this.rBtnOpenAll.Size = new System.Drawing.Size(107, 17);
            this.rBtnOpenAll.TabIndex = 4;
            this.rBtnOpenAll.Text = "Open all software";
            this.rBtnOpenAll.UseVisualStyleBackColor = true;
            // 
            // btnOpenSoftware
            // 
            this.btnOpenSoftware.Location = new System.Drawing.Point(170, 229);
            this.btnOpenSoftware.Name = "btnOpenSoftware";
            this.btnOpenSoftware.Size = new System.Drawing.Size(113, 35);
            this.btnOpenSoftware.TabIndex = 1;
            this.btnOpenSoftware.Text = "Open Software";
            this.btnOpenSoftware.UseVisualStyleBackColor = true;
            this.btnOpenSoftware.Click += new System.EventHandler(this.btnOpenSoftware_Click);
            // 
            // listSoftware
            // 
            this.listSoftware.FormattingEnabled = true;
            this.listSoftware.Items.AddRange(new object[] {
            "AutoCAD",
            "Code Warriors",
            "HyperTerminal",
            "Matlab",
            "OrCAD",
            "Pads",
            "Quartus",
            "Spyder (Anaconda)",
            "VSA"});
            this.listSoftware.Location = new System.Drawing.Point(13, 20);
            this.listSoftware.Name = "listSoftware";
            this.listSoftware.Size = new System.Drawing.Size(140, 244);
            this.listSoftware.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 306);
            this.Controls.Add(this.sCon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Lab Check";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sCon.Panel1.ResumeLayout(false);
            this.sCon.Panel2.ResumeLayout(false);
            this.sCon.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCon)).EndInit();
            this.sCon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.SplitContainer sCon;
        private System.Windows.Forms.Button btnSoftwareCheck;
        private System.Windows.Forms.Button btnOpenSoftware;
        private System.Windows.Forms.CheckedListBox listSoftware;
        private System.Windows.Forms.RadioButton rBtnOpenSelected;
        private System.Windows.Forms.RadioButton rBtnOpenAll;
    }
}

