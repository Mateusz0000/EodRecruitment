using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Exceptions
{
    public class EmptyContractorsListException : ApplicationException
    {
        public EmptyContractorsListException(string message) : base(message)
        {

        }
    }
}
