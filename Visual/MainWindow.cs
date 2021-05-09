#nullable enable

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;
using Cryptage.Crypto;
using Cryptage.Crypto.Interactive;

namespace Cryptage.Visual
{
    public partial class MainWindow : Form
    {
        #region Attributes
        
        // Metadata info
        private bool _codeAndTranslate;
        private WritingType _type;
        private string? _inputDir;
        private string? _outputDir;
        private bool _keepInvalidChar;
        private int _cesarKey;
        private TypeC _algorithm;
        
        // Specific Metadata info
        private bool _aeroUseInt;
        private bool _cesarLeftToRight;
        private string? _vigenereKey;
        
        // Interactive translation objects
        private AeroInt _aeroInt = AeroInt.GetInstance();
        private BinaireInt _binaireInt = BinaireInt.GetInstance();
        private CesarInt _cesarInt = CesarInt.GetInstance();
        private MorseInt _morseInt = MorseInt.GetInstance();
        private NavajoInt _navajoInt = NavajoInt.GetInstance();
        private VigenereInt _vigenereInt = VigenereInt.GetInstance();
        
        // Other
        public static Error? Error;
        private string _inputText = "";
        private string _outputText = "";
        private bool _isInteractive;

        #endregion


        public MainWindow()
        {
            InitializeComponent();
            InitMeta();
            InitTools();
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void InitMeta()
        {
            _codeAndTranslate = false;
            _type = WritingType.Normal;
            _keepInvalidChar = true;
            _cesarKey = 0;
            _algorithm = TypeC.Cesar;
            _aeroUseInt = true;
            _cesarLeftToRight = true;
            _inputDir = null;
            _outputDir = null;
            Error = null;
            _vigenereKey = null;
            _isInteractive = true;
        }

        private void InitTools()
        {
            quitterToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            aideToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;

            aeroCheckBox.Click += aeroCheckBox_Click;
            cesarCheckBox.Click += cesarCheckBox_Click;
            morseCheckBox.Click += morseCheckBox_Click;
            navajoCheckBox.Click += navajoCheckBox_Click;
            vigenereCheckBox.Click += vigenereCheckBox_Click;
            binaireCheckBox.Click += binaireCheckBox_Click;

            cesarKeyNormalCheckBox.Click += cesarKeyNormalCheckBox_Click;
            cesarKeyReverseCheckBox.Click += cesarKeyReverseCheckBox_Click;
            cesarKeyLayoutPanel.Enabled = true;

            aeroStdIntCheckBox.Click += aeroStdIntCheckBox_Click;
            aeroStdFrCheckBox.Click += aeroStdFrCheckBox_Click;
            aeroStdLayoutPanel.Enabled = false;

            vigPasswordLayoutPanel.Enabled = false;

            inputIntTextBox.AcceptsTab = false;
            outputIntTextBox.AcceptsTab = false;
            inputIntTextBox.PlaceholderText = @"Zone réservée au texte non crypté";
            outputIntTextBox.PlaceholderText = @"Zone Réservée au texte crypté";
            inputIntTextBox.KeyPress += new KeyPressEventHandler(this.inputIntTextBox_KeyDown);
            outputIntTextBox.KeyPress += new KeyPressEventHandler(this.outputIntTextBox_KeyDown);

            inputDirTextBox.PlaceholderText = @"Fichier source";
            outputDirTextBox.PlaceholderText = @"Fichier cible";
        }

        private void aideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void conserverSpecCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conserverSpecCharToolStripMenuItem.Checked = true;
            ignorerSpecCharToolStripMenuItem.Checked = false;
            _keepInvalidChar = true;
        }

        private void ignorerSpecCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conserverSpecCharToolStripMenuItem.Checked = false;
            ignorerSpecCharToolStripMenuItem.Checked = true;
            _keepInvalidChar = false;
        }

