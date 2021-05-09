using System;

namespace Cryptage.Commons.Util
{
    public enum State
    {
        Code = 0,
        Decode = 1
    }

    public enum TypeC
    {
        Cesar = 0,
        Morse = 1,
        Aero = 2,
        Navajo = 3,
        Vigenere = 4,
        Binaire = 5
    }

    public enum WritingType
    {
        Normal = 0,
        WordPerWord = 1
    }


    public static class EnumFunc
    {
        public static string TypeToString(TypeC? type)
        {
            return (type == TypeC.Cesar) ? "Cesar"
                : (type == TypeC.Aero) ? "Aéronautique"
                : (type == TypeC.Morse) ? "Morse"
                : (type == TypeC.Navajo) ?"Navajo"
                : (type == TypeC.Vigenere) ? "Vigenère"
                : (type == TypeC.Binaire) ? "Binaire"
                : "A propos";
        }
    } 
}