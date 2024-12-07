using System.Security.Claims;

namespace DomainLayer.Helper_Classes
{
    public static class DefalutAdminClaims
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create Student","false"),
            new Claim("Edit Student","false"),
            new Claim("Delete Student","false"),
        };
    }
}
