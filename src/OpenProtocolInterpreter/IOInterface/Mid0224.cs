﻿using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Set digital input function
    /// <para>
    ///     Set the digital input function with the digital input number. 
    ///     The digital input function numbers are defined in Table 80.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Invalid data</para>
    /// </summary>
    public class Mid0224 : Mid, IIOInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 224;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DigitalInputNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.DigitalInputNumber).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0224() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0224(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DigitalInputNumber, 20, 3, '0', PaddingOrientation.LeftPadded, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            DigitalInputNumber
        }
    }
}
