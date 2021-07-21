using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Job> GetAll()
    {
      var sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql).ToList();
    }

    public Job GetById(string id)
    {
      var sql = "SELECT * FROM jobs WHERE jobs.id = @id";
      return _db.Query<Job>(sql, new { id }).FirstOrDefault();
    }

    public Job PostJob(Job JobData)
    {
      var sql = @"INSERT INTO 
      jobs(name, expertise, rating)
      VALUES(@Name, @Expertise, @Rating)
      SELECT LAST_INCIDENT_ID()";
      return _db.ExecuteScalar<Job>(sql, JobData);
    }

    public void EditJob(Job JobData)
    {
      var sql = @"UPDATE jobs
      SET
      name = @Name,
      expertise = @Expertise,
      rating = @Rating,
      WHERE id = @Id";
      _db.Execute(sql, JobData);
    }

    public void DeleteJob(string id)
    {
      var sql = "DELETE FROM jobs WHERE jobs.id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}