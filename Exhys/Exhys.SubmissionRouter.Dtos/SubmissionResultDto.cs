﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhys.SubmissionRouter.Dtos
{
    public class SubmissionResultDto
    {
        public Guid ExecutionId { get; set; }
        public List<TestResultDto> TestResults { get; set; }
    }
}
