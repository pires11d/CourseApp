using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities.Exceptions
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
