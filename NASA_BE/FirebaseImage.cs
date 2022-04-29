using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_BE
{
    public class FirebaseImage
    {
        [Key]
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime savingeTime { get; set; }
    }
}
