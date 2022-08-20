using AssessmentProject.Interfaces;
using AssessmentProject.Models;
using AssessmentProject.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : Controller
    {
        private readonly IAseessmentRepository _aseessmentRepository;
      
        public AssessmentController(IAseessmentRepository aseessmentRepository)
        {
            _aseessmentRepository = aseessmentRepository;
           
        }
        [HttpGet()]
        public IActionResult GetAssessment()
        {
            var enrol = _aseessmentRepository.GetAllAssessment();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(enrol);
           
        }
        [HttpGet("{id}")]
        public IActionResult GetAssessment(int id)
        {
            var assessment = _aseessmentRepository.GetAssessment(id); 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(assessment);
        }
       
    }
}
