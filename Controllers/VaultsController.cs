using System.Collections.Generic;
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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;
    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }


    // Get api/vaults
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      var x = new User();
      return Ok(_vr.GetAll());
    }


    // GET api/vaults/:id
    [HttpGet("{id}")]
    public ActionResult<Vault> GetOne(string id)
    {
      return _vr.GetbyId(id);
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody]Vault newVault)
    {
      return _vr.CreateVault(newVault);
    }

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