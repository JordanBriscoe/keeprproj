using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep keep)
    {
      keep.UserId = HttpContext.User.FindFirstValue("Id");
      try
      {
        return Ok(_kr.CreateKeep(keep));

      }
      catch (System.Exception)
      {

        throw;
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetPublicKeeps()
    {
      int isprivate = 0;
      return Ok(_kr.GetAllPublicKeeps(isprivate));
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      return Ok(_kr.GetKeepById(id));
    }

    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_kr.GetKeepsByUserId(userId));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Keep> Delete(int id)
    {
      return Ok(_kr.DeleteKeepById(id));
    }
  }
}