        private void normaleLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normaleLayoutToolStripMenuItem.Checked = true;
            motParMotLayoutToolStripMenuItem.Checked = false;
            _type = WritingType.Normal;
        }

        private void motParMotLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normaleLayoutToolStripMenuItem.Checked = false;
            motParMotLayoutToolStripMenuItem.Checked = true;
            _type = WritingType.WordPerWord;
        }

        private void traductionUniquementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            traductionUniquementToolStripMenuItem.Checked = true;
            originalEtTraductionToolStripMenuItem.Checked = false;
            _codeAndTranslate = false;
        }

        private void originalEtTraductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            traductionUniquementToolStripMenuItem.Checked = false;
            originalEtTraductionToolStripMenuItem.Checked = true;
            _codeAndTranslate = true;
        }

        private void codeAéronautiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Aero);
            about.ShowDialog();
        }

        private void codeBinaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Binaire);
            about.ShowDialog();
        }

        private void codeDeCésarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Cesar);
            about.ShowDialog();
        }

        private void codeMorseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Morse);
            about.ShowDialog();
        }

        private void codeNavajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Navajo);
            about.ShowDialog();
        }

        private void cleDeVigenèreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(TypeC.Vigenere);
            about.ShowDialog();
        }

        private void tableDeVigenereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VigenereWindow vig = new VigenereWindow();
            vig.ShowDialog();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow(null);
            about.ShowDialog();
        }



        private void cesarCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = true;
            aeroCheckBox.Checked = false;
            morseCheckBox.Checked = false;
            navajoCheckBox.Checked = false;
            vigenereCheckBox.Checked = false;
            binaireCheckBox.Checked = false;

            _algorithm = TypeC.Cesar;
            
            cesarKeyLayoutPanel.Enabled = true;
            aeroStdLayoutPanel.Enabled = false;
            vigPasswordLayoutPanel.Enabled = false;

            vigPasswordTextBox.PlaceholderText = "";
        }

        private void aeroCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = false;
            aeroCheckBox.Checked = true;
            morseCheckBox.Checked = false;
            navajoCheckBox.Checked = false;
            vigenereCheckBox.Checked = false;
            binaireCheckBox.Checked = false;

            _algorithm = TypeC.Aero;
            
            cesarKeyLayoutPanel.Enabled = false;
            aeroStdLayoutPanel.Enabled = true;
            vigPasswordLayoutPanel.Enabled = false;
            
            vigPasswordTextBox.PlaceholderText = "";
        }

        private void morseCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = false;
            aeroCheckBox.Checked = false;
            morseCheckBox.Checked = true;
            navajoCheckBox.Checked = false;
            vigenereCheckBox.Checked = false;
            binaireCheckBox.Checked = false;

            _algorithm = TypeC.Morse;
            
            cesarKeyLayoutPanel.Enabled = false;
            aeroStdLayoutPanel.Enabled = false;
            vigPasswordLayoutPanel.Enabled = false;
            
            vigPasswordTextBox.PlaceholderText = "";
        }

        private void navajoCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = false;
            aeroCheckBox.Checked = false;
            morseCheckBox.Checked = false;
            navajoCheckBox.Checked = true;
            vigenereCheckBox.Checked = false;
            binaireCheckBox.Checked = false;

            _algorithm = TypeC.Navajo;
            
            cesarKeyLayoutPanel.Enabled = false;
            aeroStdLayoutPanel.Enabled = false;
            vigPasswordLayoutPanel.Enabled = false;
            
            vigPasswordTextBox.PlaceholderText = "";
        }

        private void vigenereCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = false;
            aeroCheckBox.Checked = false;
            morseCheckBox.Checked = false;
            navajoCheckBox.Checked = false;
            vigenereCheckBox.Checked = true;
            binaireCheckBox.Checked = false;

            _algorithm = TypeC.Vigenere;
            
            cesarKeyLayoutPanel.Enabled = false;
            aeroStdLayoutPanel.Enabled = false;
            vigPasswordLayoutPanel.Enabled = true;
            
            vigPasswordTextBox.PlaceholderText = @"Inserez un mot composé uniquement de lettres minuscules";
        }

        private void binaireCheckBox_Click(object? sender, EventArgs e)
        {
            cesarCheckBox.Checked = false;
            aeroCheckBox.Checked = false;
            morseCheckBox.Checked = false;
            navajoCheckBox.Checked = false;
            vigenereCheckBox.Checked = false;
            binaireCheckBox.Checked = true;

            _algorithm = TypeC.Binaire;

            cesarKeyLayoutPanel.Enabled = false;
            aeroStdLayoutPanel.Enabled = false;
            vigPasswordLayoutPanel.Enabled = false;
            
            vigPasswordTextBox.PlaceholderText = "";
        }

        
        
        private void cesarKeyTextBox_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                int val = Int32.Parse(cesarKeyTextBox.Text);
                _cesarKey = val;
            }
            catch (Exception)
            {
                _cesarKey = 0;
                cesarKeyTextBox.Text = @"0";
            }
        }

        private void cesarKeyNormalCheckBox_Click(object? sender, EventArgs e)
        {
            cesarKeyNormalCheckBox.Checked = true;
            cesarKeyReverseCheckBox.Checked = false;

            _cesarLeftToRight = true;
        }

        private void cesarKeyReverseCheckBox_Click(object? sender, EventArgs e)
        {
            cesarKeyNormalCheckBox.Checked = false;
            cesarKeyReverseCheckBox.Checked = true;

            _cesarLeftToRight = false;
        }



        private void aeroStdIntCheckBox_Click(object? sender, EventArgs e)
        {
            aeroStdIntCheckBox.Checked = true;
            aeroStdFrCheckBox.Checked = false;

            _aeroUseInt = true;
        }

        private void aeroStdFrCheckBox_Click(object? sender, EventArgs e)
        {
            aeroStdIntCheckBox.Checked = false;
            aeroStdFrCheckBox.Checked = true;

            _aeroUseInt = false;
        }

        private void vigPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (vigPasswordTextBox.Text == "")
                _vigenereKey = null;
            else
            {
                List<string> dico = DicoInit.ClassicMin();
                string text = "";
                foreach (char c in vigPasswordTextBox.Text)
                {
                    if (!dico.Contains(c.ToString()))
                        break;
                    text += c;
                }

                _vigenereKey = text;
                vigPasswordTextBox.Text = text;
            }

            Console.Out.WriteLine(_vigenereKey);
        }
        
        

        private void inputIntTextBox_KeyDown(object? sender, KeyPressEventArgs e)
        {
            if (_algorithm == TypeC.Vigenere && _vigenereKey is null)
            {
                outputIntTextBox.Text = @"Attention: veuillez entrer un mot de passe pour utiliser la Clé de Vigenère";
                return;
            }

            _inputText = inputIntTextBox.Text;
            
            int i = e.KeyChar;
            if (i != 8 && i != 27)                         // This correspond to the "delete" and "escape" keys
            {
                _inputText += e.KeyChar;    
            }
            

            outputIntTextBox.Text = InteractiveTranslate(State.Code);
            outputIntTextBox.Update();
            Update();
        }

        private void outputIntTextBox_KeyDown(object? sender, KeyPressEventArgs e)
        {
            if (_algorithm == TypeC.Vigenere && _vigenereKey is null)
            {
                inputIntTextBox.Text = @"Attention: veuillez entrer un mot de passe pour utiliser la Clé de Vigenère";
                return;
            }
            
            _outputText = outputIntTextBox.Text;

            int i = e.KeyChar;
            if (i != 8 && i != 27)                         // This correspond to the "delete" and "escape" keys
            {
                _outputText += e.KeyChar;
            }

            inputIntTextBox.Text = InteractiveTranslate(State.Decode);
            inputIntTextBox.Update();
            Update();
        }

        private string InteractiveTranslate(State state)
        {
            string text = state == State.Code ? _inputText : _outputText;
            string code = "";
            switch (_algorithm)
            {
                case TypeC.Aero:
                    _aeroInt.State = state;
                    _aeroInt.UseInternational = _aeroUseInt;
                    _aeroInt.KeepInvalidChar = _keepInvalidChar;
                    code = _aeroInt.Translate(text);
                    break;
                case TypeC.Binaire:
                    _binaireInt.State = state;
                    _binaireInt.KeepInvalidChar = _keepInvalidChar;
                    code = _binaireInt.Translate(text);
                    break;
                case TypeC.Cesar:
                    _cesarInt.State = state;
                    _cesarInt.Key = _cesarKey;
                    _cesarInt.KeepInvalidChar = _keepInvalidChar;
                    _cesarInt.LeftToRight = _cesarLeftToRight;
                    code = _cesarInt.Translate(text);
                    break;
                case TypeC.Morse:
                    _morseInt.State = state;
                    _morseInt.KeepInvalidChar = _keepInvalidChar;
                    code = _morseInt.Translate(text);
                    break;
                case TypeC.Navajo:
                    _navajoInt.State = state;
                    _navajoInt.KeepInvalidChar = _keepInvalidChar;
                    code = _navajoInt.Translate(text);
                    break;
                case TypeC.Vigenere:
                    _vigenereInt.State = state;
                    _vigenereInt.Password = _vigenereKey!;
                    _vigenereInt.KeepInvalidChar = _keepInvalidChar;
                    code = _vigenereInt.Translate(text);
                    break;
            }
            
            return code;
        }


        private void interactiveModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isInteractive)
            {
                inputIntTextBox.Visible = false;
                outputIntTextBox.Visible = false;

                inputDirTextBox.Visible = true;
                outputDirTextBox.Visible = true;
                outputDirButton.Visible = true;
                inputDirButton.Visible = true;
                crypterButton.Visible = true;
                decrypterButton.Visible = true;
            }
            else
            {
                inputIntTextBox.Visible = true;
                outputIntTextBox.Visible = true;
                interactiveModeCheckBox.Focus();
                
                inputDirTextBox.Visible = false;
                outputDirTextBox.Visible = false;
                outputDirButton.Visible = false;
                inputDirButton.Visible = false;
                crypterButton.Visible = false;
                decrypterButton.Visible = false;
            }

            _isInteractive = !_isInteractive;
        }

        private void inputDirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppContext.BaseDirectory;
            o.Filter = "fichier texte (*.txt) |*.txt";
            o.FilterIndex = 2;
            o.RestoreDirectory = true;

            if (o.ShowDialog() == DialogResult.OK)
            {
                inputDirTextBox.Text = o.FileName;
                _inputDir = o.FileName;
            }
        }

        private void outputDirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppContext.BaseDirectory;
            o.Filter = "fichier texte (*.txt) |*.txt";
            o.FilterIndex = 2;
            o.RestoreDirectory = true;

            if (o.ShowDialog() == DialogResult.OK)
            {
                outputDirTextBox.Text = o.FileName;
                _outputDir = o.FileName;
            }
        }

        private void crypterButton_Click(object sender, EventArgs e)
        {
            if (!IsReady())
                return;

            if (_inputDir != null && _outputDir != null)
            {
                Metadata met = new Metadata(_inputDir, _outputDir, State.Code, _keepInvalidChar, _codeAndTranslate,
                    _type, _cesarKey);

                ICrypt crypt = (_algorithm == TypeC.Aero) ? new Aero(met, _aeroUseInt)
                    : (_algorithm == TypeC.Cesar) ? new Cesar(met, _cesarLeftToRight)
                    : (_algorithm == TypeC.Morse) ? new Morse(met)
                    : (_algorithm == TypeC.Navajo) ? new Navajo(met)
                    : (_algorithm == TypeC.Vigenere) ? new Vigenere(met, _vigenereKey)
                    : new Binaire(met);
                
                crypt.Translate();
                crypt.WriteResult();
            }
            else
            {
                string message = "Erreur: paramètre inexistant, veuillez entrer une valeur.";
                string source = (_inputDir is null) ? nameof(_inputDir) : nameof(_outputDir);
                string details = $"Error in Crypt method: {source} should not be null";
                Error err = new Error(message, source, details);
                Error = err;
            }
            
            CryptoStatusCheck(State.Code);
        }

        private void decrypterButton_Click(object sender, EventArgs e)
        {
            if (!IsReady())
                return;

            if (_inputDir != null && _outputDir != null)
            {
                Metadata met = new Metadata(_inputDir, _outputDir, State.Decode, _keepInvalidChar, _codeAndTranslate,
                    _type, _cesarKey);

                ICrypt crypt = (_algorithm == TypeC.Aero) ? new Aero(met, _aeroUseInt)
                    : (_algorithm == TypeC.Cesar) ? new Cesar(met, _cesarLeftToRight)
                    : (_algorithm == TypeC.Morse) ? new Morse(met)
                    : (_algorithm == TypeC.Navajo) ? new Navajo(met)
                    : (_algorithm == TypeC.Vigenere) ? new Vigenere(met, _vigenereKey)
                    : new Binaire(met);
                
                crypt.Translate();
                crypt.WriteResult();
            }
            else
            {
                string message = "Erreur: paramètre inexistant, veuillez entrer une valeur.";
                string source = (_inputDir is null) ? nameof(_inputDir) : nameof(_outputDir);
                string details = $"Error in Decrypt method: {source} should not be null";
                Error err = new Error(message, source, details);
                Error = err;
            }
            
            CryptoStatusCheck(State.Decode);
        }

        private bool IsReady()
        {
            if (_inputDir is null || _outputDir is null)
                return false;

            if (!PathChecker.CheckPath(_inputDir, "in"))
            {
                MessageBox.Show($"L'addresse {_inputDir} est invalide, ou le fichier spécifié est introuvable.",
                    "Erreur: fichier source incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!PathChecker.CheckPath(_outputDir, "out"))
            {
                MessageBox.Show($"L'addresse {_outputDir} est invalide.", "Erreur : fichier cible incorrect",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_algorithm == TypeC.Vigenere && _vigenereKey is null)
                return false;

            return true;
        }

        private void CryptoStatusCheck(State state)
        {
            if (Error is not null)
            {
                MessageBox.Show(Error.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error = null;
            }
            else
            {
                string message = (state == State.Code) ? "Cryptage" : "Decryptage";
                message += " terminé !";

                MessageBox.Show(message, "Fin de l'opération", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}