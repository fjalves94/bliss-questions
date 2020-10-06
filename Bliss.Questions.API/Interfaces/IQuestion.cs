using System;
using System.Collections.Generic;

namespace Bliss.Questions.API.Interfaces
{
    public interface IQuestion
    {
        string Id { get; set; }
        string Text { get; set; }
        string ImageUrl { get; set; }
        string ThumbUrl { get; set; }        
        IEnumerable<IChoice> Choices { get; set; }
        DateTime PublishedAt { get; set; }
    }
}