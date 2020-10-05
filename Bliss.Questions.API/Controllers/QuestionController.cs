using System;
using System.Collections.Generic;
using Bliss.Questions.API.Interfaces;
using Bliss.Questions.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.Questions.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class QuestionController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public List<Question> Get() 
        {
            return new List<Question>()
            { 
                new Question()
                {
                    ImageUrl = "",
                    Choices = new List<Choice>() 
                    {
                        new Choice() 
                        {
                            Text = "C#",
                            Votes = 2000
                        }
                    },
                    ThumbUrl = "",
                    Text = ""
                }
            };
        }

        [HttpGet("{id}")]
        public Question GetOne([FromRoute] string id) 
        {
            var question = (Question)_questionService.GetOne(id);
            return question;
        }

        [HttpPost]
        public Question Create([FromBody] Question question) 
        {   
            return (Question)_questionService.Create(question);
        }

        [HttpPut("{id}")]
        public Question Edit([FromBody] Question question)
        {
            return question;
        }

        [HttpPut("{id}/vote")]
        public string Vote() 
        {
            return "OK";
        }
    }
}