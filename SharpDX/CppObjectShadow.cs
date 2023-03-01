using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000010 RID: 16
	internal abstract class CppObjectShadow : CppObject
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002A36 File Offset: 0x00000C36
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002A3E File Offset: 0x00000C3E
		public ICallbackable Callback { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000061 RID: 97
		protected abstract CppObjectVtbl GetVtbl { get; }

		// Token: 0x06000062 RID: 98 RVA: 0x00002A48 File Offset: 0x00000C48
		public unsafe virtual void Initialize(ICallbackable callbackInstance)
		{
			this.Callback = callbackInstance;
			base.NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
			GCHandle value = GCHandle.Alloc(this);
			Marshal.WriteIntPtr(base.NativePointer, this.GetVtbl.Pointer);
			*(IntPtr*)((byte*)((void*)base.NativePointer) + sizeof(IntPtr)) = GCHandle.ToIntPtr(value);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002AA4 File Offset: 0x00000CA4
		protected unsafe override void Dispose(bool disposing)
		{
			if (base.NativePointer != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(*(IntPtr*)((byte*)((void*)base.NativePointer) + sizeof(IntPtr))).Free();
				Marshal.FreeHGlobal(base.NativePointer);
				base.NativePointer = IntPtr.Zero;
			}
			this.Callback = null;
			base.Dispose(disposing);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002B08 File Offset: 0x00000D08
		internal unsafe static T ToShadow<T>(IntPtr thisPtr) where T : CppObjectShadow
		{
			return (T)((object)GCHandle.FromIntPtr(*(IntPtr*)((byte*)((void*)thisPtr) + sizeof(IntPtr))).Target);
		}
	}
}
