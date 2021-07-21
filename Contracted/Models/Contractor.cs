namespace Contracted.Models
{
  class Contractor
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Expertises { get; set; }
    public int Rating { get; set; }
    public Job Jobs { get; set; }
  }
}