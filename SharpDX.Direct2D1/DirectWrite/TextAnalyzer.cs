using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000D9 RID: 217
	[Guid("b7e6163e-7f46-43b4-84b3-e4e6249c365d")]
	public class TextAnalyzer : ComObject
	{
		// Token: 0x0600043A RID: 1082 RVA: 0x0000DE00 File Offset: 0x0000C000
		public TextAnalyzer(Factory factory)
		{
			factory.CreateTextAnalyzer(this);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000DE10 File Offset: 0x0000C010
		public void GetGlyphs(string textString, int textLength, FontFace fontFace, bool isSideways, bool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, NumberSubstitution numberSubstitution, FontFeature[][] features, int[] featureRangeLengths, int maxGlyphCount, short[] clusterMap, ShapingTextProperties[] textProps, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, out int actualGlyphCount)
		{
			IntPtr intPtr = TextAnalyzer.AllocateFeatures(features);
			try
			{
				this.GetGlyphs(textString, textLength, fontFace, isSideways, isRightToLeft, scriptAnalysis, localeName, numberSubstitution, intPtr, featureRangeLengths, (featureRangeLengths == null) ? 0 : featureRangeLengths.Length, maxGlyphCount, clusterMap, textProps, glyphIndices, glyphProps, out actualGlyphCount);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000DE84 File Offset: 0x0000C084
		public void GetGlyphPlacements(string textString, short[] clusterMap, ShapingTextProperties[] textProps, int textLength, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, int glyphCount, FontFace fontFace, float fontEmSize, bool isSideways, bool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, FontFeature[][] features, int[] featureRangeLengths, float[] glyphAdvances, GlyphOffset[] glyphOffsets)
		{
			IntPtr intPtr = TextAnalyzer.AllocateFeatures(features);
			try
			{
				this.GetGlyphPlacements(textString, clusterMap, textProps, textLength, glyphIndices, glyphProps, glyphCount, fontFace, fontEmSize, isSideways, isRightToLeft, scriptAnalysis, localeName, intPtr, featureRangeLengths, (featureRangeLengths == null) ? 0 : featureRangeLengths.Length, glyphAdvances, glyphOffsets);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		public void GetGdiCompatibleGlyphPlacements(string textString, short[] clusterMap, ShapingTextProperties[] textProps, int textLength, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, int glyphCount, FontFace fontFace, float fontEmSize, float pixelsPerDip, RawMatrix3x2? transform, bool useGdiNatural, bool isSideways, bool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, FontFeature[][] features, int[] featureRangeLengths, float[] glyphAdvances, GlyphOffset[] glyphOffsets)
		{
			IntPtr intPtr = TextAnalyzer.AllocateFeatures(features);
			try
			{
				this.GetGdiCompatibleGlyphPlacements(textString, clusterMap, textProps, textLength, glyphIndices, glyphProps, glyphCount, fontFace, fontEmSize, pixelsPerDip, transform, useGdiNatural, isSideways, isRightToLeft, scriptAnalysis, localeName, intPtr, featureRangeLengths, (featureRangeLengths == null) ? 0 : featureRangeLengths.Length, glyphAdvances, glyphOffsets);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000DF78 File Offset: 0x0000C178
		private unsafe static IntPtr AllocateFeatures(FontFeature[][] features)
		{
			byte* ptr = null;
			if (features != null && features.Length != 0)
			{
				int num = sizeof(IntPtr) * features.Length;
				int num2 = num + sizeof(TypographicFeatures) * features.Length;
				foreach (FontFeature[] array in features)
				{
					if (array == null)
					{
						throw new ArgumentNullException("features", "FontFeature[] inside features array cannot be null.");
					}
					num2 += sizeof(FontFeature) * array.Length;
				}
				ptr = (byte*)((void*)Marshal.AllocHGlobal(num2));
				TypographicFeatures* ptr2 = (TypographicFeatures*)(ptr + num);
				FontFeature* ptr3 = (FontFeature*)(ptr2 + features.Length);
				for (int j = 0; j < features.Length; j++)
				{
					*(IntPtr*)(ptr + (IntPtr)j * (IntPtr)sizeof(void*)) = ptr2;
					FontFeature[] array2 = features[j];
					ptr2->Features = (IntPtr)((void*)ptr3);
					ptr2->FeatureCount = array2.Length;
					ptr2++;
					for (int k = 0; k < array2.Length; k++)
					{
						*ptr3 = array2[k];
						ptr3++;
					}
				}
			}
			return (IntPtr)((void*)ptr);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00002A7F File Offset: 0x00000C7F
		public TextAnalyzer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000E085 File Offset: 0x0000C285
		public new static explicit operator TextAnalyzer(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextAnalyzer(nativePtr);
			}
			return null;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0000E09C File Offset: 0x0000C29C
		public unsafe void AnalyzeScript(TextAnalysisSource analysisSource, int textPosition, int textLength, TextAnalysisSink analysisSink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource>(analysisSource);
			value2 = CppObject.ToCallbackPtr<TextAnalysisSink>(analysisSink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000E0FC File Offset: 0x0000C2FC
		public unsafe void AnalyzeBidi(TextAnalysisSource analysisSource, int textPosition, int textLength, TextAnalysisSink analysisSink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource>(analysisSource);
			value2 = CppObject.ToCallbackPtr<TextAnalysisSink>(analysisSink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000E15C File Offset: 0x0000C35C
		public unsafe void AnalyzeNumberSubstitution(TextAnalysisSource analysisSource, int textPosition, int textLength, TextAnalysisSink analysisSink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource>(analysisSource);
			value2 = CppObject.ToCallbackPtr<TextAnalysisSink>(analysisSink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000E1BC File Offset: 0x0000C3BC
		public unsafe void AnalyzeLineBreakpoints(TextAnalysisSource analysisSource, int textPosition, int textLength, TextAnalysisSink analysisSink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource>(analysisSource);
			value2 = CppObject.ToCallbackPtr<TextAnalysisSink>(analysisSink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000E21C File Offset: 0x0000C41C
		internal unsafe void GetGlyphs(string textString, int textLength, FontFace fontFace, RawBool isSideways, RawBool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, NumberSubstitution numberSubstitution, IntPtr features, int[] featureRangeLengths, int featureRanges, int maxGlyphCount, short[] clusterMap, ShapingTextProperties[] textProps, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, out int actualGlyphCount)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			value2 = CppObject.ToCallbackPtr<NumberSubstitution>(numberSubstitution);
			Result result;
			fixed (int* ptr = &actualGlyphCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (ShapingGlyphProperties[] array = glyphProps)
				{
					void* ptr3;
					if (glyphProps == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					fixed (short[] array2 = glyphIndices)
					{
						void* ptr4;
						if (glyphIndices == null || array2.Length == 0)
						{
							ptr4 = null;
						}
						else
						{
							ptr4 = (void*)(&array2[0]);
						}
						fixed (ShapingTextProperties[] array3 = textProps)
						{
							void* ptr5;
							if (textProps == null || array3.Length == 0)
							{
								ptr5 = null;
							}
							else
							{
								ptr5 = (void*)(&array3[0]);
							}
							fixed (short[] array4 = clusterMap)
							{
								void* ptr6;
								if (clusterMap == null || array4.Length == 0)
								{
									ptr6 = null;
								}
								else
								{
									ptr6 = (void*)(&array4[0]);
								}
								fixed (int[] array5 = featureRangeLengths)
								{
									void* ptr7;
									if (featureRangeLengths == null || array5.Length == 0)
									{
										ptr7 = null;
									}
									else
									{
										ptr7 = (void*)(&array5[0]);
									}
									fixed (string text = localeName)
									{
										char* ptr8 = text;
										if (ptr8 != null)
										{
											ptr8 += RuntimeHelpers.OffsetToStringData / 2;
										}
										fixed (string text2 = textString)
										{
											char* ptr9 = text2;
											if (ptr9 != null)
											{
												ptr9 += RuntimeHelpers.OffsetToStringData / 2;
											}
											result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr9, textLength, (void*)value, isSideways, isRightToLeft, &scriptAnalysis, ptr8, (void*)value2, (void*)features, ptr7, featureRanges, maxGlyphCount, ptr6, ptr5, ptr4, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
										}
									}
								}
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000E380 File Offset: 0x0000C580
		internal unsafe void GetGlyphPlacements(string textString, short[] clusterMap, ShapingTextProperties[] textProps, int textLength, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, int glyphCount, FontFace fontFace, float fontEmSize, RawBool isSideways, RawBool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, IntPtr features, int[] featureRangeLengths, int featureRanges, float[] glyphAdvances, GlyphOffset[] glyphOffsets)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
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
					fixed (int[] array3 = featureRangeLengths)
					{
						void* ptr3;
						if (featureRangeLengths == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (string text = localeName)
						{
							char* ptr4 = text;
							if (ptr4 != null)
							{
								ptr4 += RuntimeHelpers.OffsetToStringData / 2;
							}
							fixed (ShapingGlyphProperties[] array4 = glyphProps)
							{
								void* ptr5;
								if (glyphProps == null || array4.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array4[0]);
								}
								fixed (short[] array5 = glyphIndices)
								{
									void* ptr6;
									if (glyphIndices == null || array5.Length == 0)
									{
										ptr6 = null;
									}
									else
									{
										ptr6 = (void*)(&array5[0]);
									}
									fixed (ShapingTextProperties[] array6 = textProps)
									{
										void* ptr7;
										if (textProps == null || array6.Length == 0)
										{
											ptr7 = null;
										}
										else
										{
											ptr7 = (void*)(&array6[0]);
										}
										fixed (short[] array7 = clusterMap)
										{
											void* ptr8;
											if (clusterMap == null || array7.Length == 0)
											{
												ptr8 = null;
											}
											else
											{
												ptr8 = (void*)(&array7[0]);
											}
											fixed (string text2 = textString)
											{
												char* ptr9 = text2;
												if (ptr9 != null)
												{
													ptr9 += RuntimeHelpers.OffsetToStringData / 2;
												}
												result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*,System.Single,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr9, ptr8, ptr7, textLength, ptr6, ptr5, glyphCount, (void*)value, fontEmSize, isSideways, isRightToLeft, &scriptAnalysis, ptr4, (void*)features, ptr3, featureRanges, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
											}
										}
									}
								}
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000E504 File Offset: 0x0000C704
		internal unsafe void GetGdiCompatibleGlyphPlacements(string textString, short[] clusterMap, ShapingTextProperties[] textProps, int textLength, short[] glyphIndices, ShapingGlyphProperties[] glyphProps, int glyphCount, FontFace fontFace, float fontEmSize, float pixelsPerDip, RawMatrix3x2? transform, RawBool useGdiNatural, RawBool isSideways, RawBool isRightToLeft, ScriptAnalysis scriptAnalysis, string localeName, IntPtr features, int[] featureRangeLengths, int featureRanges, float[] glyphAdvances, GlyphOffset[] glyphOffsets)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			RawMatrix3x2 value2;
			if (transform != null)
			{
				value2 = transform.Value;
			}
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
					fixed (int[] array3 = featureRangeLengths)
					{
						void* ptr3;
						if (featureRangeLengths == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (string text = localeName)
						{
							char* ptr4 = text;
							if (ptr4 != null)
							{
								ptr4 += RuntimeHelpers.OffsetToStringData / 2;
							}
							fixed (ShapingGlyphProperties[] array4 = glyphProps)
							{
								void* ptr5;
								if (glyphProps == null || array4.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array4[0]);
								}
								fixed (short[] array5 = glyphIndices)
								{
									void* ptr6;
									if (glyphIndices == null || array5.Length == 0)
									{
										ptr6 = null;
									}
									else
									{
										ptr6 = (void*)(&array5[0]);
									}
									fixed (ShapingTextProperties[] array6 = textProps)
									{
										void* ptr7;
										if (textProps == null || array6.Length == 0)
										{
											ptr7 = null;
										}
										else
										{
											ptr7 = (void*)(&array6[0]);
										}
										fixed (short[] array7 = clusterMap)
										{
											void* ptr8;
											if (clusterMap == null || array7.Length == 0)
											{
												ptr8 = null;
											}
											else
											{
												ptr8 = (void*)(&array7[0]);
											}
											fixed (string text2 = textString)
											{
												char* ptr9 = text2;
												if (ptr9 != null)
												{
													ptr9 += RuntimeHelpers.OffsetToStringData / 2;
												}
												result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr9, ptr8, ptr7, textLength, ptr6, ptr5, glyphCount, (void*)value, fontEmSize, pixelsPerDip, (transform == null) ? null : (&value2), useGdiNatural, isSideways, isRightToLeft, &scriptAnalysis, ptr4, (void*)features, ptr3, featureRanges, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
											}
										}
									}
								}
							}
						}
					}
				}
			}
			result.CheckError();
		}
	}
}
