namespace AppImagensTeste
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFakeData = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cboPartner = new System.Windows.Forms.ComboBox();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "do it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teste";
            // 
            // txtFakeData
            // 
            this.txtFakeData.Location = new System.Drawing.Point(15, 57);
            this.txtFakeData.Multiline = true;
            this.txtFakeData.Name = "txtFakeData";
            this.txtFakeData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFakeData.Size = new System.Drawing.Size(1132, 72);
            this.txtFakeData.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 459);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(15, 405);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(692, 40);
            this.progress.Step = 100;
            this.progress.TabIndex = 4;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 135);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(1131, 259);
            this.txtLog.TabIndex = 5;
            // 
            // cboPartner
            // 
            this.cboPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPartner.FormattingEnabled = true;
            this.cboPartner.Items.AddRange(new object[] {
            "TCL",
            "Samsung"});
            this.cboPartner.Location = new System.Drawing.Point(15, 30);
            this.cboPartner.Name = "cboPartner";
            this.cboPartner.Size = new System.Drawing.Size(554, 21);
            this.cboPartner.TabIndex = 6;
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(577, 31);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(570, 20);
            this.txtList.TabIndex = 7;
            this.txtList.Text = "1,2,3,4,5,6,7,8";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(936, 405);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(211, 39);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 457);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.cboPartner);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtFakeData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Teste";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFakeData;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cboPartner;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Button btnRemove;
    }
}

