using System.IO;
using System.Text;

namespace hash_code_2021
{
    public static class Serializer
    {
        public static void Serialize(int numOfIntersections, IntersectionSchedule[] schedules, string outputName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(numOfIntersections.ToString());
            for (int i = 0; i < schedules.Length; i++)
            {
                builder.Append(schedules[i].ToOutputFormat());
            }
            File.WriteAllText(outputName, builder.ToString());
        }
    }
}