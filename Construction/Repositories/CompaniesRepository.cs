using System.Collections.Generic;
using System.Data;
using System.Linq;
using Construction.Models;
using Dapper;

namespace Construction.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;
    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Company> Get()
    {
      string sql = "SELECT * FROM  companies;";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company Get(int id)
    {
      string sql = "SELECT * FROM  companies WHERE id = @id;";
      return _db.QueryFirstOrDefault<Company>(sql, new {id});
    }

    internal Company Create(Company newcompany)
    {
      string sql = @"INSERT INTO companies 
      (companyName, industry, employees)
      VALUE(@companyName, @industry, @employees)
      ;SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, newcompany);
      newcompany.Id = id;
      return newcompany;
    }
  }
}