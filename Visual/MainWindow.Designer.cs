using System.ComponentModel;
using System.Windows.Forms;

namespace Cryptage.Visual
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactereNontraduisiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conserverSpecCharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignorerSpecCharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miseEnPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normaleLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motParMotLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traductionUniquementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalEtTraductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeAéronautiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeBinaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeDeCésarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeMorseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeNavajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleDeVigenèreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableDeVigenereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.algoLabel = new System.Windows.Forms.Label();
            this.cesarCheckBox = new System.Windows.Forms.CheckBox();
            this.aeroCheckBox = new System.Windows.Forms.CheckBox();
            this.morseCheckBox = new System.Windows.Forms.CheckBox();
            this.navajoCheckBox = new System.Windows.Forms.CheckBox();
            this.vigenereCheckBox = new System.Windows.Forms.CheckBox();
            this.binaireCheckBox = new System.Windows.Forms.CheckBox();
            this.cesarKeyLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cesarKeyLabel = new System.Windows.Forms.Label();
            this.cesarKeyTextBox = new System.Windows.Forms.TextBox();
            this.cesarKeyNormalCheckBox = new System.Windows.Forms.CheckBox();
            this.cesarKeyReverseCheckBox = new System.Windows.Forms.CheckBox();
            this.aeroStdLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.aeroStdLabel = new System.Windows.Forms.Label();
            this.aeroStdIntCheckBox = new System.Windows.Forms.CheckBox();
            this.aeroStdFrCheckBox = new System.Windows.Forms.CheckBox();
            this.vigPasswordLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vigPasswordLabel = new System.Windows.Forms.Label();
            this.vigPasswordTextBox = new System.Windows.Forms.TextBox();
            this.inputIntTextBox = new System.Windows.Forms.TextBox();
            this.outputIntTextBox = new System.Windows.Forms.TextBox();
            this.interactiveModeCheckBox = new System.Windows.Forms.CheckBox();
            this.inputDirTextBox = new System.Windows.Forms.TextBox();
            this.outputDirTextBox = new System.Windows.Forms.TextBox();
            this.inputDirButton = new System.Windows.Forms.Button();
            this.outputDirButton = new System.Windows.Forms.Button();
            this.crypterButton = new System.Windows.Forms.Button();
            this.decrypterButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.algoLayoutPanel.SuspendLayout();
            this.cesarKeyLayoutPanel.SuspendLayout();
            this.aeroStdLayoutPanel.SuspendLayout();
            this.vigPasswordLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fichierToolStripMenuItem, this.optionsToolStripMenuItem, this.infosToolStripMenuItem, this.aboutMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.aideToolStripMenuItem, this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            this.aideToolStripMenuItem.Click += new System.EventHandler(this.aideToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.charactereNontraduisiblesToolStripMenuItem, this.miseEnPageToolStripMenuItem, this.formatToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // charactereNontraduisiblesToolStripMenuItem
            // 
            this.charactereNontraduisiblesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.conserverSpecCharToolStripMenuItem, this.ignorerSpecCharToolStripMenuItem});
            this.charactereNontraduisiblesToolStripMenuItem.Name = "charactereNontraduisiblesToolStripMenuItem";
            this.charactereNontraduisiblesToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.charactereNontraduisiblesToolStripMenuItem.Text = "Charactère non-traduisibles";
            // 
            // conserverSpecCharToolStripMenuItem
            // 
            this.conserverSpecCharToolStripMenuItem.Checked = true;
            this.conserverSpecCharToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conserverSpecCharToolStripMenuItem.Name = "conserverSpecCharToolStripMenuItem";
            this.conserverSpecCharToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.conserverSpecCharToolStripMenuItem.Text = "Conserver";
            this.conserverSpecCharToolStripMenuItem.Click += new System.EventHandler(this.conserverSpecCharToolStripMenuItem_Click);
            // 
            // ignorerSpecCharToolStripMenuItem
            // 
            this.ignorerSpecCharToolStripMenuItem.Name = "ignorerSpecCharToolStripMenuItem";
            this.ignorerSpecCharToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.ignorerSpecCharToolStripMenuItem.Text = "Ignorer";
            this.ignorerSpecCharToolStripMenuItem.Click += new System.EventHandler(this.ignorerSpecCharToolStripMenuItem_Click);
            // 
            // miseEnPageToolStripMenuItem
            // 
            this.miseEnPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.normaleLayoutToolStripMenuItem, this.motParMotLayoutToolStripMenuItem});
            this.miseEnPageToolStripMenuItem.Name = "miseEnPageToolStripMenuItem";
            this.miseEnPageToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.miseEnPageToolStripMenuItem.Text = "Mise en page";
            // 
            // normaleLayoutToolStripMenuItem
            // 
            this.normaleLayoutToolStripMenuItem.Checked = true;
            this.normaleLayoutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normaleLayoutToolStripMenuItem.Name = "normaleLayoutToolStripMenuItem";
            this.normaleLayoutToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.normaleLayoutToolStripMenuItem.Text = "Normale";
            this.normaleLayoutToolStripMenuItem.Click += new System.EventHandler(this.normaleLayoutToolStripMenuItem_Click);
            // 
            // motParMotLayoutToolStripMenuItem
            // 
            this.motParMotLayoutToolStripMenuItem.Name = "motParMotLayoutToolStripMenuItem";
            this.motParMotLayoutToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.motParMotLayoutToolStripMenuItem.Text = "Mot par mot";
            this.motParMotLayoutToolStripMenuItem.Click += new System.EventHandler(this.motParMotLayoutToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.traductionUniquementToolStripMenuItem, this.originalEtTraductionToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // traductionUniquementToolStripMenuItem
            // 
            this.traductionUniquementToolStripMenuItem.Checked = true;
            this.traductionUniquementToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.traductionUniquementToolStripMenuItem.Name = "traductionUniquementToolStripMenuItem";
            this.traductionUniquementToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.traductionUniquementToolStripMenuItem.Text = "Traduction uniquement";
            this.traductionUniquementToolStripMenuItem.Click += new System.EventHandler(this.traductionUniquementToolStripMenuItem_Click);
            // 
            // originalEtTraductionToolStripMenuItem
            // 
            this.originalEtTraductionToolStripMenuItem.Name = "originalEtTraductionToolStripMenuItem";
            this.originalEtTraductionToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.originalEtTraductionToolStripMenuItem.Text = "Original et traduction";
            this.originalEtTraductionToolStripMenuItem.Click += new System.EventHandler(this.originalEtTraductionToolStripMenuItem_Click);
            // 
            // infosToolStripMenuItem
            // 
            this.infosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.codeAéronautiqueToolStripMenuItem, this.codeBinaireToolStripMenuItem, this.codeDeCésarToolStripMenuItem, this.codeMorseToolStripMenuItem, this.codeNavajoToolStripMenuItem, this.cleDeVigenèreToolStripMenuItem});
            this.infosToolStripMenuItem.Name = "infosToolStripMenuItem";
            this.infosToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.infosToolStripMenuItem.Text = "Infos";
            // 
            // codeAéronautiqueToolStripMenuItem
            // 
            this.codeAéronautiqueToolStripMenuItem.Name = "codeAéronautiqueToolStripMenuItem";
            this.codeAéronautiqueToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.codeAéronautiqueToolStripMenuItem.Text = "Code Aéronautique";
            this.codeAéronautiqueToolStripMenuItem.Click += new System.EventHandler(this.codeAéronautiqueToolStripMenuItem_Click);
            // 
            // codeBinaireToolStripMenuItem
            // 
            this.codeBinaireToolStripMenuItem.Name = "codeBinaireToolStripMenuItem";
            this.codeBinaireToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.codeBinaireToolStripMenuItem.Text = "Code Binaire";
            this.codeBinaireToolStripMenuItem.Click += new System.EventHandler(this.codeBinaireToolStripMenuItem_Click);
            // 
            // codeDeCésarToolStripMenuItem
            // 
            this.codeDeCésarToolStripMenuItem.Name = "codeDeCésarToolStripMenuItem";
            this.codeDeCésarToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.codeDeCésarToolStripMenuItem.Text = "Code de César";
            this.codeDeCésarToolStripMenuItem.Click += new System.EventHandler(this.codeDeCésarToolStripMenuItem_Click);
            // 
            // codeMorseToolStripMenuItem
            // 
            this.codeMorseToolStripMenuItem.Name = "codeMorseToolStripMenuItem";
            this.codeMorseToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.codeMorseToolStripMenuItem.Text = "Code Morse";
            this.codeMorseToolStripMenuItem.Click += new System.EventHandler(this.codeMorseToolStripMenuItem_Click);
            // 
            // codeNavajoToolStripMenuItem
            // 
            this.codeNavajoToolStripMenuItem.Name = "codeNavajoToolStripMenuItem";
            this.codeNavajoToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.codeNavajoToolStripMenuItem.Text = "Code Navajo";
            this.codeNavajoToolStripMenuItem.Click += new System.EventHandler(this.codeNavajoToolStripMenuItem_Click);
            // 
            // cleDeVigenèreToolStripMenuItem
            // 
            this.cleDeVigenèreToolStripMenuItem.Name = "cleDeVigenèreToolStripMenuItem";
            this.cleDeVigenèreToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.cleDeVigenèreToolStripMenuItem.Text = "Clé de Vigenère";
            this.cleDeVigenèreToolStripMenuItem.Click += new System.EventHandler(this.cleDeVigenèreToolStripMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.tableDeVigenereToolStripMenuItem, this.aProposToolStripMenuItem});
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(28, 24);
            this.aboutMenuItem.Text = "?";
            // 
            // tableDeVigenereToolStripMenuItem
            // 
            this.tableDeVigenereToolStripMenuItem.Name = "tableDeVigenereToolStripMenuItem";
            this.tableDeVigenereToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.tableDeVigenereToolStripMenuItem.Text = "Table de Vigenère";
            this.tableDeVigenereToolStripMenuItem.Click += new System.EventHandler(this.tableDeVigenereToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.aProposToolStripMenuItem.Text = "A propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // algoLayoutPanel
            // 
            this.algoLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.algoLayoutPanel.Controls.Add(this.algoLabel);
            this.algoLayoutPanel.Controls.Add(this.cesarCheckBox);
            this.algoLayoutPanel.Controls.Add(this.aeroCheckBox);
            this.algoLayoutPanel.Controls.Add(this.morseCheckBox);
            this.algoLayoutPanel.Controls.Add(this.navajoCheckBox);
            this.algoLayoutPanel.Controls.Add(this.vigenereCheckBox);
            this.algoLayoutPanel.Controls.Add(this.binaireCheckBox);
            this.algoLayoutPanel.Location = new System.Drawing.Point(12, 43);
            this.algoLayoutPanel.Name = "algoLayoutPanel";
            this.algoLayoutPanel.Size = new System.Drawing.Size(272, 124);
            this.algoLayoutPanel.TabIndex = 1;
            // 
            // algoLabel
            // 
            this.algoLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.algoLabel.Location = new System.Drawing.Point(3, 0);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(275, 23);
            this.algoLabel.TabIndex = 0;
            this.algoLabel.Text = "Algorithme de Cryptage:";
            this.algoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cesarCheckBox
            // 
            this.cesarCheckBox.Checked = true;
            this.cesarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cesarCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cesarCheckBox.Location = new System.Drawing.Point(40, 28);
            this.cesarCheckBox.Margin = new System.Windows.Forms.Padding(40, 5, 5, 3);
            this.cesarCheckBox.Name = "cesarCheckBox";
            this.cesarCheckBox.Size = new System.Drawing.Size(104, 24);
            this.cesarCheckBox.TabIndex = 1;
            this.cesarCheckBox.Text = "César";
            this.cesarCheckBox.UseVisualStyleBackColor = true;
            // 
            // aeroCheckBox
            // 
            this.aeroCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aeroCheckBox.Location = new System.Drawing.Point(152, 28);
            this.aeroCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.aeroCheckBox.Name = "aeroCheckBox";
            this.aeroCheckBox.Size = new System.Drawing.Size(104, 24);
            this.aeroCheckBox.TabIndex = 2;
            this.aeroCheckBox.Text = "Aéro";
            this.aeroCheckBox.UseVisualStyleBackColor = true;
            // 
            // morseCheckBox
            // 
            this.morseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.morseCheckBox.Location = new System.Drawing.Point(40, 60);
            this.morseCheckBox.Margin = new System.Windows.Forms.Padding(40, 5, 5, 3);
            this.morseCheckBox.Name = "morseCheckBox";
            this.morseCheckBox.Size = new System.Drawing.Size(104, 24);
            this.morseCheckBox.TabIndex = 3;
            this.morseCheckBox.Text = "Morse";
            this.morseCheckBox.UseVisualStyleBackColor = true;
            // 
            // navajoCheckBox
            // 
            this.navajoCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.navajoCheckBox.Location = new System.Drawing.Point(152, 60);
            this.navajoCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.navajoCheckBox.Name = "navajoCheckBox";
            this.navajoCheckBox.Size = new System.Drawing.Size(104, 24);
            this.navajoCheckBox.TabIndex = 4;
            this.navajoCheckBox.Text = "Navajo";
            this.navajoCheckBox.UseVisualStyleBackColor = true;
            // 
            // vigenereCheckBox
            // 
            this.vigenereCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.vigenereCheckBox.Location = new System.Drawing.Point(40, 92);
            this.vigenereCheckBox.Margin = new System.Windows.Forms.Padding(40, 5, 5, 3);
            this.vigenereCheckBox.Name = "vigenereCheckBox";
            this.vigenereCheckBox.Size = new System.Drawing.Size(104, 24);
            this.vigenereCheckBox.TabIndex = 5;
            this.vigenereCheckBox.Text = "Vigenère";
            this.vigenereCheckBox.UseVisualStyleBackColor = true;
            // 
            // binaireCheckBox
            // 
            this.binaireCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.binaireCheckBox.Location = new System.Drawing.Point(152, 92);
            this.binaireCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.binaireCheckBox.Name = "binaireCheckBox";
            this.binaireCheckBox.Size = new System.Drawing.Size(104, 24);
            this.binaireCheckBox.TabIndex = 6;
            this.binaireCheckBox.Text = "Binaire";
            this.binaireCheckBox.UseVisualStyleBackColor = true;
            // 
            // cesarKeyLayoutPanel
            // 
            this.cesarKeyLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cesarKeyLayoutPanel.Controls.Add(this.cesarKeyLabel);
            this.cesarKeyLayoutPanel.Controls.Add(this.cesarKeyTextBox);
            this.cesarKeyLayoutPanel.Controls.Add(this.cesarKeyNormalCheckBox);
            this.cesarKeyLayoutPanel.Controls.Add(this.cesarKeyReverseCheckBox);
            this.cesarKeyLayoutPanel.Location = new System.Drawing.Point(290, 43);
            this.cesarKeyLayoutPanel.Name = "cesarKeyLayoutPanel";
            this.cesarKeyLayoutPanel.Size = new System.Drawing.Size(482, 76);
            this.cesarKeyLayoutPanel.TabIndex = 2;
            // 
            // cesarKeyLabel
            // 
            this.cesarKeyLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cesarKeyLabel.Location = new System.Drawing.Point(3, 0);
            this.cesarKeyLabel.Name = "cesarKeyLabel";
            this.cesarKeyLabel.Size = new System.Drawing.Size(192, 68);
            this.cesarKeyLabel.TabIndex = 0;
            this.cesarKeyLabel.Text = "Clé de chiffrement (code César)";
            this.cesarKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cesarKeyTextBox
            // 
            this.cesarKeyTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cesarKeyTextBox.Location = new System.Drawing.Point(201, 23);
            this.cesarKeyTextBox.Name = "cesarKeyTextBox";
            this.cesarKeyTextBox.Size = new System.Drawing.Size(100, 22);
            this.cesarKeyTextBox.TabIndex = 1;
            this.cesarKeyTextBox.Text = "0";
            this.cesarKeyTextBox.TextChanged += new System.EventHandler(this.cesarKeyTextBox_TextChanged);
            // 
            // cesarKeyNormalCheckBox
            // 
            this.cesarKeyNormalCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cesarKeyNormalCheckBox.Checked = true;
            this.cesarKeyNormalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cesarKeyNormalCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cesarKeyNormalCheckBox.Location = new System.Drawing.Point(307, 22);
            this.cesarKeyNormalCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cesarKeyNormalCheckBox.Name = "cesarKeyNormalCheckBox";
            this.cesarKeyNormalCheckBox.Size = new System.Drawing.Size(83, 24);
            this.cesarKeyNormalCheckBox.TabIndex = 2;
            this.cesarKeyNormalCheckBox.Text = "normale";
            this.cesarKeyNormalCheckBox.UseVisualStyleBackColor = true;
            // 
            // cesarKeyReverseCheckBox
            // 
            this.cesarKeyReverseCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cesarKeyReverseCheckBox.Location = new System.Drawing.Point(393, 22);
            this.cesarKeyReverseCheckBox.Name = "cesarKeyReverseCheckBox";
            this.cesarKeyReverseCheckBox.Size = new System.Drawing.Size(83, 24);
            this.cesarKeyReverseCheckBox.TabIndex = 3;
            this.cesarKeyReverseCheckBox.Text = "inversée";
            this.cesarKeyReverseCheckBox.UseVisualStyleBackColor = true;
            // 
            // aeroStdLayoutPanel
            // 
            this.aeroStdLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aeroStdLayoutPanel.Controls.Add(this.aeroStdLabel);
            this.aeroStdLayoutPanel.Controls.Add(this.aeroStdIntCheckBox);
            this.aeroStdLayoutPanel.Controls.Add(this.aeroStdFrCheckBox);
            this.aeroStdLayoutPanel.Location = new System.Drawing.Point(290, 127);
            this.aeroStdLayoutPanel.Name = "aeroStdLayoutPanel";
            this.aeroStdLayoutPanel.Size = new System.Drawing.Size(482, 58);
            this.aeroStdLayoutPanel.TabIndex = 3;
            // 
            // aeroStdLabel
            // 
            this.aeroStdLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aeroStdLabel.Location = new System.Drawing.Point(3, 0);
            this.aeroStdLabel.Name = "aeroStdLabel";
            this.aeroStdLabel.Size = new System.Drawing.Size(208, 57);
            this.aeroStdLabel.TabIndex = 0;
            this.aeroStdLabel.Text = "Standart  \r\n(code aéronautique)";
            this.aeroStdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aeroStdIntCheckBox
            // 
            this.aeroStdIntCheckBox.Checked = true;
            this.aeroStdIntCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aeroStdIntCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aeroStdIntCheckBox.Location = new System.Drawing.Point(217, 15);
            this.aeroStdIntCheckBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.aeroStdIntCheckBox.Name = "aeroStdIntCheckBox";
            this.aeroStdIntCheckBox.Size = new System.Drawing.Size(124, 24);
            this.aeroStdIntCheckBox.TabIndex = 1;
            this.aeroStdIntCheckBox.Text = "Internationnal";
            this.aeroStdIntCheckBox.UseVisualStyleBackColor = true;
            // 
            // aeroStdFrCheckBox
            // 
            this.aeroStdFrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aeroStdFrCheckBox.Location = new System.Drawing.Point(347, 15);
            this.aeroStdFrCheckBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.aeroStdFrCheckBox.Name = "aeroStdFrCheckBox";
            this.aeroStdFrCheckBox.Size = new System.Drawing.Size(110, 24);
            this.aeroStdFrCheckBox.TabIndex = 2;
            this.aeroStdFrCheckBox.Text = "Français";
            this.aeroStdFrCheckBox.UseVisualStyleBackColor = true;
            // 
            // vigPasswordLayoutPanel
            // 
            this.vigPasswordLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vigPasswordLayoutPanel.Controls.Add(this.vigPasswordLabel);
            this.vigPasswordLayoutPanel.Controls.Add(this.vigPasswordTextBox);
            this.vigPasswordLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.vigPasswordLayoutPanel.Location = new System.Drawing.Point(290, 191);
            this.vigPasswordLayoutPanel.Name = "vigPasswordLayoutPanel";
            this.vigPasswordLayoutPanel.Size = new System.Drawing.Size(482, 65);
            this.vigPasswordLayoutPanel.TabIndex = 4;
            // 
            // vigPasswordLabel
            // 
            this.vigPasswordLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.vigPasswordLabel.Location = new System.Drawing.Point(3, 0);
            this.vigPasswordLabel.Name = "vigPasswordLabel";
            this.vigPasswordLabel.Size = new System.Drawing.Size(473, 29);
            this.vigPasswordLabel.TabIndex = 0;
            this.vigPasswordLabel.Text = "Mot de passe (clé de Vigenère)";
            this.vigPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vigPasswordTextBox
            // 
            this.vigPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.vigPasswordTextBox.Location = new System.Drawing.Point(27, 32);
            this.vigPasswordTextBox.Name = "vigPasswordTextBox";
            this.vigPasswordTextBox.Size = new System.Drawing.Size(425, 22);
            this.vigPasswordTextBox.TabIndex = 1;
            this.vigPasswordTextBox.TextChanged += new System.EventHandler(this.vigPasswordTextBox_TextChanged);
            // 
            // inputIntTextBox
            // 
            this.inputIntTextBox.Location = new System.Drawing.Point(12, 321);
            this.inputIntTextBox.Multiline = true;
            this.inputIntTextBox.Name = "inputIntTextBox";
            this.inputIntTextBox.Size = new System.Drawing.Size(346, 104);
            this.inputIntTextBox.TabIndex = 5;
            // 
            // outputIntTextBox
            // 
            this.outputIntTextBox.Location = new System.Drawing.Point(402, 321);
            this.outputIntTextBox.Multiline = true;
            this.outputIntTextBox.Name = "outputIntTextBox";
            this.outputIntTextBox.Size = new System.Drawing.Size(346, 104);
            this.outputIntTextBox.TabIndex = 6;
            // 
            // interactiveModeCheckBox
            // 
            this.interactiveModeCheckBox.Checked = true;
            this.interactiveModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.interactiveModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.interactiveModeCheckBox.Location = new System.Drawing.Point(14, 291);
            this.interactiveModeCheckBox.Name = "interactiveModeCheckBox";
            this.interactiveModeCheckBox.Size = new System.Drawing.Size(141, 24);
            this.interactiveModeCheckBox.TabIndex = 7;
            this.interactiveModeCheckBox.Text = "Mode Interactif";
            this.interactiveModeCheckBox.UseVisualStyleBackColor = true;
            this.interactiveModeCheckBox.Click += new System.EventHandler(this.interactiveModeCheckBox_CheckedChanged);
            // 
            // inputDirTextBox
            // 
            this.inputDirTextBox.Location = new System.Drawing.Point(12, 333);
            this.inputDirTextBox.Name = "inputDirTextBox";
            this.inputDirTextBox.Size = new System.Drawing.Size(412, 22);
            this.inputDirTextBox.TabIndex = 8;
            this.inputDirTextBox.Visible = false;
            // 
            // outputDirTextBox
            // 
            this.outputDirTextBox.Location = new System.Drawing.Point(12, 381);
            this.outputDirTextBox.Name = "outputDirTextBox";
            this.outputDirTextBox.Size = new System.Drawing.Size(412, 22);
            this.outputDirTextBox.TabIndex = 9;
            this.outputDirTextBox.Visible = false;
            // 
            // inputDirButton
            // 
            this.inputDirButton.Image = ((System.Drawing.Image) (resources.GetObject("inputDirButton.Image")));
            this.inputDirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.inputDirButton.Location = new System.Drawing.Point(430, 333);
            this.inputDirButton.Name = "inputDirButton";
            this.inputDirButton.Size = new System.Drawing.Size(35, 22);
            this.inputDirButton.TabIndex = 10;
            this.inputDirButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.inputDirButton.UseVisualStyleBackColor = true;
            this.inputDirButton.Visible = false;
            this.inputDirButton.Click += new System.EventHandler(this.inputDirButton_Click);
            // 
            // outputDirButton
            // 
            this.outputDirButton.Image = ((System.Drawing.Image) (resources.GetObject("outputDirButton.Image")));
            this.outputDirButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.outputDirButton.Location = new System.Drawing.Point(430, 381);
            this.outputDirButton.Name = "outputDirButton";
            this.outputDirButton.Size = new System.Drawing.Size(35, 22);
            this.outputDirButton.TabIndex = 11;
            this.outputDirButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.outputDirButton.UseVisualStyleBackColor = true;
            this.outputDirButton.Visible = false;
            this.outputDirButton.Click += new System.EventHandler(this.outputDirButton_Click);
            // 
            // crypterButton
            // 
            this.crypterButton.Font = new System.Drawing.Font("Sitka Subheading", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.crypterButton.Location = new System.Drawing.Point(521, 291);
            this.crypterButton.Name = "crypterButton";
            this.crypterButton.Size = new System.Drawing.Size(251, 64);
            this.crypterButton.TabIndex = 12;
            this.crypterButton.Text = "Crypter";
            this.crypterButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.crypterButton.UseVisualStyleBackColor = true;
            this.crypterButton.Visible = false;
            this.crypterButton.Click += new System.EventHandler(this.crypterButton_Click);
            // 
            // decrypterButton
            // 
            this.decrypterButton.Font = new System.Drawing.Font("Sitka Subheading", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.decrypterButton.Location = new System.Drawing.Point(521, 361);
            this.decrypterButton.Name = "decrypterButton";
            this.decrypterButton.Size = new System.Drawing.Size(251, 64);
            this.decrypterButton.TabIndex = 13;
            this.decrypterButton.Text = "Décrypter";
            this.decrypterButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.decrypterButton.UseVisualStyleBackColor = true;
            this.decrypterButton.Visible = false;
            this.decrypterButton.Click += new System.EventHandler(this.decrypterButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image) (resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(82, 173);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(135, 120);
            this.logoPictureBox.TabIndex = 14;
            this.logoPictureBox.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.decrypterButton);
            this.Controls.Add(this.crypterButton);
            this.Controls.Add(this.outputDirButton);
            this.Controls.Add(this.inputDirButton);
            this.Controls.Add(this.outputDirTextBox);
            this.Controls.Add(this.inputDirTextBox);
            this.Controls.Add(this.interactiveModeCheckBox);
            this.Controls.Add(this.outputIntTextBox);
            this.Controls.Add(this.inputIntTextBox);
            this.Controls.Add(this.vigPasswordLayoutPanel);
            this.Controls.Add(this.aeroStdLayoutPanel);
            this.Controls.Add(this.cesarKeyLayoutPanel);
            this.Controls.Add(this.algoLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cryptage";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.algoLayoutPanel.ResumeLayout(false);
            this.cesarKeyLayoutPanel.ResumeLayout(false);
            this.cesarKeyLayoutPanel.PerformLayout();
            this.aeroStdLayoutPanel.ResumeLayout(false);
            this.vigPasswordLayoutPanel.ResumeLayout(false);
            this.vigPasswordLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox logoPictureBox;

        private System.Windows.Forms.Button decrypterButton;

        private System.Windows.Forms.Button crypterButton;

        private System.Windows.Forms.Button outputDirButton;

        private System.Windows.Forms.Button inputDirButton;
        private System.Windows.Forms.TextBox inputDirTextBox;
        private System.Windows.Forms.TextBox outputDirTextBox;

        private System.Windows.Forms.CheckBox interactiveModeCheckBox;

        private System.Windows.Forms.TextBox outputIntTextBox;

        private System.Windows.Forms.TextBox inputIntTextBox;

        private System.Windows.Forms.TextBox vigPasswordTextBox;

        private System.Windows.Forms.Label vigPasswordLabel;

        private System.Windows.Forms.FlowLayoutPanel vigPasswordLayoutPanel;

        private System.Windows.Forms.CheckBox aeroStdFrCheckBox;

        private System.Windows.Forms.CheckBox aeroStdIntCheckBox;

        private System.Windows.Forms.Label aeroStdLabel;

        private System.Windows.Forms.FlowLayoutPanel aeroStdLayoutPanel;

        private System.Windows.Forms.CheckBox cesarKeyNormalCheckBox;
        private System.Windows.Forms.CheckBox cesarKeyReverseCheckBox;

        private System.Windows.Forms.TextBox cesarKeyTextBox;

        private System.Windows.Forms.Label cesarKeyLabel;

        private System.Windows.Forms.FlowLayoutPanel cesarKeyLayoutPanel;

        private System.Windows.Forms.CheckBox aeroCheckBox;
        private System.Windows.Forms.CheckBox binaireCheckBox;
        private System.Windows.Forms.CheckBox cesarCheckBox;
        private System.Windows.Forms.CheckBox morseCheckBox;
        private System.Windows.Forms.CheckBox navajoCheckBox;
        private System.Windows.Forms.CheckBox vigenereCheckBox;

        private System.Windows.Forms.Label algoLabel;

        private System.Windows.Forms.FlowLayoutPanel algoLayoutPanel;

        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableDeVigenereToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem cleDeVigenèreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeAéronautiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeBinaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeDeCésarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeMorseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeNavajoToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem infosToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motParMotLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalEtTraductionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traductionUniquementToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem charactereNontraduisiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conserverSpecCharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignorerSpecCharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miseEnPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normaleLayoutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;

        #endregion
    }
}