using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CF RID: 207
	[Guid("cef08cfc-7b4f-4429-9624-2a690a933201")]
	public class XFileEnumObject : ComObject
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x00002623 File Offset: 0x00000823
		public XFileEnumObject(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00018E17 File Offset: 0x00017017
		public new static explicit operator XFileEnumObject(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new XFileEnumObject(nativePointer);
			}
			return null;
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00018E30 File Offset: 0x00017030
		public XFile File
		{
			get
			{
				XFile result;
				this.GetFile(out result);
				return result;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00018E48 File Offset: 0x00017048
		public PointerSize Children
		{
			get
			{
				PointerSize result;
				this.GetChildren(out result);
				return result;
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00018E60 File Offset: 0x00017060
		internal unsafe void GetFile(out XFile arg0)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			arg0 = ((zero == IntPtr.Zero) ? null : new XFile(zero));
			result.CheckError();
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00018EB8 File Offset: 0x000170B8
		internal unsafe void GetChildren(out PointerSize arg0)
		{
			arg0 = default(PointerSize);
			Result result;
			fixed (PointerSize* ptr = &arg0)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00018F00 File Offset: 0x00017100
		public unsafe void GetChild(PointerSize arg0, out XFileData arg1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, arg0, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			arg1 = ((zero == IntPtr.Zero) ? null : new XFileData(zero));
			result.CheckError();
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00018F60 File Offset: 0x00017160
		public unsafe void GetDataObjectById(Guid arg0, out XFileData arg1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &arg0, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			arg1 = ((zero == IntPtr.Zero) ? null : new XFileData(zero));
			result.CheckError();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00018FBC File Offset: 0x000171BC
		public unsafe void GetDataObjectByName(string arg0, out XFileData arg1)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(arg0);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			arg1 = ((zero == IntPtr.Zero) ? null : new XFileData(zero));
			result.CheckError();
		}
	}
}
