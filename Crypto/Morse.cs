using System;
using System.Collections.Generic;

using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Morse : ICrypt
    {
        private readonly Metadata _metadata;
        private bool _finished;

        private readonly List<string> _dico = DicoInit.ClassicMin();
        private readonly List<string> _dicoMorse = DicoInit.Morse();

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();

        private readonly bool _keepInvalidChar;


        public Morse(Metadata met)
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
            // analyse du texte
            for (int i = 0; i < _mots.Count; i++)
            {
                string mot = _mots[i];
                string code = "";

                // analyse lettre par lettre
                for (int j = 0; j < mot.Length; j++)
                {
                    string lettre = mot[j].ToString();
                    int pos = -1;

                    // scan dico
                    for (int k = 0; k < _dico.Count; k++)
                    {
                        if (_dico[k].Equals(lettre) || _dico[k].ToUpper().Equals(lettre.ToUpper()))
                        {
                            pos = k;
                            break;
                        }
                    }


                    // traduction si possible
                    if (pos != -1)
                    {
                        code += _dicoMorse[pos];
                        if (!_metadata.IsInteractive) code += "/";
                        else code += " ";
                    }
                    else
                    {
                        if (_keepInvalidChar)
                        {
                            code += lettre;
                            if (!_metadata.IsInteractive) code += "/";
                            else code += " ";
                        }
                    }
                }

                _codes.Add(code);
            }
        }

        private void Decode()
        {
            CodeCleaner();
            
            // analyse du texte
            for (int i = 0; i < _codes.Count; i++)
            {
                string mot = _codes[i];
                string decode = "";

                string[] data = mot.Split("/");

                // analyse lettre par lettre
                foreach (string s in data)
                {
                    int pos = -1;
                    for (int j = 0; j < _dicoMorse.Count; j++)
                    {
                        if (_dicoMorse[j].Equals(s))
                        {
                            pos = j;
                            break;
                        }
                    }

                    // traduction si possible
                    if (pos != -1)
                    {
                        decode += _dico[pos].ToLower();
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
            // Remove useless data in strings
            // This allows us to have a better layout for the output file.
            
            List<string> tmp = new List<string>();

            foreach (string s in _codes)
            {
                if (s.StartsWith("\r\n"))
                {
                    string s2 = s.Substring("\r\n".Length);
                    tmp.Add(s2);
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