using System.Collections.Generic;

namespace Cryptage.Crypto
{
    public interface ICrypt
    {
        public void Translate();
        
        public bool GetState();

        public List<string> GetResult();

        public void WriteResult();

        public void InteractiveTranslate(List<string> arg);
    }
}