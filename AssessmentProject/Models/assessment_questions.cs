using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class assessment_questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     
        public int id { get; set; }
     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid _id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string question { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int? category_id { get; set; }
        [MaxLength(11)]
        public int? level { get; set; }
        [MaxLength(11)]
        public int? order { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string type { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }

      
        public ICollection<assessment_questions_relation> relations { get; set; }
       
        public ICollection<assessment_match> match { get; set; }
        public ICollection<assessment_options> option { get; set; }
    
        public assessment_text text_id { get; set; }
        
        public assessment_true_false true_False_id { get; set; }
    }
}
