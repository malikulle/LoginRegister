﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, success: false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, success: false, message)
        {
        }
        public ErrorDataResult(string message) : base(default, success: false, message)
        {
        }
        public ErrorDataResult() : base(default, success: false)
        {
        }
    }
}
