using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000D0 RID: 208
	[Guid("cef08cfb-7b4f-4429-9624-2a690a933201")]
	public class XFileSaveData : ComObject
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x00002623 File Offset: 0x00000823
		public XFileSaveData(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00019027 File Offset: 0x00017227
		public new static explicit operator XFileSaveData(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new XFileSaveData(nativePointer);
			}
			return null;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x00019040 File Offset: 0x00017240
		public XFileSaveObject Save
		{
			get
			{
				XFileSaveObject result;
				this.GetSave(out result);
				return result;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00019058 File Offset: 0x00017258
		public Guid TypeInfo
		{
			get
			{
				Guid result;
				this.GetTypeInfo(out result);
				return result;
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00019070 File Offset: 0x00017270
		internal unsafe void GetSave(out XFileSaveObject arg0)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			arg0 = ((zero == IntPtr.Zero) ? null : new XFileSaveObject(zero));
			result.CheckError();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000190C8 File Offset: 0x000172C8
		public unsafe void GetName(string arg0, out PointerSize arg1)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(arg0);
			arg1 = default(PointerSize);
			Result result;
			fixed (PointerSize* ptr = &arg1)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00019124 File Offset: 0x00017324
		public unsafe void GetId(Guid arg0)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &arg0, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00019160 File Offset: 0x00017360
		internal unsafe void GetTypeInfo(out Guid arg0)
		{
			arg0 = default(Guid);
			Result result;
			fixed (Guid* ptr = &arg0)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000191A8 File Offset: 0x000173A8
		public unsafe void AddDataObject(Guid arg0, string arg1, Guid arg2, PointerSize arg3, IntPtr arg4, out XFileSaveData arg5)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(arg1);
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &arg0, (void*)intPtr, &arg2, arg3, (void*)arg4, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			arg5 = ((zero == IntPtr.Zero) ? null : new XFileSaveData(zero));
			result.CheckError();
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00019228 File Offset: 0x00017428
		public unsafe void AddDataReference(string arg0, Guid arg1)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(arg0);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)intPtr, &arg1, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}
	}
}
