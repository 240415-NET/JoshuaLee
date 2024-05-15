using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface
{
    public class UserHeightConverter(double totalInches)


    {
        public double TotalInches { get; private set; } = totalInches;

        public (int Feet, double Inches) ConvertToFeetAndInches()
    {
        int feet = (int)(TotalInches / 12);
        double inches = TotalInches % 12;
        return (feet, inches);
    }
}
    }
