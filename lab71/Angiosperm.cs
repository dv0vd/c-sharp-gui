using System.Collections;

namespace lab71
{
    [System.Serializable]
    public class Angiosperm:Seminal
    {
        public string TypeOfPlant { get; set; }
        public bool Oxygen { get; set; }
        public bool Building { get; set; }
        public bool Fuel { get; set; }
        public bool Medicine { get; set; }
        public bool Eating { get; set; }
        public bool Cosmetic { get; set; }

        public Angiosperm(decimal seedscount, string name, string typeofrepeoduction, string typeofseeds, string typeofplant, bool oxygen, bool building, bool fuel, bool medicine, bool cosmetic, bool eating):base(seedscount,name, typeofrepeoduction, typeofseeds)
        {
            TypeOfPlant = typeofplant;
            Oxygen = oxygen;
            Building = building;
            Fuel = fuel;
            Medicine = medicine;
            Eating = eating;
            Cosmetic = cosmetic;
        }
        public Angiosperm() { }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Angiosperm)
                    k++;
            }
            return k;
        }
    }
}
