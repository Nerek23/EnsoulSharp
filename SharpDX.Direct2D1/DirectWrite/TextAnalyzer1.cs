using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000144 RID: 324
	[Guid("80DAD800-E21F-4E83-96CE-BFCCE500DB7C")]
	public class TextAnalyzer1 : TextAnalyzer
	{
		// Token: 0x06000603 RID: 1539 RVA: 0x000135DB File Offset: 0x000117DB
		public TextAnalyzer1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x000135E4 File Offset: 0x000117E4
		public new static explicit operator TextAnalyzer1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextAnalyzer1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000135FC File Offset: 0x000117FC
		public unsafe void ApplyCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, int textLength, int glyphCount, short[] clusterMap, float[] glyphAdvances, GlyphOffset[] glyphOffsets, ShapingGlyphProperties[] glyphProperties, float[] modifiedGlyphAdvances, GlyphOffset[] modifiedGlyphOffsets)
		{
			Result result;
			fixed (GlyphOffset[] array = modifiedGlyphOffsets)
			{
				void* ptr;
				if (modifiedGlyphOffsets == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (float[] array2 = modifiedGlyphAdvances)
				{
					void* ptr2;
					if (modifiedGlyphAdvances == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (ShapingGlyphProperties[] array3 = glyphProperties)
					{
						void* ptr3;
						if (glyphProperties == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (GlyphOffset[] array4 = glyphOffsets)
						{
							void* ptr4;
							if (glyphOffsets == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							fixed (float[] array5 = glyphAdvances)
							{
								void* ptr5;
								if (glyphAdvances == null || array5.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array5[0]);
								}
								fixed (short[] array6 = clusterMap)
								{
									void* ptr6;
									if (clusterMap == null || array6.Length == 0)
									{
										ptr6 = null;
									}
									else
									{
										ptr6 = (void*)(&array6[0]);
									}
									result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, leadingSpacing, trailingSpacing, minimumAdvanceWidth, textLength, glyphCount, ptr6, ptr5, ptr4, ptr3, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
								}
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00013704 File Offset: 0x00011904
		public unsafe void GetBaseline(FontFace fontFace, Baseline baseline, RawBool isVertical, RawBool isSimulationAllowed, ScriptAnalysis scriptAnalysis, string localeName, out int baselineCoordinate, out RawBool exists)
		{
			IntPtr value = IntPtr.Zero;
			exists = default(RawBool);
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &baselineCoordinate)
				{
					void* ptr4 = (void*)ptr3;
					fixed (string text = localeName)
					{
						char* ptr5 = text;
						if (ptr5 != null)
						{
							ptr5 += RuntimeHelpers.OffsetToStringData / 2;
						}
						result = calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,SharpDX.DirectWrite.ScriptAnalysis,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, baseline, isVertical, isSimulationAllowed, scriptAnalysis, ptr5, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00013794 File Offset: 0x00011994
		public unsafe void AnalyzeVerticalGlyphOrientation(TextAnalysisSource1 analysisSource, int textPosition, int textLength, TextAnalysisSink1 analysisSink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource1>(analysisSource);
			value2 = CppObject.ToCallbackPtr<TextAnalysisSink1>(analysisSink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000137F8 File Offset: 0x000119F8
		public unsafe void GetGlyphOrientationTransform(GlyphOrientationAngle glyphOrientationAngle, RawBool isSideways, out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			Result result;
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, glyphOrientationAngle, isSideways, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00013844 File Offset: 0x00011A44
		public unsafe void GetScriptProperties(ScriptAnalysis scriptAnalysis, out ScriptProperties scriptProperties)
		{
			scriptProperties = default(ScriptProperties);
			Result result;
			fixed (ScriptProperties* ptr = &scriptProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,SharpDX.DirectWrite.ScriptAnalysis,System.Void*), this._nativePointer, scriptAnalysis, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00013890 File Offset: 0x00011A90
		public unsafe void GetTextComplexity(string textString, int textLength, FontFace fontFace, out RawBool isTextSimple, int textLengthRead, short[] glyphIndices)
		{
			IntPtr value = IntPtr.Zero;
			isTextSimple = default(RawBool);
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
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
				fixed (RawBool* ptr2 = &isTextSimple)
				{
					void* ptr3 = (void*)ptr2;
					fixed (string text = textString)
					{
						char* ptr4 = text;
						if (ptr4 != null)
						{
							ptr4 += RuntimeHelpers.OffsetToStringData / 2;
						}
						result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, textLength, (void*)value, ptr3, &textLengthRead, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00013930 File Offset: 0x00011B30
		public unsafe void GetJustificationOpportunities(FontFace fontFace, float fontEmSize, ScriptAnalysis scriptAnalysis, int textLength, int glyphCount, string textString, short[] clusterMap, ShapingGlyphProperties[] glyphProperties, JustificationOpportunity[] justificationOpportunities)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (JustificationOpportunity[] array = justificationOpportunities)
			{
				void* ptr;
				if (justificationOpportunities == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (ShapingGlyphProperties[] array2 = glyphProperties)
				{
					void* ptr2;
					if (glyphProperties == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (short[] array3 = clusterMap)
					{
						void* ptr3;
						if (clusterMap == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (string text = textString)
						{
							char* ptr4 = text;
							if (ptr4 != null)
							{
								ptr4 += RuntimeHelpers.OffsetToStringData / 2;
							}
							result = calli(System.Int32(System.Void*,System.Void*,System.Single,SharpDX.DirectWrite.ScriptAnalysis,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, fontEmSize, scriptAnalysis, textLength, glyphCount, ptr4, ptr3, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00013A00 File Offset: 0x00011C00
		public unsafe void JustifyGlyphAdvances(float lineWidth, int glyphCount, JustificationOpportunity[] justificationOpportunities, float[] glyphAdvances, GlyphOffset[] glyphOffsets, float[] justifiedGlyphAdvances, GlyphOffset[] justifiedGlyphOffsets)
		{
			Result result;
			fixed (GlyphOffset[] array = justifiedGlyphOffsets)
			{
				void* ptr;
				if (justifiedGlyphOffsets == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (float[] array2 = justifiedGlyphAdvances)
				{
					void* ptr2;
					if (justifiedGlyphAdvances == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (GlyphOffset[] array3 = glyphOffsets)
					{
						void* ptr3;
						if (glyphOffsets == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (float[] array4 = glyphAdvances)
						{
							void* ptr4;
							if (glyphAdvances == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							fixed (JustificationOpportunity[] array5 = justificationOpportunities)
							{
								void* ptr5;
								if (justificationOpportunities == null || array5.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array5[0]);
								}
								result = calli(System.Int32(System.Void*,System.Single,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, lineWidth, glyphCount, ptr5, ptr4, ptr3, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00013AE0 File Offset: 0x00011CE0
		public unsafe void GetJustifiedGlyphs(FontFace fontFace, float fontEmSize, ScriptAnalysis scriptAnalysis, int textLength, int glyphCount, int maxGlyphCount, short[] clusterMap, short[] glyphIndices, float[] glyphAdvances, float[] justifiedGlyphAdvances, GlyphOffset[] justifiedGlyphOffsets, ShapingGlyphProperties[] glyphProperties, int actualGlyphCount, short[] modifiedClusterMap, short[] modifiedGlyphIndices, float[] modifiedGlyphAdvances, GlyphOffset[] modifiedGlyphOffsets)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (GlyphOffset[] array = modifiedGlyphOffsets)
			{
				void* ptr;
				if (modifiedGlyphOffsets == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (float[] array2 = modifiedGlyphAdvances)
				{
					void* ptr2;
					if (modifiedGlyphAdvances == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (short[] array3 = modifiedGlyphIndices)
					{
						void* ptr3;
						if (modifiedGlyphIndices == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (short[] array4 = modifiedClusterMap)
						{
							void* ptr4;
							if (modifiedClusterMap == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							fixed (ShapingGlyphProperties[] array5 = glyphProperties)
							{
								void* ptr5;
								if (glyphProperties == null || array5.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array5[0]);
								}
								fixed (GlyphOffset[] array6 = justifiedGlyphOffsets)
								{
									void* ptr6;
									if (justifiedGlyphOffsets == null || array6.Length == 0)
									{
										ptr6 = null;
									}
									else
									{
										ptr6 = (void*)(&array6[0]);
									}
									fixed (float[] array7 = justifiedGlyphAdvances)
									{
										void* ptr7;
										if (justifiedGlyphAdvances == null || array7.Length == 0)
										{
											ptr7 = null;
										}
										else
										{
											ptr7 = (void*)(&array7[0]);
										}
										fixed (float[] array8 = glyphAdvances)
										{
											void* ptr8;
											if (glyphAdvances == null || array8.Length == 0)
											{
												ptr8 = null;
											}
											else
											{
												ptr8 = (void*)(&array8[0]);
											}
											fixed (short[] array9 = glyphIndices)
											{
												void* ptr9;
												if (glyphIndices == null || array9.Length == 0)
												{
													ptr9 = null;
												}
												else
												{
													ptr9 = (void*)(&array9[0]);
												}
												fixed (short[] array10 = clusterMap)
												{
													void* ptr10;
													if (clusterMap == null || array10.Length == 0)
													{
														ptr10 = null;
													}
													else
													{
														ptr10 = (void*)(&array10[0]);
													}
													result = calli(System.Int32(System.Void*,System.Void*,System.Single,SharpDX.DirectWrite.ScriptAnalysis,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, fontEmSize, scriptAnalysis, textLength, glyphCount, maxGlyphCount, ptr10, ptr9, ptr8, ptr7, ptr6, ptr5, &actualGlyphCount, ptr4, ptr3, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
												}
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
