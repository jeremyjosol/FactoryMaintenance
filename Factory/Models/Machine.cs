using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "* Please fill out this field.")]
    public string Name { get; set; }
    public List<MachineEngineer> JoinEntities { get; }
  }
}