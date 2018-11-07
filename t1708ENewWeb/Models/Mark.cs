using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace t1708ENewWeb.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int SubjectMark { get; set; }
        public string SubjectName { get; set; }
        public string SubjectRollNumber { get; set; }
        [ForeignKey("SubjectRollNumber")]
        public Student Students { get; set; }
    }
}
