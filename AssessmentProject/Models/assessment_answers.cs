using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class assessment_answers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public int id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid _id { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int assessment_id { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int question_id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? answer { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int user_id { get; set; }
        [MaxLength(4)]
        public int? score { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
}
