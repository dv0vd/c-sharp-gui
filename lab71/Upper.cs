using System.Collections;

namespace lab71
{
    [System.Serializable]
    abstract public class Upper : Plant
    { 
        public string WayOfReproduction { get; set; }

        public Upper(string name, string wayofreproduction): base(name)
        {
            WayOfReproduction = wayofreproduction;
        }
        public Upper() { }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Upper)
                    k++;
            }
            return k;
        }
    }
}
