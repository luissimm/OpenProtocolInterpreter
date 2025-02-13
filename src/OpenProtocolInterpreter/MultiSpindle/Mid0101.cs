﻿using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result
    /// <para>
    ///     The multi-spindle result is sent after each sync tightening and if it is subscribed. The multiple results
    ///     contain the common status of the multiple as well as the individual tightening result(torque and angle)
    ///     of each spindle.
    /// </para>
    /// <para>
    ///     This telegram is also used for PowerMACS systems running a Press.The layout of the telegram is
    ///     exactly the same but some of the fields have slightly different definitions.The fields for Torque are
    ///     used for Force values and the fields for Angle are used for Stroke values. A press system always uses
    ///     revision 4 or higher of the telegram.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0102"/> Multi-spindle result acknowledge</para>
    /// </summary>
    public class Mid0101 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0102>
    {
        public const int MID = 101;

        public int NumberOfSpindlesOrPresses
        {
            get => GetField(1, (int)DataFields.NumberOfSpindlesOrPresses).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfSpindlesOrPresses).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VinNumber).Value;
            set => GetField(1, (int)DataFields.VinNumber).SetValue(value);
        }
        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchSize
        {
            get => GetField(1, (int)DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchCounter
        {
            get => GetField(1, (int)DataFields.BatchCounter).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.BatchCounter).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(1, (int)DataFields.BatchStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.BatchStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal TorqueOrForceMinLimit
        {
            get => GetField(1, (int)DataFields.TorqueOrForceMinLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.TorqueOrForceMinLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueOrForceMaxLimit
        {
            get => GetField(1, (int)DataFields.TorqueOrForceMaxLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.TorqueOrForceMaxLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueOrForceFinalTarget
        {
            get => GetField(1, (int)DataFields.TorqueOrForceFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.TorqueOrForceFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal AngleOrStrokeMinLimit
        {
            get => GetField(1, (int)DataFields.AngleOrStrokeMinLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.AngleOrStrokeMinLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal AngleOrStrokeMaxLimit
        {
            get => GetField(1, (int)DataFields.AngleOrStrokeMaxLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.AngleOrStrokeMaxLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal FinalAngleOrStrokeTarget
        {
            get => GetField(1, (int)DataFields.FinalAngleOrStrokeTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.FinalAngleOrStrokeTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(1, (int)DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, (int)DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, (int)DataFields.SyncOverallStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.SyncOverallStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<SpindleOrPressStatus> SpindlesOrPressesStatus { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SystemSubType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(4, (int)DataFields.SystemSubType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(5, (int)DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0101() : this(DEFAULT_REVISION)
        {

        }

        public Mid0101(Header header) : base(header)
        {

        }

        public Mid0101(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SpindesOrPressesStatus);
            spindesOrPressesStatusField.Size = SpindlesOrPressesStatus.Count * 18;
            spindesOrPressesStatusField.Value = PackSpindlesOrPressesStatus();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var spindleOrPressesField = GetField(1, (int)DataFields.NumberOfSpindlesOrPresses);
            int spindleOrPresses = OpenProtocolConvert.ToInt32(package.Substring(spindleOrPressesField.Index + 2, spindleOrPressesField.Size));
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SpindesOrPressesStatus);
            spindesOrPressesStatusField.Size = spindleOrPresses * 18;
            if(Header.Revision > 3)
            {
                var systemSubTypeField = GetField(4, (int)DataFields.SystemSubType);
                systemSubTypeField.Index = spindesOrPressesStatusField.Index + spindesOrPressesStatusField.Size + 2;
                if(Header.Revision > 4)
                {
                    GetField(5, (int)DataFields.JobSequenceNumber).Index = systemSubTypeField.Index + systemSubTypeField.Size + 2;
                }
            }
            ProcessDataFields(package);
            SpindlesOrPressesStatus = ParseSpindlesOrPressesStatus(spindesOrPressesStatusField.Value);
            return this;
        }

        protected virtual string PackSpindlesOrPressesStatus()
        {
            string package = string.Empty;
            foreach (var v in SpindlesOrPressesStatus)
            {
                package += OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, v.SpindleOrPressNumber) +
                           OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, v.ChannelId) +
                           OpenProtocolConvert.ToString(v.OverallStatus) +
                           OpenProtocolConvert.ToString((int)v.TorqueOrForceStatus) +
                           OpenProtocolConvert.TruncatedDecimalToString('0', 6, PaddingOrientation.LeftPadded, v.TorqueOrForce) +
                           OpenProtocolConvert.ToString(v.AngleOrStrokeStatus) +
                           OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, v.AngleOrStroke);
            }

            return package;
        }

        protected virtual List<SpindleOrPressStatus> ParseSpindlesOrPressesStatus(string section)
        {
            var list = new List<SpindleOrPressStatus>();
            for (int i = 0; i < section.Length; i += 18)
            {
                var spindleValue = section.Substring(i, 18);
                var obj = new SpindleOrPressStatus()
                {
                    SpindleOrPressNumber = OpenProtocolConvert.ToInt32(spindleValue.Substring(0, 2)),
                    ChannelId = OpenProtocolConvert.ToInt32(spindleValue.Substring(2, 2)),
                    OverallStatus = OpenProtocolConvert.ToBoolean(spindleValue.Substring(4, 1)),
                    TorqueOrForceStatus = (TighteningValueStatus)OpenProtocolConvert.ToInt32(spindleValue.Substring(5, 1)),
                    TorqueOrForce = OpenProtocolConvert.ToTruncatedDecimal(spindleValue.Substring(6, 6)),
                    AngleOrStrokeStatus = OpenProtocolConvert.ToBoolean(spindleValue.Substring(12, 1)),
                    AngleOrStroke = OpenProtocolConvert.ToInt32(spindleValue.Substring(13, 5))
                };
                list.Add(obj);
            }

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NumberOfSpindlesOrPresses, 20, 2, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.VinNumber, 24, 25, ' '),
                                new DataField((int)DataFields.JobId, 51, 2, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 55, 3, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.BatchSize, 60, 4, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 66, 4, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.BatchStatus, 72, 1),
                                new DataField((int)DataFields.TorqueOrForceMinLimit, 75, 6, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.TorqueOrForceMaxLimit, 83, 6, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.TorqueOrForceFinalTarget, 91, 6, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.AngleOrStrokeMinLimit, 99, 5, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.AngleOrStrokeMaxLimit, 106, 5, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.FinalAngleOrStrokeTarget, 113, 5, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.LastChangeInParameterSet, 120, 19),
                                new DataField((int)DataFields.Timestamp, 141, 19),
                                new DataField((int)DataFields.SyncTighteningId, 162, 5, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.SyncOverallStatus, 169, 1),
                                new DataField((int)DataFields.SpindesOrPressesStatus, 172, 0)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.SystemSubType, 0, 3, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.JobSequenceNumber, 0, 5, '0', PaddingOrientation.LeftPadded)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfSpindlesOrPresses,
            VinNumber,
            JobId,
            ParameterSetId,
            BatchSize,
            BatchCounter,
            BatchStatus,
            TorqueOrForceMinLimit,
            TorqueOrForceMaxLimit,
            TorqueOrForceFinalTarget,
            AngleOrStrokeMinLimit,
            AngleOrStrokeMaxLimit,
            FinalAngleOrStrokeTarget,
            Target,
            LastChangeInParameterSet,
            Timestamp,
            SyncTighteningId,
            SyncOverallStatus,
            SpindesOrPressesStatus,
            //Rev 4
            SystemSubType,
            //Rev 5
            JobSequenceNumber
        }
    }
}
