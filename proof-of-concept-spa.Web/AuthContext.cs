namespace proof_of_concept_spa.Web
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using proof_of_concept_spa.Web.Entities;

    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
     
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }

}