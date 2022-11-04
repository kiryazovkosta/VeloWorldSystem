namespace VeloWorldSystem.Web.Infrastructure.TagHelpers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authorization.Policy;
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
            this.policyProvider = policyProviderParam;
            this.policyEvaluator = policyEvaluatorParam;
            this.httpContextAccessor = httpContextAccessorParam;
        }

        [HtmlAttributeName("asp-policy")]
        public string? Policy { get; set; }

        [HtmlAttributeName("asp-roles")]
        public string? Roles { get; set; }

        [HtmlAttributeName("asp-authentication-schemes")]
        public string? AuthenticationSchemes { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var policy = await AuthorizationPolicy.CombineAsync(this.policyProvider, new[] { this });

            var authenticateResult = await this.policyEvaluator.AuthenticateAsync(policy!, this.httpContextAccessor.HttpContext!);

            var authorizeResult = await this.policyEvaluator.AuthorizeAsync(policy!, authenticateResult, this.httpContextAccessor.HttpContext!, null);

            if (!authorizeResult.Succeeded)
            {
                output.SuppressOutput();
            }
        }
    }
}
