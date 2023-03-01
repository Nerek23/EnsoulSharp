using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000057 RID: 87
	[Guid("0AA1AE0A-FA0E-4B84-8644-E05FF8E5ACB5")]
	public class Adapter2 : Adapter1
	{
		// Token: 0x06000155 RID: 341 RVA: 0x00005F96 File Offset: 0x00004196
		public Adapter2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005F9F File Offset: 0x0000419F
		public new static explicit operator Adapter2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Adapter2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00005FB8 File Offset: 0x000041B8
		public AdapterDescription2 Description2
		{
			get
			{
				AdapterDescription2 result;
				this.GetDescription2(out result);
				return result;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005FD0 File Offset: 0x000041D0
		internal unsafe void GetDescription2(out AdapterDescription2 descRef)
		{
			AdapterDescription2.__Native _Native = default(AdapterDescription2.__Native);
			descRef = default(AdapterDescription2);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}
	}
}
