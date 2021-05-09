#nullable enable

using System;

namespace Cryptage.Commons.Util
{
    public class Metadata
    {
        // absolute file path
        public readonly string Input;
        public readonly string Output;
        
        // file names (without extension)
        public readonly string InputName;
        public readonly string OutputName;
        
        // informations about crypting
        public readonly State State;
        public readonly bool KeepInvalidChar;
        public readonly bool CodeAndTranslate;
        public readonly WritingType Type;
        public readonly bool IsInteractive;
        
        // only for Cesar code
        public readonly int? CesarKey;
        
        
        // Constructor
        public Metadata(string input, string output, State state, bool keepInvalidChar, bool codeAndTranslate,
            WritingType type, int? cesarKey = null, bool isInteractive = false)
        {
            if (!isInteractive)
            {
                if (input.Equals("") || !(input.EndsWith(".txt") || input.EndsWith(".txt/")))
                    throw new ArgumentException("Invalid input path", nameof(input));

                if (output.Equals("") || !(output.EndsWith(".txt") || output.EndsWith(".txt/")))
                    throw new ArgumentException("Invalid output path", nameof(output));
            }


            this.Input = input;
            this.Output = output;
            this.IsInteractive = isInteractive;

            string[] inp = input.Split("/");
            string[] inpF = inp[^1].Split(".");
            this.InputName = inpF[0];

            string[] outp = output.Split("/");
            string[] outpF = outp[^1].Split(".");
            this.OutputName = outpF[0];

            this.State = state;
            this.KeepInvalidChar = keepInvalidChar;
            this.CodeAndTranslate = codeAndTranslate;
            this.Type = type;
            this.CesarKey = cesarKey;
        }
    }
}