using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B4 RID: 180
	[Guid("9B32F9AD-BDCC-40a6-A39D-D5C865845720")]
	public class CryptoSession : DeviceChild
	{
		// Token: 0x0600036C RID: 876 RVA: 0x00002075 File Offset: 0x00000275
		public CryptoSession(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000D8CB File Offset: 0x0000BACB
		public new static explicit operator CryptoSession(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CryptoSession(nativePtr);
			}
			return null;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000D8E4 File Offset: 0x0000BAE4
		public Guid CryptoType
		{
			get
			{
				Guid result;
				this.GetCryptoType(out result);
				return result;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600036F RID: 879 RVA: 0x0000D8FC File Offset: 0x0000BAFC
		public Guid DecoderProfile
		{
			get
			{
				Guid result;
				this.GetDecoderProfile(out result);
				return result;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000D914 File Offset: 0x0000BB14
		public int CertificateSize
		{
			get
			{
				int result;
				this.GetCertificateSize(out result);
				return result;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000371 RID: 881 RVA: 0x0000D92C File Offset: 0x0000BB2C
		public IntPtr CryptoSessionHandle
		{
			get
			{
				IntPtr result;
				this.GetCryptoSessionHandle(out result);
				return result;
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000D944 File Offset: 0x0000BB44
		internal unsafe void GetCryptoType(out Guid cryptoTypeRef)
		{
			cryptoTypeRef = default(Guid);
			fixed (Guid* ptr = &cryptoTypeRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000D980 File Offset: 0x0000BB80
		internal unsafe void GetDecoderProfile(out Guid decoderProfileRef)
		{
			decoderProfileRef = default(Guid);
			fixed (Guid* ptr = &decoderProfileRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000D9BC File Offset: 0x0000BBBC
		internal unsafe void GetCertificateSize(out int certificateSizeRef)
		{
			Result result;
			fixed (int* ptr = &certificateSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000DA00 File Offset: 0x0000BC00
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
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, certificateSize, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000DA54 File Offset: 0x0000BC54
		internal unsafe void GetCryptoSessionHandle(out IntPtr cryptoSessionHandleRef)
		{
			fixed (IntPtr* ptr = &cryptoSessionHandleRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
