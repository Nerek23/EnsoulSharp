using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000143 RID: 323
	[Guid("CFEE3140-1157-47CA-8B85-31BFCF3F2D0E")]
	public class StringList : ComObject
	{
		// Token: 0x060005FB RID: 1531 RVA: 0x00002A7F File Offset: 0x00000C7F
		public StringList(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x000134B4 File Offset: 0x000116B4
		public new static explicit operator StringList(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new StringList(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x000134CB File Offset: 0x000116CB
		public int Count
		{
			get
			{
				return this.GetCount();
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000134D4 File Offset: 0x000116D4
		public unsafe void GetLocaleNameLength(int listIndex, out int length)
		{
			Result result;
			fixed (int* ptr = &length)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00013518 File Offset: 0x00011718
		public unsafe void GetLocaleName(int listIndex, IntPtr localeName, int size)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, listIndex, (void*)localeName, size, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00013558 File Offset: 0x00011758
		public unsafe void GetStringLength(int listIndex, out int length)
		{
			Result result;
			fixed (int* ptr = &length)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001359C File Offset: 0x0001179C
		public unsafe void GetString(int listIndex, IntPtr stringBuffer, int stringBufferSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, listIndex, (void*)stringBuffer, stringBufferSize, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
