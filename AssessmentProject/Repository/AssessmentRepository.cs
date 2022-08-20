using AssessmentProject.Interfaces;
using AssessmentProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Repository
{
    public class AssessmentRepository : IAseessmentRepository
    {
        private readonly AppDbContext _db;
      
        public AssessmentRepository(AppDbContext db)
        {
            _db = db;
         
        }
        public ICollection<assessment_enrols> GetAllAssessment()
        {
            return _db.assessment_enrols.ToList();
        }

        public ICollection<assessments> GetAssessment(int id)
        {
           var assessment = _db.assessments.Where(a => a.id == id).Include(e => e.enrols).Include(q => q.relations).
               ThenInclude(q => q.question).ThenInclude(m => m.match).Include(q => q.relations).
               ThenInclude(q => q.question).ThenInclude(op => op.option).Include(q => q.relations).
               ThenInclude(q => q.question).ThenInclude(text => text.text_id).Include(q => q.relations).
               ThenInclude(q => q.question).ThenInclude(tf => tf.true_False_id).ToList();
            return assessment;
        }

      
    }
}
