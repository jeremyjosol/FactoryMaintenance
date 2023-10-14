using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = " * Please fill out this field with a valid entry.")]
    public string Name { get; set; }
    public List<MachineEngineer> JoinEntities { get; }
  }
}