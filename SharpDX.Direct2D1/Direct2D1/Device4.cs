using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C9 RID: 457
	[Guid("d7bdb159-5683-4a46-bc9c-72dc720b858b")]
	public class Device4 : Device3
	{
		// Token: 0x060008E8 RID: 2280 RVA: 0x00019401 File Offset: 0x00017601
		public Device4(Factory5 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00019416 File Offset: 0x00017616
		public Device4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001941F File Offset: 0x0001761F
		public new static explicit operator Device4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device4(nativePtr);
			}
			return null;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00019436 File Offset: 0x00017636
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x0001943E File Offset: 0x0001763E
		public long MaximumColorGlyphCacheMemory
		{
			get
			{
				return this.GetMaximumColorGlyphCacheMemory();
			}
			set
			{
				this.SetMaximumColorGlyphCacheMemory(value);
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00019448 File Offset: 0x00017648
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext4 deviceContext4)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			deviceContext4.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00019491 File Offset: 0x00017691
		internal unsafe void SetMaximumColorGlyphCacheMemory(long maximumInBytes)
		{
			calli(System.Void(System.Void*,System.Int64), this._nativePointer, maximumInBytes, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x000194B2 File Offset: 0x000176B2
		internal unsafe long GetMaximumColorGlyphCacheMemory()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}
	}
}
