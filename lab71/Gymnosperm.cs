using System.Collections;

namespace lab71
{
    [System.Serializable]
    public class GymnoSperm : Seminal
    {
        public string TypeOfPlant { get; set; }
        public bool Oxygen { get; set; }
        public bool Building { get; set; }
        public bool Fuel { get; set; }
        public bool Medicine { get; set; }
        public bool Eating { get; set; }
        public bool Furniture { get; set; }
        public bool ShipBuilding { get; set; }

        public GymnoSperm(decimal seedscount, string name, string typeofrepeoduction, string typeofseeds, string typeofplant, bool shipbuilding, bool oxygen, bool building, bool fuel, bool medicine, bool furniture, bool eating) : base(seedscount, name, typeofrepeoduction, typeofseeds)
        {
            TypeOfPlant = typeofplant;
            Oxygen = oxygen;
            Building = building;
            Fuel = fuel;
            Medicine = medicine;
            Eating = eating;
            Furniture = furniture;
            ShipBuilding = shipbuilding;
        }
        public GymnoSperm() { }

        public new static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is GymnoSperm)
                    k++;
            }
            return k;
        }
    }
}
