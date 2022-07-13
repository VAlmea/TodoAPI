using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Common.DTO.Request
{
    public class ActivityRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}