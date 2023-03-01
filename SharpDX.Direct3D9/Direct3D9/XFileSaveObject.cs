using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000D1 RID: 209
	[Guid("cef08cfa-7b4f-4429-9624-2a690a933201")]
	public class XFileSaveObject : ComObject
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x00002623 File Offset: 0x00000823
		public XFileSaveObject(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00019275 File Offset: 0x00017475
		public new static explicit operator XFileSaveObject(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new XFileSaveObject(nativePointer);
			}
			return null;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x0001928C File Offset: 0x0001748C
		public XFile File
		{
			get
			{
				XFile result;
				this.GetFile(out result);
				return result;
			}
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000192A4 File Offset: 0x000174A4
		internal unsafe void GetFile(out XFile arg0)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			arg0 = ((zero == IntPtr.Zero) ? null : new XFile(zero));
			result.CheckError();
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000192FC File Offset: 0x000174FC
		public unsafe void AddDataObject(Guid arg0, string arg1, Guid arg2, PointerSize arg3, IntPtr arg4, out XFileSaveData arg5)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(arg1);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &arg0, (void*)intPtr, &arg2, arg3, (void*)arg4, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			arg5 = ((zero == IntPtr.Zero) ? null : new XFileSaveData(zero));
			result.CheckError();
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001937C File Offset: 0x0001757C
		public unsafe void Save()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
