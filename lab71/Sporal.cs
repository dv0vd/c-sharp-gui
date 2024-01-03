using System.Collections;

namespace lab71
{
    [System.Serializable]
    public class Sporal: Upper
    {
        public string TypeOfSpores { get; set; }
        public string Habitat { get; set; }
        public string Type { get; set; }

        public Sporal(string name, string type, string wayofreproduction, string typeofspores, string habitat) : base(name, wayofreproduction)
        {
            TypeOfSpores = typeofspores;
            Habitat = habitat;
            Type = type;
        }
        public Sporal() { }

        public static int Count(ArrayList array,ref int моховидный, ref int плауновидный,ref int хвощевидный,ref int папоротниковидный)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Sporal)
                {
                    Sporal s = (Sporal)v;
                    if (s.Type == "моховидный")
                        моховидный++;
                    if (s.Type == "плауновидный")
                        плауновидный++;
                    if (s.Type == "хвощевидный")
                        хвощевидный++;
                    if (s.Type == "папоротниковидный")
                        папоротниковидный++;
                }
            }
            return k;
        }
    }
}
