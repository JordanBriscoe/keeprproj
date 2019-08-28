using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }


    // FIXME ASK QUESTIONS HERE 
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetUserKeeps(string userId)
    {
      userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_kr.GetUserKeeps(userId));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_kr.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetOne(string id)
    {
      return Ok(_kr.GetbyKeepId(id));
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      bool wasSuccessful = _kr.DeleteKeep(id);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {
      newKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return _kr.CreateKeep(newKeep);
    }
  }
}