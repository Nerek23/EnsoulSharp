using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006E RID: 110
	[Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
	public class Resource : DeviceChild
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x00004C1F File Offset: 0x00002E1F
		public Resource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00007441 File Offset: 0x00005641
		public new static explicit operator Resource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Resource(nativePtr);
			}
			return null;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00007458 File Offset: 0x00005658
		public IntPtr SharedHandle
		{
			get
			{
				IntPtr result;
				this.GetSharedHandle(out result);
				return result;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00007470 File Offset: 0x00005670
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00007486 File Offset: 0x00005686
		public int EvictionPriority
		{
			get
			{
				int result;
				this.GetEvictionPriority(out result);
				return result;
			}
			set
			{
				this.SetEvictionPriority(value);
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007490 File Offset: 0x00005690
		internal unsafe void GetSharedHandle(out IntPtr sharedHandleRef)
		{
			Result result;
			fixed (IntPtr* ptr = &sharedHandleRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000074D0 File Offset: 0x000056D0
		public unsafe void GetUsage(int usageRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &usageRef, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000750C File Offset: 0x0000570C
		internal unsafe void SetEvictionPriority(int evictionPriority)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, evictionPriority, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00007548 File Offset: 0x00005748
		internal unsafe void GetEvictionPriority(out int evictionPriorityRef)
		{
			Result result;
			fixed (int* ptr = &evictionPriorityRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
