using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200000F RID: 15
	[Guid("1bc6ea02-ef36-464f-bf0c-21ca39e5168a")]
	public class Factory4 : Factory3
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00003130 File Offset: 0x00001330
		public Factory4() : this(IntPtr.Zero)
		{
			IntPtr nativePointer;
			DXGI.CreateDXGIFactory1(Utilities.GetGuidFromType(base.GetType()), out nativePointer);
			base.NativePointer = nativePointer;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003164 File Offset: 0x00001364
		public Adapter GetWarpAdapter()
		{
			IntPtr nativePtr;
			this.EnumWarpAdapter(Utilities.GetGuidFromType(typeof(Adapter)), out nativePtr);
			return new Adapter(nativePtr);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003190 File Offset: 0x00001390
		public Adapter GetAdapterByLuid(long adapterLuid)
		{
			IntPtr nativePtr;
			this.EnumAdapterByLuid(adapterLuid, Utilities.GetGuidFromType(typeof(Adapter)), out nativePtr);
			return new Adapter(nativePtr);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000031BB File Offset: 0x000013BB
		public Factory4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000031C4 File Offset: 0x000013C4
		public new static explicit operator Factory4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory4(nativePtr);
			}
			return null;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000031DC File Offset: 0x000013DC
		private unsafe void EnumAdapterByLuid(long adapterLuid, Guid riid, out IntPtr vAdapterOut)
		{
			Result result;
			fixed (IntPtr* ptr = &vAdapterOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int64,System.Void*,System.Void*), this._nativePointer, adapterLuid, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003224 File Offset: 0x00001424
		private unsafe void EnumWarpAdapter(Guid riid, out IntPtr vAdapterOut)
		{
			Result result;
			fixed (IntPtr* ptr = &vAdapterOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
