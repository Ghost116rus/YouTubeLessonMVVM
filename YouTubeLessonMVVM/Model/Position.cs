﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeLessonMVVM.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
        public int? MaxNumber { get; set; }
        public List<Staff>? Staffs { get; set; } 
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }


    }
}