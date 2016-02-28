using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Misc
{
    public class AccountingModuleException : Exception
    {
        public AccountingModuleException()
        { }

        public AccountingModuleException(string message)
            : base(message)
        { }

        public AccountingModuleException(string message, Exception inner)
            : base(message, inner)
        { }

        public AccountingModuleException(string fmt, params object[] args)
            : base(string.Format(fmt, args))
        { }

        public AccountingModuleException(Exception inner, string fmt, params object[] args)
            : base(string.Format(fmt, args), inner)
        { }
    }
}
