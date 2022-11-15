namespace VeloWorldSystem.Common.Constants
{
    public static class DataConstants
    {
        public static class BikeTypeConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class BikeConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const double WeightMaxValue = 100.00;
            public const double WeightMinValue = 0.00;

            public const int BrandMaxLength = 50;
            public const int BrandMinLength = 2;

            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 2;

            public const int NotesMaxLength = 255;
        }

        public static class ActivityConstants
        {
            public const int TitleMaxLength = 80;
            public const int TitleMinLength = 5;

            public const int DescriptionMaxLength = 255;
            public const int DescriptionMinLength = 10;

            public const int PrivateNotesMaxLength = 255;
            public const int PrivateNotesMinLength = 10;

            public const int DestancePrecision = 7;
            public const int DestanceScale = 3;
        }

        public static class CommentConstants
        {
            public const int ContentMaxLength = 255;
            public const int ContentMinLength = 5;
        }

        public static class ImageConstants
        {
            public const int UrlMaxLength = 2048;
        }

        public static class ApplicationUserConstants
        {
            public const int FirstNameMaxLength = 20;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 20;
            public const int LastNameMinLength = 2;

            public const int ImageUrlMaxLength = 2048;

            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }

        public static class ChallengeConstants
        {
            public const int TitleMaxLength = 80;
            public const int TitleMinLength = 5;

            public const int DescriptionMaxLength = 255;
            public const int DescriptionMinLength = 10;
        }
        
        public static class TrainingPlanConstants
        {
            public const int TitleMaxLength = 80;
            public const int TitleMinLength = 5;
        }

        public static class WaypointConstants
        {
            public const int LatitudePrecision = 12;
            public const int LatitudeScale = 9;

            public const int LongitudePrecision = 12;
            public const int LongitudeScale = 9;

            public const int SpeedPrecision = 12;
            public const int SpeedScale = 3;
        }

        public static class ApplicationRoleConstants
        {
            public const string MemberRole = "Member";
            public const string SuperMemberRole = "SuperMember";
            public const string AdminRole = "Administrator";
            public const string UsersOnly = MemberRole + "," + SuperMemberRole;
        }
    }
}
