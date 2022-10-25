using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.Common.Constants
{
    public class GlobalData
    {
        public class BikeType
        {
            public const int BikeTypeMaxNameLength = 50;
            public const int BikeTypeMinNameLength = 3;
        }

        public class Bike
        {
            public const int BikeMaxNameLength = 50;
            public const int BikeMinNameLength = 3;

            public const double BikeWeightMinValue = 0.00;
            public const double BikeWeightMaxValue = 100.00;

            public const int BikeMaxBrandLength = 50;
            public const int BikeMinBrandLength = 5;

            public const int BikeMaxModelLength = 50;
            public const int BikeMinModelLength = 5;

            public const int BikeMaxNotesLength = 255;
        }

        public class Activity
        {
            public const int ActivityMaxTitleLength = 80;
            public const int ActivityMinTitleLength = 5;

            public const int ActivityMaxDescriptionLength = 255;
            public const int ActivityMinDescriptionLength = 10;

            public const int ActivityMaxPrivateNotesLength = 255;
            public const int ActivityMinPrivateNotesLength = 10;
        }
    }
}
