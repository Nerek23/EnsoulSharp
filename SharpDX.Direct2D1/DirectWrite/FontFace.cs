using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200008E RID: 142
	[Guid("5f49804d-7024-4d43-bfa9-d25984f53849")]
	public class FontFace : ComObject
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x0000B438 File Offset: 0x00009638
		public FontFace(Factory factory, FontFaceType fontFaceType, FontFile[] fontFiles, int faceIndex, FontSimulations fontFaceSimulationFlags)
		{
			factory.CreateFontFace(fontFaceType, fontFiles.Length, fontFiles, faceIndex, fontFaceSimulationFlags, this);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B450 File Offset: 0x00009650
		public FontFace(Font font)
		{
			font.CreateFontFace(this);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B460 File Offset: 0x00009660
		public GlyphMetrics[] GetDesignGlyphMetrics(short[] glyphIndices, bool isSideways)
		{
			GlyphMetrics[] array = new GlyphMetrics[glyphIndices.Length];
			this.GetDesignGlyphMetrics(glyphIndices, glyphIndices.Length, array, isSideways);
			return array;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B488 File Offset: 0x00009688
		public GlyphMetrics[] GetGdiCompatibleGlyphMetrics(float fontSize, float pixelsPerDip, RawMatrix3x2? transform, bool useGdiNatural, short[] glyphIndices, bool isSideways)
		{
			GlyphMetrics[] array = new GlyphMetrics[glyphIndices.Length];
			this.GetGdiCompatibleGlyphMetrics(fontSize, pixelsPerDip, transform, useGdiNatural, glyphIndices, glyphIndices.Length, array, isSideways);
			return array;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000B4C0 File Offset: 0x000096C0
		public short[] GetGlyphIndices(int[] codePoints)
		{
			short[] array = new short[codePoints.Length];
			this.GetGlyphIndices(codePoints, codePoints.Length, array);
			return array;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B4E4 File Offset: 0x000096E4
		public FontFile[] GetFiles()
		{
			int num = 0;
			this.GetFiles(ref num, null);
			FontFile[] array = new FontFile[num];
			this.GetFiles(ref num, array);
			return array;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000B510 File Offset: 0x00009710
		public unsafe bool TryGetFontTable(int openTypeTableTag, out DataPointer tableData, out IntPtr tableContext)
		{
			tableData = DataPointer.Zero;
			IntPtr zero = IntPtr.Zero;
			int size;
			RawBool booleanValue;
			this.TryGetFontTable(openTypeTableTag, new IntPtr((void*)(&zero)), out size, out tableContext, out booleanValue);
			if (zero != IntPtr.Zero)
			{
				tableData = new DataPointer(zero, size);
			}
			return booleanValue;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFace(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000B562 File Offset: 0x00009762
		public new static explicit operator FontFace(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFace(nativePtr);
			}
			return null;
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000B579 File Offset: 0x00009779
		public FontFaceType FaceType
		{
			get
			{
				return this.GetFaceType();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002DB RID: 731 RVA: 0x0000B581 File Offset: 0x00009781
		public int Index
		{
			get
			{
				return this.GetIndex();
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000B589 File Offset: 0x00009789
		public FontSimulations Simulations
		{
			get
			{
				return this.GetSimulations();
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002DD RID: 733 RVA: 0x0000B591 File Offset: 0x00009791
		public RawBool IsSymbolFont
		{
			get
			{
				return this.IsSymbolFont_();
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000B59C File Offset: 0x0000979C
		public FontMetrics Metrics
		{
			get
			{
				FontMetrics result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000B5B2 File Offset: 0x000097B2
		public short GlyphCount
		{
			get
			{
				return this.GetGlyphCount();
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000B5BA File Offset: 0x000097BA
		internal unsafe FontFaceType GetFaceType()
		{
			return calli(SharpDX.DirectWrite.FontFaceType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000B5DC File Offset: 0x000097DC
		internal unsafe void GetFiles(ref int numberOfFiles, FontFile[] fontFiles)
		{
			IntPtr* ptr = null;
			if (fontFiles != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)fontFiles.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			Result result;
			fixed (int* ptr2 = &numberOfFiles)
			{
				void* ptr3 = (void*)ptr2;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			if (fontFiles != null)
			{
				for (int i = 0; i < fontFiles.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						fontFiles[i] = new FontFile(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						fontFiles[i] = null;
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000B67C File Offset: 0x0000987C
		internal unsafe int GetIndex()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000B69B File Offset: 0x0000989B
		internal unsafe FontSimulations GetSimulations()
		{
			return calli(SharpDX.DirectWrite.FontSimulations(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000B6BA File Offset: 0x000098BA
		internal unsafe RawBool IsSymbolFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000B6DC File Offset: 0x000098DC
		internal unsafe void GetMetrics(out FontMetrics fontFaceMetrics)
		{
			fontFaceMetrics = default(FontMetrics);
			fixed (FontMetrics* ptr = &fontFaceMetrics)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000B716 File Offset: 0x00009916
		internal unsafe short GetGlyphCount()
		{
			return calli(System.Int16(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000B738 File Offset: 0x00009938
		internal unsafe void GetDesignGlyphMetrics(short[] glyphIndices, int glyphCount, GlyphMetrics[] glyphMetrics, RawBool isSideways)
		{
			Result result;
			fixed (GlyphMetrics[] array = glyphMetrics)
			{
				void* ptr;
				if (glyphMetrics == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = glyphIndices)
				{
					void* ptr2;
					if (glyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, ptr2, glyphCount, ptr, isSideways, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000B7B0 File Offset: 0x000099B0
		internal unsafe void GetGlyphIndices(int[] codePoints, int codePointCount, short[] glyphIndices)
		{
			Result result;
			fixed (short[] array = glyphIndices)
			{
				void* ptr;
				if (glyphIndices == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = codePoints)
				{
					void* ptr2;
					if (codePoints == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr2, codePointCount, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000B824 File Offset: 0x00009A24
		internal unsafe void TryGetFontTable(int openTypeTableTag, IntPtr tableData, out int tableSize, out IntPtr tableContext, out RawBool exists)
		{
			exists = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				fixed (IntPtr* ptr3 = &tableContext)
				{
					void* ptr4 = (void*)ptr3;
					fixed (int* ptr5 = &tableSize)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, openTypeTableTag, (void*)tableData, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000B890 File Offset: 0x00009A90
		public unsafe void ReleaseFontTable(IntPtr tableContext)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)tableContext, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000B8B8 File Offset: 0x00009AB8
		public unsafe void GetGlyphRunOutline(float emSize, short[] glyphIndices, float[] glyphAdvances, GlyphOffset[] glyphOffsets, int glyphCount, RawBool isSideways, RawBool isRightToLeft, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			Result result;
			fixed (GlyphOffset[] array = glyphOffsets)
			{
				void* ptr;
				if (glyphOffsets == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (float[] array2 = glyphAdvances)
				{
					void* ptr2;
					if (glyphAdvances == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (short[] array3 = glyphIndices)
					{
						void* ptr3;
						if (glyphIndices == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						result = calli(System.Int32(System.Void*,System.Single,System.Void*,System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, emSize, ptr3, ptr2, ptr, glyphCount, isSideways, isRightToLeft, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000B96C File Offset: 0x00009B6C
		public unsafe RenderingMode GetRecommendedRenderingMode(float emSize, float pixelsPerDip, MeasuringMode measuringMode, RenderingParams renderingParams)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderingParams>(renderingParams);
			RenderingMode result;
			calli(System.Int32(System.Void*,System.Single,System.Single,System.Int32,System.Void*,System.Void*), this._nativePointer, emSize, pixelsPerDip, measuringMode, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		public unsafe FontMetrics GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, RawMatrix3x2? transform)
		{
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			FontMetrics result;
			calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,System.Void*), this._nativePointer, emSize, pixelsPerDip, (transform == null) ? null : (&value), &result, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000BA20 File Offset: 0x00009C20
		internal unsafe void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, RawMatrix3x2? transform, RawBool useGdiNatural, short[] glyphIndices, int glyphCount, GlyphMetrics[] glyphMetrics, RawBool isSideways)
		{
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result;
			fixed (GlyphMetrics[] array = glyphMetrics)
			{
				void* ptr;
				if (glyphMetrics == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = glyphIndices)
				{
					void* ptr2;
					if (glyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, emSize, pixelsPerDip, (transform == null) ? null : (&value), useGdiNatural, ptr2, glyphCount, ptr, isSideways, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
