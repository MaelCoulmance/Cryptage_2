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
    public class CesarInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;
        private static int _key = 0;
        private static bool _leftToRight = true;


        private static Cesar? _data = null;
        private static Metadata _meta = SetMeta();
        private static CesarInt? _cesarInt = null;

        private static Metadata SetMeta()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, _key, true);
            _data = new Cesar(_meta, _leftToRight);
            return _meta;
        }

        private CesarInt()
        {
        }

        public static CesarInt GetInstance()
        {
            if (_cesarInt is null)
                _cesarInt = new CesarInt();

            return _cesarInt;
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

        public int Key
        {
            get => _key;
            set
            {
                _key = value;
                SetMeta();
            }
        }

        public bool LeftToRight
        {
            get => _leftToRight;
            set
            {
                _leftToRight = value;
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
            List<string> s =  _data!.GetResult();
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