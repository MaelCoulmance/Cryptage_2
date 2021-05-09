using System.ComponentModel;

namespace Cryptage.Visual
{
    partial class HelpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpWindow));
            this.aideLabel = new System.Windows.Forms.Label();
            this.aideCryptageButton = new System.Windows.Forms.Button();
            this.paramSpecButton = new System.Windows.Forms.Button();
            this.layoutButton = new System.Windows.Forms.Button();
            this.retourButton = new System.Windows.Forms.Button();
            this.navigateButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aideLabel
            // 
            this.aideLabel.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aideLabel.Location = new System.Drawing.Point(288, 31);
            this.aideLabel.Name = "aideLabel";
            this.aideLabel.Size = new System.Drawing.Size(212, 61);
            this.aideLabel.TabIndex = 0;
            this.aideLabel.Text = "Aide";
            this.aideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aideCryptageButton
            // 
            this.aideCryptageButton.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aideCryptageButton.Location = new System.Drawing.Point(313, 118);
            this.aideCryptageButton.Name = "aideCryptageButton";
            this.aideCryptageButton.Size = new System.Drawing.Size(187, 72);
            this.aideCryptageButton.TabIndex = 1;
            this.aideCryptageButton.Text = "Aide Cryptage";
            this.aideCryptageButton.UseVisualStyleBackColor = true;
            this.aideCryptageButton.Click += new System.EventHandler(this.aideCryptageButton_Click);
            // 
            // paramSpecButton
            // 
            this.paramSpecButton.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.paramSpecButton.Location = new System.Drawing.Point(313, 228);
            this.paramSpecButton.Name = "paramSpecButton";
            this.paramSpecButton.Size = new System.Drawing.Size(187, 73);
            this.paramSpecButton.TabIndex = 2;
            this.paramSpecButton.Text = "Parmètres spéciaux";
            this.paramSpecButton.UseVisualStyleBackColor = true;
            this.paramSpecButton.Click += new System.EventHandler(this.paramSpecButton_Click);
            // 
            // layoutButton
            // 
            this.layoutButton.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.layoutButton.Location = new System.Drawing.Point(313, 331);
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.Size = new System.Drawing.Size(187, 73);
            this.layoutButton.TabIndex = 3;
            this.layoutButton.Text = "Paramètres de mise en page";
            this.layoutButton.UseVisualStyleBackColor = true;
            this.layoutButton.Click += new System.EventHandler(this.layoutButton_Click);
            // 
            // retourButton
            // 
            this.retourButton.Location = new System.Drawing.Point(12, 444);
            this.retourButton.Name = "retourButton";
            this.retourButton.Size = new System.Drawing.Size(105, 30);
            this.retourButton.TabIndex = 4;
            this.retourButton.Text = "retour";
            this.retourButton.UseVisualStyleBackColor = true;
            this.retourButton.Click += new System.EventHandler(this.retourButton_Click);
            // 
            // navigateButton
            // 
            this.navigateButton.Location = new System.Drawing.Point(713, 444);
            this.navigateButton.Name = "navigateButton";
            this.navigateButton.Size = new System.Drawing.Size(105, 30);
            this.navigateButton.TabIndex = 5;
            this.navigateButton.Text = "suivant";
            this.navigateButton.UseVisualStyleBackColor = true;
            this.navigateButton.Click += new System.EventHandler(this.navigateButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(124, 92);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(600, 340);
            this.textLabel.TabIndex = 6;
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 487);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.navigateButton);
            this.Controls.Add(this.retourButton);
            this.Controls.Add(this.layoutButton);
            this.Controls.Add(this.paramSpecButton);
            this.Controls.Add(this.aideCryptageButton);
            this.Controls.Add(this.aideLabel);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "HelpWindow";
            this.Text = "Aide";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label textLabel;

        private System.Windows.Forms.Button navigateButton;
        private System.Windows.Forms.Button retourButton;

        private System.Windows.Forms.Button aideCryptageButton;
        private System.Windows.Forms.Button layoutButton;
        private System.Windows.Forms.Button paramSpecButton;

        private System.Windows.Forms.Label aideLabel;

        #endregion
    }
}