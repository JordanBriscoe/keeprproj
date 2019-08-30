using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;
    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    [HttpPost]
    public ActionResult<Vault> Post([FromBody]Vault vault)
    {
      vault.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_vr.CreateVault(vault));
    }

    // Get api/vaults
    [HttpGet]
    public ActionResult<Vault> Get()
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_vr.GetVaultsByUser(userId));
    }


    // GET api/vaults/:id
    // [HttpGet("{id}")]
    // public ActionResult<Vault> Get()
    // {
    //   return _vr.GetbyId(id);
    // }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      bool wasSuccessfull = _vr.DeleteVault(id);
      if (wasSuccessfull)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}