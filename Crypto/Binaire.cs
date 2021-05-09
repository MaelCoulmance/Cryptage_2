using System;
using System.Collections.Generic;
using System.Text;

using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto
{
    public class Binaire : ICrypt
    {
        private readonly Metadata _metadata;
        private bool _finished;

        private List<string> _mots = new List<string>();
        private List<string> _codes = new List<string>();

        private bool _keepInvalidChar;


        public Binaire(Metadata met)
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
                        FileManager.WriteFile(_metadata.Output, " ", 15, _codes);
                    else 
                        FileManager.WriteFile(_metadata.Output, null, null, _codes);
                } 
                else
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 15, 25, _codes, _mots);
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
                    FileManager.WriteFileWithOriginalText(_metadata.Output, " ", " ", 25, 15, _mots, _codes);
            }
        }


        private string StringToBin(string arg)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in arg)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return sb.ToString();
        }

        private string BinToString(string arg)
        {
            List<Byte> data = new List<byte>();

            for (int i = 0; i < arg.Length; i += 8)
            {
                data.Add(Convert.ToByte(arg.Substring(i, 8), 2));
            }

            return Encoding.UTF8.GetString(data.ToArray());
        }


        private void Code()
        {
            foreach (string s in _mots)
            {
                string code = StringToBin(s);
                _codes.Add(code);
            }
        }

        private void Decode()
        {
            List<string> dico = DicoInit.ClassicMin();
            foreach (string s in _codes)
            {
                string decode = BinToString(s);

                string res = "";
                for (int i = 0; i < decode.Length; i++)
                {
                    char c = decode[i];
                    bool isCorrect = false;
                    foreach (string d in dico)
                    {
                        if (c.ToString() == d || c.ToString() == d.ToUpper())
                        {
                            isCorrect = true;
                            break;
                        }
                    }

                    if (isCorrect || _keepInvalidChar)
                        res += c;
                }
                
                _mots.Add(res);
            }
        }
    }
}