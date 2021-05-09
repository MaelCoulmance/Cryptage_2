using System;
using System.Collections.Generic;
using System.IO;
using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Vigenere : ICrypt
    {
        private readonly Metadata _metadata;
        private readonly string _key;
        private List<string> _fullKey;

        private bool _finished;
        private readonly bool _keepInvalidChar;

        private readonly List<string> _dico = DicoInit.ClassicMin();
        private readonly Dictionary<string, List<string>> _table = InitTable();

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();


        public Vigenere(Metadata met, string key)
        {
            _metadata = met;
            _key = key;

            _finished = false;
            _keepInvalidChar = met.KeepInvalidChar;
        }

        public void Translate()
        {
            if (_metadata.State == State.Code)
            {
                _mots = FileManager.ReadFile(_metadata.Input);
                _fullKey = SetFullKey();
                Code();
            }
            else
            {
                _codes = FileManager.ReadFile(_metadata.Input);
                _fullKey = SetFullKey();
                Decode();
            }

            _finished = true;
        }

        public void InteractiveTranslate(List<string> arg)
        {
            if (_metadata.State == State.Code)
            {
                _mots = arg;
                _fullKey = SetFullKey();
                Code();
            }
            else
            {
                _codes = arg;
                _fullKey = SetFullKey();
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
                } 
                else
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 25, 25, _mots, _codes);
            }
        }



        private static Dictionary<string, List<string>> InitTable()
        {
            Dictionary<string, List<string>> tmp = new Dictionary<string, List<string>>();
            List<string> firstLine = DicoInit.ClassicMin();
            tmp.Add("a", firstLine);

            for (int i = 1; i < 26; i++)
            {
                List<string> nextLine = new List<string>();
                for (int j = 1; j < firstLine.Count; j++)
                {
                    nextLine.Add(firstLine[j]);
                }
                nextLine.Add(firstLine[0]);

                string lettre = nextLine[0];
                tmp.Add(lettre, nextLine);

                firstLine = nextLine;
            }

            return tmp;
        }

        private List<string> SetFullKey()
        {
            if ((_metadata.State == State.Code && _mots.Count == 0) || (_metadata.State == State.Decode && _codes.Count == 0))
                throw new MethodAccessException("The method SetFullKey should be used only after the initialization of _mots or _codes");

            int length = 0;
            foreach (string s in (_metadata.State == State.Code) ? _mots : _codes)
            {
                foreach (char c in s)
                {
                    length++;
                }
            }

            List<string> res = new List<string>();
            while (length >= _key.Length)
            {
                foreach (char c in _key)
                {
                    res.Add(c.ToString());
                }

                length -= _key.Length;
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), $"problem with length initialization: value={length}");
            }

            int compt = 0;
            while (length != 0)
            {
                res.Add(_key[compt].ToString());
                length--;
                compt++;
            }

            return res;
        }

        public List<string> GetFullKey() => _fullKey ?? throw new MethodAccessException("Full key not set yet");
        
        
        // static field
        public static void PrintTable()
        {
            Console.Out.WriteLine(GetTable());
        }

        public static string GetTable()
        {
            var table = InitTable();

            List<string> d = DicoInit.ClassicMin();
            string res = "";

            foreach (string s in d)
            {
                res += $"{s} : ";
                List<string> data = table[s];
                foreach (string sd in data)
                    res += $"{sd} ";
                res += "\n";
            }

            return res;
        }


        private void Code()
        {
            // analyse texte
            for (int i = 0, keyPos = 0; i < _mots.Count; i++)
            {
                string mot = _mots[i];
                string code = "";
                
                // analyse lettre par lettre
                for (int j = 0; j < mot.Length; j++)
                {
                    string lettre = mot[j].ToString();
                    string key = _fullKey[keyPos];
                    string mode = "";
                    int pos = -1;
                    
                    // scan dico
                    for (int k = 0; k < _dico.Count; k++)
                    {
                        if (_dico[k] == lettre)
                        {
                            mode = "min";
                            pos = k;
                            break;
                        }

                        if (_dico[k].ToUpper() == lettre)
                        {
                            mode = "maj";
                            pos = k;
                            break;
                        }
                    }
                    
                    // traduction si possible
                    if (mode != "" && pos != -1)
                    {
                        List<string> data = _table[key];

                        if (mode == "min")
                            code += data[pos];
                        else
                            code += data[pos].ToUpper();

                        keyPos++;
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
            // analyse texte
            for (int i = 0, keyPos = 0; i < _codes.Count; i++)
            {
                string mot = _codes[i];
                string decode = "";
                
                // analyse lettre par lettre
                for (int j = 0; j < mot.Length; j++)
                {
                    string key = _fullKey[keyPos];
                    string lettre = mot[j].ToString();
                    string mode = "";
                    int pos = -1;

                    List<string> data = _table[key];
                    
                    // scan data
                    for (int k = 0; k < data.Count; k++)
                    {
                        if (data[k] == lettre)
                        {
                            mode = "min";
                            pos = k;
                            break;
                        }

                        if (data[k].ToUpper() == lettre)
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
                            decode += _dico[pos];
                        else
                            decode += _dico[pos].ToUpper();

                        keyPos++;
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