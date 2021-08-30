using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application_Trial.Models
{
    public class Story
    {
        public int StoryID { get; set; }
        public int Nooftasks { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
    public class Taski
    {
        public int TaskID { get; set; }
        public int StoryID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string TaskDesc { get; set; }
        public string TaskStatus { get; set; }
    }
}