using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest
{
    interface IWizard
    {
        double GetThreeSheepAngle(int y, int x, int z);

        double[] GetSheepsMaximumEyeMovoment(int numberOfSheep);

        int GetAtLeastEyeMovomentSheep();

        int[,] SheepCoordinates { get; set; }

        int numberOfSheep { get; set; }
    }
}
