using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  class ContractorsService
  {
    private readonly ContractorsRepository _cRepo;

    public ContractorsService(ContractorsRepository cRepo)
    {
      _cRepo = cRepo;
    }

    public List<Contractor> GetAll()
    {
      return _cRepo.GetAll();
    }

    public Contractor GetById(string id)
    {
      return _cRepo.GetById(id);
    }

    public Contractor PostContractor(Contractor contractorData, string userId)
    {
      contractorData.Id = userId;
      return _cRepo.PostContractor(contractorData);
    }

    public void EditContractor(Contractor contractorData, string userId, string id)
    {
      var contractor = GetById(id);
      if (contractor == null)
      {
        throw new Exception("You dont exist...");
      }
      if (contractor.Id != userId)
      {
        throw new Exception("Imposter!");
      }
      contractorData.Id = userId;
      _cRepo.EditContractor(contractorData);
    }

    public void DeleteContractor(string id, string userId)
    {
      var contractor = GetById(id);
      if (contractor.Id != userId)
      {
        throw new Exception("Imposter!");
      }
      _cRepo.DeleteContractor(id);
    }
  }
}