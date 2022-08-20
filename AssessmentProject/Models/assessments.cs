using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{

    public class assessments
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid _id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string titel { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string short_description { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string description { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        
        public string? slug { get; set; }
        [MaxLength(11)]
        public int? create_by { get; set; }
        [MaxLength(11)]
        public int? update_by { get; set; }
        [MaxLength(11)]
        public int? durition { get; set; }
        [Column(TypeName = "bigint")]
        [MaxLength(20)]
        public int? category_id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? thumbnail { get; set; }
        [MaxLength(1)]
        public int? published { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? update_at { get; set; }
        public ICollection<assessment_questions_relation> relations { get; set; }
        public ICollection<assessment_enrols> enrols { get; set; }
    }
}
