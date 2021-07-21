using System;
using System.Collections.Generic;
using System.Data;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  class JobsService
  {
    private readonly JobsRepository _jRepo;

    public JobsService(JobsRepository jRepo)
    {
      _jRepo = jRepo;
    }

    public List<Job> GetAll()
    {
      return _jRepo.GetAll();
    }

    public Job GetById(string id)
    {
      return _jRepo.GetById(id);
    }

    public Job PostJob(Job JobData, string id)
    {
      JobData.CreatorId = id;
      return _jRepo.PostJob(JobData);
    }

    public void EditJob(Job JobData, string id, string userId)
    {
      var Job = GetById(id);
      if (Job == null)
      {
        throw new Exception("What the Crap are you trying to do? That doesnt exist.");
      }
      if (Job.CreatorId != userId)
      {
        throw new Exception("Who the Heck are you?");
      }
      _jRepo.EditJob(JobData);
    }

    public void DeleteJob(string id, string userId)
    {
      var job = GetById(id);
      if (job.CreatorId != userId)
      {
        throw new Exception("Not on my watch Imposter!");
      }
      _jRepo.DeleteJob(id);
    }
  }
}