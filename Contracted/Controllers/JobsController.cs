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
  class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<List<Job>> GetAll()
    {
      try
      {
        var Jobs = _js.GetAll();
        return Ok(Jobs);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> GetById(string id)
    {
      try
      {
        var Job = _js.GetById(id);
        return Ok(Job);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost("{id}")]
    public ActionResult<Job> PostJob([FromBody] Job JobData, string id)
    {
      try
      {
        var Job = _js.PostJob(JobData, id);
        return Created("Job Created", Job);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Job>> EditJob([FromBody] Job JobData, string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _js.EditJob(JobData, id, userInfo.Id);
        return Ok(JobData);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteJob(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _js.DeleteJob(id, userInfo.Id);
        return "Deleted";
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}