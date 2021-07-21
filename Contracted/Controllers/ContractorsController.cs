using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;

    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        var Contractors = _cs.GetAll();
        return Ok(Contractors);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> GetById(string id)
    {
      try
      {
        var Contractor = _cs.GetById(id);
        return Ok(Contractor);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Contractor>> PostContractor([FromBody] Contractor ContractorData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var Contractor = _cs.PostContractor(ContractorData, userInfo.Id);
        return Created("Contractor Created", Contractor);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Contractor>> EditContractor([FromBody] Contractor ContractorData, string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _cs.EditContractor(ContractorData, userInfo.Id, id);
        return Ok(ContractorData);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteContractor(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _cs.DeleteContractor(id, userInfo.Id);
        return "Deleted";
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}