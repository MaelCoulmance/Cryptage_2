using System;
using System.Collections.Generic;

using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Navajo : ICrypt
    {
        private readonly Metadata _metadata;
        private bool _finished = false;

        private readonly List<string> _dico = DicoInit.ClassicMin();
        private readonly List<string> _dicoNavajo = DicoInit.NavajoMin();
        private readonly List<string> _dicoNavajoMaj = DicoInit.NavajoMaj();

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();

        private readonly bool _keepInvalidChar;


        public Navajo(Metadata met)
        {
            _metadata = met;
            _finished = false;
            _keepInvalidChar = met.KeepInvalidChar;
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

            return _metadata.State == State.Code ? _codes : _mots;
        }

        public void WriteResult()
        {
            if (_metadata.State == State.Code)
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 5, _codes);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _codes);
                } 
                else
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 5, 20, _codes, _mots);
            }
            else
            {
                if (!_metadata.CodeAndTranslate)
                {
                    if (_metadata.Type == WritingType.Normal)
                        FileManager.WriteFile(_metadata.Output, " ", 20, _mots);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _mots);
                } 
                else
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 20, 5, _mots, _codes);
            }
        }



        private void Code()
        {
            // lecture du texte
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
                    if (mode != "" && pos != -1)
                    {
                        if (mode == "min")
                        {
                            code += _dicoNavajo[pos];
                        }
                        else
                        {
                            code += _dicoNavajoMaj[pos];
                        }
                    }
                    else
                    {
                        if (_keepInvalidChar)
                            code += lettre;
                    }

                    code += ".";
                }
                
                _codes.Add(code);
            }
        }

        private void Decode()
        {
            CodeCleaner();

            // lecture du texte
            for (int i = 0; i < _codes.Count; i++)
            {
                string mot = _codes[i];
                string decode = "";

                string[] data = mot.Split(".");
                
                // analyse lettre par lettre
                foreach (string s in data)
                {
                    string mode = "";
                    int pos = -1;
                    
                    // scan dico
                    for (int j = 0; j < _dicoNavajo.Count; j++)
                    {
                        if (_dicoNavajo[j].Equals(s))
                        {
                            mode = "min";
                            pos = j;
                            break;
                        }

                        if (_dicoNavajoMaj[j].Equals(s))
                        {
                            mode = "maj";
                            pos = j;
                            break;
                        }
                    }
                    
                    // traduction si possible
                    if (mode != "" && pos != -1)
                    {
                        if (mode == "min")
                        {
                            decode += _dico[pos];
                        }
                        else
                        {
                            decode += _dico[pos].ToUpper();
                        }
                    }
                    else
                    {
                        if (_keepInvalidChar)
                            decode += s;
                    }
                }
                
                _mots.Add(decode);
            }
        }

        private void CodeCleaner()
        {
            // Deletes useless strings in list
            // This allows us to have a better layout for the output file.
            
            List<string> tmp = new List<string>();

            foreach (string s in _codes)
            {
                if (s.StartsWith("\r\n"))
                {
                    string s1 = s.Substring("\r\n".Length);
                    tmp.Add(s1);
                } else if (s.EndsWith("\r\n"))
                {
                    string s2 = s.Substring(0, s.Length - "\r\n".Length);
                    tmp.Add(s2);
                }
                else
                {
                    tmp.Add(s);
                }
            }

            _codes = tmp;
        }
    }
}