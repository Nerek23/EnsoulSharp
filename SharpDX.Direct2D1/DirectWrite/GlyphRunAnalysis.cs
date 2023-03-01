using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000A8 RID: 168
	[Guid("7d97dbf7-e085-42d4-81e3-6a883bded118")]
	public class GlyphRunAnalysis : ComObject
	{
		// Token: 0x0600035B RID: 859 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
		public GlyphRunAnalysis(Factory factory, GlyphRun glyphRun, float pixelsPerDip, RenderingMode renderingMode, MeasuringMode measuringMode, float baselineOriginX, float baselineOriginY) : this(factory, glyphRun, pixelsPerDip, null, renderingMode, measuringMode, baselineOriginX, baselineOriginY)
		{
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000C8D0 File Offset: 0x0000AAD0
		public GlyphRunAnalysis(Factory factory, GlyphRun glyphRun, float pixelsPerDip, RawMatrix3x2? transform, RenderingMode renderingMode, MeasuringMode measuringMode, float baselineOriginX, float baselineOriginY)
		{
			factory.CreateGlyphRunAnalysis(glyphRun, pixelsPerDip, transform, renderingMode, measuringMode, baselineOriginX, baselineOriginY, this);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00002A7F File Offset: 0x00000C7F
		public GlyphRunAnalysis(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000C8F6 File Offset: 0x0000AAF6
		public new static explicit operator GlyphRunAnalysis(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GlyphRunAnalysis(nativePtr);
			}
			return null;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000C910 File Offset: 0x0000AB10
		public unsafe RawRectangle GetAlphaTextureBounds(TextureType textureType)
		{
			RawRectangle result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, textureType, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000C94C File Offset: 0x0000AB4C
		public unsafe void CreateAlphaTexture(TextureType textureType, RawRectangle textureBounds, byte[] alphaValues, int bufferSize)
		{
			Result result;
			fixed (byte[] array = alphaValues)
			{
				void* ptr;
				if (alphaValues == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, textureType, &textureBounds, ptr, bufferSize, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000C9A4 File Offset: 0x0000ABA4
		public unsafe void GetAlphaBlendParams(RenderingParams renderingParams, out float blendGamma, out float blendEnhancedContrast, out float blendClearTypeLevel)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderingParams>(renderingParams);
			Result result;
			fixed (float* ptr = &blendClearTypeLevel)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &blendEnhancedContrast)
				{
					void* ptr4 = (void*)ptr3;
					fixed (float* ptr5 = &blendGamma)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}
	}
}
