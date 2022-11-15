namespace VeloWorldSystem.Infrastructure.TagHelpers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authorization.Policy;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement(Attributes = "asp-authorize")]
    [HtmlTargetElement(Attributes = "asp-authorize,asp-policy")]
    [HtmlTargetElement(Attributes = "asp-authorize,asp-roles")]
    [HtmlTargetElement(Attributes = "asp-authorize,asp-authentication-schemes")]
    public class AuthorizationTagHelper : TagHelper, IAuthorizeData
    {
        private readonly IAuthorizationPolicyProvider policyProvider;
        private readonly IPolicyEvaluator policyEvaluator;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationTagHelper(
            IAuthorizationPolicyProvider policyProviderParam,
            IPolicyEvaluator policyEvaluatorParam,
            IHttpContextAccessor httpContextAccessorParam)
        {
            policyProvider = policyProviderParam;
            policyEvaluator = policyEvaluatorParam;
            httpContextAccessor = httpContextAccessorParam;
        }

        [HtmlAttributeName("asp-policy")]
        public string? Policy { get; set; }

        [HtmlAttributeName("asp-roles")]
        public string? Roles { get; set; }

        [HtmlAttributeName("asp-authentication-schemes")]
        public string? AuthenticationSchemes { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var policy = await AuthorizationPolicy.CombineAsync(policyProvider, new[] { this });

            var authenticateResult = await policyEvaluator.AuthenticateAsync(policy!, httpContextAccessor.HttpContext!);

            var authorizeResult = await policyEvaluator.AuthorizeAsync(policy!, authenticateResult, httpContextAccessor.HttpContext!, null);

            if (!authorizeResult.Succeeded)
            {
                output.SuppressOutput();
            }
        }
    }
}
