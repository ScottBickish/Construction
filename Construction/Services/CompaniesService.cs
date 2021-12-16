using System;
using System.Collections.Generic;
using Construction.Models;
using Construction.Repositories;

namespace Construction.Services
{
  public class CompaniesService
  {
      
        private readonly CompaniesRepository _repo;
        public  CompaniesService(CompaniesRepository repo)
        {
          _repo = repo;
        }
        internal List<Company> Get()
        {
          return _repo.Get();
        }
          internal Company Get(int id)
        {
          Company found = _repo.Get(id);
          if(found == null)
          {
            throw new Exception("Invalid Id");
          
          }
          return found;
        }

    internal Company Create(Company newcompany)
    {
      return _repo.Create(newcompany);
      
    }
  }
}