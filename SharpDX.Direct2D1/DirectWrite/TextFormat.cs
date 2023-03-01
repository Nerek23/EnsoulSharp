using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DA RID: 218
	[Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
	public class TextFormat : ComObject
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		public TextFormat(Factory factory, string fontFamilyName, float fontSize) : this(factory, fontFamilyName, null, FontWeight.Normal, FontStyle.Normal, FontStretch.Normal, fontSize, "")
		{
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		public TextFormat(Factory factory, string fontFamilyName, FontWeight fontWeight, FontStyle fontStyle, float fontSize) : this(factory, fontFamilyName, null, fontWeight, fontStyle, FontStretch.Normal, fontSize, "")
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000E6FC File Offset: 0x0000C8FC
		public TextFormat(Factory factory, string fontFamilyName, FontWeight fontWeight, FontStyle fontStyle, FontStretch fontStretch, float fontSize) : this(factory, fontFamilyName, null, fontWeight, fontStyle, fontStretch, fontSize, "")
		{
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000E720 File Offset: 0x0000C920
		public TextFormat(Factory factory, string fontFamilyName, FontCollection fontCollection, FontWeight fontWeight, FontStyle fontStyle, FontStretch fontStretch, float fontSize) : this(factory, fontFamilyName, fontCollection, fontWeight, fontStyle, fontStretch, fontSize, "")
		{
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000E744 File Offset: 0x0000C944
		public TextFormat(Factory factory, string fontFamilyName, FontCollection fontCollection, FontWeight fontWeight, FontStyle fontStyle, FontStretch fontStretch, float fontSize, string localeName) : base(IntPtr.Zero)
		{
			factory.CreateTextFormat(fontFamilyName, fontCollection, fontWeight, fontStyle, fontStretch, fontSize, localeName, this);
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000E770 File Offset: 0x0000C970
		public unsafe string FontFamilyName
		{
			get
			{
				int fontFamilyNameLength = this.GetFontFamilyNameLength();
				char* value = stackalloc char[checked(unchecked((UIntPtr)(fontFamilyNameLength + 1)) * 2)];
				this.GetFontFamilyName(new IntPtr((void*)value), fontFamilyNameLength + 1);
				return new string(value, 0, fontFamilyNameLength);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x0000E7A4 File Offset: 0x0000C9A4
		public unsafe string LocaleName
		{
			get
			{
				int localeNameLength = this.GetLocaleNameLength();
				char* value = stackalloc char[checked(unchecked((UIntPtr)(localeNameLength + 1)) * 2)];
				this.GetLocaleName(new IntPtr((void*)value), localeNameLength + 1);
				return new string(value, 0, localeNameLength);
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00002A7F File Offset: 0x00000C7F
		public TextFormat(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000E7D8 File Offset: 0x0000C9D8
		public new static explicit operator TextFormat(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextFormat(nativePtr);
			}
			return null;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000E7EF File Offset: 0x0000C9EF
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000E7F7 File Offset: 0x0000C9F7
		public TextAlignment TextAlignment
		{
			get
			{
				return this.GetTextAlignment();
			}
			set
			{
				this.SetTextAlignment(value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000E800 File Offset: 0x0000CA00
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000E808 File Offset: 0x0000CA08
		public ParagraphAlignment ParagraphAlignment
		{
			get
			{
				return this.GetParagraphAlignment();
			}
			set
			{
				this.SetParagraphAlignment(value);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000E811 File Offset: 0x0000CA11
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x0000E819 File Offset: 0x0000CA19
		public WordWrapping WordWrapping
		{
			get
			{
				return this.GetWordWrapping();
			}
			set
			{
				this.SetWordWrapping(value);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000E822 File Offset: 0x0000CA22
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0000E82A File Offset: 0x0000CA2A
		public ReadingDirection ReadingDirection
		{
			get
			{
				return this.GetReadingDirection();
			}
			set
			{
				this.SetReadingDirection(value);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000E833 File Offset: 0x0000CA33
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000E83B File Offset: 0x0000CA3B
		public FlowDirection FlowDirection
		{
			get
			{
				return this.GetFlowDirection();
			}
			set
			{
				this.SetFlowDirection(value);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000E844 File Offset: 0x0000CA44
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0000E84C File Offset: 0x0000CA4C
		public float IncrementalTabStop
		{
			get
			{
				return this.GetIncrementalTabStop();
			}
			set
			{
				this.SetIncrementalTabStop(value);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000E858 File Offset: 0x0000CA58
		public FontCollection FontCollection
		{
			get
			{
				FontCollection result;
				this.GetFontCollection(out result);
				return result;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x0000E86E File Offset: 0x0000CA6E
		public FontWeight FontWeight
		{
			get
			{
				return this.GetFontWeight();
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000E876 File Offset: 0x0000CA76
		public FontStyle FontStyle
		{
			get
			{
				return this.GetFontStyle();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000E87E File Offset: 0x0000CA7E
		public FontStretch FontStretch
		{
			get
			{
				return this.GetFontStretch();
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000E886 File Offset: 0x0000CA86
		public float FontSize
		{
			get
			{
				return this.GetFontSize();
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000E890 File Offset: 0x0000CA90
		internal unsafe void SetTextAlignment(TextAlignment textAlignment)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, textAlignment, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000E8C8 File Offset: 0x0000CAC8
		internal unsafe void SetParagraphAlignment(ParagraphAlignment paragraphAlignment)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, paragraphAlignment, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000E900 File Offset: 0x0000CB00
		internal unsafe void SetWordWrapping(WordWrapping wordWrapping)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, wordWrapping, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000E938 File Offset: 0x0000CB38
		internal unsafe void SetReadingDirection(ReadingDirection readingDirection)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, readingDirection, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000E970 File Offset: 0x0000CB70
		internal unsafe void SetFlowDirection(FlowDirection flowDirection)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, flowDirection, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
		internal unsafe void SetIncrementalTabStop(float incrementalTabStop)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, incrementalTabStop, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		public unsafe void SetTrimming(Trimming trimmingOptions, InlineObject trimmingSign)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<InlineObject>(trimmingSign);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &trimmingOptions, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000EA30 File Offset: 0x0000CC30
		public unsafe void SetLineSpacing(LineSpacingMethod lineSpacingMethod, float lineSpacing, float baseline)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Single,System.Single), this._nativePointer, lineSpacingMethod, lineSpacing, baseline, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000EA6B File Offset: 0x0000CC6B
		internal unsafe TextAlignment GetTextAlignment()
		{
			return calli(SharpDX.DirectWrite.TextAlignment(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000EA8B File Offset: 0x0000CC8B
		internal unsafe ParagraphAlignment GetParagraphAlignment()
		{
			return calli(SharpDX.DirectWrite.ParagraphAlignment(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000EAAB File Offset: 0x0000CCAB
		internal unsafe WordWrapping GetWordWrapping()
		{
			return calli(SharpDX.DirectWrite.WordWrapping(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000EACB File Offset: 0x0000CCCB
		internal unsafe ReadingDirection GetReadingDirection()
		{
			return calli(SharpDX.DirectWrite.ReadingDirection(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		internal unsafe FlowDirection GetFlowDirection()
		{
			return calli(SharpDX.DirectWrite.FlowDirection(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000EB0B File Offset: 0x0000CD0B
		internal unsafe float GetIncrementalTabStop()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000EB2C File Offset: 0x0000CD2C
		public unsafe void GetTrimming(out Trimming trimmingOptions, out InlineObject trimmingSign)
		{
			trimmingOptions = default(Trimming);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (Trimming* ptr = &trimmingOptions)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				trimmingSign = new InlineObjectNative(zero);
			}
			else
			{
				trimmingSign = null;
			}
			result.CheckError();
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000EB98 File Offset: 0x0000CD98
		public unsafe void GetLineSpacing(out LineSpacingMethod lineSpacingMethod, out float lineSpacing, out float baseline)
		{
			Result result;
			fixed (float* ptr = &baseline)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &lineSpacing)
				{
					void* ptr4 = (void*)ptr3;
					fixed (LineSpacingMethod* ptr5 = &lineSpacingMethod)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		internal unsafe void GetFontCollection(out FontCollection fontCollection)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontCollection = new FontCollection(zero);
			}
			else
			{
				fontCollection = null;
			}
			result.CheckError();
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000EC4F File Offset: 0x0000CE4F
		internal unsafe int GetFontFamilyNameLength()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000EC70 File Offset: 0x0000CE70
		internal unsafe void GetFontFamilyName(IntPtr fontFamilyName, int nameSize)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)fontFamilyName, nameSize, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000ECAF File Offset: 0x0000CEAF
		internal unsafe FontWeight GetFontWeight()
		{
			return calli(SharpDX.DirectWrite.FontWeight(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000ECCF File Offset: 0x0000CECF
		internal unsafe FontStyle GetFontStyle()
		{
			return calli(SharpDX.DirectWrite.FontStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000ECEF File Offset: 0x0000CEEF
		internal unsafe FontStretch GetFontStretch()
		{
			return calli(SharpDX.DirectWrite.FontStretch(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000ED0F File Offset: 0x0000CF0F
		internal unsafe float GetFontSize()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000ED2F File Offset: 0x0000CF2F
		internal unsafe int GetLocaleNameLength()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000ED50 File Offset: 0x0000CF50
		internal unsafe void GetLocaleName(IntPtr localeName, int nameSize)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)localeName, nameSize, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
