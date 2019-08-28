using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;
    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    [HttpPost]
    public ActionResult<VaultKeep> AddKeepToVault([FromBody] VaultKeep newvaultkeep)
    {
      newvaultkeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_vkr.AddKeepToVault(newvaultkeep));
    }

    [HttpGet("{VaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int VaultId)
    {
      var UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_vkr.GetKeepsByVaults(VaultId, UserId));
    }
  }
}