﻿using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models.VideoDto
{
    public class ReadVideoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
