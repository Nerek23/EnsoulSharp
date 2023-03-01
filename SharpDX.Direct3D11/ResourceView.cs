using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000041 RID: 65
	[Guid("839d1216-bb2e-412b-b7f4-a9dbebe08ed1")]
	public class ResourceView : DeviceChild
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000B440 File Offset: 0x00009640
		public Resource Resource
		{
			get
			{
				IntPtr nativePtr;
				this.GetResource(out nativePtr);
				return new Resource(nativePtr);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000B45C File Offset: 0x0000965C
		public T ResourceAs<T>() where T : Resource
		{
			IntPtr iunknownPtr;
			this.GetResource(out iunknownPtr);
			return ComObject.As<T>(iunknownPtr);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00002075 File Offset: 0x00000275
		public ResourceView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000B477 File Offset: 0x00009677
		public new static explicit operator ResourceView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ResourceView(nativePtr);
			}
			return null;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000B490 File Offset: 0x00009690
		internal unsafe void GetResource(out IntPtr resourceOut)
		{
			fixed (IntPtr* ptr = &resourceOut)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
