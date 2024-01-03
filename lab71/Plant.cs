using System;
using System.Collections;

namespace lab71
{
    [System.Serializable]
    public abstract class Plant: IComparable<Plant>
    {
        public string Name { get; set; }

        public Plant(string name)
        {
            Name = name;
        }
        public Plant() { }

        public static int Count(ArrayList array)
        {
            int k = 0;
            foreach (var v in array)
            {
                if (v is Plant)
                    k++;
            }
            return k;
        }

        public int CompareTo(Plant other)
        {
            for (int i = 0; i < (this.Name.Length > other.Name.Length ? other.Name.Length : this.Name.Length); i++)
            {
                if (this.Name.ToCharArray()[i] < other.Name.ToCharArray()[i]) return -1;
                if (this.Name.ToCharArray()[i] > other.Name.ToCharArray()[i]) return 1;
            }
            return -1;
        }
}
}
