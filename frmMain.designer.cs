namespace SignatureVerifier
{
    partial class frmMain
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRSAPubKey = new System.Windows.Forms.TabPage();
            this.gbRSAModulus = new System.Windows.Forms.GroupBox();
            this.lbRSAPubExp = new System.Windows.Forms.Label();
            this.tbRSAPubExp = new System.Windows.Forms.TextBox();
            this.lbRSAModulus = new System.Windows.Forms.Label();
            this.tbRSAModulus = new System.Windows.Forms.TextBox();
            this.gbRSACommands = new System.Windows.Forms.GroupBox();
            this.btnRSAImportPem = new System.Windows.Forms.Button();
            this.cbRSAKeyLength = new System.Windows.Forms.ComboBox();
            this.lbRSAKeyLength = new System.Windows.Forms.Label();
            this.btnRSAImportP12 = new System.Windows.Forms.Button();
            this.tabECPubKey = new System.Windows.Forms.TabPage();
            this.gbECPubKey = new System.Windows.Forms.GroupBox();
            this.lbECPubKey = new System.Windows.Forms.Label();
            this.tbECPubKey = new System.Windows.Forms.TextBox();
            this.gbECDomainParameters = new System.Windows.Forms.GroupBox();
            this.lbECParamK = new System.Windows.Forms.Label();
            this.tbECParamK = new System.Windows.Forms.TextBox();
            this.lbECParamR = new System.Windows.Forms.Label();
            this.tbECParamR = new System.Windows.Forms.TextBox();
            this.lbECParamG = new System.Windows.Forms.Label();
            this.tbECParamG = new System.Windows.Forms.TextBox();
            this.lbECParamB = new System.Windows.Forms.Label();
            this.tbECParamB = new System.Windows.Forms.TextBox();
            this.ltbECParamA = new System.Windows.Forms.Label();
            this.tbECParamA = new System.Windows.Forms.TextBox();
            this.gbECReductionPolynomial = new System.Windows.Forms.GroupBox();
            this.rtbECReductionPolynomial = new System.Windows.Forms.RichTextBox();
            this.lbECParamE3 = new System.Windows.Forms.Label();
            this.tbECParamE3 = new System.Windows.Forms.TextBox();
            this.lbECParamE2 = new System.Windows.Forms.Label();
            this.tbECParamE2 = new System.Windows.Forms.TextBox();
            this.lbECParamE1 = new System.Windows.Forms.Label();
            this.tbECParamE1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbECFieldPrime = new System.Windows.Forms.RadioButton();
            this.rbECFieldBinary = new System.Windows.Forms.RadioButton();
            this.lbECParamPrime = new System.Windows.Forms.Label();
            this.tbECParamPrime = new System.Windows.Forms.TextBox();
            this.gbECCommands = new System.Windows.Forms.GroupBox();
            this.btnECImportFromPem = new System.Windows.Forms.Button();
            this.cbECName = new System.Windows.Forms.ComboBox();
            this.lbECName = new System.Windows.Forms.Label();
            this.cbECKeyLength = new System.Windows.Forms.ComboBox();
            this.lbECKeyLength = new System.Windows.Forms.Label();
            this.btnECImportP12 = new System.Windows.Forms.Button();
            this.tabVerify = new System.Windows.Forms.TabPage();
            this.gbSignature = new System.Windows.Forms.GroupBox();
            this.pbVerification = new System.Windows.Forms.ProgressBar();
            this.btnVerifySignature = new System.Windows.Forms.Button();
            this.btnSignatureLoadFromBin = new System.Windows.Forms.Button();
            this.rbSignatureBase64 = new System.Windows.Forms.RadioButton();
            this.rbSignatureHex = new System.Windows.Forms.RadioButton();
            this.lbSignature = new System.Windows.Forms.Label();
            this.tbSignature = new System.Windows.Forms.TextBox();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.btnPlainLoadFromBin = new System.Windows.Forms.Button();
            this.rbMessageFromFile = new System.Windows.Forms.RadioButton();
            this.rbMessageBase64 = new System.Windows.Forms.RadioButton();
            this.rbMessageHex = new System.Windows.Forms.RadioButton();
            this.rbMessageAscii = new System.Windows.Forms.RadioButton();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.gbSignatureParameters = new System.Windows.Forms.GroupBox();
            this.cbCipher = new System.Windows.Forms.ComboBox();
            this.lbCipher = new System.Windows.Forms.Label();
            this.cbDigest = new System.Windows.Forms.ComboBox();
            this.lbDigest = new System.Windows.Forms.Label();
            this.llbDLogicURL = new System.Windows.Forms.LinkLabel();
            this.tabControl.SuspendLayout();
            this.tabRSAPubKey.SuspendLayout();
            this.gbRSAModulus.SuspendLayout();
            this.gbRSACommands.SuspendLayout();
            this.tabECPubKey.SuspendLayout();
            this.gbECPubKey.SuspendLayout();
            this.gbECDomainParameters.SuspendLayout();
            this.gbECReductionPolynomial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbECCommands.SuspendLayout();
            this.tabVerify.SuspendLayout();
            this.gbSignature.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.gbSignatureParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabRSAPubKey);
            this.tabControl.Controls.Add(this.tabECPubKey);
            this.tabControl.Controls.Add(this.tabVerify);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1142, 514);
            this.tabControl.TabIndex = 0;
            // 
            // tabRSAPubKey
            // 
            this.tabRSAPubKey.BackColor = System.Drawing.SystemColors.Control;
            this.tabRSAPubKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabRSAPubKey.Controls.Add(this.gbRSAModulus);
            this.tabRSAPubKey.Controls.Add(this.gbRSACommands);
            this.tabRSAPubKey.Location = new System.Drawing.Point(4, 22);
            this.tabRSAPubKey.Margin = new System.Windows.Forms.Padding(0);
            this.tabRSAPubKey.Name = "tabRSAPubKey";
            this.tabRSAPubKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabRSAPubKey.Size = new System.Drawing.Size(1134, 488);
            this.tabRSAPubKey.TabIndex = 0;
            this.tabRSAPubKey.Text = "RSA public key";
            // 
            // gbRSAModulus
            // 
            this.gbRSAModulus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRSAModulus.Controls.Add(this.lbRSAPubExp);
            this.gbRSAModulus.Controls.Add(this.tbRSAPubExp);
            this.gbRSAModulus.Controls.Add(this.lbRSAModulus);
            this.gbRSAModulus.Controls.Add(this.tbRSAModulus);
            this.gbRSAModulus.Location = new System.Drawing.Point(8, 82);
            this.gbRSAModulus.Margin = new System.Windows.Forms.Padding(8);
            this.gbRSAModulus.Name = "gbRSAModulus";
            this.gbRSAModulus.Size = new System.Drawing.Size(1116, 96);
            this.gbRSAModulus.TabIndex = 1;
            this.gbRSAModulus.TabStop = false;
            this.gbRSAModulus.Text = "Public key:";
            // 
            // lbRSAPubExp
            // 
            this.lbRSAPubExp.AutoSize = true;
            this.lbRSAPubExp.Location = new System.Drawing.Point(6, 62);
            this.lbRSAPubExp.Margin = new System.Windows.Forms.Padding(3);
            this.lbRSAPubExp.Name = "lbRSAPubExp";
            this.lbRSAPubExp.Size = new System.Drawing.Size(55, 13);
            this.lbRSAPubExp.TabIndex = 2;
            this.lbRSAPubExp.Text = "Exponent:";
            // 
            // tbRSAPubExp
            // 
            this.tbRSAPubExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRSAPubExp.BackColor = System.Drawing.SystemColors.Window;
            this.tbRSAPubExp.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRSAPubExp.Location = new System.Drawing.Point(64, 58);
            this.tbRSAPubExp.Margin = new System.Windows.Forms.Padding(0);
            this.tbRSAPubExp.Name = "tbRSAPubExp";
            this.tbRSAPubExp.Size = new System.Drawing.Size(1039, 22);
            this.tbRSAPubExp.TabIndex = 3;
            // 
            // lbRSAModulus
            // 
            this.lbRSAModulus.AutoSize = true;
            this.lbRSAModulus.Location = new System.Drawing.Point(6, 30);
            this.lbRSAModulus.Margin = new System.Windows.Forms.Padding(3);
            this.lbRSAModulus.Name = "lbRSAModulus";
            this.lbRSAModulus.Size = new System.Drawing.Size(50, 13);
            this.lbRSAModulus.TabIndex = 0;
            this.lbRSAModulus.Text = "Modulus:";
            // 
            // tbRSAModulus
            // 
            this.tbRSAModulus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRSAModulus.BackColor = System.Drawing.SystemColors.Window;
            this.tbRSAModulus.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRSAModulus.Location = new System.Drawing.Point(64, 26);
            this.tbRSAModulus.Margin = new System.Windows.Forms.Padding(10);
            this.tbRSAModulus.Name = "tbRSAModulus";
            this.tbRSAModulus.Size = new System.Drawing.Size(1039, 22);
            this.tbRSAModulus.TabIndex = 1;
            // 
            // gbRSACommands
            // 
            this.gbRSACommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRSACommands.Controls.Add(this.btnRSAImportPem);
            this.gbRSACommands.Controls.Add(this.cbRSAKeyLength);
            this.gbRSACommands.Controls.Add(this.lbRSAKeyLength);
            this.gbRSACommands.Controls.Add(this.btnRSAImportP12);
            this.gbRSACommands.Location = new System.Drawing.Point(8, 0);
            this.gbRSACommands.Margin = new System.Windows.Forms.Padding(8);
            this.gbRSACommands.Name = "gbRSACommands";
            this.gbRSACommands.Size = new System.Drawing.Size(1116, 74);
            this.gbRSACommands.TabIndex = 0;
            this.gbRSACommands.TabStop = false;
            // 
            // btnRSAImportPem
            // 
            this.btnRSAImportPem.Location = new System.Drawing.Point(406, 15);
            this.btnRSAImportPem.Margin = new System.Windows.Forms.Padding(0);
            this.btnRSAImportPem.Name = "btnRSAImportPem";
            this.btnRSAImportPem.Size = new System.Drawing.Size(160, 48);
            this.btnRSAImportPem.TabIndex = 4;
            this.btnRSAImportPem.Text = "Import from PEM file";
            this.btnRSAImportPem.UseVisualStyleBackColor = true;
            this.btnRSAImportPem.Click += new System.EventHandler(this.btnRSAImportPem_Click);
            // 
            // cbRSAKeyLength
            // 
            this.cbRSAKeyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRSAKeyLength.FormattingEnabled = true;
            this.cbRSAKeyLength.Items.AddRange(new object[] {
            "512",
            "736",
            "768",
            "896",
            "1024",
            "1280",
            "1536",
            "1984",
            "2048",
            "4096"});
            this.cbRSAKeyLength.Location = new System.Drawing.Point(99, 16);
            this.cbRSAKeyLength.Name = "cbRSAKeyLength";
            this.cbRSAKeyLength.Size = new System.Drawing.Size(124, 21);
            this.cbRSAKeyLength.TabIndex = 3;
            // 
            // lbRSAKeyLength
            // 
            this.lbRSAKeyLength.AutoSize = true;
            this.lbRSAKeyLength.Location = new System.Drawing.Point(8, 19);
            this.lbRSAKeyLength.Name = "lbRSAKeyLength";
            this.lbRSAKeyLength.Size = new System.Drawing.Size(85, 13);
            this.lbRSAKeyLength.TabIndex = 2;
            this.lbRSAKeyLength.Text = "Key length [bits]:";
            // 
            // btnRSAImportP12
            // 
            this.btnRSAImportP12.Location = new System.Drawing.Point(236, 15);
            this.btnRSAImportP12.Margin = new System.Windows.Forms.Padding(10);
            this.btnRSAImportP12.Name = "btnRSAImportP12";
            this.btnRSAImportP12.Size = new System.Drawing.Size(160, 48);
            this.btnRSAImportP12.TabIndex = 0;
            this.btnRSAImportP12.Text = "Import from PKCS#12 file    (.p12 ;  .pfx)";
            this.btnRSAImportP12.UseVisualStyleBackColor = true;
            this.btnRSAImportP12.Click += new System.EventHandler(this.btnRSAImportP12_Click);
            // 
            // tabECPubKey
            // 
            this.tabECPubKey.BackColor = System.Drawing.SystemColors.Control;
            this.tabECPubKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabECPubKey.Controls.Add(this.gbECPubKey);
            this.tabECPubKey.Controls.Add(this.gbECDomainParameters);
            this.tabECPubKey.Controls.Add(this.gbECCommands);
            this.tabECPubKey.Location = new System.Drawing.Point(4, 22);
            this.tabECPubKey.Name = "tabECPubKey";
            this.tabECPubKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabECPubKey.Size = new System.Drawing.Size(1134, 488);
            this.tabECPubKey.TabIndex = 1;
            this.tabECPubKey.Text = "EC public key";
            // 
            // gbECPubKey
            // 
            this.gbECPubKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbECPubKey.Controls.Add(this.lbECPubKey);
            this.gbECPubKey.Controls.Add(this.tbECPubKey);
            this.gbECPubKey.Location = new System.Drawing.Point(8, 373);
            this.gbECPubKey.Margin = new System.Windows.Forms.Padding(8);
            this.gbECPubKey.Name = "gbECPubKey";
            this.gbECPubKey.Size = new System.Drawing.Size(1116, 104);
            this.gbECPubKey.TabIndex = 6;
            this.gbECPubKey.TabStop = false;
            this.gbECPubKey.Text = "EC public key:";
            // 
            // lbECPubKey
            // 
            this.lbECPubKey.AutoSize = true;
            this.lbECPubKey.Location = new System.Drawing.Point(8, 48);
            this.lbECPubKey.Margin = new System.Windows.Forms.Padding(3);
            this.lbECPubKey.Name = "lbECPubKey";
            this.lbECPubKey.Size = new System.Drawing.Size(39, 13);
            this.lbECPubKey.TabIndex = 17;
            this.lbECPubKey.Text = "W(uc):";
            // 
            // tbECPubKey
            // 
            this.tbECPubKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECPubKey.BackColor = System.Drawing.SystemColors.Window;
            this.tbECPubKey.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECPubKey.Location = new System.Drawing.Point(53, 22);
            this.tbECPubKey.Multiline = true;
            this.tbECPubKey.Name = "tbECPubKey";
            this.tbECPubKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbECPubKey.Size = new System.Drawing.Size(1049, 65);
            this.tbECPubKey.TabIndex = 18;
            // 
            // gbECDomainParameters
            // 
            this.gbECDomainParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbECDomainParameters.Controls.Add(this.lbECParamK);
            this.gbECDomainParameters.Controls.Add(this.tbECParamK);
            this.gbECDomainParameters.Controls.Add(this.lbECParamR);
            this.gbECDomainParameters.Controls.Add(this.tbECParamR);
            this.gbECDomainParameters.Controls.Add(this.lbECParamG);
            this.gbECDomainParameters.Controls.Add(this.tbECParamG);
            this.gbECDomainParameters.Controls.Add(this.lbECParamB);
            this.gbECDomainParameters.Controls.Add(this.tbECParamB);
            this.gbECDomainParameters.Controls.Add(this.ltbECParamA);
            this.gbECDomainParameters.Controls.Add(this.tbECParamA);
            this.gbECDomainParameters.Controls.Add(this.gbECReductionPolynomial);
            this.gbECDomainParameters.Controls.Add(this.groupBox1);
            this.gbECDomainParameters.Controls.Add(this.lbECParamPrime);
            this.gbECDomainParameters.Controls.Add(this.tbECParamPrime);
            this.gbECDomainParameters.Location = new System.Drawing.Point(7, 82);
            this.gbECDomainParameters.Margin = new System.Windows.Forms.Padding(0);
            this.gbECDomainParameters.Name = "gbECDomainParameters";
            this.gbECDomainParameters.Size = new System.Drawing.Size(1116, 283);
            this.gbECDomainParameters.TabIndex = 4;
            this.gbECDomainParameters.TabStop = false;
            this.gbECDomainParameters.Text = "EC domain parameters:";
            // 
            // lbECParamK
            // 
            this.lbECParamK.AutoSize = true;
            this.lbECParamK.Location = new System.Drawing.Point(260, 239);
            this.lbECParamK.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamK.Name = "lbECParamK";
            this.lbECParamK.Size = new System.Drawing.Size(17, 13);
            this.lbECParamK.TabIndex = 19;
            this.lbECParamK.Text = "K:";
            // 
            // tbECParamK
            // 
            this.tbECParamK.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamK.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamK.Location = new System.Drawing.Point(284, 235);
            this.tbECParamK.Margin = new System.Windows.Forms.Padding(0);
            this.tbECParamK.Name = "tbECParamK";
            this.tbECParamK.ReadOnly = true;
            this.tbECParamK.Size = new System.Drawing.Size(139, 22);
            this.tbECParamK.TabIndex = 20;
            // 
            // lbECParamR
            // 
            this.lbECParamR.AutoSize = true;
            this.lbECParamR.Location = new System.Drawing.Point(260, 207);
            this.lbECParamR.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamR.Name = "lbECParamR";
            this.lbECParamR.Size = new System.Drawing.Size(18, 13);
            this.lbECParamR.TabIndex = 17;
            this.lbECParamR.Text = "R:";
            // 
            // tbECParamR
            // 
            this.tbECParamR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECParamR.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamR.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamR.Location = new System.Drawing.Point(284, 203);
            this.tbECParamR.Margin = new System.Windows.Forms.Padding(10);
            this.tbECParamR.Name = "tbECParamR";
            this.tbECParamR.ReadOnly = true;
            this.tbECParamR.Size = new System.Drawing.Size(819, 22);
            this.tbECParamR.TabIndex = 18;
            // 
            // lbECParamG
            // 
            this.lbECParamG.AutoSize = true;
            this.lbECParamG.Location = new System.Drawing.Point(242, 152);
            this.lbECParamG.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamG.Name = "lbECParamG";
            this.lbECParamG.Size = new System.Drawing.Size(36, 13);
            this.lbECParamG.TabIndex = 15;
            this.lbECParamG.Text = "G(uc):";
            // 
            // tbECParamG
            // 
            this.tbECParamG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECParamG.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamG.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamG.Location = new System.Drawing.Point(284, 126);
            this.tbECParamG.Margin = new System.Windows.Forms.Padding(0);
            this.tbECParamG.Multiline = true;
            this.tbECParamG.Name = "tbECParamG";
            this.tbECParamG.ReadOnly = true;
            this.tbECParamG.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbECParamG.Size = new System.Drawing.Size(819, 65);
            this.tbECParamG.TabIndex = 16;
            // 
            // lbECParamB
            // 
            this.lbECParamB.AutoSize = true;
            this.lbECParamB.Location = new System.Drawing.Point(212, 94);
            this.lbECParamB.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamB.Name = "lbECParamB";
            this.lbECParamB.Size = new System.Drawing.Size(16, 13);
            this.lbECParamB.TabIndex = 13;
            this.lbECParamB.Text = "b:";
            // 
            // tbECParamB
            // 
            this.tbECParamB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECParamB.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamB.Location = new System.Drawing.Point(233, 90);
            this.tbECParamB.Margin = new System.Windows.Forms.Padding(14);
            this.tbECParamB.Name = "tbECParamB";
            this.tbECParamB.ReadOnly = true;
            this.tbECParamB.Size = new System.Drawing.Size(870, 22);
            this.tbECParamB.TabIndex = 14;
            // 
            // ltbECParamA
            // 
            this.ltbECParamA.AutoSize = true;
            this.ltbECParamA.Location = new System.Drawing.Point(212, 64);
            this.ltbECParamA.Margin = new System.Windows.Forms.Padding(3);
            this.ltbECParamA.Name = "ltbECParamA";
            this.ltbECParamA.Size = new System.Drawing.Size(16, 13);
            this.ltbECParamA.TabIndex = 11;
            this.ltbECParamA.Text = "a:";
            // 
            // tbECParamA
            // 
            this.tbECParamA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECParamA.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamA.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamA.Location = new System.Drawing.Point(233, 60);
            this.tbECParamA.Margin = new System.Windows.Forms.Padding(10);
            this.tbECParamA.Name = "tbECParamA";
            this.tbECParamA.ReadOnly = true;
            this.tbECParamA.Size = new System.Drawing.Size(870, 22);
            this.tbECParamA.TabIndex = 12;
            // 
            // gbECReductionPolynomial
            // 
            this.gbECReductionPolynomial.Controls.Add(this.rtbECReductionPolynomial);
            this.gbECReductionPolynomial.Controls.Add(this.lbECParamE3);
            this.gbECReductionPolynomial.Controls.Add(this.tbECParamE3);
            this.gbECReductionPolynomial.Controls.Add(this.lbECParamE2);
            this.gbECReductionPolynomial.Controls.Add(this.tbECParamE2);
            this.gbECReductionPolynomial.Controls.Add(this.lbECParamE1);
            this.gbECReductionPolynomial.Controls.Add(this.tbECParamE1);
            this.gbECReductionPolynomial.Enabled = false;
            this.gbECReductionPolynomial.Location = new System.Drawing.Point(11, 120);
            this.gbECReductionPolynomial.Margin = new System.Windows.Forms.Padding(8);
            this.gbECReductionPolynomial.Name = "gbECReductionPolynomial";
            this.gbECReductionPolynomial.Size = new System.Drawing.Size(220, 151);
            this.gbECReductionPolynomial.TabIndex = 10;
            this.gbECReductionPolynomial.TabStop = false;
            this.gbECReductionPolynomial.Text = "Reduction polynomial:";
            // 
            // rtbECReductionPolynomial
            // 
            this.rtbECReductionPolynomial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbECReductionPolynomial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbECReductionPolynomial.Location = new System.Drawing.Point(12, 22);
            this.rtbECReductionPolynomial.Multiline = false;
            this.rtbECReductionPolynomial.Name = "rtbECReductionPolynomial";
            this.rtbECReductionPolynomial.ReadOnly = true;
            this.rtbECReductionPolynomial.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbECReductionPolynomial.Size = new System.Drawing.Size(202, 29);
            this.rtbECReductionPolynomial.TabIndex = 17;
            this.rtbECReductionPolynomial.Text = " f(x) = ";
            // 
            // lbECParamE3
            // 
            this.lbECParamE3.AutoSize = true;
            this.lbECParamE3.Location = new System.Drawing.Point(12, 119);
            this.lbECParamE3.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamE3.Name = "lbECParamE3";
            this.lbECParamE3.Size = new System.Drawing.Size(22, 13);
            this.lbECParamE3.TabIndex = 15;
            this.lbECParamE3.Text = "e3:";
            // 
            // tbECParamE3
            // 
            this.tbECParamE3.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamE3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamE3.Location = new System.Drawing.Point(41, 115);
            this.tbECParamE3.Margin = new System.Windows.Forms.Padding(0);
            this.tbECParamE3.Name = "tbECParamE3";
            this.tbECParamE3.ReadOnly = true;
            this.tbECParamE3.Size = new System.Drawing.Size(139, 22);
            this.tbECParamE3.TabIndex = 16;
            // 
            // lbECParamE2
            // 
            this.lbECParamE2.AutoSize = true;
            this.lbECParamE2.Location = new System.Drawing.Point(12, 87);
            this.lbECParamE2.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamE2.Name = "lbECParamE2";
            this.lbECParamE2.Size = new System.Drawing.Size(22, 13);
            this.lbECParamE2.TabIndex = 13;
            this.lbECParamE2.Text = "e2:";
            // 
            // tbECParamE2
            // 
            this.tbECParamE2.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamE2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamE2.Location = new System.Drawing.Point(41, 83);
            this.tbECParamE2.Margin = new System.Windows.Forms.Padding(10);
            this.tbECParamE2.Name = "tbECParamE2";
            this.tbECParamE2.ReadOnly = true;
            this.tbECParamE2.Size = new System.Drawing.Size(139, 22);
            this.tbECParamE2.TabIndex = 14;
            // 
            // lbECParamE1
            // 
            this.lbECParamE1.AutoSize = true;
            this.lbECParamE1.Location = new System.Drawing.Point(12, 55);
            this.lbECParamE1.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamE1.Name = "lbECParamE1";
            this.lbECParamE1.Size = new System.Drawing.Size(22, 13);
            this.lbECParamE1.TabIndex = 11;
            this.lbECParamE1.Text = "e1:";
            // 
            // tbECParamE1
            // 
            this.tbECParamE1.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamE1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamE1.Location = new System.Drawing.Point(41, 51);
            this.tbECParamE1.Margin = new System.Windows.Forms.Padding(10);
            this.tbECParamE1.Name = "tbECParamE1";
            this.tbECParamE1.ReadOnly = true;
            this.tbECParamE1.Size = new System.Drawing.Size(139, 22);
            this.tbECParamE1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbECFieldPrime);
            this.groupBox1.Controls.Add(this.rbECFieldBinary);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(11, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EC over field:";
            // 
            // rbECFieldPrime
            // 
            this.rbECFieldPrime.AutoSize = true;
            this.rbECFieldPrime.Checked = true;
            this.rbECFieldPrime.Location = new System.Drawing.Point(12, 26);
            this.rbECFieldPrime.Margin = new System.Windows.Forms.Padding(10);
            this.rbECFieldPrime.Name = "rbECFieldPrime";
            this.rbECFieldPrime.Size = new System.Drawing.Size(102, 17);
            this.rbECFieldPrime.TabIndex = 0;
            this.rbECFieldPrime.TabStop = true;
            this.rbECFieldPrime.Text = "Prime field { Fp }";
            this.rbECFieldPrime.UseVisualStyleBackColor = true;
            this.rbECFieldPrime.CheckedChanged += new System.EventHandler(this.rbECFieldPrime_CheckedChanged);
            // 
            // rbECFieldBinary
            // 
            this.rbECFieldBinary.AutoSize = true;
            this.rbECFieldBinary.Location = new System.Drawing.Point(12, 53);
            this.rbECFieldBinary.Margin = new System.Windows.Forms.Padding(0);
            this.rbECFieldBinary.Name = "rbECFieldBinary";
            this.rbECFieldBinary.Size = new System.Drawing.Size(113, 17);
            this.rbECFieldBinary.TabIndex = 1;
            this.rbECFieldBinary.Text = "Binary field { F2m }";
            this.rbECFieldBinary.UseVisualStyleBackColor = true;
            this.rbECFieldBinary.CheckedChanged += new System.EventHandler(this.rbECFieldBinary_CheckedChanged);
            // 
            // lbECParamPrime
            // 
            this.lbECParamPrime.AutoSize = true;
            this.lbECParamPrime.Location = new System.Drawing.Point(212, 34);
            this.lbECParamPrime.Margin = new System.Windows.Forms.Padding(3);
            this.lbECParamPrime.Name = "lbECParamPrime";
            this.lbECParamPrime.Size = new System.Drawing.Size(16, 13);
            this.lbECParamPrime.TabIndex = 0;
            this.lbECParamPrime.Text = "p:";
            // 
            // tbECParamPrime
            // 
            this.tbECParamPrime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbECParamPrime.BackColor = System.Drawing.SystemColors.Window;
            this.tbECParamPrime.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbECParamPrime.Location = new System.Drawing.Point(233, 30);
            this.tbECParamPrime.Margin = new System.Windows.Forms.Padding(10);
            this.tbECParamPrime.Name = "tbECParamPrime";
            this.tbECParamPrime.ReadOnly = true;
            this.tbECParamPrime.Size = new System.Drawing.Size(870, 22);
            this.tbECParamPrime.TabIndex = 1;
            // 
            // gbECCommands
            // 
            this.gbECCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbECCommands.Controls.Add(this.btnECImportFromPem);
            this.gbECCommands.Controls.Add(this.cbECName);
            this.gbECCommands.Controls.Add(this.lbECName);
            this.gbECCommands.Controls.Add(this.cbECKeyLength);
            this.gbECCommands.Controls.Add(this.lbECKeyLength);
            this.gbECCommands.Controls.Add(this.btnECImportP12);
            this.gbECCommands.Location = new System.Drawing.Point(8, 0);
            this.gbECCommands.Margin = new System.Windows.Forms.Padding(8);
            this.gbECCommands.Name = "gbECCommands";
            this.gbECCommands.Size = new System.Drawing.Size(1116, 74);
            this.gbECCommands.TabIndex = 1;
            this.gbECCommands.TabStop = false;
            // 
            // btnECImportFromPem
            // 
            this.btnECImportFromPem.Location = new System.Drawing.Point(406, 15);
            this.btnECImportFromPem.Margin = new System.Windows.Forms.Padding(0);
            this.btnECImportFromPem.Name = "btnECImportFromPem";
            this.btnECImportFromPem.Size = new System.Drawing.Size(160, 48);
            this.btnECImportFromPem.TabIndex = 10;
            this.btnECImportFromPem.Text = "Import from PEM file";
            this.btnECImportFromPem.UseVisualStyleBackColor = true;
            this.btnECImportFromPem.Click += new System.EventHandler(this.btnECImportFromPem_Click);
            // 
            // cbECName
            // 
            this.cbECName.DropDownHeight = 432;
            this.cbECName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbECName.FormattingEnabled = true;
            this.cbECName.IntegralHeight = false;
            this.cbECName.Items.AddRange(new object[] {
            "secp112r1",
            "secp112r2",
            "secp128r1",
            "secp128r2",
            "secp160k1",
            "secp160r1",
            "secp160r2",
            "secp192k1",
            "secp192r1",
            "secp224k1",
            "secp224r1",
            "secp256k1",
            "secp256r1",
            "secp384r1",
            "secp521r1",
            "sect113r1",
            "sect113r2",
            "sect131r1",
            "sect131r2",
            "sect163k1",
            "sect163r1",
            "sect163r2",
            "sect193r1",
            "sect193r2",
            "sect233k1",
            "sect233r1",
            "sect239k1",
            "sect283k1",
            "sect283r1",
            "sect409k1",
            "sect409r1",
            "sect571k1",
            "sect571r1"});
            this.cbECName.Location = new System.Drawing.Point(99, 16);
            this.cbECName.Margin = new System.Windows.Forms.Padding(2);
            this.cbECName.Name = "cbECName";
            this.cbECName.Size = new System.Drawing.Size(124, 21);
            this.cbECName.TabIndex = 9;
            this.cbECName.SelectedIndexChanged += new System.EventHandler(this.cbECName_SelectedIndexChanged);
            // 
            // lbECName
            // 
            this.lbECName.AutoSize = true;
            this.lbECName.Location = new System.Drawing.Point(8, 19);
            this.lbECName.Name = "lbECName";
            this.lbECName.Size = new System.Drawing.Size(67, 13);
            this.lbECName.TabIndex = 8;
            this.lbECName.Text = "Curve name:";
            // 
            // cbECKeyLength
            // 
            this.cbECKeyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbECKeyLength.FormattingEnabled = true;
            this.cbECKeyLength.Items.AddRange(new object[] {
            "112",
            "113",
            "128",
            "131",
            "160",
            "163",
            "192",
            "193",
            "224",
            "233",
            "239",
            "256",
            "283",
            "384",
            "409",
            "521",
            "571"});
            this.cbECKeyLength.Location = new System.Drawing.Point(99, 42);
            this.cbECKeyLength.Name = "cbECKeyLength";
            this.cbECKeyLength.Size = new System.Drawing.Size(124, 21);
            this.cbECKeyLength.TabIndex = 3;
            this.cbECKeyLength.SelectedIndexChanged += new System.EventHandler(this.cbECKeyLength_SelectedIndexChanged);
            // 
            // lbECKeyLength
            // 
            this.lbECKeyLength.AutoSize = true;
            this.lbECKeyLength.Location = new System.Drawing.Point(8, 45);
            this.lbECKeyLength.Name = "lbECKeyLength";
            this.lbECKeyLength.Size = new System.Drawing.Size(85, 13);
            this.lbECKeyLength.TabIndex = 2;
            this.lbECKeyLength.Text = "Key length [bits]:";
            // 
            // btnECImportP12
            // 
            this.btnECImportP12.Location = new System.Drawing.Point(236, 15);
            this.btnECImportP12.Margin = new System.Windows.Forms.Padding(10);
            this.btnECImportP12.Name = "btnECImportP12";
            this.btnECImportP12.Size = new System.Drawing.Size(160, 48);
            this.btnECImportP12.TabIndex = 0;
            this.btnECImportP12.Text = "Import from PKCS#12 file    (.p12 ;  .pfx)";
            this.btnECImportP12.UseVisualStyleBackColor = true;
            this.btnECImportP12.Click += new System.EventHandler(this.btnECImportP12_Click);
            // 
            // tabVerify
            // 
            this.tabVerify.BackColor = System.Drawing.SystemColors.Control;
            this.tabVerify.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabVerify.Controls.Add(this.gbSignature);
            this.tabVerify.Controls.Add(this.gbMessage);
            this.tabVerify.Controls.Add(this.gbSignatureParameters);
            this.tabVerify.Location = new System.Drawing.Point(4, 22);
            this.tabVerify.Name = "tabVerify";
            this.tabVerify.Size = new System.Drawing.Size(1134, 488);
            this.tabVerify.TabIndex = 3;
            this.tabVerify.Text = "Verify signature";
            // 
            // gbSignature
            // 
            this.gbSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSignature.Controls.Add(this.pbVerification);
            this.gbSignature.Controls.Add(this.btnVerifySignature);
            this.gbSignature.Controls.Add(this.btnSignatureLoadFromBin);
            this.gbSignature.Controls.Add(this.rbSignatureBase64);
            this.gbSignature.Controls.Add(this.rbSignatureHex);
            this.gbSignature.Controls.Add(this.lbSignature);
            this.gbSignature.Controls.Add(this.tbSignature);
            this.gbSignature.Location = new System.Drawing.Point(8, 219);
            this.gbSignature.Margin = new System.Windows.Forms.Padding(8);
            this.gbSignature.Name = "gbSignature";
            this.gbSignature.Size = new System.Drawing.Size(1116, 137);
            this.gbSignature.TabIndex = 24;
            this.gbSignature.TabStop = false;
            this.gbSignature.Text = "Signature:";
            // 
            // pbVerification
            // 
            this.pbVerification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVerification.Location = new System.Drawing.Point(69, 118);
            this.pbVerification.Maximum = 1000;
            this.pbVerification.Name = "pbVerification";
            this.pbVerification.Size = new System.Drawing.Size(1033, 10);
            this.pbVerification.Step = 1;
            this.pbVerification.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVerification.TabIndex = 31;
            // 
            // btnVerifySignature
            // 
            this.btnVerifySignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerifySignature.BackColor = System.Drawing.Color.LightBlue;
            this.btnVerifySignature.Location = new System.Drawing.Point(942, 19);
            this.btnVerifySignature.Margin = new System.Windows.Forms.Padding(0);
            this.btnVerifySignature.Name = "btnVerifySignature";
            this.btnVerifySignature.Size = new System.Drawing.Size(160, 21);
            this.btnVerifySignature.TabIndex = 30;
            this.btnVerifySignature.Text = "Verify signature";
            this.btnVerifySignature.UseVisualStyleBackColor = false;
            this.btnVerifySignature.Click += new System.EventHandler(this.btnVerifySignature_Click);
            // 
            // btnSignatureLoadFromBin
            // 
            this.btnSignatureLoadFromBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignatureLoadFromBin.Location = new System.Drawing.Point(772, 19);
            this.btnSignatureLoadFromBin.Margin = new System.Windows.Forms.Padding(0);
            this.btnSignatureLoadFromBin.Name = "btnSignatureLoadFromBin";
            this.btnSignatureLoadFromBin.Size = new System.Drawing.Size(160, 21);
            this.btnSignatureLoadFromBin.TabIndex = 29;
            this.btnSignatureLoadFromBin.Text = "Load signature from binary file";
            this.btnSignatureLoadFromBin.UseVisualStyleBackColor = true;
            this.btnSignatureLoadFromBin.Click += new System.EventHandler(this.btnSignatureLoadFromBin_Click);
            // 
            // rbSignatureBase64
            // 
            this.rbSignatureBase64.AutoSize = true;
            this.rbSignatureBase64.Location = new System.Drawing.Point(122, 24);
            this.rbSignatureBase64.Name = "rbSignatureBase64";
            this.rbSignatureBase64.Size = new System.Drawing.Size(61, 17);
            this.rbSignatureBase64.TabIndex = 22;
            this.rbSignatureBase64.TabStop = true;
            this.rbSignatureBase64.Text = "Base64";
            this.rbSignatureBase64.UseVisualStyleBackColor = true;
            this.rbSignatureBase64.Click += new System.EventHandler(this.tbSignatureRadixChanged);
            // 
            // rbSignatureHex
            // 
            this.rbSignatureHex.AutoSize = true;
            this.rbSignatureHex.Checked = true;
            this.rbSignatureHex.Location = new System.Drawing.Point(69, 24);
            this.rbSignatureHex.Name = "rbSignatureHex";
            this.rbSignatureHex.Size = new System.Drawing.Size(47, 17);
            this.rbSignatureHex.TabIndex = 21;
            this.rbSignatureHex.TabStop = true;
            this.rbSignatureHex.Text = "HEX";
            this.rbSignatureHex.UseVisualStyleBackColor = true;
            this.rbSignatureHex.Click += new System.EventHandler(this.tbSignatureRadixChanged);
            // 
            // lbSignature
            // 
            this.lbSignature.AutoSize = true;
            this.lbSignature.Location = new System.Drawing.Point(8, 73);
            this.lbSignature.Margin = new System.Windows.Forms.Padding(3);
            this.lbSignature.Name = "lbSignature";
            this.lbSignature.Size = new System.Drawing.Size(55, 13);
            this.lbSignature.TabIndex = 17;
            this.lbSignature.Text = "Signature:";
            // 
            // tbSignature
            // 
            this.tbSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSignature.BackColor = System.Drawing.SystemColors.Window;
            this.tbSignature.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSignature.Location = new System.Drawing.Point(69, 47);
            this.tbSignature.Multiline = true;
            this.tbSignature.Name = "tbSignature";
            this.tbSignature.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbSignature.Size = new System.Drawing.Size(1033, 65);
            this.tbSignature.TabIndex = 18;
            // 
            // gbMessage
            // 
            this.gbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMessage.Controls.Add(this.btnPlainLoadFromBin);
            this.gbMessage.Controls.Add(this.rbMessageFromFile);
            this.gbMessage.Controls.Add(this.rbMessageBase64);
            this.gbMessage.Controls.Add(this.rbMessageHex);
            this.gbMessage.Controls.Add(this.rbMessageAscii);
            this.gbMessage.Controls.Add(this.lbMessage);
            this.gbMessage.Controls.Add(this.tbMessage);
            this.gbMessage.Location = new System.Drawing.Point(8, 84);
            this.gbMessage.Margin = new System.Windows.Forms.Padding(0);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(1116, 127);
            this.gbMessage.TabIndex = 7;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Plain text (message for verification):";
            // 
            // btnPlainLoadFromBin
            // 
            this.btnPlainLoadFromBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlainLoadFromBin.Location = new System.Drawing.Point(942, 20);
            this.btnPlainLoadFromBin.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlainLoadFromBin.Name = "btnPlainLoadFromBin";
            this.btnPlainLoadFromBin.Size = new System.Drawing.Size(160, 21);
            this.btnPlainLoadFromBin.TabIndex = 30;
            this.btnPlainLoadFromBin.Text = "Load message from binary file";
            this.btnPlainLoadFromBin.UseVisualStyleBackColor = true;
            this.btnPlainLoadFromBin.Click += new System.EventHandler(this.btnPlainLoadFromBin_Click);
            // 
            // rbMessageFromFile
            // 
            this.rbMessageFromFile.AutoSize = true;
            this.rbMessageFromFile.Location = new System.Drawing.Point(211, 24);
            this.rbMessageFromFile.Name = "rbMessageFromFile";
            this.rbMessageFromFile.Size = new System.Drawing.Size(379, 17);
            this.rbMessageFromFile.TabIndex = 23;
            this.rbMessageFromFile.TabStop = true;
            this.rbMessageFromFile.Text = "Set file for verification (ATTENTION: it will remove any message text below)";
            this.rbMessageFromFile.UseVisualStyleBackColor = true;
            this.rbMessageFromFile.Click += new System.EventHandler(this.tbMessageRadixChanged);
            // 
            // rbMessageBase64
            // 
            this.rbMessageBase64.AutoSize = true;
            this.rbMessageBase64.Location = new System.Drawing.Point(86, 24);
            this.rbMessageBase64.Name = "rbMessageBase64";
            this.rbMessageBase64.Size = new System.Drawing.Size(61, 17);
            this.rbMessageBase64.TabIndex = 22;
            this.rbMessageBase64.TabStop = true;
            this.rbMessageBase64.Text = "Base64";
            this.rbMessageBase64.UseVisualStyleBackColor = true;
            this.rbMessageBase64.Click += new System.EventHandler(this.tbMessageRadixChanged);
            // 
            // rbMessageHex
            // 
            this.rbMessageHex.AutoSize = true;
            this.rbMessageHex.Checked = true;
            this.rbMessageHex.Location = new System.Drawing.Point(33, 24);
            this.rbMessageHex.Name = "rbMessageHex";
            this.rbMessageHex.Size = new System.Drawing.Size(47, 17);
            this.rbMessageHex.TabIndex = 21;
            this.rbMessageHex.TabStop = true;
            this.rbMessageHex.Text = "HEX";
            this.rbMessageHex.UseVisualStyleBackColor = true;
            this.rbMessageHex.Click += new System.EventHandler(this.tbMessageRadixChanged);
            // 
            // rbMessageAscii
            // 
            this.rbMessageAscii.AutoSize = true;
            this.rbMessageAscii.Location = new System.Drawing.Point(153, 24);
            this.rbMessageAscii.Name = "rbMessageAscii";
            this.rbMessageAscii.Size = new System.Drawing.Size(52, 17);
            this.rbMessageAscii.TabIndex = 20;
            this.rbMessageAscii.Text = "ASCII";
            this.rbMessageAscii.UseVisualStyleBackColor = true;
            this.rbMessageAscii.Click += new System.EventHandler(this.tbMessageRadixChanged);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(8, 73);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(3);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(19, 13);
            this.lbMessage.TabIndex = 17;
            this.lbMessage.Text = "M:";
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.BackColor = System.Drawing.SystemColors.Window;
            this.tbMessage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMessage.Location = new System.Drawing.Point(33, 47);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbMessage.Size = new System.Drawing.Size(1069, 65);
            this.tbMessage.TabIndex = 18;
            // 
            // gbSignatureParameters
            // 
            this.gbSignatureParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSignatureParameters.Controls.Add(this.cbCipher);
            this.gbSignatureParameters.Controls.Add(this.lbCipher);
            this.gbSignatureParameters.Controls.Add(this.cbDigest);
            this.gbSignatureParameters.Controls.Add(this.lbDigest);
            this.gbSignatureParameters.Location = new System.Drawing.Point(8, 0);
            this.gbSignatureParameters.Margin = new System.Windows.Forms.Padding(8);
            this.gbSignatureParameters.Name = "gbSignatureParameters";
            this.gbSignatureParameters.Size = new System.Drawing.Size(1116, 76);
            this.gbSignatureParameters.TabIndex = 2;
            this.gbSignatureParameters.TabStop = false;
            // 
            // cbCipher
            // 
            this.cbCipher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCipher.FormattingEnabled = true;
            this.cbCipher.Items.AddRange(new object[] {
            "RSA",
            "ECDSA"});
            this.cbCipher.Location = new System.Drawing.Point(99, 42);
            this.cbCipher.Name = "cbCipher";
            this.cbCipher.Size = new System.Drawing.Size(124, 21);
            this.cbCipher.TabIndex = 9;
            // 
            // lbCipher
            // 
            this.lbCipher.AutoSize = true;
            this.lbCipher.Location = new System.Drawing.Point(8, 45);
            this.lbCipher.Name = "lbCipher";
            this.lbCipher.Size = new System.Drawing.Size(85, 13);
            this.lbCipher.TabIndex = 8;
            this.lbCipher.Text = "Cipher algorithm:";
            // 
            // cbDigest
            // 
            this.cbDigest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDigest.FormattingEnabled = true;
            this.cbDigest.Items.AddRange(new object[] {
            "None",
            "SHA-1",
            "SHA-224",
            "SHA-256",
            "SHA-384",
            "SHA-512"});
            this.cbDigest.Location = new System.Drawing.Point(143, 16);
            this.cbDigest.Name = "cbDigest";
            this.cbDigest.Size = new System.Drawing.Size(80, 21);
            this.cbDigest.TabIndex = 9;
            // 
            // lbDigest
            // 
            this.lbDigest.AutoSize = true;
            this.lbDigest.Location = new System.Drawing.Point(8, 19);
            this.lbDigest.Name = "lbDigest";
            this.lbDigest.Size = new System.Drawing.Size(129, 13);
            this.lbDigest.TabIndex = 8;
            this.lbDigest.Text = "Message digest algorithm:";
            // 
            // llbDLogicURL
            // 
            this.llbDLogicURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbDLogicURL.Location = new System.Drawing.Point(690, 7);
            this.llbDLogicURL.Name = "llbDLogicURL";
            this.llbDLogicURL.Size = new System.Drawing.Size(460, 24);
            this.llbDLogicURL.TabIndex = 1;
            this.llbDLogicURL.TabStop = true;
            this.llbDLogicURL.Text = "http://www.d-logic.net/nfc-rfid-reader-sdk/";
            this.llbDLogicURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llbDLogicURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDLogicURL_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 537);
            this.Controls.Add(this.llbDLogicURL);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(1040, 576);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digital Signature Verifier";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl.ResumeLayout(false);
            this.tabRSAPubKey.ResumeLayout(false);
            this.gbRSAModulus.ResumeLayout(false);
            this.gbRSAModulus.PerformLayout();
            this.gbRSACommands.ResumeLayout(false);
            this.gbRSACommands.PerformLayout();
            this.tabECPubKey.ResumeLayout(false);
            this.gbECPubKey.ResumeLayout(false);
            this.gbECPubKey.PerformLayout();
            this.gbECDomainParameters.ResumeLayout(false);
            this.gbECDomainParameters.PerformLayout();
            this.gbECReductionPolynomial.ResumeLayout(false);
            this.gbECReductionPolynomial.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbECCommands.ResumeLayout(false);
            this.gbECCommands.PerformLayout();
            this.tabVerify.ResumeLayout(false);
            this.gbSignature.ResumeLayout(false);
            this.gbSignature.PerformLayout();
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.gbSignatureParameters.ResumeLayout(false);
            this.gbSignatureParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRSAPubKey;
        private System.Windows.Forms.TabPage tabECPubKey;
        private System.Windows.Forms.TabPage tabVerify;
        private System.Windows.Forms.Label lbRSAKeyLength;
        private System.Windows.Forms.LinkLabel llbDLogicURL;
        private System.Windows.Forms.ComboBox cbRSAKeyLength;
        private System.Windows.Forms.GroupBox gbRSACommands;
        private System.Windows.Forms.Button btnRSAImportP12;
        private System.Windows.Forms.GroupBox gbRSAModulus;
        private System.Windows.Forms.Label lbRSAModulus;
        private System.Windows.Forms.TextBox tbRSAModulus;
        private System.Windows.Forms.GroupBox gbECCommands;
        private System.Windows.Forms.ComboBox cbECKeyLength;
        private System.Windows.Forms.Label lbECKeyLength;
        private System.Windows.Forms.Button btnECImportP12;
        private System.Windows.Forms.ComboBox cbECName;
        private System.Windows.Forms.Label lbECName;
        private System.Windows.Forms.GroupBox gbECDomainParameters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbECFieldPrime;
        private System.Windows.Forms.RadioButton rbECFieldBinary;
        private System.Windows.Forms.Label lbECParamPrime;
        private System.Windows.Forms.TextBox tbECParamPrime;
        private System.Windows.Forms.GroupBox gbECReductionPolynomial;
        private System.Windows.Forms.RichTextBox rtbECReductionPolynomial;
        private System.Windows.Forms.Label lbECParamE3;
        private System.Windows.Forms.TextBox tbECParamE3;
        private System.Windows.Forms.Label lbECParamE2;
        private System.Windows.Forms.TextBox tbECParamE2;
        private System.Windows.Forms.Label lbECParamE1;
        private System.Windows.Forms.TextBox tbECParamE1;
        private System.Windows.Forms.Label lbECParamK;
        private System.Windows.Forms.TextBox tbECParamK;
        private System.Windows.Forms.Label lbECParamR;
        private System.Windows.Forms.TextBox tbECParamR;
        private System.Windows.Forms.Label lbECParamG;
        private System.Windows.Forms.TextBox tbECParamG;
        private System.Windows.Forms.Label lbECParamB;
        private System.Windows.Forms.TextBox tbECParamB;
        private System.Windows.Forms.Label ltbECParamA;
        private System.Windows.Forms.TextBox tbECParamA;
        private System.Windows.Forms.GroupBox gbECPubKey;
        private System.Windows.Forms.Label lbECPubKey;
        private System.Windows.Forms.TextBox tbECPubKey;
        private System.Windows.Forms.GroupBox gbSignatureParameters;
        private System.Windows.Forms.ComboBox cbDigest;
        private System.Windows.Forms.Label lbDigest;
        private System.Windows.Forms.ComboBox cbCipher;
        private System.Windows.Forms.Label lbCipher;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.RadioButton rbMessageFromFile;
        private System.Windows.Forms.RadioButton rbMessageBase64;
        private System.Windows.Forms.RadioButton rbMessageHex;
        private System.Windows.Forms.RadioButton rbMessageAscii;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.GroupBox gbSignature;
        private System.Windows.Forms.RadioButton rbSignatureBase64;
        private System.Windows.Forms.RadioButton rbSignatureHex;
        private System.Windows.Forms.Label lbSignature;
        private System.Windows.Forms.TextBox tbSignature;
        private System.Windows.Forms.Label lbRSAPubExp;
        private System.Windows.Forms.TextBox tbRSAPubExp;
        private System.Windows.Forms.Button btnSignatureLoadFromBin;
        private System.Windows.Forms.Button btnVerifySignature;
        private System.Windows.Forms.Button btnPlainLoadFromBin;
        private System.Windows.Forms.Button btnRSAImportPem;
        private System.Windows.Forms.Button btnECImportFromPem;
        private System.Windows.Forms.ProgressBar pbVerification;
    }
}

