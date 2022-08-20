using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class assessment_true_false
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        public int id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid _id { get; set; }
        public int question_id { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public assessment_questions question { get; set; }
        [MaxLength(11)]
        public int? is_true { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
}
