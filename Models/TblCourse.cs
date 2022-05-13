using System;
using System.Collections.Generic;

namespace ServerConnections.Models
{
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblFaculties = new HashSet<TblFaculty>();
            TblStudents = new HashSet<TblStudent>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblFaculty> TblFaculties { get; set; }
        public virtual ICollection<TblStudent> TblStudents { get; set; }
    }
}
