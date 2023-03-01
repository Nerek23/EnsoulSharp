using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000016 RID: 22
	[Guid("23BC3F0A-698B-4357-886B-F24D50671334")]
	public class ComponentInfo : ComObject
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00004C4F File Offset: 0x00002E4F
		public ComponentInfo(ImagingFactory factory, Guid clsidComponent) : base(IntPtr.Zero)
		{
			factory.CreateComponentInfo(clsidComponent, this);
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00004C64 File Offset: 0x00002E64
		public unsafe string Author
		{
			get
			{
				int num = 0;
				this.GetAuthor(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetAuthor(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004CA4 File Offset: 0x00002EA4
		public unsafe string Version
		{
			get
			{
				int num = 0;
				this.GetVersion(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetVersion(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00004CE4 File Offset: 0x00002EE4
		public unsafe string SpecVersion
		{
			get
			{
				int num = 0;
				this.GetSpecVersion(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetSpecVersion(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004D24 File Offset: 0x00002F24
		public unsafe string FriendlyName
		{
			get
			{
				int num = 0;
				this.GetFriendlyName(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetFriendlyName(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ComponentInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00004D64 File Offset: 0x00002F64
		public new static explicit operator ComponentInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComponentInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004D7C File Offset: 0x00002F7C
		public ComponentType ComponentType
		{
			get
			{
				ComponentType result;
				this.GetComponentType(out result);
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00004D94 File Offset: 0x00002F94
		public Guid CLSID
		{
			get
			{
				Guid result;
				this.GetCLSID(out result);
				return result;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004DAC File Offset: 0x00002FAC
		public int SigningStatus
		{
			get
			{
				int result;
				this.GetSigningStatus(out result);
				return result;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00004DC4 File Offset: 0x00002FC4
		public Guid VendorGUID
		{
			get
			{
				Guid result;
				this.GetVendorGUID(out result);
				return result;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00004DDC File Offset: 0x00002FDC
		internal unsafe void GetComponentType(out ComponentType typeRef)
		{
			Result result;
			fixed (ComponentType* ptr = &typeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00004E1C File Offset: 0x0000301C
		internal unsafe void GetCLSID(out Guid clsidRef)
		{
			clsidRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &clsidRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00004E64 File Offset: 0x00003064
		internal unsafe void GetSigningStatus(out int statusRef)
		{
			Result result;
			fixed (int* ptr = &statusRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00004EA4 File Offset: 0x000030A4
		internal unsafe void GetAuthor(int cchAuthor, IntPtr author, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchAuthor, (void*)author, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00004EEC File Offset: 0x000030EC
		internal unsafe void GetVendorGUID(out Guid guidVendorRef)
		{
			guidVendorRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &guidVendorRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00004F34 File Offset: 0x00003134
		internal unsafe void GetVersion(int cchVersion, IntPtr version, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchVersion, (void*)version, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00004F7C File Offset: 0x0000317C
		internal unsafe void GetSpecVersion(int cchSpecVersion, IntPtr specVersion, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchSpecVersion, (void*)specVersion, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004FC4 File Offset: 0x000031C4
		internal unsafe void GetFriendlyName(int cchFriendlyName, IntPtr friendlyName, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchFriendlyName, (void*)friendlyName, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
