using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000059 RID: 89
	[Guid("3c8d99d1-4fbf-4181-a82c-af66bf7bd24e")]
	public class Adapter4 : Adapter3
	{
		// Token: 0x06000161 RID: 353 RVA: 0x00006187 File Offset: 0x00004387
		public Adapter4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006190 File Offset: 0x00004390
		public new static explicit operator Adapter4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Adapter4(nativePtr);
			}
			return null;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000163 RID: 355 RVA: 0x000061A8 File Offset: 0x000043A8
		public AdapterDescription3 Desc3
		{
			get
			{
				AdapterDescription3 result;
				this.GetDesc3(out result);
				return result;
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000061C0 File Offset: 0x000043C0
		internal unsafe void GetDesc3(out AdapterDescription3 descRef)
		{
			AdapterDescription3.__Native _Native = default(AdapterDescription3.__Native);
			descRef = default(AdapterDescription3);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}
	}
}
