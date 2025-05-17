

using ClientTM.Tries.Reals;

namespace ClientTM.Tries
{
    public class FabriqueTry
    {
        public static ITry Creer(int nbTry)
        {
            if (nbTry == 1) { return new FirstTry(); }
            if (nbTry == 2) { return new SecondTry();}
            return null;
        }
    }
}
