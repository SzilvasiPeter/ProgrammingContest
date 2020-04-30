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

        public int GetAtLeastEyeMovomentSheep(double[] sheepEyeMovoments)
        {
            throw new NotImplementedException();
        }

        public double[] GetSheepsMaximumEyeMovoment(int numberOfSheep)
        {
            throw new NotImplementedException();
        }

        public double GetThreeSheepAngle(int y, int x, int z)
        {
            throw new NotImplementedException();
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
