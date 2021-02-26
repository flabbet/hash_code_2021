namespace hash_code_2021
{
    public class Path
    {
        public int NumOfStreetsCarWantsToTravel { get; set; }
        public string[] NameOfStreets { get; set; }

        public Path(int numOfStreetsCarWantsToTravel, string[] nameOfStreets)
        {
            NumOfStreetsCarWantsToTravel = numOfStreetsCarWantsToTravel;
            NameOfStreets = nameOfStreets;
        }
    }
}