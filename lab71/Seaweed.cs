using System.Collections;

namespace lab71
{
    [System.Serializable]
    public class Seaweed: Lower
    {
        public bool Eating { get; set; }
        public bool Oxygen { get; set; }
        public bool Fertilizer { get; set; }

        public Seaweed(string name, string habitat, bool eating, bool oxygen, bool fertilizer) : base(name, habitat)
        {
            Eating = eating;
            Oxygen = oxygen;
            Fertilizer = fertilizer;
        }
        public Seaweed() { }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach(var v in array)
            {
                if (v is Seaweed)
                    k++;
            }
            return k;
        }
    }
}
