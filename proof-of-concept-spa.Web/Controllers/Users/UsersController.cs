namespace proof_of_concept_spa.Web.Controllers.Users
{
    using System.Net;
    using System.Web.Http;
    using proof_of_concept_spa.Domain.Users;
    using proof_of_concept_spa.Domain.Users.Dto;

    [Authorize]
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public UsersController(IUserRepository userRepository, ICurrentUserProvider currentUserProvider)
        {
            _userRepository = userRepository;
            _currentUserProvider = currentUserProvider;
        }

        [Route("users/current/details")]
        public IHttpActionResult GetUserDetails()
        {
            string currentUserId = _currentUserProvider.CurrentUserDetail.UserId;
            var userDetails = _userRepository.GetUserDetails(currentUserId);
            return Ok(userDetails);
        }

        [Route("users/current/details/{id}"), HttpPut]
        public IHttpActionResult UpdateUserDetails(string id, UserDetailDto userDetailDto)
        {
            if (userDetailDto == null)
            {
                return BadRequest();
            }
            _userRepository.UpdateUserDetails(userDetailDto);
            
            return StatusCode(HttpStatusCode.Accepted);
        }

    }
}
