﻿

namespace J6.Cms.DataTransfer
{
    public class RelatedLinkDto
    {
        public bool Enabled { get; set; }
        public int ContentId { get; set; }
        public int ContentType { get; set; }
        public int RelatedContentId { get; set; }
        public int RelatedIndent { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}