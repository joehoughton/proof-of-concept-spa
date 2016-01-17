namespace proof_of_concept_spa.Domain.Users
{
    using proof_of_concept_spa.Domain.Users.Dto;

    public interface IUserRepository
    {
        UserDetailDto GetUserDetails(string currentUserId);
        void UpdateUserDetails(UserDetailDto userDetailDto);
    }
}