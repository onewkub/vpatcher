namespace vpatcher {
    partial class Patcher {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patcher));
            this.pbarDL = new System.Windows.Forms.ProgressBar();
            this.pbarPatch = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPatchAll = new System.Windows.Forms.Button();
            this.lblDL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbarDL
            // 
            this.pbarDL.Location = new System.Drawing.Point(293, 252);
            this.pbarDL.Name = "pbarDL";
            this.pbarDL.Size = new System.Drawing.Size(300, 23);
            this.pbarDL.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarDL.TabIndex = 0;
            // 
            // pbarPatch
            // 
            this.pbarPatch.Location = new System.Drawing.Point(293, 306);
            this.pbarPatch.Name = "pbarPatch";
            this.pbarPatch.Size = new System.Drawing.Size(300, 23);
            this.pbarPatch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarPatch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Download Progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patch Progress";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Tw Cen MT Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStart.Location = new System.Drawing.Point(475, 372);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 32);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Game!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(293, 335);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 18);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // btnPatchAll
            // 
            this.btnPatchAll.Enabled = false;
            this.btnPatchAll.Font = new System.Drawing.Font("Tw Cen MT Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatchAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPatchAll.Location = new System.Drawing.Point(351, 372);
            this.btnPatchAll.Name = "btnPatchAll";
            this.btnPatchAll.Size = new System.Drawing.Size(118, 32);
            this.btnPatchAll.TabIndex = 7;
            this.btnPatchAll.Text = "Repatch All";
            this.btnPatchAll.UseVisualStyleBackColor = true;
            this.btnPatchAll.Visible = false;
            this.btnPatchAll.Click += new System.EventHandler(this.btnPatchAll_Click);
            // 
            // lblDL
            // 
            this.lblDL.BackColor = System.Drawing.Color.Transparent;
            this.lblDL.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDL.ForeColor = System.Drawing.Color.White;
            this.lblDL.Location = new System.Drawing.Point(293, 281);
            this.lblDL.Name = "lblDL";
            this.lblDL.Size = new System.Drawing.Size(300, 18);
            this.lblDL.TabIndex = 9;
            this.lblDL.Text = "Status";
            // 
            // Patcher
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(751, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDL);
            this.Controls.Add(this.pbarDL);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbarPatch);
            this.Controls.Add(this.btnPatchAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Patcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VPatcher";
            this.Load += new System.EventHandler(this.Patcher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbarDL;
        private System.Windows.Forms.ProgressBar pbarPatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPatchAll;
        private System.Windows.Forms.Label lblDL;
    }
}

