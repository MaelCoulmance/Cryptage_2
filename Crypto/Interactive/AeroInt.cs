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
    public class AeroInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;
        private static bool _useInternational = true;

        private static Aero? _data = null;
        private static Metadata _meta = SetMeta();
        private static AeroInt? _aeroInt = null;


        private static Metadata SetMeta()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, isInteractive: true);
            _data = new Aero(_meta, _useInternational);

            return _meta;
        }

        private AeroInt()
        {
        }

        public static AeroInt GetInstance()
        {
            if (_aeroInt is null)
                _aeroInt = new AeroInt();

            return _aeroInt;
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

        public bool UseInternational
        {
            get => _useInternational;
            set
            {
                _useInternational = value;
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
                string n = sd;
                if (_state == State.Code)
                {
                    n = n.Replace('.', ' ');
                }

                res += n;
            }

            return res;
        }
    }
}