namespace hash_code_2021
{
    public class GreenLightSchedule
    {
        public string StreetName { get; set; }
        public int GreenLightDuration { get; set; }

        public GreenLightSchedule(string streetName, int greenLightDuration)
        {
            StreetName = streetName;
            GreenLightDuration = greenLightDuration;
        }
    }
}