using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000035 RID: 53
	[Guid("d6c00747-87b7-425e-b84d-44d108560afd")]
	public class Query : Asynchronous
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000AD3F File Offset: 0x00008F3F
		public Query(Device device, QueryDescription description) : base(IntPtr.Zero)
		{
			device.CreateQuery(description, this);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00002D17 File Offset: 0x00000F17
		public Query(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000AD54 File Offset: 0x00008F54
		public new static explicit operator Query(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Query(nativePtr);
			}
			return null;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000AD6C File Offset: 0x00008F6C
		public QueryDescription Description
		{
			get
			{
				QueryDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000AD84 File Offset: 0x00008F84
		internal unsafe void GetDescription(out QueryDescription descRef)
		{
			descRef = default(QueryDescription);
			fixed (QueryDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
