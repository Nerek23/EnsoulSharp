using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000056 RID: 86
	[Guid("29038f61-3839-4626-91fd-086879011a05")]
	public class Adapter1 : Adapter
	{
		// Token: 0x06000151 RID: 337 RVA: 0x00005F09 File Offset: 0x00004109
		public Adapter1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005F12 File Offset: 0x00004112
		public new static explicit operator Adapter1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Adapter1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00005F2C File Offset: 0x0000412C
		public AdapterDescription1 Description1
		{
			get
			{
				AdapterDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005F44 File Offset: 0x00004144
		internal unsafe void GetDescription1(out AdapterDescription1 descRef)
		{
			AdapterDescription1.__Native _Native = default(AdapterDescription1.__Native);
			descRef = default(AdapterDescription1);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}
	}
}
