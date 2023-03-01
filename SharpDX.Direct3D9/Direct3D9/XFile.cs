using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CD RID: 205
	[Guid("cef08cf9-7b4f-4429-9624-2a690a933201")]
	public class XFile : ComObject
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x00002623 File Offset: 0x00000823
		public XFile(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x000189CB File Offset: 0x00016BCB
		public new static explicit operator XFile(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new XFile(nativePointer);
			}
			return null;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x000189E4 File Offset: 0x00016BE4
		public unsafe void CreateEnumObject(IntPtr arg0, int arg1, out XFileEnumObject arg2)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)arg0, arg1, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			arg2 = ((zero == IntPtr.Zero) ? null : new XFileEnumObject(zero));
			result.CheckError();
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00018A44 File Offset: 0x00016C44
		public unsafe void CreateSaveObject(IntPtr arg0, int arg1, int arg2, out XFileSaveObject arg3)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)arg0, arg1, arg2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			arg3 = ((zero == IntPtr.Zero) ? null : new XFileSaveObject(zero));
			result.CheckError();
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00018AA8 File Offset: 0x00016CA8
		public unsafe void RegisterTemplates(IntPtr arg0, PointerSize arg1)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)arg0, arg1, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00018AEC File Offset: 0x00016CEC
		public unsafe void RegisterEnumTemplates(XFileEnumObject arg0)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((arg0 == null) ? IntPtr.Zero : arg0.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
