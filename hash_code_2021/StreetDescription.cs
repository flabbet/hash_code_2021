namespace hash_code_2021
{
    public class StreetDescription
    {
        public int StartIntersections { get; set; }
        public int EndIntersections { get; set; }
        public string Name { get; set; }
        public int TimeToFinishAStreet { get; set; }

        public StreetDescription(int startIntersections, int endIntersections, string name, int timeToFinishAStreet)
        {
            StartIntersections = startIntersections;
            EndIntersections = endIntersections;
            Name = name;
            TimeToFinishAStreet = timeToFinishAStreet;
        }
    }
}