namespace proof_of_concept_spa.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using proof_of_concept_spa.Web;

    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {
        private AuthRepository _repo;

        public RefreshTokensController()
        {
            this._repo = new AuthRepository();
        }

        // [Authorize(Users="Admin")]
        // Todo: Implement roles http://bitoftech.net/2015/03/11/asp-net-identity-2-1-roles-based-authorization-authentication-asp-net-web-api/
        [Route("")]
        public IHttpActionResult Get()
        {
            return this.Ok(this._repo.GetAllRefreshTokens());
        }

        // [Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await this._repo.RemoveRefreshToken(tokenId);
            if (result)
            {
                return this.Ok();
            }
            return this.BadRequest("Token Id does not exist");
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
