﻿using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job restart
    /// <para>Job restart message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job not running, or Invalid data</para>
    /// </summary>
    public class Mid0039 : Mid, IJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 39;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobNotRunning, Error.InvalidData };

        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0039() : this(DEFAULT_REVISION)
        {

        }

        public Mid0039(Header header) : base(header)
        {
            HandleRevisions();
        }

        public Mid0039(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JobId, 20, 2, '0', PaddingOrientation.LeftPadded, false),
                            }
                }
            };
        }

        private void HandleRevisions()
        {
            if (Header.Revision == 1)
            {
                GetField(1, (int)DataFields.JobId).Size = 2;
            }
            else
            {
                GetField(1, (int)DataFields.JobId).Size = 4;
            }
        }

        protected enum DataFields
        {
            JobId
        }
    }
}
