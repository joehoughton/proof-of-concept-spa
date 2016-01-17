namespace proof_of_concept_spa.Web.Controllers.Organisation
{
    using System.Web.Http;
    using proof_of_concept_spa.Domain.Organisation;
    using proof_of_concept_spa.Domain.Users;

    [Authorize]
    [RoutePrefix("api")]
    public class OrganisationController : ApiController
    {
        private readonly IOrganisationRepository _organisationRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public OrganisationController(IOrganisationRepository organisationRepository, ICurrentUserProvider currentUserProvider)
        {
            _organisationRepository = organisationRepository;
            _currentUserProvider = currentUserProvider;
        }

        [Route("users/current/organisation")]
        public IHttpActionResult GetOrganisation()
        {
            var currentUserId = _currentUserProvider.CurrentUserDetail.UserId;
            var organisation = _organisationRepository.GetByUserId(currentUserId);
         
            return Ok(organisation);
        }

    }
}
