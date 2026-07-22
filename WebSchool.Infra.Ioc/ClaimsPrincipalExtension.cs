using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebSchool.Infra.Ioc
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst("id");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            throw new Exception("Claim para User ID não encontrada ou inválida");
        }
    }
}
