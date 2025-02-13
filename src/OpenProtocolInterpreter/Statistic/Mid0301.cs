﻿using System.Collections.Generic;

namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// Histogram upload reply
    /// <para>
    ///    Histogram upload reply for the requested parameter set and for the requested histogram type. The
    ///    histogram uploaded is made of 9 bars according to Figure 22 Histogram example.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0301 : Mid, IStatistic, IController
    {
        public const int MID = 301;

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)GetField(1,(int)DataFields.HistogramType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.HistogramType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal SigmaHistogram
        {
            get => GetField(1,(int)DataFields.SigmaHistogram).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1,(int)DataFields.SigmaHistogram).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal MeanValueHistogram
        {
            get => GetField(1,(int)DataFields.MeanValueHistogram).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1,(int)DataFields.MeanValueHistogram).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ClassRange
        {
            get => GetField(1,(int)DataFields.ClassRange).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1,(int)DataFields.ClassRange).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int FirstBar
        {
            get => GetField(1,(int)DataFields.Bar1).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar1).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SecondBar
        {
            get => GetField(1,(int)DataFields.Bar2).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar2).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ThirdBar
        {
            get => GetField(1,(int)DataFields.Bar3).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar3).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int FourthBar
        {
            get => GetField(1,(int)DataFields.Bar4).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar4).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int FifthBar
        {
            get => GetField(1,(int)DataFields.Bar5).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar5).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SixthBar
        {
            get => GetField(1,(int)DataFields.Bar6).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar6).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SeventhBar
        {
            get => GetField(1,(int)DataFields.Bar7).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar7).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int EighthBar
        {
            get => GetField(1,(int)DataFields.Bar8).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar8).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NinethBar
        {
            get => GetField(1,(int)DataFields.Bar9).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.Bar9).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0301() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0301(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.ParameterSetId, 20, 3, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.HistogramType, 25, 2, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.SigmaHistogram, 29, 6, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.MeanValueHistogram, 37, 6, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.ClassRange, 45, 6, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar1, 53, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar2, 59, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar3, 65, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar4, 71, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar5, 77, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar6, 83, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar7, 89, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar8, 95, 4, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.Bar9, 101, 4, '0', PaddingOrientation.LeftPadded)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId,
            HistogramType,
            SigmaHistogram,
            /// <summary>
            /// X-BAR
            /// </summary>
            MeanValueHistogram,
            ClassRange,
            Bar1,
            Bar2,
            Bar3,
            Bar4,
            Bar5,
            Bar6,
            Bar7,
            Bar8,
            Bar9
        }
    }
}
