using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030D RID: 781
	[Guid("31e6e7bc-e0ff-4d46-8c64-a0a8c41c15d3")]
	public class Multithread : ComObject
	{
		// Token: 0x06000DB5 RID: 3509 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Multithread(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00025F1E File Offset: 0x0002411E
		public new static explicit operator Multithread(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Multithread(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00025F35 File Offset: 0x00024135
		public RawBool MultithreadProtected
		{
			get
			{
				return this.GetMultithreadProtected();
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00025F3D File Offset: 0x0002413D
		internal unsafe RawBool GetMultithreadProtected()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00025F5C File Offset: 0x0002415C
		public unsafe void Enter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00025F7B File Offset: 0x0002417B
		public unsafe void Leave()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}
	}
}
