namespace Server
{
    partial class FormServer
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.grpSurvey = new System.Windows.Forms.GroupBox();
            this.txtBoxSurvey = new System.Windows.Forms.RichTextBox();
            this.btnDefine = new System.Windows.Forms.Button();
            this.grpAddQuestion = new System.Windows.Forms.GroupBox();
            this.txtRightAnsw = new System.Windows.Forms.TextBox();
            this.lblRightAnsw = new System.Windows.Forms.Label();
            this.txtAnsw4S = new System.Windows.Forms.TextBox();
            this.txtAnsw2S = new System.Windows.Forms.TextBox();
            this.txtAnsw3S = new System.Windows.Forms.TextBox();
            this.txtAnsw1S = new System.Windows.Forms.TextBox();
            this.txtTextQuestionS = new System.Windows.Forms.TextBox();
            this.lblQuest2S = new System.Windows.Forms.Label();
            this.lblQuest4S = new System.Windows.Forms.Label();
            this.lblTextQuestion = new System.Windows.Forms.Label();
            this.lblQuest3S = new System.Windows.Forms.Label();
            this.lblQuest1S = new System.Windows.Forms.Label();
            this.grpBoxInfoServer = new System.Windows.Forms.GroupBox();
            this.txtInfoServer = new System.Windows.Forms.RichTextBox();
            this.btnResizeForm = new System.Windows.Forms.Button();
            this.grpSurvey.SuspendLayout();
            this.grpAddQuestion.SuspendLayout();
            this.grpBoxInfoServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Papyrus", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(10, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(366, 33);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Define time for the test (in seconds):";
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Font = new System.Drawing.Font("Papyrus", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestions.Location = new System.Drawing.Point(12, 56);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(349, 30);
            this.lblQuestions.TabIndex = 1;
            this.lblQuestions.Text = "Define the count of questions in test:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(481, 66);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(84, 20);
            this.txtCount.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(481, 17);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(84, 20);
            this.txtTime.TabIndex = 3;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.BackColor = System.Drawing.Color.Aqua;
            this.btnAddQuestion.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddQuestion.Location = new System.Drawing.Point(736, 375);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(211, 36);
            this.btnAddQuestion.TabIndex = 4;
            this.btnAddQuestion.Text = "Add a question!";
            this.btnAddQuestion.UseVisualStyleBackColor = false;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // grpSurvey
            // 
            this.grpSurvey.Controls.Add(this.txtBoxSurvey);
            this.grpSurvey.Font = new System.Drawing.Font("Niagara Solid", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSurvey.Location = new System.Drawing.Point(12, 153);
            this.grpSurvey.Name = "grpSurvey";
            this.grpSurvey.Size = new System.Drawing.Size(553, 142);
            this.grpSurvey.TabIndex = 5;
            this.grpSurvey.TabStop = false;
            this.grpSurvey.Text = "Survey for Exam";
            // 
            // txtBoxSurvey
            // 
            this.txtBoxSurvey.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurvey.Location = new System.Drawing.Point(5, 23);
            this.txtBoxSurvey.Name = "txtBoxSurvey";
            this.txtBoxSurvey.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBoxSurvey.Size = new System.Drawing.Size(542, 108);
            this.txtBoxSurvey.TabIndex = 0;
            this.txtBoxSurvey.Text = "";
            // 
            // btnDefine
            // 
            this.btnDefine.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDefine.Location = new System.Drawing.Point(481, 111);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(84, 36);
            this.btnDefine.TabIndex = 6;
            this.btnDefine.Text = "Define";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // grpAddQuestion
            // 
            this.grpAddQuestion.Controls.Add(this.txtRightAnsw);
            this.grpAddQuestion.Controls.Add(this.lblRightAnsw);
            this.grpAddQuestion.Controls.Add(this.txtAnsw4S);
            this.grpAddQuestion.Controls.Add(this.txtAnsw2S);
            this.grpAddQuestion.Controls.Add(this.txtAnsw3S);
            this.grpAddQuestion.Controls.Add(this.txtAnsw1S);
            this.grpAddQuestion.Controls.Add(this.txtTextQuestionS);
            this.grpAddQuestion.Controls.Add(this.lblQuest2S);
            this.grpAddQuestion.Controls.Add(this.lblQuest4S);
            this.grpAddQuestion.Controls.Add(this.lblTextQuestion);
            this.grpAddQuestion.Controls.Add(this.lblQuest3S);
            this.grpAddQuestion.Controls.Add(this.lblQuest1S);
            this.grpAddQuestion.Font = new System.Drawing.Font("Snap ITC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddQuestion.Location = new System.Drawing.Point(640, 12);
            this.grpAddQuestion.Name = "grpAddQuestion";
            this.grpAddQuestion.Size = new System.Drawing.Size(336, 340);
            this.grpAddQuestion.TabIndex = 7;
            this.grpAddQuestion.TabStop = false;
            this.grpAddQuestion.Text = "Add a Question!";
            // 
            // txtRightAnsw
            // 
            this.txtRightAnsw.Location = new System.Drawing.Point(195, 301);
            this.txtRightAnsw.Name = "txtRightAnsw";
            this.txtRightAnsw.Size = new System.Drawing.Size(100, 27);
            this.txtRightAnsw.TabIndex = 11;
            // 
            // lblRightAnsw
            // 
            this.lblRightAnsw.AutoSize = true;
            this.lblRightAnsw.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightAnsw.Location = new System.Drawing.Point(18, 306);
            this.lblRightAnsw.Name = "lblRightAnsw";
            this.lblRightAnsw.Size = new System.Drawing.Size(171, 16);
            this.lblRightAnsw.TabIndex = 10;
            this.lblRightAnsw.Text = "RightAnswer (as number):";
            // 
            // txtAnsw4S
            // 
            this.txtAnsw4S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnsw4S.Location = new System.Drawing.Point(70, 254);
            this.txtAnsw4S.Name = "txtAnsw4S";
            this.txtAnsw4S.Size = new System.Drawing.Size(260, 21);
            this.txtAnsw4S.TabIndex = 9;
            // 
            // txtAnsw2S
            // 
            this.txtAnsw2S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnsw2S.Location = new System.Drawing.Point(70, 162);
            this.txtAnsw2S.Name = "txtAnsw2S";
            this.txtAnsw2S.Size = new System.Drawing.Size(260, 21);
            this.txtAnsw2S.TabIndex = 8;
            // 
            // txtAnsw3S
            // 
            this.txtAnsw3S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnsw3S.Location = new System.Drawing.Point(70, 210);
            this.txtAnsw3S.Name = "txtAnsw3S";
            this.txtAnsw3S.Size = new System.Drawing.Size(260, 21);
            this.txtAnsw3S.TabIndex = 7;
            // 
            // txtAnsw1S
            // 
            this.txtAnsw1S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnsw1S.Location = new System.Drawing.Point(70, 119);
            this.txtAnsw1S.Name = "txtAnsw1S";
            this.txtAnsw1S.Size = new System.Drawing.Size(260, 21);
            this.txtAnsw1S.TabIndex = 6;
            // 
            // txtTextQuestionS
            // 
            this.txtTextQuestionS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextQuestionS.Location = new System.Drawing.Point(21, 65);
            this.txtTextQuestionS.Name = "txtTextQuestionS";
            this.txtTextQuestionS.Size = new System.Drawing.Size(298, 22);
            this.txtTextQuestionS.TabIndex = 5;
            // 
            // lblQuest2S
            // 
            this.lblQuest2S.AutoSize = true;
            this.lblQuest2S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuest2S.Location = new System.Drawing.Point(6, 166);
            this.lblQuest2S.Name = "lblQuest2S";
            this.lblQuest2S.Size = new System.Drawing.Size(57, 15);
            this.lblQuest2S.TabIndex = 4;
            this.lblQuest2S.Text = "Answer2:";
            // 
            // lblQuest4S
            // 
            this.lblQuest4S.AutoSize = true;
            this.lblQuest4S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuest4S.Location = new System.Drawing.Point(6, 258);
            this.lblQuest4S.Name = "lblQuest4S";
            this.lblQuest4S.Size = new System.Drawing.Size(57, 15);
            this.lblQuest4S.TabIndex = 3;
            this.lblQuest4S.Text = "Answer4:";
            // 
            // lblTextQuestion
            // 
            this.lblTextQuestion.AutoSize = true;
            this.lblTextQuestion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextQuestion.Location = new System.Drawing.Point(18, 45);
            this.lblTextQuestion.Name = "lblTextQuestion";
            this.lblTextQuestion.Size = new System.Drawing.Size(169, 17);
            this.lblTextQuestion.TabIndex = 2;
            this.lblTextQuestion.Text = "Add text of the question: ";
            // 
            // lblQuest3S
            // 
            this.lblQuest3S.AutoSize = true;
            this.lblQuest3S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuest3S.Location = new System.Drawing.Point(6, 214);
            this.lblQuest3S.Name = "lblQuest3S";
            this.lblQuest3S.Size = new System.Drawing.Size(57, 15);
            this.lblQuest3S.TabIndex = 1;
            this.lblQuest3S.Text = "Answer3:";
            // 
            // lblQuest1S
            // 
            this.lblQuest1S.AutoSize = true;
            this.lblQuest1S.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuest1S.Location = new System.Drawing.Point(6, 123);
            this.lblQuest1S.Name = "lblQuest1S";
            this.lblQuest1S.Size = new System.Drawing.Size(57, 15);
            this.lblQuest1S.TabIndex = 0;
            this.lblQuest1S.Text = "Answer1:";
            // 
            // grpBoxInfoServer
            // 
            this.grpBoxInfoServer.Controls.Add(this.txtInfoServer);
            this.grpBoxInfoServer.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBoxInfoServer.Location = new System.Drawing.Point(12, 315);
            this.grpBoxInfoServer.Name = "grpBoxInfoServer";
            this.grpBoxInfoServer.Size = new System.Drawing.Size(553, 96);
            this.grpBoxInfoServer.TabIndex = 8;
            this.grpBoxInfoServer.TabStop = false;
            this.grpBoxInfoServer.Text = "Information for Server connection!";
            // 
            // txtInfoServer
            // 
            this.txtInfoServer.Location = new System.Drawing.Point(6, 28);
            this.txtInfoServer.Name = "txtInfoServer";
            this.txtInfoServer.Size = new System.Drawing.Size(532, 58);
            this.txtInfoServer.TabIndex = 9;
            this.txtInfoServer.Text = "";
            // 
            // btnResizeForm
            // 
            this.btnResizeForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnResizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResizeForm.ForeColor = System.Drawing.Color.Black;
            this.btnResizeForm.Location = new System.Drawing.Point(584, 9);
            this.btnResizeForm.Name = "btnResizeForm";
            this.btnResizeForm.Size = new System.Drawing.Size(25, 402);
            this.btnResizeForm.TabIndex = 9;
            this.btnResizeForm.Text = "Add  a   quest ion!";
            this.btnResizeForm.UseVisualStyleBackColor = false;
            this.btnResizeForm.Click += new System.EventHandler(this.btnResizeForm_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 415);
            this.Controls.Add(this.btnResizeForm);
            this.Controls.Add(this.grpBoxInfoServer);
            this.Controls.Add(this.grpAddQuestion);
            this.Controls.Add(this.btnDefine);
            this.Controls.Add(this.grpSurvey);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblTime);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormServer";
            this.Text = "Information for Test!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.grpSurvey.ResumeLayout(false);
            this.grpAddQuestion.ResumeLayout(false);
            this.grpAddQuestion.PerformLayout();
            this.grpBoxInfoServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.GroupBox grpSurvey;
        private System.Windows.Forms.RichTextBox txtBoxSurvey;
        private System.Windows.Forms.Button btnDefine;
        private System.Windows.Forms.GroupBox grpAddQuestion;
        private System.Windows.Forms.TextBox txtAnsw4S;
        private System.Windows.Forms.TextBox txtAnsw2S;
        private System.Windows.Forms.TextBox txtAnsw3S;
        private System.Windows.Forms.TextBox txtAnsw1S;
        private System.Windows.Forms.TextBox txtTextQuestionS;
        private System.Windows.Forms.Label lblQuest2S;
        private System.Windows.Forms.Label lblQuest4S;
        private System.Windows.Forms.Label lblTextQuestion;
        private System.Windows.Forms.Label lblQuest3S;
        private System.Windows.Forms.Label lblQuest1S;
        private System.Windows.Forms.TextBox txtRightAnsw;
        private System.Windows.Forms.Label lblRightAnsw;
        private System.Windows.Forms.GroupBox grpBoxInfoServer;
        private System.Windows.Forms.RichTextBox txtInfoServer;
        private System.Windows.Forms.Button btnResizeForm;
    }
}

