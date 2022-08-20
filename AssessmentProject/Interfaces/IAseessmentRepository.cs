using AssessmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Interfaces
{
   public interface IAseessmentRepository
    {
        ICollection<assessment_enrols> GetAllAssessment();
        ICollection<assessments> GetAssessment(int user_id);
    }
}
