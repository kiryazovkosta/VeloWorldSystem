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

        public static class CloudinaryErrors 
        {
            public const string ExceptionMessage = "Unable to upload non existsing file otr file with not valid content type";        
        }

        public static class SendGridErrors 
        {
            public const string ExceptionMessage = "Value cannot be null. (Parameter '{0}')";
            public const string EmptyMessage = "Subject and message should be provided.";
        }
    }
}
