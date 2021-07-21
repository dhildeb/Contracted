using System;

namespace Contracted.Models
{
  class Job
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Available { get; set; }
    public int JobSize { get; set; }
    public Contractor Contractors { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}