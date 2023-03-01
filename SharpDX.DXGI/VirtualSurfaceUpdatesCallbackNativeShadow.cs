using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200002A RID: 42
	internal class VirtualSurfaceUpdatesCallbackNativeShadow : ComObjectShadow
	{
		// Token: 0x06000141 RID: 321 RVA: 0x00005994 File Offset: 0x00003B94
		public static IntPtr ToIntPtr(IVirtualSurfaceUpdatesCallbackNative virtualSurfaceUpdatesCallbackNative)
		{
			return CppObject.ToCallbackPtr<IVirtualSurfaceUpdatesCallbackNative>(virtualSurfaceUpdatesCallbackNative);
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000599C File Offset: 0x00003B9C
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return VirtualSurfaceUpdatesCallbackNativeShadow.Vtbl;
			}
		}

		// Token: 0x0400002F RID: 47
		private static readonly VirtualSurfaceUpdatesCallbackNativeShadow.VirtualSurfaceUpdatesCallbackNativeVtbl Vtbl = new VirtualSurfaceUpdatesCallbackNativeShadow.VirtualSurfaceUpdatesCallbackNativeVtbl();

		// Token: 0x0200002B RID: 43
		public class VirtualSurfaceUpdatesCallbackNativeVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000145 RID: 325 RVA: 0x000059B7 File Offset: 0x00003BB7
			public VirtualSurfaceUpdatesCallbackNativeVtbl() : base(1)
			{
				base.AddMethod(new VirtualSurfaceUpdatesCallbackNativeShadow.VirtualSurfaceUpdatesCallbackNativeVtbl.UpdatesNeededDelegate(VirtualSurfaceUpdatesCallbackNativeShadow.VirtualSurfaceUpdatesCallbackNativeVtbl.UpdatesNeededImpl));
			}

			// Token: 0x06000146 RID: 326 RVA: 0x000059D4 File Offset: 0x00003BD4
			private static int UpdatesNeededImpl(IntPtr thisPtr)
			{
				try
				{
					((IVirtualSurfaceUpdatesCallbackNative)CppObjectShadow.ToShadow<VirtualSurfaceUpdatesCallbackNativeShadow>(thisPtr).Callback).UpdatesNeeded();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200002C RID: 44
			// (Invoke) Token: 0x06000148 RID: 328
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int UpdatesNeededDelegate(IntPtr thisPtr);
		}
	}
}
