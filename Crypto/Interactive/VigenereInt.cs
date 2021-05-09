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
    public class VigenereInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;
        private static string? _password = null;

        private static Vigenere? _data = null;
        private static Metadata _meta = SetMet();
        private static VigenereInt? _vigenereInt = null;

        private static Metadata SetMet()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, isInteractive: true);
            _data = new Vigenere(_meta, _password ?? "");

            return _meta;
        }

        private VigenereInt()
        {
        }


        public static VigenereInt GetInstance()
        {
            if (_vigenereInt is null)
                _vigenereInt = new VigenereInt();

            return _vigenereInt;
        }
        
        #region Get Set

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                SetMet();
            }
        }

        public bool KeepInvalidChar
        {
            get => _keepInvalidChar;
            set
            {
                _keepInvalidChar = value;
                SetMet();
            }
        }

        public string Password
        {
            get => _password ?? "";
            set
            {
                _password = value;
                SetMet();
            }
        }
        
        #endregion

        private static List<string> Convert(string arg)
        {
            List<string> res = new List<string>();
            res.AddRange(arg.Split(" "));
            return res;
        }

        public string Translate(string arg)
        {
            if (_password is null)
                throw new InvalidOperationException("Password cannot be null");

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