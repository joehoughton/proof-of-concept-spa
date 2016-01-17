namespace proof_of_concept_spa.Web.Controllers.Users
{
    using System.Net;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using proof_of_concept_spa.Domain.Users;
    using proof_of_concept_spa.Domain.Users.Dto;

    [Authorize]
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("users/current/details")]
        public IHttpActionResult GetUserDetails()
        {
            string currentUserId = User.Identity.GetUserId();
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
