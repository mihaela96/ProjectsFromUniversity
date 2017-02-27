namespace Client
{
    partial class FormClient
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
            this.radioBtnAns4 = new System.Windows.Forms.RadioButton();
            this.radioBtnAns3 = new System.Windows.Forms.RadioButton();
            this.radioBtnAns2 = new System.Windows.Forms.RadioButton();
            this.radioBtnAns1 = new System.Windows.Forms.RadioButton();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDisplayMsg = new System.Windows.Forms.RichTextBox();
            this.grpInfoForS = new System.Windows.Forms.GroupBox();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.grpInfoForS.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBtnAns4
            // 
            this.radioBtnAns4.AutoSize = true;
            this.radioBtnAns4.Location = new System.Drawing.Point(20, 217);
            this.radioBtnAns4.Name = "radioBtnAns4";
            this.radioBtnAns4.Size = new System.Drawing.Size(97, 24);
            this.radioBtnAns4.TabIndex = 6;
            this.radioBtnAns4.TabStop = true;
            this.radioBtnAns4.Text = "Answer4:\r\n";
            this.radioBtnAns4.UseVisualStyleBackColor = true;
            // 
            // radioBtnAns3
            // 
            this.radioBtnAns3.AutoSize = true;
            this.radioBtnAns3.Location = new System.Drawing.Point(20, 162);
            this.radioBtnAns3.Name = "radioBtnAns3";
            this.radioBtnAns3.Size = new System.Drawing.Size(96, 24);
            this.radioBtnAns3.TabIndex = 5;
            this.radioBtnAns3.TabStop = true;
            this.radioBtnAns3.Text = "Answer3:\r\n";
            this.radioBtnAns3.UseVisualStyleBackColor = true;
            // 
            // radioBtnAns2
            // 
            this.radioBtnAns2.AutoSize = true;
            this.radioBtnAns2.Location = new System.Drawing.Point(20, 109);
            this.radioBtnAns2.Name = "radioBtnAns2";
            this.radioBtnAns2.Size = new System.Drawing.Size(97, 24);
            this.radioBtnAns2.TabIndex = 4;
            this.radioBtnAns2.TabStop = true;
            this.radioBtnAns2.Text = "Answer2:\r\n";
            this.radioBtnAns2.UseVisualStyleBackColor = true;
            // 
            // radioBtnAns1
            // 
            this.radioBtnAns1.AutoSize = true;
            this.radioBtnAns1.Location = new System.Drawing.Point(20, 59);
            this.radioBtnAns1.Name = "radioBtnAns1";
            this.radioBtnAns1.Size = new System.Drawing.Size(94, 44);
            this.radioBtnAns1.TabIndex = 3;
            this.radioBtnAns1.TabStop = true;
            this.radioBtnAns1.Text = "Answer1:\r\n\r\n";
            this.radioBtnAns1.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(19, 15);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(50, 20);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "TexT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(123, 385);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(103, 21);
            this.lblTimeLeft.TabIndex = 2;
            this.lblTimeLeft.Text = "Time Left:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(123, 347);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 21);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time:";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.Location = new System.Drawing.Point(422, 355);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(96, 51);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(15, 347);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 51);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(677, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start a test!";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(596, 20);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDisplayMsg
            // 
            this.txtDisplayMsg.Location = new System.Drawing.Point(6, 20);
            this.txtDisplayMsg.Name = "txtDisplayMsg";
            this.txtDisplayMsg.Size = new System.Drawing.Size(230, 56);
            this.txtDisplayMsg.TabIndex = 9;
            this.txtDisplayMsg.Text = "";
            // 
            // grpInfoForS
            // 
            this.grpInfoForS.Controls.Add(this.txtDisplayMsg);
            this.grpInfoForS.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpInfoForS.Location = new System.Drawing.Point(533, 347);
            this.grpInfoForS.Name = "grpInfoForS";
            this.grpInfoForS.Size = new System.Drawing.Size(242, 82);
            this.grpInfoForS.TabIndex = 10;
            this.grpInfoForS.TabStop = false;
            this.grpInfoForS.Text = "Information for server connection!";
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.AutoScroll = true;
            this.pnlQuestion.Controls.Add(this.radioBtnAns4);
            this.pnlQuestion.Controls.Add(this.radioBtnAns1);
            this.pnlQuestion.Controls.Add(this.radioBtnAns3);
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Controls.Add(this.radioBtnAns2);
            this.pnlQuestion.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlQuestion.Location = new System.Drawing.Point(12, 64);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(741, 266);
            this.pnlQuestion.TabIndex = 7;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 441);
            this.Controls.Add(this.grpInfoForS);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.label1);
            this.Name = "FormClient";
            this.Text = "C# Test!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.grpInfoForS.ResumeLayout(false);
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioBtnAns4;
        private System.Windows.Forms.RadioButton radioBtnAns3;
        private System.Windows.Forms.RadioButton radioBtnAns2;
        private System.Windows.Forms.RadioButton radioBtnAns1;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox txtDisplayMsg;
        private System.Windows.Forms.GroupBox grpInfoForS;
        private System.Windows.Forms.Panel pnlQuestion;
    }
}

