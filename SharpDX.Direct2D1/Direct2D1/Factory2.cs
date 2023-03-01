using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E3 RID: 483
	[Guid("94f81a73-9212-4376-9c58-b16a3a0d3992")]
	public class Factory2 : Factory1
	{
		// Token: 0x060009FB RID: 2555 RVA: 0x0001D5B7 File Offset: 0x0001B7B7
		public Factory2()
		{
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0001D5BF File Offset: 0x0001B7BF
		public Factory2(FactoryType factoryType) : base(factoryType)
		{
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0001D5C8 File Offset: 0x0001B7C8
		public Factory2(FactoryType factoryType, DebugLevel debugLevel) : base(factoryType, debugLevel)
		{
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0001D5D2 File Offset: 0x0001B7D2
		public Factory2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0001D5DB File Offset: 0x0001B7DB
		public new static explicit operator Factory2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory2(nativePtr);
			}
			return null;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0001D5F4 File Offset: 0x0001B7F4
		internal unsafe void CreateDevice(Device dxgiDevice, Device1 d2dDevice1)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			d2dDevice1.NativePointer = zero;
			result.CheckError();
		}
	}
}
