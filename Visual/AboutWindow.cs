#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using Cryptage.Commons;
using Cryptage.Commons.Util;

using ContentAlignment = System.Drawing.ContentAlignment;

namespace Cryptage.Visual
{
    public partial class AboutWindow : Form
    {
        private static readonly Size AeroSize = new Size(605, 300);
        private static readonly Size CesarSize = new Size(565, 250);
        private static readonly Size MorseSize = new Size(580, 200);
        private static readonly Size NavajoSize = new Size(585, 230);
        private static readonly Size BinaireSize = new Size(710, 200);
        private static readonly Size AboutSize = new Size(710, 325);
        
        
        public AboutWindow(TypeC? type)
        {
            InitializeComponent();
            InitUi(type);
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void InitUi(TypeC? type)
        {
            string title = EnumFunc.TypeToString(type);
            if (title != "A propos")
                title += " Infos";
            Text = title;

            ClientSize = SetSize(type);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            
            string text = (type.Equals(TypeC.Aero)) ? Ressources.AERO_ABOUT
                : (type.Equals(TypeC.Cesar)) ? Ressources.CESAR_ABOUT
                : (type.Equals(TypeC.Morse)) ? Ressources.MORSE_ABOUT
                : (type.Equals(TypeC.Navajo)) ? Ressources.NAVAJO_ABOUT
                : (type.Equals(TypeC.Vigenere)) ? Ressources.VIGENERE_ABOUT
                : (type.Equals(TypeC.Binaire)) ? Ressources.BINAIRE_ABOUT
                : Ressources.PROGRAM_ABOUT;

            var font = new Font("Verdana", 9, FontStyle.Italic | FontStyle.Bold);

            var lyrics = new Label();
            lyrics.Parent = this;
            lyrics.Text = text;
            lyrics.Font = font;
            lyrics.AutoSize = true;
            lyrics.TextAlign = ContentAlignment.MiddleCenter;
            
            Controls.Add(lyrics);
            CenterToParent();
        }
        
        private Size SetSize(TypeC? type)
        {
            return (type == TypeC.Aero) ? AeroSize
                : (type == TypeC.Cesar) ? CesarSize
                : (type == TypeC.Morse) ? MorseSize
                : (type == TypeC.Navajo) ? NavajoSize
                : (type == TypeC.Binaire) ? BinaireSize
                : AboutSize;
        }
    }
}