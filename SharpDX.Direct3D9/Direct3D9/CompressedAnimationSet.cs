using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AE RID: 174
	[Guid("6cc2480d-3808-4739-9f88-de49facd8d4c")]
	public class CompressedAnimationSet : AnimationSet
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x000115B7 File Offset: 0x0000F7B7
		public CompressedAnimationSet(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x000115C0 File Offset: 0x0000F7C0
		public new static explicit operator CompressedAnimationSet(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new CompressedAnimationSet(nativePointer);
			}
			return null;
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x000115D7 File Offset: 0x0000F7D7
		public PlaybackType PlaybackType
		{
			get
			{
				return this.GetPlaybackType();
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x000115DF File Offset: 0x0000F7DF
		public double SourceTicksPerSecond
		{
			get
			{
				return this.GetSourceTicksPerSecond();
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x000115E8 File Offset: 0x0000F7E8
		public Blob CompressedData
		{
			get
			{
				Blob result;
				this.GetCompressedData(out result);
				return result;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x000115FE File Offset: 0x0000F7FE
		public int NumCallbackKeys
		{
			get
			{
				return this.GetNumCallbackKeys();
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00011606 File Offset: 0x0000F806
		internal unsafe PlaybackType GetPlaybackType()
		{
			return calli(SharpDX.Direct3D9.PlaybackType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00011626 File Offset: 0x0000F826
		internal unsafe double GetSourceTicksPerSecond()
		{
			return calli(System.Double(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00011648 File Offset: 0x0000F848
		internal unsafe void GetCompressedData(out Blob compressedDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			compressedDataOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000116A1 File Offset: 0x0000F8A1
		internal unsafe int GetNumCallbackKeys()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000116C4 File Offset: 0x0000F8C4
		public unsafe void GetCallbackKeys(CallbackKey callbackKeysRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &callbackKeysRef, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
