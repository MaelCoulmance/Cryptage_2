using System;
using System.Collections.Generic;

using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Cesar : ICrypt
    {
        private readonly Metadata _metadata;
        private readonly int _key;
        private readonly bool _leftToRight;

        private bool _finished;
        private readonly bool _keepInvalidChar;

        private readonly List<string> _dico = DicoInit.ClassicMin();

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();


        public Cesar(Metadata met, bool leftToRight)
        {
            this._metadata = met;

            if (met.CesarKey is null)
                throw new NullReferenceException($"Error in Cesar constructor: {nameof(met.CesarKey)} cannot be null");
            this._key = Math.Abs((int) _metadata.CesarKey!);
            this._leftToRight = leftToRight;

            this._finished = false;
            this._keepInvalidChar = met.KeepInvalidChar;
        }


        public void Translate()
        {
            if (_metadata.State == State.Code)
            {
                _mots = FileManager.ReadFile(_metadata.Input);
                Code();
            }
            else
            {
                _codes = FileManager.ReadFile(_metadata.Input);
                Decode();
            }

            _finished = true;
        }

        public void InteractiveTranslate(List<string> arg)
        {
            if (_metadata.State == State.Code)
            {
                _mots = arg;
                Code();
            }
            else
            {
                _codes = arg;
                Decode();
            }

            _finished = true;
        }

        public bool GetState()
        {
            return _finished;
        }

        public List<string> GetResult()
        {
            if (!_finished)
                throw new InvalidOperationException("Nothing to return");

            return (_metadata.State == State.Code) ? _codes : _mots;
        }

        public void WriteResult()
        {
            if (_metadata.State == State.Code)
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 25, _codes);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _codes);
                }
                else 
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 25, 25, _codes, _mots);
            }
            else
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 25, _mots);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _mots);
                } else 
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 25, 25, _mots, _codes);
            }
        }


        private void Code()
        {
            // analyse du texte
            for (int i = 0; i < _mots.Count; i++)
            {
                string mot = _mots[i];              // On récupère le i-eme mot du texte
                string code = "";                   // Version traduite du mot
                
                // analyse lettre par lettre
                for (int j = 0; j < mot.Length; j++)
                {
                    string lettre = mot[j].ToString();
                    int pos = 0;
                    string mode = "";
                    
                    // scan dico
                    for (int k = 0; k < _dico.Count; k++)
                    {
                        if (_dico[k].Equals(lettre))
                        {
                            mode = "min";
                            pos = k;
                            break;
                        }

                        if (_dico[k].ToUpper().Equals(lettre))
                        {
                            mode = "maj";
                            pos = k;
                            break;
                        }
                    }
                    
                    // Traduction de la lettre si possible
                    if (!mode.Equals("") && pos != -1)
                    {
                        int newPos = pos;

                        if (_leftToRight)
                        {
                            newPos += _key;
                            while (newPos >= _dico.Count)
                                newPos -= _dico.Count;
                        }
                        else
                        {
                            newPos -= _key;
                            while (newPos < 0)
                                newPos += _dico.Count;
                        }


                        if (mode == "min")
                        {
                            code += _dico[newPos];
                        }
                        else
                        {
                            code += _dico[newPos].ToUpper();
                        }
                    }
                    else
                    {
                        if (_keepInvalidChar)
                            code += lettre;
                    }
                }

                _codes.Add(code);
            }
        }

        private void Decode()
        {
            // analyse du texte
            for (int i = 0; i < _codes.Count; i++)
            {
                string mot = _codes[i];                     // On récupère le i-eme mot de la liste
                string decode = "";                         // Version décodée du mot
                
                // analyse lettre par lettre
                for (int j = 0; j < mot.Length; j++)
                {
                    string lettre = mot[j].ToString();
                    string mode = "";
                    int pos = -1;
                    
                    // scan dico
                    for (int k = 0; k < _dico.Count; k++)
                    {
                        if (_dico[k].Equals(lettre))
                        {
                            mode = "min";
                            pos = k;
                            break;
                        }

                        if (_dico[k].ToUpper().Equals(lettre))
                        {
                            mode = "maj";
                            pos = k;
                            break;
                        }
                    }
                    
                    // On traduit la lettre si possible
                    if (!mode.Equals("") && pos != -1)
                    {
                        int newPos = pos;

                        if (_leftToRight)
                        {
                            newPos -= _key;

                            while (newPos < 0)
                                newPos += _dico.Count;
                        }
                        else
                        {
                            newPos += _key;

                            while (newPos >= _dico.Count)
                                newPos -= _dico.Count;
                        }

                        if (mode == "min")
                            decode += _dico[newPos];
                        else
                            decode += _dico[newPos].ToUpper();
                    }
                    else
                    {
                        if (_keepInvalidChar)
                            decode += lettre;
                    }
                }
                
                _mots.Add(decode);
            }
        }
    }
}