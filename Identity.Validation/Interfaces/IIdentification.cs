using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Validation.Interfaces
{
    public interface IIdentification
    {
        string RawNumber { get; }

        DateTime DateOfBirth { get; }

        Gender Gender { get; }

        Citizenship Citizenship { get; }

        bool IsValid { get; }

        int ControlDigit { get; }
    }
}
