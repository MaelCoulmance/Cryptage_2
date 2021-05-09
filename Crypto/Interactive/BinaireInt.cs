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
    public class BinaireInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;

        private static Binaire? _data = null;
        private static Metadata _meta = SetMeta();
        private static BinaireInt? _binaireInt = null;

        private static Metadata SetMeta()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, isInteractive: true);
            _data = new Binaire(_meta);

            return _meta;
        }

        private BinaireInt()
        {
        }

        public static BinaireInt GetInstance()
        {
            if (_binaireInt is null)
                _binaireInt = new BinaireInt();

            return _binaireInt;
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
            res.AddRange(arg.Split(" "));
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