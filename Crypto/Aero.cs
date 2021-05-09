using System;
using System.Collections.Generic;

using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Aero : ICrypt
    {
        private readonly Metadata _metadata;
        private bool _finished;

        private readonly List<string> _dico = DicoInit.ClassicMin();
        private readonly List<string> _dicoAero;
        private readonly List<string> _dicoAeroMaj;

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();

        private readonly bool _keepInvalidChar;


        public Aero(Metadata met, bool useInternational)
        {
            _metadata = met;
            _finished = false;
            _keepInvalidChar = met.KeepInvalidChar;

            _dicoAero = useInternational ? DicoInit.AeroIntMin() : DicoInit.AeroFrMin();
            _dicoAeroMaj = useInternational ? DicoInit.AeroIntMaj() : DicoInit.AeroFrMaj();
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
                throw new InvalidOperationException("Nothing to return here");

            if (_metadata.State == State.Decode)
            {
                for (int i = 0; i < _mots.Count; i++)
                {
                    _mots[i] += " ";
                }
            }
            
            return _metadata.State == State.Code ? _codes : _mots;
        }

        public void WriteResult()
        {
            if (_metadata.State == State.Code)
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 1, _codes);
                    else
                        FileManager.WriteFile(_metadata.Output, null, null, _codes);
                }
                else
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 1, 30, _codes, _mots);
            }
            else
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 30, _mots);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _mots);
                } 
                else 
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 30, 1, _mots, _codes);
            }
        }


        private void Code()
        {
            // analyse du texte
            for (int i = 0; i < _mots.Count; i++)
            {
                string mot = _mots[i];
                string code = "";
                
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
                    
                    // traduction si possible
                    if (!mode.Equals("") && pos != -1)
                    {
                        if (mode == "min")
                        {
                            code += _dicoAero[pos];
                            code += ".";
                        }
                        else
                        {
                            code += _dicoAeroMaj[pos];
                            code += ".";
                        }
                    }
                    else
                    {
                        if (_keepInvalidChar)
                        {
                            code += lettre;
                            code += ".";
                        }
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
                string mot = _codes[i];
                string decode = "";

                string[] data = mot.Split(".");
                
                // analyse mot par mot
                foreach (string lettre in data)
                {
                    string mode = "";
                    int pos = -1;
                    
                    // scan dico
                    for (int k = 0; k < _dicoAero.Count; k++)
                    {
                        if (_dicoAero[k].Equals(lettre) || lettre.Contains(_dicoAero[k]))
                        {
                            mode = "min";
                            pos = k;
                            break;
                        }

                        if (_dicoAeroMaj[k].Equals(lettre) || lettre.Contains(_dicoAeroMaj[k]))
                        {
                            mode = "maj";
                            pos = k;
                            break;
                        }
                    }
                    
                    // traduction si possible
                    if (!mode.Equals("") && pos != -1)
                    {
                        if (mode == "min")
                            decode += _dico[pos];
                        else
                            decode += _dico[pos].ToUpper();
                    }
                    else
                    {
                        if (_keepInvalidChar)
                            decode += lettre;
                    }
                }
                
                _mots.Add(decode);
            }
            
            DecodeOptimization();
        }

        private void DecodeOptimization()
        {
            // Deletes empty strings from _mots
            // This allows us to have a better layout for the output file
            
            List<string> tmp = new List<string>();

            foreach (string s in _mots)
            {
                if (!s.Equals(""))
                    tmp.Add(s);
            }

            _mots = tmp;
        }
    }
}