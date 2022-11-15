namespace VeloWorldSystem.Common.Constants
{
    public static class GlobalConstants
    {

        public static class Images
        {
            public const int MaxFileLengthInBytes = 200000;
            public static readonly string[] ValidImageContentTypes = { "image/x-png", "image/gif", "image/jpeg", "image/jpg", "image/png", "image/gif" };
            public const string DefaultAvatarImage = "https://res.cloudinary.com/dfn7thtsx/image/upload/v1668419470/l2qtxtgwz8pyk6zhbqpv.png";
        }

        public static class RegisterUserModel
        {
            public const string FirstNameDispaly = "First Name";
            public const string LastNameDispaly = "Last Name";
            public const string EmailNameDispaly = "Email";
            public const string UserNameNameDispaly = "User Name";
            public const string PasswordNameDispaly = "Password";
            public const string ConfirmPasswordNameDispaly = "Confirm password";
        }

        public static class LoginUserModel
        {
            public const string Remember = "Remember me?";
        }
    }
}