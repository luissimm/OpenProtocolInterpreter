﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Operation result Overall data
    /// <para>
    ///     This MID contains the overall result data and some of the object data of the last tightening. 
    ///     In the subscription of this message it can be chosen to also start subscription of <see cref="Mid1202"/> Operation result object data. 
    ///     The user defined values is preconfigured in the controller via the configuration tool.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: <see cref="Mid1203"/> Operation result data acknowledge or 
    ///             <see cref="Communication.Mid0005"/> with <see cref="Mid1201"/> in the data field.
    /// </para>
    /// <para>If the sequence number acknowledge functionality is used there is no need for these acknowledges.</para>
    /// </summary>
    public class Mid1201 : Mid, IResult, IController, IAcknowledgeable<Mid1203>, IAcceptableCommand
    {
        public const int MID = 1201;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TotalMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.TotalMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ResultDataIdentifier
        {
            get => GetField(1, (int)DataFields.ResultDataIdentifier).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ResultDataIdentifier).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResultStatus
        {
            get => GetField(1, (int)DataFields.ResultStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.ResultStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public OperationType OperationType
        {
            get => (OperationType)GetField(1, (int)DataFields.OperationType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.OperationType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int NumberOfObjects
        {
            get => GetField(1, (int)DataFields.NumberOfObjects).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfObjects).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDataFields
        {
            get => GetField(1, (int)DataFields.NumberOfDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<ObjectData> ObjectDataList { get; set; }
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid1201() : this(DEFAULT_REVISION)
        {

        }

        public Mid1201(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid1201(Header header) : base(header)
        {
            ObjectDataList = new List<ObjectData>();
            VariableDataFields = new List<VariableDataField>();
        }

        public override string Pack()
        {
            NumberOfObjects = ObjectDataList.Count;
            NumberOfDataFields = VariableDataFields.Count;

            GetField(1, (int)DataFields.ObjectData).SetValue(PackObjectDataList());
            GetField(1, (int)DataFields.DataFieldList).SetValue(OpenProtocolConvert.ToString(VariableDataFields));
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var rawTotalObjectData = GetValue(GetField(1, (int)DataFields.NumberOfObjects), package);
            int totalObjectData = OpenProtocolConvert.ToInt32(rawTotalObjectData);

            var objectDataField = GetField(1, (int)DataFields.ObjectData);
            objectDataField.Size = totalObjectData * 5;

            var totalNumberDataField = GetField(1, (int)DataFields.NumberOfDataFields);
            totalNumberDataField.Index = objectDataField.Index + objectDataField.Size;

            var dataFieldListField = GetField(1, (int)DataFields.DataFieldList);
            dataFieldListField.Index = totalNumberDataField.Index + totalNumberDataField.Size;
            dataFieldListField.Size = Header.Length - dataFieldListField.Index;

            ProcessDataFields(package);
            ObjectDataList = ObjectData.ParseAll(objectDataField.Value).ToList();
            VariableDataFields = VariableDataField.ParseAll(dataFieldListField.Value).ToList();
            return this;
        }

        protected virtual string PackObjectDataList()
        {
            string pack = string.Empty;
            foreach (var v in ObjectDataList)
            {
                pack += v.Pack();
            }

            return pack;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.TotalMessages, 20, 3, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.MessageNumber, 23, 3, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.ResultDataIdentifier, 26, 10, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.Time, 36, 19, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.ResultStatus, 55, 1, false),
                        new DataField((int)DataFields.OperationType, 56, 2, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.NumberOfObjects, 58, 3, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.ObjectData, 61, 0, false),
                        new DataField((int)DataFields.NumberOfDataFields, 0, 3, '0', PaddingOrientation.LeftPadded, false),
                        new DataField((int)DataFields.DataFieldList, 0, 0, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            TotalMessages,
            MessageNumber,
            ResultDataIdentifier,
            Time,
            ResultStatus,
            OperationType,
            NumberOfObjects,
            ObjectData,  // list of data
            NumberOfDataFields,
            DataFieldList
        }
    }
}

