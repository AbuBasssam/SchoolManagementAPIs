using DomainLayer.Enums;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Models;
using System.Net;
using DomainLayer.Entities;

namespace ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage
{
    public class CourseFilter
    {
        public enCourseHours? CourseHours { get; set; }
        public enLevel? CourseLevel { get; set; }
        public bool? HasPractical { get; set; }
        public bool? HasPrerequisite { get; set; }

    }

}
