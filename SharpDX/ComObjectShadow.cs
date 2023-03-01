using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000009 RID: 9
	internal abstract class ComObjectShadow : CppObjectShadow
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002724 File Offset: 0x00000924
		protected int QueryInterfaceImpl(ref Guid guid, out IntPtr output)
		{
			ComObjectShadow comObjectShadow = (ComObjectShadow)((ShadowContainer)base.Callback.Shadow).FindShadow(guid);
			if (comObjectShadow != null)
			{
				((IUnknown)base.Callback).AddReference();
				output = comObjectShadow.NativePointer;
				return Result.Ok.Code;
			}
			output = IntPtr.Zero;
			return Result.NoInterface.Code;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000278D File Offset: 0x0000098D
		protected virtual int AddRefImpl()
		{
			return ((IUnknown)base.Callback).AddReference();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000279F File Offset: 0x0000099F
		protected virtual int ReleaseImpl()
		{
			return ((IUnknown)base.Callback).Release();
		}

		// Token: 0x04000008 RID: 8
		public static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

		// Token: 0x0200000A RID: 10
		internal class ComObjectVtbl : CppObjectVtbl
		{
			// Token: 0x0600003D RID: 61 RVA: 0x000027CC File Offset: 0x000009CC
			public ComObjectVtbl(int numberOfCallbackMethods) : base(numberOfCallbackMethods + 3)
			{
				base.AddMethod(new ComObjectShadow.ComObjectVtbl.QueryInterfaceDelegate(ComObjectShadow.ComObjectVtbl.QueryInterfaceImpl));
				base.AddMethod(new ComObjectShadow.ComObjectVtbl.AddRefDelegate(ComObjectShadow.ComObjectVtbl.AddRefImpl));
				base.AddMethod(new ComObjectShadow.ComObjectVtbl.ReleaseDelegate(ComObjectShadow.ComObjectVtbl.ReleaseImpl));
			}

			// Token: 0x0600003E RID: 62 RVA: 0x00002818 File Offset: 0x00000A18
			protected unsafe static int QueryInterfaceImpl(IntPtr thisObject, IntPtr guid, out IntPtr output)
			{
				ComObjectShadow comObjectShadow = CppObjectShadow.ToShadow<ComObjectShadow>(thisObject);
				if (comObjectShadow == null)
				{
					output = IntPtr.Zero;
					return Result.NoInterface.Code;
				}
				return comObjectShadow.QueryInterfaceImpl(ref *(Guid*)((void*)guid), out output);
			}

			// Token: 0x0600003F RID: 63 RVA: 0x00002850 File Offset: 0x00000A50
			protected static int AddRefImpl(IntPtr thisObject)
			{
				ComObjectShadow comObjectShadow = CppObjectShadow.ToShadow<ComObjectShadow>(thisObject);
				if (comObjectShadow == null)
				{
					return 0;
				}
				return comObjectShadow.AddRefImpl();
			}

			// Token: 0x06000040 RID: 64 RVA: 0x00002870 File Offset: 0x00000A70
			protected static int ReleaseImpl(IntPtr thisObject)
			{
				ComObjectShadow comObjectShadow = CppObjectShadow.ToShadow<ComObjectShadow>(thisObject);
				if (comObjectShadow == null)
				{
					return 0;
				}
				return comObjectShadow.ReleaseImpl();
			}

			// Token: 0x0200000B RID: 11
			// (Invoke) Token: 0x06000042 RID: 66
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate int QueryInterfaceDelegate(IntPtr thisObject, IntPtr guid, out IntPtr output);

			// Token: 0x0200000C RID: 12
			// (Invoke) Token: 0x06000046 RID: 70
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate int AddRefDelegate(IntPtr thisObject);

			// Token: 0x0200000D RID: 13
			// (Invoke) Token: 0x0600004A RID: 74
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate int ReleaseDelegate(IntPtr thisObject);
		}
	}
}
