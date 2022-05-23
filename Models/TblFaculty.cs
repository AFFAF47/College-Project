using System;
using System.Collections.Generic;

namespace ServerConnections.Models
{
    public partial class TblFaculty
    {
        public long Id { get; set; }
        public string FacultyName { get; set; } = null!;
        public long CourseId { get; set; }

        public virtual TblCourse Course { get; set; } = null!;
    }
}
