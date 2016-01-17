namespace proof_of_concept_spa.Domain.Organisation.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual OrganisationType OrganisationType { get; set; }
    }
}
