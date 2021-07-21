using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Contractor> GetAll()
    {
      var sql = @"SELECT * FROM 
      c*,
      j*
      FROM contractors c
      JOIN jobs j ON c.";
      return _db.Query<Contractor>(sql).ToList();
    }

    public Contractor GetById(string id)
    {
      var sql = "SELECT * FROM contractors WHERE contractors.id = @id";
      return _db.Query<Contractor>(sql, new { id }).FirstOrDefault();
    }

    public Contractor PostContractor(Contractor contractorData)
    {
      var sql = @"INSERT INTO 
      contractors(name, expertise, rating)
      VALUES(@Name, @Expertise, @Rating)
      SELECT LAST_INCIDENT_ID()";
      return _db.ExecuteScalar<Contractor>(sql, contractorData);
    }

    public void EditContractor(Contractor contractorData)
    {
      var sql = @"UPDATE contractors
      SET
      name = @Name,
      expertise = @Expertise,
      rating = @Rating,
      WHERE id = @Id";
      _db.Execute(sql, contractorData);
    }

    public void DeleteContractor(string id)
    {
      var sql = "DELETE FROM contractors WHERE contractors.id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}