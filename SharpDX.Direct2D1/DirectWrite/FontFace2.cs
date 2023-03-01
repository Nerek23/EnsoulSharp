using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012F RID: 303
	[Guid("d8b768ff-64bc-4e66-982b-ec8e87f693f7")]
	public class FontFace2 : FontFace1
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x0001170B File Offset: 0x0000F90B
		public FontFace2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00011714 File Offset: 0x0000F914
		public new static explicit operator FontFace2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFace2(nativePtr);
			}
			return null;
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0001172B File Offset: 0x0000F92B
		public RawBool IsColorFont
		{
			get
			{
				return this.IsColorFont_();
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x00011733 File Offset: 0x0000F933
		public int ColorPaletteCount
		{
			get
			{
				return this.GetColorPaletteCount();
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0001173B File Offset: 0x0000F93B
		public int PaletteEntryCount
		{
			get
			{
				return this.GetPaletteEntryCount();
			}
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00011743 File Offset: 0x0000F943
		internal unsafe RawBool IsColorFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00011763 File Offset: 0x0000F963
		internal unsafe int GetColorPaletteCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00011783 File Offset: 0x0000F983
		internal unsafe int GetPaletteEntryCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x000117A4 File Offset: 0x0000F9A4
		public unsafe void GetPaletteEntries(int colorPaletteIndex, int firstEntryIndex, int entryCount, RawColor4[] aletteEntriesRef)
		{
			Result result;
			fixed (RawColor4[] array = aletteEntriesRef)
			{
				void* ptr;
				if (aletteEntriesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, colorPaletteIndex, firstEntryIndex, entryCount, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x000117FC File Offset: 0x0000F9FC
		public unsafe void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, RawMatrix3x2? transform, RawBool isSideways, OutlineThreshold outlineThreshold, MeasuringMode measuringMode, RenderingParams renderingParams, out RenderingMode renderingMode, out GridFitMode gridFitMode)
		{
			IntPtr value = IntPtr.Zero;
			RawMatrix3x2 value2;
			if (transform != null)
			{
				value2 = transform.Value;
			}
			value = CppObject.ToCallbackPtr<RenderingParams>(renderingParams);
			Result result;
			fixed (GridFitMode* ptr = &gridFitMode)
			{
				void* ptr2 = (void*)ptr;
				fixed (RenderingMode* ptr3 = &renderingMode)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, fontEmSize, dpiX, dpiY, (transform == null) ? null : (&value2), isSideways, outlineThreshold, measuringMode, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
