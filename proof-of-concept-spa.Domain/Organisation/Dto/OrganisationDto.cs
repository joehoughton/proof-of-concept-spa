namespace proof_of_concept_spa.Domain.Organisation.Dto
{
    public class OrganisationDto
    {
        public OrganisationDto(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }
        public string Type { get; private set; }
    }
}
