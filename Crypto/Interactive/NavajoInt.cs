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
    public class NavajoInt
    {
        private static State _state = State.Code;
        private static bool _keepInvalidChar = true;

        private static Navajo? _data = null;
        private static Metadata _meta = SetMeta();
        private static NavajoInt? _navajoInt = null;


        private static Metadata SetMeta()
        {
            _meta = new Metadata("", "", _state, _keepInvalidChar, false, WritingType.Normal, isInteractive: true);
            _data = new Navajo(_meta);
            return _meta;
        }

        private NavajoInt()
        {
        }

        public static NavajoInt GetInstance()
        {
            if (_navajoInt is null)
                _navajoInt = new NavajoInt();

            return _navajoInt;
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
                string next = sd;
                if (_state == State.Code)
                {
                    string n = "";
                    foreach (char c in next)
                    {
                        if (c != '.')
                            n += c;
                        else
                            n += " ";
                    }

                    next = n;
                }

                res += next;
                res += " ";
            }

            return res;
        }
    }
}