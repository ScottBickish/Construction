using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Construction.Models;
using Construction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Construction.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    private readonly CompaniesService _cs;
    private readonly AccountService _acctService;
    public CompaniesController(CompaniesService cs, AccountService acctService)
    {
      _cs = cs;
      _acctService = acctService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Company>>Get()
    {
      try
      {
           var companies = _cs.Get();
           return Ok(companies);
      }
      catch (Exception e)
      {
            return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Company>Get(int id)
    {
      try
      {
           var company = _cs.Get(id);
           return Ok(company);
      }
      catch (Exception e)
      {
            return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public async Task<ActionResult<Company>>Create([FromBody] Company newcompany)
    {
      try
      {
           Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          //  newcompany.CreatorId = userInfo?.Id;
           Company company =_cs.Create(newcompany);
           return Ok(company);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}