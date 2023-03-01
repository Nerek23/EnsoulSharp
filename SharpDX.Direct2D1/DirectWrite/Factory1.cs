using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000087 RID: 135
	[Guid("30572f99-dac6-41db-a16e-0486307e606a")]
	public class Factory1 : Factory
	{
		// Token: 0x060002AD RID: 685 RVA: 0x0000ADCF File Offset: 0x00008FCF
		public Factory1() : this(FactoryType.Shared)
		{
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000ADD8 File Offset: 0x00008FD8
		public Factory1(FactoryType factoryType) : base(IntPtr.Zero)
		{
			DWrite.CreateFactory(factoryType, Utilities.GetGuidFromType(typeof(Factory1)), this);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000ADFB File Offset: 0x00008FFB
		public Factory1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000AE04 File Offset: 0x00009004
		public new static explicit operator Factory1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory1(nativePtr);
			}
			return null;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000AE1C File Offset: 0x0000901C
		public unsafe void GetEudcFontCollection(out FontCollection fontCollection, RawBool checkForUpdates)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, &zero, checkForUpdates, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060002B2 RID: 690 RVA: 0x0000AE78 File Offset: 0x00009078
		public unsafe void CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, PixelGeometry pixelGeometry, RenderingMode renderingMode, out RenderingParams1 renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Void*), this._nativePointer, gamma, enhancedContrast, enhancedContrastGrayscale, clearTypeLevel, pixelGeometry, renderingMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				renderingParams = new RenderingParams1(zero);
			}
			else
			{
				renderingParams = null;
			}
			result.CheckError();
		}
	}
}
