﻿namespace Blogi.Application.Features.Tags.Dtos.GetTagList
{
    public class GetTagListOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LanguageName { get; set; }
        public int Count { get; set; }
    }
}