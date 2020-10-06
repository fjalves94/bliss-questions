using System;
using Bliss.Questions.API.DTO;
using Bliss.Questions.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.Questions.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class HealthController
    {
        private readonly IQuestionService _questionService;

        public HealthController(IQuestionService questionService) 
        {
            _questionService = questionService;
        }

        [HttpGet]
        public HealthStatusDTO Get() 
        {
            try
            {
                _questionService.Get("", 1, 0);
                return new HealthStatusDTO() 
                {
                    status = "OK"
                };
            }
            catch (Exception)
            {
                return new HealthStatusDTO()
                {
                    status = "Service Unavailable. Please try again later."
                };
            }
        }
    }
}