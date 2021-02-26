using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hash_code_2021
{
    class Program
    {
        static InputFile Parse(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            InputFile file = new InputFile();

            string[] firstLineData = lines[0].Split(" ");
            file.SimulationDuration = int.Parse(firstLineData[0]);
            file.IntersectionsNumber = int.Parse(firstLineData[1]);
            file.NumOfStreets = int.Parse(firstLineData[2]);
            file.NumOfCars = int.Parse(firstLineData[3]);
            file.BonusPoints = int.Parse(firstLineData[4]);
            file.Streets = new StreetDescription[file.NumOfStreets];
            file.Paths = new Path[file.NumOfCars];

            for (int i = 0; i < file.NumOfStreets; i++)
            {
                string[] desc = lines[1 + i].Split(" ");
                file.Streets[i] =
                    new StreetDescription(
                        int.Parse(desc[0]),
                        int.Parse(desc[1]),
                        desc[2], int.Parse(desc[3]));
            }

            for (int i = 0; i < file.NumOfCars; i++)
            {
                string[] car = lines[file.NumOfStreets + i + 1].Split(" ");
                int numOfStreetsCarWantsToTravel = int.Parse(car[0]);
                string[] names = new string[numOfStreetsCarWantsToTravel];
                for (int j = 0; j < numOfStreetsCarWantsToTravel; j++)
                {
                    names[j] = car[j + 1];
                }
                file.Paths[i] = new Path(numOfStreetsCarWantsToTravel, names);
            }
            return file;
        }

        static void Main(string[] args)
        {
            var files = Directory.GetFiles("InputFiles");
            foreach (var file in files)
            {
                var parsedFile = Parse(file);
            Dictionary<string, int> counters = new Dictionary<string, int>();

            foreach (var path in parsedFile.Paths)
            {
                foreach (var street in path.NameOfStreets)
                {
                    if (!counters.ContainsKey(street))
                        counters.Add(street, 0);
                    counters[street]++;
                }
            }

            Dictionary<int, List<StreetDescription>> intersections = new Dictionary<int, List<StreetDescription>>();
            foreach (var street in parsedFile.Streets)
            {
                if (!intersections.ContainsKey(street.EndIntersections))
                    intersections.Add(street.EndIntersections, new List<StreetDescription>());
                intersections[street.EndIntersections].Add(street);
            }

            List<IntersectionSchedule> schedules = new List<IntersectionSchedule>();

            foreach (var intersection in intersections)
            {
                List<GreenLightSchedule> greenLights = new List<GreenLightSchedule>();


                int result = counters.ContainsKey(intersection.Value[0].Name) ? counters[intersection.Value[0].Name] : 0;
                for (int i = 1; i < intersection.Value.Count; i++)
                {
                    int dur = counters.ContainsKey(intersection.Value[i].Name) ? counters[intersection.Value[i].Name] : 0;

                    result = GCD(result, dur);
                }

                foreach (var street in intersection.Value)
                {
                    if (!counters.ContainsKey(street.Name) || counters[street.Name] == 0)
                        continue;
                    GreenLightSchedule greenLight = new GreenLightSchedule(street.Name, (int)Math.Ceiling(counters[street.Name] / result / 30f));
                    //GreenLightSchedule greenLight = new GreenLightSchedule(street.Name, 1);
                    greenLights.Add(greenLight);
                }

                if (greenLights.Count > 0)
                {
                    IntersectionSchedule schedule = new IntersectionSchedule(intersection.Key, greenLights.Count, greenLights.ToArray());
                    schedules.Add(schedule);
                }
            }
            Serializer.Serialize(schedules.Count, schedules.ToArray(), $"{System.IO.Path.GetFileName(file)}-output.txt");

            }
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }
}