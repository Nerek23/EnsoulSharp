using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DB RID: 219
	[Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
	public class TextLayout : TextFormat
	{
		// Token: 0x0600047B RID: 1147 RVA: 0x0000ED8F File Offset: 0x0000CF8F
		public TextLayout(Factory factory, string text, TextFormat textFormat, float maxWidth, float maxHeight) : base(IntPtr.Zero)
		{
			factory.CreateTextLayout(text, text.Length, textFormat, maxWidth, maxHeight, this);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		public TextLayout(Factory factory, string text, TextFormat textFormat, float layoutWidth, float layoutHeight, float pixelsPerDip, bool useGdiNatural) : this(factory, text, textFormat, layoutWidth, layoutHeight, pixelsPerDip, null, useGdiNatural)
		{
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000EDD8 File Offset: 0x0000CFD8
		public TextLayout(Factory factory, string text, TextFormat textFormat, float layoutWidth, float layoutHeight, float pixelsPerDip, RawMatrix3x2? transform, bool useGdiNatural) : base(IntPtr.Zero)
		{
			factory.CreateGdiCompatibleTextLayout(text, text.Length, textFormat, layoutWidth, layoutHeight, pixelsPerDip, transform, useGdiNatural, this);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000EE0E File Offset: 0x0000D00E
		public void Draw(TextRenderer renderer, float originX, float originY)
		{
			this.Draw(null, renderer, originX, originY);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000EE1C File Offset: 0x0000D01C
		public void Draw(object clientDrawingContext, TextRenderer renderer, float originX, float originY)
		{
			GCHandle value = GCHandle.Alloc(clientDrawingContext);
			try
			{
				this.Draw(GCHandle.ToIntPtr(value), renderer, originX, originY);
			}
			finally
			{
				if (value.IsAllocated)
				{
					value.Free();
				}
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000EE64 File Offset: 0x0000D064
		public ClusterMetrics[] GetClusterMetrics()
		{
			ClusterMetrics[] array = new ClusterMetrics[0];
			int maxClusterCount = 0;
			int num = 0;
			this.GetClusterMetrics(array, maxClusterCount, out num);
			if (num > 0)
			{
				array = new ClusterMetrics[num];
				this.GetClusterMetrics(array, num, out num);
			}
			return array;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000EEA0 File Offset: 0x0000D0A0
		public void SetDrawingEffect(ComObject drawingEffect, TextRange textRange)
		{
			IntPtr iunknownForObject = Utilities.GetIUnknownForObject(drawingEffect);
			this.SetDrawingEffect(iunknownForObject, textRange);
			if (iunknownForObject != IntPtr.Zero)
			{
				Marshal.Release(iunknownForObject);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0000EED0 File Offset: 0x0000D0D0
		public ComObject GetDrawingEffect(int currentPosition)
		{
			TextRange textRange;
			return this.GetDrawingEffect(currentPosition, out textRange);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000EEE6 File Offset: 0x0000D0E6
		public ComObject GetDrawingEffect(int currentPosition, out TextRange textRange)
		{
			return (ComObject)Utilities.GetObjectForIUnknown(this.GetDrawingEffect_(currentPosition, out textRange));
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000EEFC File Offset: 0x0000D0FC
		public FontCollection GetFontCollection(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontCollection(currentPosition, out textRange);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000EF14 File Offset: 0x0000D114
		public string GetFontFamilyName(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontFamilyName(currentPosition, out textRange);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000EF2C File Offset: 0x0000D12C
		public unsafe string GetFontFamilyName(int currentPosition, out TextRange textRange)
		{
			int num;
			this.GetFontFamilyNameLength(currentPosition, out num, out textRange);
			char* value = stackalloc char[checked(unchecked((UIntPtr)(num + 1)) * 2)];
			this.GetFontFamilyName(currentPosition, new IntPtr((void*)value), num + 1, out textRange);
			return new string(value, 0, num);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000EF68 File Offset: 0x0000D168
		public float GetFontSize(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontSize(currentPosition, out textRange);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000EF80 File Offset: 0x0000D180
		public FontStretch GetFontStretch(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontStretch(currentPosition, out textRange);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000EF98 File Offset: 0x0000D198
		public FontStyle GetFontStyle(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontStyle(currentPosition, out textRange);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000EFB0 File Offset: 0x0000D1B0
		public FontWeight GetFontWeight(int currentPosition)
		{
			TextRange textRange;
			return this.GetFontWeight(currentPosition, out textRange);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000EFC8 File Offset: 0x0000D1C8
		public InlineObject GetInlineObject(int currentPosition)
		{
			TextRange textRange;
			return this.GetInlineObject(currentPosition, out textRange);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000EFE0 File Offset: 0x0000D1E0
		public LineMetrics[] GetLineMetrics()
		{
			LineMetrics[] array = new LineMetrics[0];
			int maxLineCount = 0;
			int num = 0;
			this.GetLineMetrics(array, maxLineCount, out num);
			if (num > 0)
			{
				array = new LineMetrics[num];
				this.GetLineMetrics(array, num, out num);
			}
			return array;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000F01C File Offset: 0x0000D21C
		public string GetLocaleName(int currentPosition)
		{
			TextRange textRange;
			return this.GetLocaleName(currentPosition, out textRange);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000F034 File Offset: 0x0000D234
		public unsafe string GetLocaleName(int currentPosition, out TextRange textRange)
		{
			int num;
			this.GetLocaleNameLength(currentPosition, out num, out textRange);
			char* value = stackalloc char[checked(unchecked((UIntPtr)(num + 1)) * 2)];
			this.GetLocaleName(currentPosition, new IntPtr((void*)value), num + 1, out textRange);
			return new string(value, 0, num);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000F070 File Offset: 0x0000D270
		public bool HasStrikethrough(int currentPosition)
		{
			TextRange textRange;
			return this.HasStrikethrough(currentPosition, out textRange);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000F08C File Offset: 0x0000D28C
		public Typography GetTypography(int currentPosition)
		{
			TextRange textRange;
			return this.GetTypography(currentPosition, out textRange);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000F0A4 File Offset: 0x0000D2A4
		public bool HasUnderline(int currentPosition)
		{
			TextRange textRange;
			return this.HasUnderline(currentPosition, out textRange);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000F0C0 File Offset: 0x0000D2C0
		public HitTestMetrics[] HitTestTextRange(int textPosition, int textLength, float originX, float originY)
		{
			HitTestMetrics[] array = new HitTestMetrics[0];
			int num = 0;
			this.HitTestTextRange(textPosition, textLength, originX, originY, array, 0, out num);
			if (num > 0)
			{
				array = new HitTestMetrics[num];
				this.HitTestTextRange(textPosition, textLength, originX, originY, array, num, out num);
			}
			return array;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000F102 File Offset: 0x0000D302
		public TextLayout(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000F10B File Offset: 0x0000D30B
		public new static explicit operator TextLayout(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextLayout(nativePtr);
			}
			return null;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000F122 File Offset: 0x0000D322
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000F12A File Offset: 0x0000D32A
		public float MaxWidth
		{
			get
			{
				return this.GetMaxWidth();
			}
			set
			{
				this.SetMaxWidth(value);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000F133 File Offset: 0x0000D333
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000F13B File Offset: 0x0000D33B
		public float MaxHeight
		{
			get
			{
				return this.GetMaxHeight();
			}
			set
			{
				this.SetMaxHeight(value);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000F144 File Offset: 0x0000D344
		public TextMetrics Metrics
		{
			get
			{
				TextMetrics result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000F15C File Offset: 0x0000D35C
		public OverhangMetrics OverhangMetrics
		{
			get
			{
				OverhangMetrics result;
				this.GetOverhangMetrics(out result);
				return result;
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000F174 File Offset: 0x0000D374
		internal unsafe void SetMaxWidth(float maxWidth)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, maxWidth, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
		internal unsafe void SetMaxHeight(float maxHeight)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, maxHeight, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		public unsafe void SetFontCollection(FontCollection fontCollection, TextRange textRange)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollection>(fontCollection);
			calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, (void*)value, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000F238 File Offset: 0x0000D438
		public unsafe void SetFontFamilyName(string fontFamilyName, TextRange textRange)
		{
			Result result;
			fixed (string text = fontFamilyName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, ptr, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000F284 File Offset: 0x0000D484
		public unsafe void SetFontWeight(FontWeight fontWeight, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.DirectWrite.TextRange), this._nativePointer, fontWeight, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000F2C0 File Offset: 0x0000D4C0
		public unsafe void SetFontStyle(FontStyle fontStyle, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.DirectWrite.TextRange), this._nativePointer, fontStyle, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000F2FC File Offset: 0x0000D4FC
		public unsafe void SetFontStretch(FontStretch fontStretch, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.DirectWrite.TextRange), this._nativePointer, fontStretch, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000F338 File Offset: 0x0000D538
		public unsafe void SetFontSize(float fontSize, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Single,SharpDX.DirectWrite.TextRange), this._nativePointer, fontSize, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000F374 File Offset: 0x0000D574
		public unsafe void SetUnderline(RawBool hasUnderline, TextRange textRange)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.DirectWrite.TextRange), this._nativePointer, hasUnderline, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
		public unsafe void SetStrikethrough(RawBool hasStrikethrough, TextRange textRange)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.DirectWrite.TextRange), this._nativePointer, hasStrikethrough, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000F3EC File Offset: 0x0000D5EC
		public unsafe void SetDrawingEffect(IntPtr drawingEffect, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, (void*)drawingEffect, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000F42C File Offset: 0x0000D62C
		public unsafe void SetInlineObject(InlineObject inlineObject, TextRange textRange)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<InlineObject>(inlineObject);
			calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, (void*)value, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000F478 File Offset: 0x0000D678
		public unsafe void SetTypography(Typography typography, TextRange textRange)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Typography>(typography);
			calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, (void*)value, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000F4C4 File Offset: 0x0000D6C4
		public unsafe void SetLocaleName(string localeName, TextRange textRange)
		{
			Result result;
			fixed (string text = localeName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.TextRange), this._nativePointer, ptr, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000F510 File Offset: 0x0000D710
		internal unsafe float GetMaxWidth()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000F530 File Offset: 0x0000D730
		internal unsafe float GetMaxHeight()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000F550 File Offset: 0x0000D750
		public unsafe FontCollection GetFontCollection(int currentPosition, out TextRange textRange)
		{
			IntPtr zero = IntPtr.Zero;
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
			}
			FontCollection result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new FontCollection(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000F5C0 File Offset: 0x0000D7C0
		internal unsafe void GetFontFamilyNameLength(int currentPosition, out int nameLength, out TextRange textRange)
		{
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &nameLength)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000F618 File Offset: 0x0000D818
		internal unsafe void GetFontFamilyName(int currentPosition, IntPtr fontFamilyName, int nameSize, out TextRange textRange)
		{
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, currentPosition, (void*)fontFamilyName, nameSize, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000F66C File Offset: 0x0000D86C
		public unsafe FontWeight GetFontWeight(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			FontWeight result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000F6BC File Offset: 0x0000D8BC
		public unsafe FontStyle GetFontStyle(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			FontStyle result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000F70C File Offset: 0x0000D90C
		public unsafe FontStretch GetFontStretch(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			FontStretch result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000F75C File Offset: 0x0000D95C
		public unsafe float GetFontSize(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			float result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000F7AC File Offset: 0x0000D9AC
		public unsafe RawBool HasUnderline(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			RawBool result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000F7FC File Offset: 0x0000D9FC
		public unsafe RawBool HasStrikethrough(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			RawBool result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000F84C File Offset: 0x0000DA4C
		internal unsafe IntPtr GetDrawingEffect_(int currentPosition, out TextRange textRange)
		{
			textRange = default(TextRange);
			IntPtr result2;
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000F89C File Offset: 0x0000DA9C
		public unsafe InlineObject GetInlineObject(int currentPosition, out TextRange textRange)
		{
			IntPtr zero = IntPtr.Zero;
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*)));
			}
			InlineObject result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new InlineObjectNative(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000F90C File Offset: 0x0000DB0C
		public unsafe Typography GetTypography(int currentPosition, out TextRange textRange)
		{
			IntPtr zero = IntPtr.Zero;
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
			}
			Typography result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Typography(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0000F97C File Offset: 0x0000DB7C
		internal unsafe void GetLocaleNameLength(int currentPosition, out int nameLength, out TextRange textRange)
		{
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &nameLength)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000F9D4 File Offset: 0x0000DBD4
		internal unsafe void GetLocaleName(int currentPosition, IntPtr localeName, int nameSize, out TextRange textRange)
		{
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, currentPosition, (void*)localeName, nameSize, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000FA28 File Offset: 0x0000DC28
		public unsafe void Draw(IntPtr clientDrawingContext, TextRenderer renderer, float originX, float originY)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextRenderer>(renderer);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Single), this._nativePointer, (void*)clientDrawingContext, (void*)value, originX, originY, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000FA7C File Offset: 0x0000DC7C
		internal unsafe Result GetLineMetrics(LineMetrics[] lineMetrics, int maxLineCount, out int actualLineCount)
		{
			Result result;
			fixed (int* ptr = &actualLineCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (LineMetrics[] array = lineMetrics)
				{
					void* ptr3;
					if (lineMetrics == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, maxLineCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
				}
			}
			return result;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000FAD4 File Offset: 0x0000DCD4
		internal unsafe void GetMetrics(out TextMetrics textMetrics)
		{
			textMetrics = default(TextMetrics);
			Result result;
			fixed (TextMetrics* ptr = &textMetrics)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		internal unsafe void GetOverhangMetrics(out OverhangMetrics overhangs)
		{
			overhangs = default(OverhangMetrics);
			Result result;
			fixed (OverhangMetrics* ptr = &overhangs)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0000FB64 File Offset: 0x0000DD64
		internal unsafe Result GetClusterMetrics(ClusterMetrics[] clusterMetrics, int maxClusterCount, out int actualClusterCount)
		{
			Result result;
			fixed (int* ptr = &actualClusterCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (ClusterMetrics[] array = clusterMetrics)
				{
					void* ptr3;
					if (clusterMetrics == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, maxClusterCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*)));
				}
			}
			return result;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000FBBC File Offset: 0x0000DDBC
		public unsafe float DetermineMinWidth()
		{
			float result;
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000FBF8 File Offset: 0x0000DDF8
		public unsafe HitTestMetrics HitTestPoint(float pointX, float pointY, out RawBool isTrailingHit, out RawBool isInside)
		{
			isTrailingHit = default(RawBool);
			isInside = default(RawBool);
			HitTestMetrics result2;
			Result result;
			fixed (RawBool* ptr = &isInside)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &isTrailingHit)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,System.Void*,System.Void*), this._nativePointer, pointX, pointY, ptr4, ptr2, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000FC60 File Offset: 0x0000DE60
		public unsafe HitTestMetrics HitTestTextPosition(int textPosition, RawBool isTrailingHit, out float ointXRef, out float ointYRef)
		{
			HitTestMetrics result2;
			Result result;
			fixed (float* ptr = &ointYRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &ointXRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Void*), this._nativePointer, textPosition, isTrailingHit, ptr4, ptr2, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000FCB8 File Offset: 0x0000DEB8
		internal unsafe Result HitTestTextRange(int textPosition, int textLength, float originX, float originY, HitTestMetrics[] hitTestMetrics, int maxHitTestMetricsCount, out int actualHitTestMetricsCount)
		{
			Result result;
			fixed (int* ptr = &actualHitTestMetricsCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (HitTestMetrics[] array = hitTestMetrics)
				{
					void* ptr3;
					if (hitTestMetrics == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Single,System.Single,System.Void*,System.Int32,System.Void*), this._nativePointer, textPosition, textLength, originX, originY, ptr3, maxHitTestMetricsCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*)));
				}
			}
			return result;
		}
	}
}
