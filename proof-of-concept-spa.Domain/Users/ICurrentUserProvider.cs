namespace proof_of_concept_spa.Domain.Users
{
    using proof_of_concept_spa.Domain.Users.Models;

    public interface ICurrentUserProvider
    {
        CurrentUserDetail CurrentUserDetail { get; }
    }
}
