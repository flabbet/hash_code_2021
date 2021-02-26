using System.Collections.Generic;

namespace hash_code_2021
{
    public class InputFile
    {
        public int SimulationDuration { get; set; }
        public int IntersectionsNumber { get; set; }
        public int NumOfStreets { get; set; }
        public int NumOfCars { get; set; }
        public int BonusPoints { get; set; }
        public StreetDescription[] Streets { get; set; }
        public Path[] Paths { get; set; }
    }
}