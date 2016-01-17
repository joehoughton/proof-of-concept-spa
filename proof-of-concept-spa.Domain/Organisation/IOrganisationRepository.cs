namespace proof_of_concept_spa.Domain.Organisation
{
    using proof_of_concept_spa.Domain.Organisation.Dto;

    public interface IOrganisationRepository
    {
        OrganisationDto GetByUserId(string userId);
    }
}
