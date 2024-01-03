using System.Collections;

namespace lab71
{
    [System.Serializable]
    public abstract class Seminal : Upper
    {
        public string TypeOfSeed { get; set; }
        public decimal SeedsCount { get; set; } 

        public Seminal(decimal seedscout, string name, string wayofreproduction, string typeofseed ) : base(name, wayofreproduction )
        {
            TypeOfSeed = typeofseed;
            SeedsCount = seedscout;
        }
        public Seminal(){ }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Seminal)
                    k++;
            }
            return k;
        }
    }
}
