using System.Security.Principal;

namespace MyShop.Application.Common.Security;

/// <summary>
/// Specifies the class this attribute is applied to requires authorization.
/// </summary>
[AttributeUsage(AttributeTargets.Class| AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class AuthorizeAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class. 
    /// </summary>
    public AuthorizeAttribute() { }

    /// <summary>
    /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
    /// </summary>
    public string Roles { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the policy name that determines access to the resource.
    /// </summary>
    public string Policy { get; set; } = string.Empty;
}


//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//public class AuthorizeAttribute : Attribute, IAuthorizationFilter
//{
//    private readonly IList<Role> _roles;

//    public AuthorizeAttribute(params Role[] roles)
//    {
//        _roles = roles ?? new Role[] { };
//    }

//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        // skip authorization if action is decorated with [AllowAnonymous] attribute
//        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
//        if (allowAnonymous)
//            return;

//        // authorization
//        var account = (Account)context.HttpContext.Items["Account"];
//        if (account == null || (_roles.Any() && !_roles.Contains(account.Role)))
//        {
//            // not logged in or role not authorized
//            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
//        }
//    }
//}