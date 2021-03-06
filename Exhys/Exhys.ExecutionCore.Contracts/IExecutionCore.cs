﻿using Exhys.SubmissionRouter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhys.ExecutionCore.Contracts
{
    public interface IExecutionCore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        ExecutionResultDto Execute (ExecutionDto execution);
        Task<ExecutionResultDto> ExecuteAsync (ExecutionDto execution);
    }
}
