using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace ShopBridge.Microservices.Product.Models
{
    public class ApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        private IEnumerable<Claim> Claims => User.Claims;


        public int UserId { get => GetUserId(); }
        public Guid UserGuid { get => GetUserGuid(); }

        public Guid GetUserGuid()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Subject))
            {
                return Guid.Parse(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Subject).Value);
            }
            return Guid.Empty;
        }

        public int GetUserId()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Id))
            {
                return Convert.ToInt32(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Id).Value);
            }
            return 0;
        }
    }
}
