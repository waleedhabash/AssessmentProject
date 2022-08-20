using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string username { get; set; }

    }
}
