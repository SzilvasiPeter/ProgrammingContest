using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSheep = 0;
            int[,] coordinates;

            using (StreamReader streamReader = new StreamReader(@"c:\Users\petis\Downloads\MSC\2\Minőségbiztosítás\inputs\A\A2.in"))
            {
                numberOfSheep = Int32.Parse(streamReader.ReadLine());
                string line = streamReader.ReadLine();
                coordinates = new int[numberOfSheep, 2];
                for (int i = 1; i < numberOfSheep; i++)
                {
                    line = streamReader.ReadLine();
                    string[] xyCoordinates = line.Split(' ');
                    int x = Int32.Parse(xyCoordinates[0]);
                    int y = Int32.Parse(xyCoordinates[1]);
                    coordinates[i, 0] = x;
                    coordinates[i, 1] = y;
                }
            }

            SimpleExample();
            double[] maxAngleOfSheeps = GetPointsMaxAngle(coordinates, numberOfSheep);
            double minimumEyeMovoment = maxAngleOfSheeps.Min();
            Console.WriteLine(minimumEyeMovoment);

            Console.ReadLine();
        }

        private static void SimpleExample()
        {
            int n = 10;
            int[,] sheepCoordinates = new int[n, 2];
            sheepCoordinates[0, 0] = 1;
            sheepCoordinates[0, 1] = 0;

            sheepCoordinates[1, 0] = 0;
            sheepCoordinates[1, 1] = 0;
            sheepCoordinates[2, 0] = 1;
            sheepCoordinates[2, 1] = 1;
            sheepCoordinates[3, 0] = 10;
            sheepCoordinates[3, 1] = 0;
            sheepCoordinates[4, 0] = 1;
            sheepCoordinates[4, 1] = -1;
            sheepCoordinates[5, 0] = 6;
            sheepCoordinates[5, 1] = 2;
            sheepCoordinates[6, 0] = 4;
            sheepCoordinates[6, 1] = 3;
            sheepCoordinates[7, 0] = 8;
            sheepCoordinates[7, 1] = 2;
            sheepCoordinates[8, 0] = 6;
            sheepCoordinates[8, 1] = 0;
            sheepCoordinates[9, 0] = 13;
            sheepCoordinates[9, 1] = 8;

            List<double> listOfAngles = new List<double>();
            double[,] angles = new double[n, n - 2];

            double[] maxAngleOfPoints = GetPointsMaxAngle(sheepCoordinates, n);
            double sheepToDog = maxAngleOfPoints.Min();
            Console.WriteLine(sheepToDog);

            double angle0 = GetAngle(0, 1, 2, sheepCoordinates);
            double angle1 = GetAngle(1, 0, 2, sheepCoordinates);
            double angle2 = GetAngle(2, 1, 0, sheepCoordinates);
            Console.WriteLine(angle0 + angle1 + angle2);
        }

        private static double GetAngle(int y, int x, int z, int[,] sheepCoordinates)
        {
            double[] P01Vector = new double[] { sheepCoordinates[y, 0] - sheepCoordinates[x, 0], sheepCoordinates[y, 1] - sheepCoordinates[x, 1] };
            double[] P12Vector = new double[] { sheepCoordinates[z, 0] - sheepCoordinates[y, 0], sheepCoordinates[z, 1] - sheepCoordinates[y, 1] };
            double P01P12 = P01Vector[0] * P12Vector[0] + P01Vector[1] * P12Vector[1];
            double P01Lenght = Math.Sqrt(Math.Pow(P01Vector[0], 2) + Math.Pow(P01Vector[1], 2));
            double P12Lenght = Math.Sqrt(Math.Pow(P12Vector[0], 2) + Math.Pow(P12Vector[1], 2));

            double cos = Math.Cos(P01P12 / (P01Lenght * P12Lenght));
            double angle = Math.Acos(P01P12 / (P01Lenght * P12Lenght)) * (180.0 / Math.PI);

            return 180 - angle;
        }

        private static double[] GetPointsMaxAngle(int[,] sheepCoordinates, int numberOfSheep)
        {
            int n = numberOfSheep;
            double[] angles = new double[n - 2];
            double[] MaxAngles = new double[n];
            double[] EdgesMaxAngle = new double[n];

            for (int i = 0; i < n; i++)
            {
                int index = 0;
                int maxIndex = 0;
                for (int j = 0; j < n; j++)
                {
                    if (index == n - 2)
                    {
                        MaxAngles[maxIndex] = angles.Max();
                        angles = new double[n - 2];
                        maxIndex++;
                    }
                    else if (index != 0)
                    {
                        MaxAngles[maxIndex] = angles.Max();
                        break;
                    }

                    if (j == i)
                    {
                        index = 0;
                        continue;
                    }

                    index = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i || k == j)
                        {
                            continue;
                        }

                        angles[index] = GetAngle(i, j, k, sheepCoordinates);
                        if (angles[index] >= 180)
                        {
                            break;
                        }
                        index++;
                    }
                }

                MaxAngles[maxIndex] = angles.Max();
                angles = new double[n - 2];
                EdgesMaxAngle[i] = MaxAngles.Max();
            }

            return EdgesMaxAngle;
        }

    }
}
