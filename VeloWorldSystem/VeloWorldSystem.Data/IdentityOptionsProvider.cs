namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// IdentityOptionsProvider.
    /// </summary>
    public static class IdentityOptionsProvider
    {
        /// <summary>
        /// GetIdentityOptions.
        /// </summary>
        /// <param name="options">options.</param>
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            options.SignIn.RequireConfirmedAccount = false;
        }
    }
}
