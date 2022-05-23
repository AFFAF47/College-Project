using System;
using System.Collections.Generic;

namespace ServerConnections.Models
{
    public partial class TblStudent
    {
        public long Id { get; set; }
        public string StudentName { get; set; } = null!;
        public long CourseId { get; set; }
        public string Email { get; set; } = null!;
        public string VcPassword { get; set; } = null!;

        public virtual TblCourse Course { get; set; } = null!;
    }
}
