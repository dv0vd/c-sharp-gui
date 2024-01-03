using System.Collections;

namespace lab71
{
    [System.Serializable]
    abstract public class Lower:Plant
    {
        public string Habitat { get; set; }

        public Lower(string name, string habitat ) : base(name)
        {
            Habitat = habitat;
        }
        public Lower() { }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Lower)
                    k++;
            }
            return k;
        }
    }
}
