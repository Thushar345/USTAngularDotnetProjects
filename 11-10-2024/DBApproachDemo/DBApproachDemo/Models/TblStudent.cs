﻿using System;
using System.Collections.Generic;

namespace DBApproachDemo.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGrade { get; set; }

    public string? StudentRollNo { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
