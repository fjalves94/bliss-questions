using System;
using System.Collections.Generic;
using Bliss.Questions.API.DTO;
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
        public List<Question> Get([FromQuery] string filter, [FromQuery] int limit, [FromQuery] int offset) 
        {
            return (List<Question>)_questionService.Get(filter, limit, offset);
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
        public void Edit([FromRoute] string id, [FromBody] Question question)
        {
            _questionService.Edit(id, question);
        }

        [HttpPut("{id}/vote")]
        public void Vote([FromRoute] string id, [FromBody] VoteDTO voteDto) 
        {
            _questionService.Vote(id, voteDto.choice);
        }
    }
}