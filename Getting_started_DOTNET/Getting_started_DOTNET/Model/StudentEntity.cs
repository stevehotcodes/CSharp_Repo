﻿using System.ComponentModel.DataAnnotations;

namespace Getting_started_DOTNET.Model
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Standard { get; set; }
        public string EmailAddress { get; set; }

    }
}
