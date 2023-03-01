using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CE RID: 206
	[Guid("cef08cfd-7b4f-4429-9624-2a690a933201")]
	public class XFileData : ComObject
	{
		// Token: 0x060006EA RID: 1770 RVA: 0x00002623 File Offset: 0x00000823
		public XFileData(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00018B38 File Offset: 0x00016D38
		public new static explicit operator XFileData(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new XFileData(nativePointer);
			}
			return null;
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x00018B50 File Offset: 0x00016D50
		public XFileEnumObject Enum
		{
			get
			{
				XFileEnumObject result;
				this.GetEnum(out result);
				return result;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00018B68 File Offset: 0x00016D68
		public Guid TypeInfo
		{
			get
			{
				Guid result;
				this.GetTypeInfo(out result);
				return result;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x00018B7E File Offset: 0x00016D7E
		public RawBool IsReference
		{
			get
			{
				return this.IsReference_();
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x00018B88 File Offset: 0x00016D88
		public PointerSize Children
		{
			get
			{
				PointerSize result;
				this.GetChildren(out result);
				return result;
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00018BA0 File Offset: 0x00016DA0
		internal unsafe void GetEnum(out XFileEnumObject arg0)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			arg0 = ((zero == IntPtr.Zero) ? null : new XFileEnumObject(zero));
			result.CheckError();
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00018BF8 File Offset: 0x00016DF8
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

		// Token: 0x060006F2 RID: 1778 RVA: 0x00018C54 File Offset: 0x00016E54
		public unsafe void GetId(Guid arg0)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &arg0, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00018C90 File Offset: 0x00016E90
		public unsafe void Lock(PointerSize arg0, IntPtr arg1)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &arg0, (void*)arg1, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00018CD0 File Offset: 0x00016ED0
		public unsafe void Unlock()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00018D08 File Offset: 0x00016F08
		internal unsafe void GetTypeInfo(out Guid arg0)
		{
			arg0 = default(Guid);
			Result result;
			fixed (Guid* ptr = &arg0)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00018D4F File Offset: 0x00016F4F
		internal unsafe RawBool IsReference_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00018D70 File Offset: 0x00016F70
		internal unsafe void GetChildren(out PointerSize arg0)
		{
			arg0 = default(PointerSize);
			Result result;
			fixed (PointerSize* ptr = &arg0)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00018DB8 File Offset: 0x00016FB8
		public unsafe void GetChild(PointerSize arg0, out XFileData arg1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, arg0, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			arg1 = ((zero == IntPtr.Zero) ? null : new XFileData(zero));
			result.CheckError();
		}
	}
}
