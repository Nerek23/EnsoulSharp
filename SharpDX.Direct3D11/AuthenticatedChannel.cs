using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B2 RID: 178
	[Guid("3015A308-DCBD-47aa-A747-192486D14D4A")]
	public class AuthenticatedChannel : DeviceChild
	{
		// Token: 0x06000363 RID: 867 RVA: 0x00002075 File Offset: 0x00000275
		public AuthenticatedChannel(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000D7A3 File Offset: 0x0000B9A3
		public new static explicit operator AuthenticatedChannel(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new AuthenticatedChannel(nativePtr);
			}
			return null;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		public int CertificateSize
		{
			get
			{
				int result;
				this.GetCertificateSize(out result);
				return result;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000D7D4 File Offset: 0x0000B9D4
		public IntPtr ChannelHandle
		{
			get
			{
				IntPtr result;
				this.GetChannelHandle(out result);
				return result;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000D7EC File Offset: 0x0000B9EC
		internal unsafe void GetCertificateSize(out int certificateSizeRef)
		{
			Result result;
			fixed (int* ptr = &certificateSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000D82C File Offset: 0x0000BA2C
		public unsafe void GetCertificate(int certificateSize, byte[] certificateRef)
		{
			Result result;
			fixed (byte[] array = certificateRef)
			{
				void* ptr;
				if (certificateRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, certificateSize, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000D880 File Offset: 0x0000BA80
		internal unsafe void GetChannelHandle(out IntPtr channelHandleRef)
		{
			fixed (IntPtr* ptr = &channelHandleRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
