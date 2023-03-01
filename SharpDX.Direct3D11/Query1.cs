using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000036 RID: 54
	[Guid("631b4766-36dc-461d-8db6-c47e13e60916")]
	public class Query1 : Query
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000ADBE File Offset: 0x00008FBE
		public Query1(Device3 device, QueryDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateQuery1(description, this);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000AD1F File Offset: 0x00008F1F
		public Query1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000ADD3 File Offset: 0x00008FD3
		public new static explicit operator Query1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Query1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000ADEC File Offset: 0x00008FEC
		public QueryDescription1 Description1
		{
			get
			{
				QueryDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000AE04 File Offset: 0x00009004
		internal unsafe void GetDescription1(out QueryDescription1 desc1Ref)
		{
			desc1Ref = default(QueryDescription1);
			fixed (QueryDescription1* ptr = &desc1Ref)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
