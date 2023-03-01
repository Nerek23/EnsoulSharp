using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000011 RID: 17
	internal class CppObjectVtbl
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00002B35 File Offset: 0x00000D35
		public CppObjectVtbl(int numberOfCallbackMethods)
		{
			this.vtbl = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
			this.methods = new List<Delegate>();
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002B5A File Offset: 0x00000D5A
		public IntPtr Pointer
		{
			get
			{
				return this.vtbl;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002B64 File Offset: 0x00000D64
		public unsafe void AddMethod(Delegate method)
		{
			int count = this.methods.Count;
			this.methods.Add(method);
			*(IntPtr*)((byte*)((void*)this.vtbl) + (IntPtr)count * (IntPtr)sizeof(IntPtr)) = Marshal.GetFunctionPointerForDelegate(method);
		}

		// Token: 0x04000011 RID: 17
		private readonly List<Delegate> methods;

		// Token: 0x04000012 RID: 18
		private readonly IntPtr vtbl;
	}
}
