using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000145 RID: 325
	[Guid("553A9FF3-5693-4DF7-B52B-74806F7F2EB9")]
	public class TextAnalyzer2 : TextAnalyzer1
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x00013C8D File Offset: 0x00011E8D
		public TextAnalyzer2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00013C96 File Offset: 0x00011E96
		public new static explicit operator TextAnalyzer2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextAnalyzer2(nativePtr);
			}
			return null;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00013CB0 File Offset: 0x00011EB0
		public unsafe void GetGlyphOrientationTransform(GlyphOrientationAngle glyphOrientationAngle, RawBool isSideways, float originX, float originY, out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			Result result;
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Single,System.Single,System.Void*), this._nativePointer, glyphOrientationAngle, isSideways, originX, originY, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00013D00 File Offset: 0x00011F00
		public unsafe void GetTypographicFeatures(FontFace fontFace, ScriptAnalysis scriptAnalysis, string localeName, int maxTagCount, out int actualTagCount, FontFeatureTag[] tags)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (FontFeatureTag[] array = tags)
			{
				void* ptr;
				if (tags == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int* ptr2 = &actualTagCount)
				{
					void* ptr3 = (void*)ptr2;
					fixed (string text = localeName)
					{
						char* ptr4 = text;
						if (ptr4 != null)
						{
							ptr4 += RuntimeHelpers.OffsetToStringData / 2;
						}
						result = calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.ScriptAnalysis,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, scriptAnalysis, ptr4, maxTagCount, ptr3, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00013D94 File Offset: 0x00011F94
		public unsafe void CheckTypographicFeature(FontFace fontFace, ScriptAnalysis scriptAnalysis, string localeName, FontFeatureTag featureTag, int glyphCount, short[] glyphIndices, byte[] featureApplies)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (byte[] array = featureApplies)
			{
				void* ptr;
				if (featureApplies == null || array.Length == 0)
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
					fixed (string text = localeName)
					{
						char* ptr3 = text;
						if (ptr3 != null)
						{
							ptr3 += RuntimeHelpers.OffsetToStringData / 2;
						}
						result = calli(System.Int32(System.Void*,System.Void*,SharpDX.DirectWrite.ScriptAnalysis,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, scriptAnalysis, ptr3, featureTag, glyphCount, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}
	}
}
