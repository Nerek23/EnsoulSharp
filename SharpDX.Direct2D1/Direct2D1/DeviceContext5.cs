using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Win32;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D0 RID: 464
	[Guid("7836d248-68cc-4df6-b9e8-de991bf62eb7")]
	public class DeviceContext5 : DeviceContext4
	{
		// Token: 0x06000956 RID: 2390 RVA: 0x0001B0D8 File Offset: 0x000192D8
		public DeviceContext5(Device5 device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001B0F0 File Offset: 0x000192F0
		public SvgDocument CreateSvgDocument(IStream stream, Size2F viewportSize)
		{
			SvgDocument result;
			this.CreateSvgDocument(stream, viewportSize, out result);
			return result;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001B108 File Offset: 0x00019308
		public DeviceContext5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001B111 File Offset: 0x00019311
		public new static explicit operator DeviceContext5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext5(nativePtr);
			}
			return null;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001B128 File Offset: 0x00019328
		public unsafe void CreateSvgDocument(IStream inputXmlStream, Size2F viewportSize, out SvgDocument svgDocument)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(inputXmlStream);
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Size2F,System.Void*), this._nativePointer, (void*)value, viewportSize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)115 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				svgDocument = new SvgDocument(zero);
			}
			else
			{
				svgDocument = null;
			}
			result.CheckError();
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001B198 File Offset: 0x00019398
		public unsafe void DrawSvgDocument(SvgDocument svgDocument)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SvgDocument>(svgDocument);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)116 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001B1D8 File Offset: 0x000193D8
		public unsafe void CreateColorContextFromDxgiColorSpace(ColorSpaceType colorSpace, ColorContext1 colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, colorSpace, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)117 * (IntPtr)sizeof(void*)));
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001B224 File Offset: 0x00019424
		public unsafe void CreateColorContextFromSimpleColorProfile(ref SimpleColorProfile simpleProfile, ColorContext1 colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (SimpleColorProfile* ptr = &simpleProfile)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)118 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}
	}
}
