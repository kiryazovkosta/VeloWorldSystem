namespace VeloWorldSystem.Common.Constants
{
    public static class GlobalErrorMessages
    {
        public static class RegisterUserModelErrors
        {
            public const string PasswordLength = "The {0} must be at least {2} and at max {1} characters long.";
            public const string PasswordCompare = "The password and confirmation password do not match.";
            public const string AvatarError = "The selected image for avatar is not valid.";
        }

        public static class BikeTypeErrors 
        {
            public const string PasswordLength = "The {0} must be at least {2} and at max {1} characters long.";
        }
    }
}
