using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000B6 RID: 182
	[Guid("08256209-099a-4b34-b86d-c22b110e7771")]
	public class LocalizedStrings : ComObject
	{
		// Token: 0x060003A5 RID: 933 RVA: 0x0000D228 File Offset: 0x0000B428
		public unsafe string GetLocaleName(int index)
		{
			int num;
			this.GetLocaleNameLength(index, out num);
			char* value = stackalloc char[checked(unchecked((UIntPtr)(num + 1)) * 2)];
			this.GetLocaleName(index, new IntPtr((void*)value), num + 1);
			return new string(value, 0, num);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000D260 File Offset: 0x0000B460
		public unsafe string GetString(int index)
		{
			int num;
			this.GetStringLength(index, out num);
			char* value = stackalloc char[checked(unchecked((UIntPtr)(num + 1)) * 2)];
			this.GetString(index, new IntPtr((void*)value), num + 1);
			return new string(value, 0, num);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00002A7F File Offset: 0x00000C7F
		public LocalizedStrings(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000D297 File Offset: 0x0000B497
		public new static explicit operator LocalizedStrings(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new LocalizedStrings(nativePtr);
			}
			return null;
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000D2AE File Offset: 0x0000B4AE
		public int Count
		{
			get
			{
				return this.GetCount();
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
		public unsafe RawBool FindLocaleName(string localeName, out int index)
		{
			RawBool result2;
			Result result;
			fixed (int* ptr = &index)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = localeName)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr2, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000D318 File Offset: 0x0000B518
		internal unsafe void GetLocaleNameLength(int index, out int length)
		{
			Result result;
			fixed (int* ptr = &length)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000D35C File Offset: 0x0000B55C
		internal unsafe void GetLocaleName(int index, IntPtr localeName, int size)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, index, (void*)localeName, size, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000D39C File Offset: 0x0000B59C
		internal unsafe void GetStringLength(int index, out int length)
		{
			Result result;
			fixed (int* ptr = &length)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000D3E0 File Offset: 0x0000B5E0
		internal unsafe void GetString(int index, IntPtr stringBuffer, int size)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, index, (void*)stringBuffer, size, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
