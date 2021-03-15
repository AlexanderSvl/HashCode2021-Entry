using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace HashCodeTraffic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] line;

            int duration;
            int numOfIntersections;
            int numOfStreets;
            int numOfCars;
            int bonusPoints;

            List<Street> streets = new List<Street>();
            List<Car> cars = new List<Car>();

            for (int n = 0; n < 6; n++)
            {
                using (StreamReader reader = new StreamReader("Input" + n + ".txt"))
                {
                    line = reader.ReadLine().Split();
                    duration = int.Parse(line[0]);
                    numOfIntersections = int.Parse(line[1]);
                    numOfStreets = int.Parse(line[2]);
                    numOfCars = int.Parse(line[3]);
                    bonusPoints = int.Parse(line[4]);

                    for (int i = 0; i < numOfStreets; i++)
                    {
                        line = reader.ReadLine().Split();
                        streets.Add(new Street(line[2], int.Parse(line[3]), int.Parse(line[0]), int.Parse(line[1])));
                    }

                    for (int i = 0; i < numOfCars; i++)
                    {
                        line = reader.ReadLine().Split();
                        string[] path = new string[int.Parse(line[0])];

                        for (int j = 1; j < line.Length; j++)
                        {
                            path[j - 1] = line[j];
                        }

                        cars.Add(new Car(path));
                    }

                }

                Dictionary<string, int> dict = new Dictionary<string, int>();

                foreach(Car car in cars)
                {
                    while (!car.isDone())
                    {
                        string stName = car.NextStreet();

                        if (dict.ContainsKey(stName))
                        {
                            dict[stName]++;
                        }
                        else
                        {
                            dict.Add(stName, 1);
                        }
                    }
                }

                dict.OrderByDescending(x => x.Value);

                Console.WriteLine("doing " + n);

                using (StreamWriter writer = new StreamWriter("output" + n + ".txt"))
                {
                    writer.WriteLine(numOfIntersections);
                    string name = "";
                    int place = 0;

                    while (streets.Count > 0)
                    {
                        int c = 0;

                        foreach (KeyValuePair<string, int> pair in dict)
                        {
                            name = pair.Key;

                            if (c == place)
                            {
                                break;
                            }

                            c++;
                        }
                        int index = 0;
                        for (int i = 0; i < streets.Count; i++)
                        {
                            if (streets[i].Name == name)
                            {
                                index = i;
                                break;
                            }
                        }
                        int intersection = streets[index].exitID;
                        writer.WriteLine(intersection);
                        int num = 0;

                        for (int i = 0; i < streets.Count; i++)
                        {
                            if (streets[i].exitID == intersection)
                            {
                                num++;
                            }
                        }

                        writer.WriteLine(num);
                        writer.WriteLine(streets[index].Name + " 2");

                        dict.Remove(streets[index].Name);
                        streets.RemoveAt(index);

                        for (int i = 0; i < streets.Count; i++)
                        {
                            if (streets[i].exitID == intersection)
                            {
                                writer.WriteLine(streets[i].Name + " 2");
                                dict.Remove(streets[i].Name);
                                streets.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }

            }  
        }
    }
}
