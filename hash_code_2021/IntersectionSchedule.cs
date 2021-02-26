using System.Text;

namespace hash_code_2021
{
    public class IntersectionSchedule
    {
        public int IntersectionId { get; set; }
        public int NumOfIncomingStreets { get; set; }
        public GreenLightSchedule[] GreenLightSchedules { get; set; }

        public IntersectionSchedule(int intersectionId, int numOfIncomingStreets, GreenLightSchedule[] greenLightSchedules)
        {
            IntersectionId = intersectionId;
            NumOfIncomingStreets = numOfIncomingStreets;
            GreenLightSchedules = greenLightSchedules;
        }

        public string ToOutputFormat()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(IntersectionId.ToString());
            builder.AppendLine(NumOfIncomingStreets.ToString());
            foreach (var greenLightSchedule in GreenLightSchedules)
            {
                builder.AppendLine($"{greenLightSchedule.StreetName} {greenLightSchedule.GreenLightDuration}");
            }

            return builder.ToString();
        }
    }
}