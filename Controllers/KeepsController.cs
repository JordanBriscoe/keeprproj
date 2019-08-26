


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController
  {

  }
}