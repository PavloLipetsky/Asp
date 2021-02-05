using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ToDOList.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsDone { get; set; }
        
    

    }
}
