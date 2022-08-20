using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class assessment_enrols
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid _id { get; set; }
        public int assessment_id { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public assessments assessment { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int user_id { get; set; }
        [MaxLength(11)]
        public int? result { get; set; }
        [MaxLength(4)]
        public int? score { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
}
