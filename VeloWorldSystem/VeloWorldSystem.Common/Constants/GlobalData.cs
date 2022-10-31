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

        public class Comment
        {
            public const int CommentMaxContentLength = 255;
            public const int CommentMinContentLength = 5;
        }

        public class Image
        {
            public const int ImageMaxUrlLength = 2048;
        }

        public class ApplicationUser
        {
            public const int ApplicationUserMaxFirstNameLength = 20;
            public const int ApplicationUserMinFirstNameLength = 2;

            public const int ApplicationUserMaxLastNameLength = 20;
            public const int ApplicationUserMinLastNameLength = 2;
        }
    }
}
