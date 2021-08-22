﻿using MediatR;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.CourseUpdate
{
    public class CourseUpdateCommand : IRequest<CourseUpdateCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public long CategoryId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
    }
}
