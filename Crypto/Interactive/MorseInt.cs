#nullable enable

using System;
using System.IO;
using System.Collections.Generic;

using Cryptage.Crypto;
using Cryptage.Commons;
using Cryptage.Commons.Util;
using Cryptage.Commons.Util.Generic;

namespace Cryptage.Crypto.Interactive
{
    public class MorseInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;

        private static Morse? _data = null;
        private static Metadata _meta = SetMeta();
        private static MorseInt? _morseInt = null;

        private static Metadata SetMeta()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, isInteractive: true);
            _data = new Morse(_meta);
            return _meta;
        }

        private MorseInt()
        {
        }


        public static MorseInt GetInstance()
        {
            if (_morseInt is null)
                _morseInt = new MorseInt();

            return _morseInt;
        }
        
        
        #region Get Set

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                SetMeta();
            }
        }

        public bool KeepInvalidChar
        {
            get => _keepInvalidChar;
            set
            {
                _keepInvalidChar = value;
                SetMeta();
            }
        }
        
        #endregion
        
        private static List<string> Convert(string arg)
        {
            List<string> res = new List<string>();

            if (_state == State.Code)
            {
                res.AddRange(arg.Split(" "));
                return res;
            }

            string tmp = "";
            foreach (char c in arg)
            {
                if (c == ' ')
                {
                    tmp += "/";
                    res.Add(tmp);
                    tmp = "";
                }
                else
                    tmp += c;
            }

            return res;
        }

        public string Translate(string arg)
        {
            List<string> tmp = Convert(arg);
            _data!.InteractiveTranslate(tmp);
            List<string> s = _data!.GetResult();
            string res = "";
            foreach (string sd in s)
            {
                res += sd;
                res += " ";
            }

            return res;
        }
        
    }
}