using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest
{
    public class Wizard : IWizard
    {
        public Wizard(string inputFilePath)
        {
            ReadCoordinatesFromFile(inputFilePath);
        }

        public int GetAtLeastEyeMovomentSheep()
        {
            double[] maxAngleOfPoints = GetSheepsMaximumEyeMovoment(numberOfSheep);
            double temp = Double.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < numberOfSheep; i++)
            {
                if(temp > maxAngleOfPoints[i])
                {
                    minIndex = i;
                    temp = maxAngleOfPoints[i];
                }
            }

            return minIndex;
        }

        public double[] GetSheepsMaximumEyeMovoment(int numberOfSheep)
        {
            double[] angles = new double[numberOfSheep - 2];
            double[] MaxAngles = new double[numberOfSheep];
            double[] EdgesMaxAngle = new double[numberOfSheep];

            for (int i = 0; i < numberOfSheep; i++)
            {
                int index = 0;
                int maxIndex = 0;
                for (int j = 0; j < numberOfSheep; j++)
                {
                    if (index == numberOfSheep - 2)
                    {
                        MaxAngles[maxIndex] = angles.Max();
                        angles = new double[numberOfSheep - 2];
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
                    // TODO: optimalization -> k = j + 1. Only compare k and i
                    for (int k = 0; k < numberOfSheep; k++)
                    {
                        if (k == i || k == j)
                        {
                            continue;
                        }

                        angles[index] = GetThreeSheepAngle(i, j, k);
                        if (angles[index] >= 180)
                        {
                            break;
                        }
                        index++;
                    }
                }

                MaxAngles[maxIndex] = angles.Max();
                angles = new double[numberOfSheep - 2];
                EdgesMaxAngle[i] = MaxAngles.Max();
            }

            return EdgesMaxAngle;
        }

        public double GetThreeSheepAngle(int y, int x, int z)
        {
            double[] P01Vector = new double[] { SheepCoordinates[y, 0] - SheepCoordinates[x, 0], SheepCoordinates[y, 1] - SheepCoordinates[x, 1] };
            double[] P12Vector = new double[] { SheepCoordinates[z, 0] - SheepCoordinates[y, 0], SheepCoordinates[z, 1] - SheepCoordinates[y, 1] };
            double P01P12 = P01Vector[0] * P12Vector[0] + P01Vector[1] * P12Vector[1];
            double P01Lenght = Math.Sqrt(Math.Pow(P01Vector[0], 2) + Math.Pow(P01Vector[1], 2));
            double P12Lenght = Math.Sqrt(Math.Pow(P12Vector[0], 2) + Math.Pow(P12Vector[1], 2));

            double cos = Math.Cos(P01P12 / (P01Lenght * P12Lenght));
            double angle = Math.Acos(P01P12 / (P01Lenght * P12Lenght)) * (180.0 / Math.PI);

            return 180 - angle;
        }

        public int[,] SheepCoordinates { get; set; }

        public int numberOfSheep { get; set; }

        private void ReadCoordinatesFromFile(string inputFilePath)
        {
            using (StreamReader streamReader = new StreamReader(inputFilePath))
            {
                numberOfSheep = Int32.Parse(streamReader.ReadLine());
                string line = streamReader.ReadLine();
                SheepCoordinates = new int[numberOfSheep, 2];
                for (int i = 1; i < numberOfSheep; i++)
                {
                    line = streamReader.ReadLine();
                    string[] xyCoordinates = line.Split(' ');
                    SheepCoordinates[i, 0] = Int32.Parse(xyCoordinates[0]);
                    SheepCoordinates[i, 1] = Int32.Parse(xyCoordinates[1]);
                }
            }
        }
    }
}
