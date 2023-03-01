using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000004 RID: 4
	[Guid("E87A44C4-B76E-4c47-8B09-298EB12A2714")]
	public class BitmapCodecInfo : ComponentInfo
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000022E4 File Offset: 0x000004E4
		public Guid[] PixelFormats
		{
			get
			{
				int num = 0;
				this.GetPixelFormats(0, null, out num);
				if (num == 0)
				{
					return new Guid[0];
				}
				Guid[] array = new Guid[num];
				this.GetPixelFormats(num, array, out num);
				return array;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000231C File Offset: 0x0000051C
		public unsafe string ColorManagementVersion
		{
			get
			{
				int num = 0;
				this.GetColorManagementVersion(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetColorManagementVersion(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000235C File Offset: 0x0000055C
		public unsafe string DeviceManufacturer
		{
			get
			{
				int num = 0;
				this.GetDeviceManufacturer(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetDeviceManufacturer(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000239C File Offset: 0x0000059C
		public unsafe string DeviceModels
		{
			get
			{
				int num = 0;
				this.GetDeviceModels(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetDeviceModels(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000023DC File Offset: 0x000005DC
		public unsafe string MimeTypes
		{
			get
			{
				int num = 0;
				this.GetMimeTypes(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetMimeTypes(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000241C File Offset: 0x0000061C
		public unsafe string FileExtensions
		{
			get
			{
				int num = 0;
				this.GetFileExtensions(0, IntPtr.Zero, out num);
				if (num == 0)
				{
					return null;
				}
				char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
				this.GetFileExtensions(num, (IntPtr)((void*)value), out num);
				return new string(value, 0, num);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000245C File Offset: 0x0000065C
		public BitmapCodecInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002465 File Offset: 0x00000665
		public new static explicit operator BitmapCodecInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapCodecInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000247C File Offset: 0x0000067C
		public Guid ContainerFormat
		{
			get
			{
				Guid result;
				this.GetContainerFormat(out result);
				return result;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002494 File Offset: 0x00000694
		public RawBool IsAnimationSupported
		{
			get
			{
				RawBool result;
				this.IsAnimationSupported_(out result);
				return result;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000024AC File Offset: 0x000006AC
		public RawBool IsChromakeySupported
		{
			get
			{
				RawBool result;
				this.IsChromakeySupported_(out result);
				return result;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000024C4 File Offset: 0x000006C4
		public RawBool IsLosslessSupported
		{
			get
			{
				RawBool result;
				this.IsLosslessSupported_(out result);
				return result;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000024DC File Offset: 0x000006DC
		public RawBool IsMultiframeSupported
		{
			get
			{
				RawBool result;
				this.IsMultiframeSupported_(out result);
				return result;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024F4 File Offset: 0x000006F4
		internal unsafe void GetContainerFormat(out Guid guidContainerFormatRef)
		{
			guidContainerFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &guidContainerFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000253C File Offset: 0x0000073C
		internal unsafe void GetPixelFormats(int formats, Guid[] guidPixelFormatsRef, out int actualRef)
		{
			Result result;
			fixed (int* ptr = &actualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (Guid[] array = guidPixelFormatsRef)
				{
					void* ptr3;
					if (guidPixelFormatsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, formats, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025A0 File Offset: 0x000007A0
		internal unsafe void GetColorManagementVersion(int cchColorManagementVersion, IntPtr colorManagementVersion, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchColorManagementVersion, (void*)colorManagementVersion, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000025E8 File Offset: 0x000007E8
		internal unsafe void GetDeviceManufacturer(int cchDeviceManufacturer, IntPtr deviceManufacturer, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchDeviceManufacturer, (void*)deviceManufacturer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002630 File Offset: 0x00000830
		internal unsafe void GetDeviceModels(int cchDeviceModels, IntPtr deviceModels, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchDeviceModels, (void*)deviceModels, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002678 File Offset: 0x00000878
		internal unsafe void GetMimeTypes(int cchMimeTypes, IntPtr mimeTypes, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchMimeTypes, (void*)mimeTypes, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000026C0 File Offset: 0x000008C0
		internal unsafe void GetFileExtensions(int cchFileExtensions, IntPtr fileExtensions, out int cchActualRef)
		{
			Result result;
			fixed (int* ptr = &cchActualRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, cchFileExtensions, (void*)fileExtensions, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002708 File Offset: 0x00000908
		internal unsafe void IsAnimationSupported_(out RawBool fSupportAnimationRef)
		{
			fSupportAnimationRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fSupportAnimationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002750 File Offset: 0x00000950
		internal unsafe void IsChromakeySupported_(out RawBool fSupportChromakeyRef)
		{
			fSupportChromakeyRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fSupportChromakeyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002798 File Offset: 0x00000998
		internal unsafe void IsLosslessSupported_(out RawBool fSupportLosslessRef)
		{
			fSupportLosslessRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fSupportLosslessRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000027E0 File Offset: 0x000009E0
		internal unsafe void IsMultiframeSupported_(out RawBool fSupportMultiframeRef)
		{
			fSupportMultiframeRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fSupportMultiframeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002828 File Offset: 0x00000A28
		public unsafe RawBool MatchesMimeType(string mimeType)
		{
			RawBool result2;
			Result result;
			fixed (string text = mimeType)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}
	}
}
