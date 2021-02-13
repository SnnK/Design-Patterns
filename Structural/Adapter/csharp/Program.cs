using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            CryptoA cryptoA = new CryptoA();
            cryptoA.EnCrypto("TestEn");
            cryptoA.DeCrypto("TestDe");

            CryptoOther cryptoOther = new CryptoOther();
            var crypto = new CryptoOtherAdapter(cryptoOther);
            crypto.EnCrypto("TestEn");
            crypto.DeCrypto("TestDe");

            Console.Read();
        }
    }


    public interface Crypto
    {
        void DeCrypto(string text);
        void EnCrypto(string text);
    }

    public class CryptoA : Crypto
    {
        public void DeCrypto(string text)
        {
            Console.WriteLine("CryptoA DeCrypto " + text);
        }

        public void EnCrypto(string text)
        {
            Console.WriteLine("CryptoA EnCrypto " + text);
        }
    }

    public class CryptoB : Crypto
    {
        public void DeCrypto(string text)
        {
            Console.WriteLine("CryptoB DeCrypto " + text);
        }

        public void EnCrypto(string text)
        {
            Console.WriteLine("CryptoB EnCrypto" + text);
        }
    }

    //yukarıdaki 2 class Crypto interface'inden türetilmiştir. Bu class'ların çalışmasında herhangi bir proıblem yoktur.

    //Aşağıdaki class Crypto interface'i kullanılarak türetilmediğinden metodları farklıdır. Bu class'ın adapter'ını yazarak CryptoA ve CryptoB class'larının kullanıldığı gibi kullanılabilir.

    public class CryptoOther
    {
        public void OtherDeCrypto(string text)
        {
            Console.WriteLine("OtherCryptoA DeCrypto " + text);
        }

        public void OtherEnCrypto(string text)
        {
            Console.WriteLine("OtherCryptoA EnCrypto " + text);
        }
    }

    public class CryptoOtherAdapter : Crypto
    {

        private readonly CryptoOther _cryptoOther;

        public CryptoOtherAdapter(CryptoOther cryptoOther)
        {
            _cryptoOther = cryptoOther;
        }

        public void DeCrypto(string text)
        {
            _cryptoOther.OtherDeCrypto(text);
        }

        public void EnCrypto(string text)
        {
            _cryptoOther.OtherEnCrypto(text);
        }
    }
}