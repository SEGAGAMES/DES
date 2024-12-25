namespace Forms
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
            tabControl1 = new TabControl();
            cryptTabPage = new TabPage();
            IVTxtBox = new TextBox();
            IVLbl = new Label();
            key3TxtBox = new TextBox();
            key2TxtBox = new TextBox();
            key1TxtBox = new TextBox();
            key3Lbl = new Label();
            modeGrpBox = new GroupBox();
            EDE2RdBtn = new RadioButton();
            EEE2RdBtn = new RadioButton();
            EDE3RdBtn = new RadioButton();
            EEE3RdBtn = new RadioButton();
            CBCRdBtn = new RadioButton();
            ECBRdBtn = new RadioButton();
            key2Lbl = new Label();
            key1Lbl = new Label();
            modeInfoLbl = new Label();
            DecryptInfoLbl = new Label();
            encryptInfolbl = new Label();
            decryptResultTxtBox = new TextBox();
            encryptResultTxtBox = new TextBox();
            decryptTextTxtBox = new TextBox();
            encryptTextTxtBox = new TextBox();
            decryptBtn = new Button();
            ecnryptBtn = new Button();
            logTabPage = new TabPage();
            logTxtBox = new TextBox();
            tabControl1.SuspendLayout();
            cryptTabPage.SuspendLayout();
            modeGrpBox.SuspendLayout();
            logTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(cryptTabPage);
            tabControl1.Controls.Add(logTabPage);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(637, 423);
            tabControl1.TabIndex = 0;
            // 
            // cryptTabPage
            // 
            cryptTabPage.Controls.Add(IVTxtBox);
            cryptTabPage.Controls.Add(IVLbl);
            cryptTabPage.Controls.Add(key3TxtBox);
            cryptTabPage.Controls.Add(key2TxtBox);
            cryptTabPage.Controls.Add(key1TxtBox);
            cryptTabPage.Controls.Add(key3Lbl);
            cryptTabPage.Controls.Add(modeGrpBox);
            cryptTabPage.Controls.Add(key2Lbl);
            cryptTabPage.Controls.Add(key1Lbl);
            cryptTabPage.Controls.Add(modeInfoLbl);
            cryptTabPage.Controls.Add(DecryptInfoLbl);
            cryptTabPage.Controls.Add(encryptInfolbl);
            cryptTabPage.Controls.Add(decryptResultTxtBox);
            cryptTabPage.Controls.Add(encryptResultTxtBox);
            cryptTabPage.Controls.Add(decryptTextTxtBox);
            cryptTabPage.Controls.Add(encryptTextTxtBox);
            cryptTabPage.Controls.Add(decryptBtn);
            cryptTabPage.Controls.Add(ecnryptBtn);
            cryptTabPage.Location = new Point(4, 24);
            cryptTabPage.Name = "cryptTabPage";
            cryptTabPage.Padding = new Padding(3);
            cryptTabPage.Size = new Size(629, 395);
            cryptTabPage.TabIndex = 0;
            cryptTabPage.Text = "Шифрование";
            cryptTabPage.UseVisualStyleBackColor = true;
            // 
            // IVTxtBox
            // 
            IVTxtBox.Location = new Point(261, 370);
            IVTxtBox.Name = "IVTxtBox";
            IVTxtBox.Size = new Size(100, 23);
            IVTxtBox.TabIndex = 17;
            IVTxtBox.Visible = false;
            // 
            // IVLbl
            // 
            IVLbl.AutoSize = true;
            IVLbl.Location = new Point(261, 347);
            IVLbl.Name = "IVLbl";
            IVLbl.Size = new Size(180, 15);
            IVLbl.TabIndex = 16;
            IVLbl.Text = "Введите вектор инициализации";
            IVLbl.Visible = false;
            // 
            // key3TxtBox
            // 
            key3TxtBox.Location = new Point(261, 320);
            key3TxtBox.Name = "key3TxtBox";
            key3TxtBox.Size = new Size(100, 23);
            key3TxtBox.TabIndex = 15;
            key3TxtBox.Text = "3456789";
            key3TxtBox.Visible = false;
            // 
            // key2TxtBox
            // 
            key2TxtBox.Location = new Point(261, 276);
            key2TxtBox.Name = "key2TxtBox";
            key2TxtBox.Size = new Size(100, 23);
            key2TxtBox.TabIndex = 14;
            key2TxtBox.Text = "2345678";
            key2TxtBox.Visible = false;
            // 
            // key1TxtBox
            // 
            key1TxtBox.Location = new Point(261, 228);
            key1TxtBox.Name = "key1TxtBox";
            key1TxtBox.Size = new Size(100, 23);
            key1TxtBox.TabIndex = 13;
            key1TxtBox.Text = "1234567";
            // 
            // key3Lbl
            // 
            key3Lbl.AutoSize = true;
            key3Lbl.Location = new Point(261, 302);
            key3Lbl.Name = "key3Lbl";
            key3Lbl.Size = new Size(123, 15);
            key3Lbl.TabIndex = 12;
            key3Lbl.Text = "Введите третий ключ";
            key3Lbl.Visible = false;
            // 
            // modeGrpBox
            // 
            modeGrpBox.Controls.Add(EDE2RdBtn);
            modeGrpBox.Controls.Add(EEE2RdBtn);
            modeGrpBox.Controls.Add(EDE3RdBtn);
            modeGrpBox.Controls.Add(EEE3RdBtn);
            modeGrpBox.Controls.Add(CBCRdBtn);
            modeGrpBox.Controls.Add(ECBRdBtn);
            modeGrpBox.Location = new Point(25, 228);
            modeGrpBox.Name = "modeGrpBox";
            modeGrpBox.Size = new Size(200, 164);
            modeGrpBox.TabIndex = 11;
            modeGrpBox.TabStop = false;
            // 
            // EDE2RdBtn
            // 
            EDE2RdBtn.AutoSize = true;
            EDE2RdBtn.Location = new Point(6, 142);
            EDE2RdBtn.Name = "EDE2RdBtn";
            EDE2RdBtn.Size = new Size(51, 19);
            EDE2RdBtn.TabIndex = 5;
            EDE2RdBtn.Text = "EDE2";
            EDE2RdBtn.UseVisualStyleBackColor = true;
            EDE2RdBtn.CheckedChanged += EDE2RdBtn_CheckedChanged;
            // 
            // EEE2RdBtn
            // 
            EEE2RdBtn.AutoSize = true;
            EEE2RdBtn.Location = new Point(6, 117);
            EEE2RdBtn.Name = "EEE2RdBtn";
            EEE2RdBtn.Size = new Size(49, 19);
            EEE2RdBtn.TabIndex = 4;
            EEE2RdBtn.Text = "EEE2";
            EEE2RdBtn.UseVisualStyleBackColor = true;
            EEE2RdBtn.CheckedChanged += EEE2RdBtn_CheckedChanged;
            // 
            // EDE3RdBtn
            // 
            EDE3RdBtn.AutoSize = true;
            EDE3RdBtn.Location = new Point(6, 92);
            EDE3RdBtn.Name = "EDE3RdBtn";
            EDE3RdBtn.Size = new Size(51, 19);
            EDE3RdBtn.TabIndex = 3;
            EDE3RdBtn.Text = "EDE3";
            EDE3RdBtn.UseVisualStyleBackColor = true;
            EDE3RdBtn.CheckedChanged += EDE3RdBtn_CheckedChanged;
            // 
            // EEE3RdBtn
            // 
            EEE3RdBtn.AutoSize = true;
            EEE3RdBtn.Location = new Point(6, 67);
            EEE3RdBtn.Name = "EEE3RdBtn";
            EEE3RdBtn.Size = new Size(49, 19);
            EEE3RdBtn.TabIndex = 2;
            EEE3RdBtn.Text = "EEE3";
            EEE3RdBtn.UseVisualStyleBackColor = true;
            EEE3RdBtn.CheckedChanged += EEE3RdBtn_CheckedChanged;
            // 
            // CBCRdBtn
            // 
            CBCRdBtn.AutoSize = true;
            CBCRdBtn.Location = new Point(6, 42);
            CBCRdBtn.Name = "CBCRdBtn";
            CBCRdBtn.Size = new Size(48, 19);
            CBCRdBtn.TabIndex = 1;
            CBCRdBtn.Text = "CBC";
            CBCRdBtn.UseVisualStyleBackColor = true;
            CBCRdBtn.CheckedChanged += CBCRdBtn_CheckedChanged;
            // 
            // ECBRdBtn
            // 
            ECBRdBtn.AutoSize = true;
            ECBRdBtn.Checked = true;
            ECBRdBtn.Location = new Point(6, 19);
            ECBRdBtn.Name = "ECBRdBtn";
            ECBRdBtn.Size = new Size(46, 19);
            ECBRdBtn.TabIndex = 0;
            ECBRdBtn.TabStop = true;
            ECBRdBtn.Text = "ECB";
            ECBRdBtn.UseVisualStyleBackColor = true;
            ECBRdBtn.CheckedChanged += ECBRdBtn_CheckedChanged;
            // 
            // key2Lbl
            // 
            key2Lbl.AutoSize = true;
            key2Lbl.Location = new Point(261, 258);
            key2Lbl.Name = "key2Lbl";
            key2Lbl.Size = new Size(125, 15);
            key2Lbl.TabIndex = 10;
            key2Lbl.Text = "Введите второй ключ";
            key2Lbl.Visible = false;
            // 
            // key1Lbl
            // 
            key1Lbl.AutoSize = true;
            key1Lbl.Location = new Point(261, 210);
            key1Lbl.Name = "key1Lbl";
            key1Lbl.Size = new Size(128, 15);
            key1Lbl.TabIndex = 9;
            key1Lbl.Text = "Введите первый ключ";
            // 
            // modeInfoLbl
            // 
            modeInfoLbl.AutoSize = true;
            modeInfoLbl.Location = new Point(25, 210);
            modeInfoLbl.Name = "modeInfoLbl";
            modeInfoLbl.Size = new Size(178, 15);
            modeInfoLbl.TabIndex = 8;
            modeInfoLbl.Text = "Выберите режим шифрования";
            // 
            // DecryptInfoLbl
            // 
            DecryptInfoLbl.AutoSize = true;
            DecryptInfoLbl.Location = new Point(325, 21);
            DecryptInfoLbl.Name = "DecryptInfoLbl";
            DecryptInfoLbl.Size = new Size(178, 15);
            DecryptInfoLbl.TabIndex = 7;
            DecryptInfoLbl.Text = "Введите текст для дешифровки";
            // 
            // encryptInfolbl
            // 
            encryptInfolbl.AutoSize = true;
            encryptInfolbl.Location = new Point(25, 21);
            encryptInfolbl.Name = "encryptInfolbl";
            encryptInfolbl.Size = new Size(179, 15);
            encryptInfolbl.TabIndex = 6;
            encryptInfolbl.Text = "Введите текст для шифрования";
            // 
            // decryptResultTxtBox
            // 
            decryptResultTxtBox.Location = new Point(326, 149);
            decryptResultTxtBox.Multiline = true;
            decryptResultTxtBox.Name = "decryptResultTxtBox";
            decryptResultTxtBox.Size = new Size(292, 49);
            decryptResultTxtBox.TabIndex = 5;
            // 
            // encryptResultTxtBox
            // 
            encryptResultTxtBox.Location = new Point(22, 149);
            encryptResultTxtBox.Multiline = true;
            encryptResultTxtBox.Name = "encryptResultTxtBox";
            encryptResultTxtBox.ReadOnly = true;
            encryptResultTxtBox.Size = new Size(295, 49);
            encryptResultTxtBox.TabIndex = 4;
            encryptResultTxtBox.MouseDown += encryptResultTxtBox_MouseDown;
            // 
            // decryptTextTxtBox
            // 
            decryptTextTxtBox.Location = new Point(325, 39);
            decryptTextTxtBox.Multiline = true;
            decryptTextTxtBox.Name = "decryptTextTxtBox";
            decryptTextTxtBox.Size = new Size(293, 49);
            decryptTextTxtBox.TabIndex = 3;
            // 
            // encryptTextTxtBox
            // 
            encryptTextTxtBox.Location = new Point(25, 39);
            encryptTextTxtBox.Multiline = true;
            encryptTextTxtBox.Name = "encryptTextTxtBox";
            encryptTextTxtBox.Size = new Size(292, 49);
            encryptTextTxtBox.TabIndex = 2;
            encryptTextTxtBox.Text = "Пример";
            // 
            // decryptBtn
            // 
            decryptBtn.Location = new Point(326, 94);
            decryptBtn.Name = "decryptBtn";
            decryptBtn.Size = new Size(292, 49);
            decryptBtn.TabIndex = 1;
            decryptBtn.Text = "Дешифровать";
            decryptBtn.UseVisualStyleBackColor = true;
            decryptBtn.Click += decryptBtn_Click;
            // 
            // ecnryptBtn
            // 
            ecnryptBtn.Location = new Point(25, 94);
            ecnryptBtn.Name = "ecnryptBtn";
            ecnryptBtn.Size = new Size(292, 49);
            ecnryptBtn.TabIndex = 0;
            ecnryptBtn.Text = "Зашифровать";
            ecnryptBtn.UseVisualStyleBackColor = true;
            ecnryptBtn.Click += ecnryptBtn_Click;
            // 
            // logTabPage
            // 
            logTabPage.Controls.Add(logTxtBox);
            logTabPage.Location = new Point(4, 24);
            logTabPage.Name = "logTabPage";
            logTabPage.Padding = new Padding(3);
            logTabPage.Size = new Size(629, 395);
            logTabPage.TabIndex = 1;
            logTabPage.Text = "Лог";
            logTabPage.UseVisualStyleBackColor = true;
            // 
            // logTxtBox
            // 
            logTxtBox.Location = new Point(6, 6);
            logTxtBox.Multiline = true;
            logTxtBox.Name = "logTxtBox";
            logTxtBox.ScrollBars = ScrollBars.Vertical;
            logTxtBox.Size = new Size(616, 383);
            logTxtBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 439);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DES";
            tabControl1.ResumeLayout(false);
            cryptTabPage.ResumeLayout(false);
            cryptTabPage.PerformLayout();
            modeGrpBox.ResumeLayout(false);
            modeGrpBox.PerformLayout();
            logTabPage.ResumeLayout(false);
            logTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage cryptTabPage;
        private GroupBox modeGrpBox;
        private RadioButton EDE2RdBtn;
        private RadioButton EEE2RdBtn;
        private RadioButton EDE3RdBtn;
        private RadioButton EEE3RdBtn;
        private RadioButton CBCRdBtn;
        private RadioButton ECBRdBtn;
        private Label key2Lbl;
        private Label key1Lbl;
        private Label modeInfoLbl;
        private Label DecryptInfoLbl;
        private Label encryptInfolbl;
        private TextBox decryptResultTxtBox;
        private TextBox encryptResultTxtBox;
        private TextBox decryptTextTxtBox;
        private TextBox encryptTextTxtBox;
        private Button decryptBtn;
        private Button ecnryptBtn;
        private TabPage logTabPage;
        private TextBox key3TxtBox;
        private TextBox key2TxtBox;
        private TextBox key1TxtBox;
        private Label key3Lbl;
        private TextBox IVTxtBox;
        private Label IVLbl;
        private TextBox logTxtBox;
    }
}
