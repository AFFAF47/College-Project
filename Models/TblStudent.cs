﻿using System;
using System.Collections.Generic;

namespace ServerConnections.Models
{
    public partial class TblStudent
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long CourseId { get; set; }

        public virtual TblCourse Course { get; set; } = null!;
    }
}
