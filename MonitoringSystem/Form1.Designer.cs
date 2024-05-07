namespace MonitoringSystem
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRed = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ruler1 = new System.Windows.Forms.Panel();
            this.lbhtemp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbwlevel = new System.Windows.Forms.Label();
            this.ruler2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbair2 = new System.Windows.Forms.TextBox();
            this.tbair1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btnxmlsave = new System.Windows.Forms.Button();
            this.btnlogreset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRed
            // 
            this.btnRed.Location = new System.Drawing.Point(11, 16);
            this.btnRed.Margin = new System.Windows.Forms.Padding(0);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(30, 75);
            this.btnRed.TabIndex = 0;
            this.btnRed.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGreen);
            this.groupBox1.Controls.Add(this.btnYellow);
            this.groupBox1.Controls.Add(this.btnRed);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(53, 247);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lamp";
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Location = new System.Drawing.Point(11, 164);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(1);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(30, 75);
            this.btnGreen.TabIndex = 2;
            this.btnGreen.UseVisualStyleBackColor = false;
            // 
            // btnYellow
            // 
            this.btnYellow.Location = new System.Drawing.Point(11, 90);
            this.btnYellow.Margin = new System.Windows.Forms.Padding(1);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(30, 75);
            this.btnYellow.TabIndex = 1;
            this.btnYellow.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ruler1);
            this.groupBox2.Controls.Add(this.lbhtemp);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(97, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 360);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heater Temp";
            // 
            // ruler1
            // 
            this.ruler1.Location = new System.Drawing.Point(79, 41);
            this.ruler1.Name = "ruler1";
            this.ruler1.Size = new System.Drawing.Size(39, 313);
            this.ruler1.TabIndex = 10;
            this.ruler1.Paint += new System.Windows.Forms.PaintEventHandler(this.ruler1_Paint1);
            // 
            // lbhtemp
            // 
            this.lbhtemp.AutoSize = true;
            this.lbhtemp.Location = new System.Drawing.Point(36, 23);
            this.lbhtemp.Name = "lbhtemp";
            this.lbhtemp.Size = new System.Drawing.Size(38, 12);
            this.lbhtemp.TabIndex = 11;
            this.lbhtemp.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(18, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 300);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbwlevel);
            this.groupBox3.Controls.Add(this.ruler2);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(226, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 360);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Water Tank";
            // 
            // lbwlevel
            // 
            this.lbwlevel.AutoSize = true;
            this.lbwlevel.Location = new System.Drawing.Point(33, 24);
            this.lbwlevel.Name = "lbwlevel";
            this.lbwlevel.Size = new System.Drawing.Size(38, 12);
            this.lbwlevel.TabIndex = 12;
            this.lbwlevel.Text = "label2";
            // 
            // ruler2
            // 
            this.ruler2.Location = new System.Drawing.Point(78, 41);
            this.ruler2.Name = "ruler2";
            this.ruler2.Size = new System.Drawing.Size(39, 313);
            this.ruler2.TabIndex = 11;
            this.ruler2.Paint += new System.Windows.Forms.PaintEventHandler(this.ruler2_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(17, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 300);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbair2);
            this.groupBox4.Controls.Add(this.tbair1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(374, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 90);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "배관 기압";
            // 
            // tbair2
            // 
            this.tbair2.Enabled = false;
            this.tbair2.Location = new System.Drawing.Point(70, 49);
            this.tbair2.Name = "tbair2";
            this.tbair2.Size = new System.Drawing.Size(100, 21);
            this.tbair2.TabIndex = 3;
            // 
            // tbair1
            // 
            this.tbair1.Enabled = false;
            this.tbair1.Location = new System.Drawing.Point(70, 20);
            this.tbair1.Name = "tbair1";
            this.tbair1.Size = new System.Drawing.Size(100, 21);
            this.tbair1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "배출구";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "투입구";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(580, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 6;
            this.button1.Text = "EMO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "배수",
            "누수 경고"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 336);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(79, 36);
            this.checkedListBox1.TabIndex = 7;
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 12;
            this.lbLog.Location = new System.Drawing.Point(374, 123);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(286, 244);
            this.lbLog.TabIndex = 3;
            // 
            // btnxmlsave
            // 
            this.btnxmlsave.Location = new System.Drawing.Point(419, 384);
            this.btnxmlsave.Name = "btnxmlsave";
            this.btnxmlsave.Size = new System.Drawing.Size(75, 23);
            this.btnxmlsave.TabIndex = 8;
            this.btnxmlsave.Text = "DataTrend";
            this.btnxmlsave.UseVisualStyleBackColor = true;
            this.btnxmlsave.Click += new System.EventHandler(this.btnxmlsave_Click);
            // 
            // btnlogreset
            // 
            this.btnlogreset.Location = new System.Drawing.Point(525, 384);
            this.btnlogreset.Name = "btnlogreset";
            this.btnlogreset.Size = new System.Drawing.Size(75, 23);
            this.btnlogreset.TabIndex = 9;
            this.btnlogreset.Text = "Log Reset";
            this.btnlogreset.UseVisualStyleBackColor = true;
            this.btnlogreset.Click += new System.EventHandler(this.btnlogreset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.btnlogreset);
            this.Controls.Add(this.btnxmlsave);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MonitoringSystem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnYellow;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbair2;
        private System.Windows.Forms.TextBox tbair1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel ruler1;
        private System.Windows.Forms.Panel ruler2;
        private System.Windows.Forms.Label lbhtemp;
        private System.Windows.Forms.Label lbwlevel;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnxmlsave;
        private System.Windows.Forms.Button btnlogreset;
    }
}

