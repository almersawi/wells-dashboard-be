using System;
using System.Collections.Generic;
using API.DTOs;

namespace API.Helpers
{
    public static class TrajectoryCalculations
    {
        public static List<TrajectoryDto> Calculate(List<TrajectoryDto> inputData) 
        {
            if(inputData == null || inputData.Count == 0) return new List<TrajectoryDto>{};

            double C = (2 * Math.PI) / 360;

            inputData[0].Tvd = 0;
            inputData[0].East = 0;
            inputData[0].North = 0;

            for(var i=1; i < inputData.Count-1; i++)
            {
                var currentPoint = inputData[i];
                var prevPoint = inputData[i-1];

                var xNorth = prevPoint.North;
                var xMD = prevPoint.Md;
                var xEast = prevPoint.East;
                var xTVD = prevPoint.Tvd;
                var MD = currentPoint.Md;

                var md = MD - xMD; // difference between current MD and previous MD

                var a = currentPoint.Inc * C;
                var b = currentPoint.Azi * C;

                var North = md * Math.Sin(a) * Math.Cos(b) + xNorth;
                var East = md * Math.Sin(a) * Math.Sin(b) + xEast;
                var TVD = md * Math.Cos(a) + xTVD;

                // assign calculated parameters to the point
                currentPoint.North = North;
                currentPoint.East = East;
                currentPoint.Tvd = TVD;
            }

            return inputData;
        }
    }
}
