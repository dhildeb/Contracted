using System.Collections.Generic;
using System.Data;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  class ContractorsJobsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsJobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public ContractorsJobs Bid(ContractorsJobs cj)
    {
      var sql = @"
      INSERT INTO 
      contractor_jobs(bid, contractorId, jobId)
      VALUES(@Bid, @ContractorId, @JobId);
      SELECT LAST_INSERT_ID()";
      cj.Id = _db.ExecuteScalar<int>(sql, cj);
      return cj;
    }
    public void Bid(string contractorId, int jobId, int bid)
    {
      var sql = @"
      INSERT INTO 
      contractor_jobs(bid, contractorId, jobId)
      VALUES(@bid, @contractorId, @jobId);";
      _db.ExecuteScalar<int>(sql, new { contractorId, jobId, bid });
    }
    public List<ContractorsJobs> GetContractorByJobId(int id)
    {
      var sql = @"
      SELECT *
      FROM jobs j
      JOIN contractor_jobs cj ON cj.jobId = j.id
      WHERE contractorId = @id;";
      return _db.Query<ContractorsJobs, Job, ContractorsJobs>(sql, (cj, j) =>
      {
        cj.JobId = j;
      }).ToList();
    }
  }
}