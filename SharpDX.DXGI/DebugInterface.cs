using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000005 RID: 5
	internal static class DebugInterface
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000022CC File Offset: 0x000004CC
		static DebugInterface()
		{
			IntPtr intPtr = Kernel32.LoadLibraryEx("dxgidebug.dll", IntPtr.Zero, Kernel32.LoadLibraryFlags.LoadLibrarySearchSystem32);
			if (intPtr != IntPtr.Zero)
			{
				IntPtr procAddress = Kernel32.GetProcAddress(intPtr, "DXGIGetDebugInterface");
				if (procAddress != IntPtr.Zero)
				{
					DebugInterface.getDebugInterface = (DebugInterface.GetDebugInterface)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DebugInterface.GetDebugInterface));
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002330 File Offset: 0x00000530
		public static bool TryCreateComPtr<T>(out IntPtr comPtr) where T : class
		{
			comPtr = IntPtr.Zero;
			if (DebugInterface.getDebugInterface == null)
			{
				return false;
			}
			Guid guid = typeof(T).GetTypeInfo().GUID;
			return !DebugInterface.getDebugInterface(ref guid, out comPtr).Failure && comPtr != IntPtr.Zero;
		}

		// Token: 0x04000005 RID: 5
		private static readonly DebugInterface.GetDebugInterface getDebugInterface;

		// Token: 0x02000006 RID: 6
		// (Invoke) Token: 0x06000014 RID: 20
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate Result GetDebugInterface(ref Guid guid, out IntPtr result);
	}
}
