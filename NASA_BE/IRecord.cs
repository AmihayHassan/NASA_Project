﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NASA_BE
{
    public interface IRecord
    {
        [Key]
        int Id { get; set; }
    }
}