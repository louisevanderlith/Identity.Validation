using System;

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

        /// <summary>
        /// This Identifier isn't used in South Africa.
        /// Just thought it would come in handy someday.
        /// </summary>
        Race Race { get; }
    }
}
