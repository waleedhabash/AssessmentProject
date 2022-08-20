using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class assessment_options
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        public int id { get; set; }
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? _id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? option { get; set; }
        public int question_id { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public assessment_questions question { get; set; }
        [MaxLength(1)]
        public int? correct { get; set; }
        [MaxLength(11)]
        public int? order { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
}
