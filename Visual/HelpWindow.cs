using System;
using System.Windows.Forms;

using Cryptage.Commons;

namespace Cryptage.Visual
{
    public partial class HelpWindow : Form
    {
        private bool _isParamSpec = true;
        private bool _isFirstScreen = true;

        public HelpWindow()
        {
            InitializeComponent();
            CenterToParent();
            FormBorderStyle = FormBorderStyle.Fixed3D;
            
            aideCryptageButton.Visible = true;
            paramSpecButton.Visible = true;
            layoutButton.Visible = true;

            retourButton.Visible = false;
            navigateButton.Visible = false;
            textLabel.Visible = false;
        }

        private void aideCryptageButton_Click(object sender, EventArgs e)
        {
            textLabel.Text = Ressources.HELP_MENU_AIDE_CRYPTAGE;
            
            aideCryptageButton.Visible = false;
            paramSpecButton.Visible = false;
            layoutButton.Visible = false;

            retourButton.Visible = true;
            textLabel.Visible = true;
        }

        private void paramSpecButton_Click(object sender, EventArgs e)
        {
            textLabel.Text = Ressources.HELP_MENU_SPECIAL_PARAM1;
            
            aideCryptageButton.Visible = false;
            paramSpecButton.Visible = false;
            layoutButton.Visible = false;

            retourButton.Visible = true;
            navigateButton.Visible = true;
            textLabel.Visible = true;

            _isFirstScreen = true;
            _isParamSpec = true;

            navigateButton.Text = @"suivant";
        }

        private void layoutButton_Click(object sender, EventArgs e)
        {
            textLabel.Text = Ressources.HELP_MENU_LAYOUT1;
            
            aideCryptageButton.Visible = false;
            paramSpecButton.Visible = false;
            layoutButton.Visible = false;

            retourButton.Visible = true;
            navigateButton.Visible = true;
            textLabel.Visible = true;

            navigateButton.Text = @"suivant";
        }

        private void retourButton_Click(object sender, EventArgs e)
        {
            aideCryptageButton.Visible = true;
            paramSpecButton.Visible = true;
            layoutButton.Visible = true;

            retourButton.Visible = false;
            navigateButton.Visible = false;
            textLabel.Visible = false;
        }

        private void navigateButton_Click(object sender, EventArgs e)
        {
            if (_isParamSpec)
            {
                if (_isFirstScreen)
                {
                    textLabel.Text = Ressources.HELP_MENU_SPECIAL_PARAM2;
                    _isFirstScreen = false;
                    navigateButton.Text = @"précedant";
                }
                else
                {
                    textLabel.Text = Ressources.HELP_MENU_SPECIAL_PARAM1;
                    _isFirstScreen = true;
                    navigateButton.Text = @"suivant";
                }
            }
            else
            {
                if (_isFirstScreen)
                {
                    textLabel.Text = Ressources.HELP_MENU_LAYOUT2;
                    _isFirstScreen = false;
                    navigateButton.Text = "@précedant";
                }
                else
                {
                    textLabel.Text = Ressources.HELP_MENU_LAYOUT1;
                    _isFirstScreen = true;
                    navigateButton.Text = @"suivant";
                }
            }
        }
    }
}