using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000029 RID: 41
	[Guid("a8be2ac4-199f-4946-b331-79599fb98de7")]
	public class SwapChain2 : SwapChain1
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00005740 File Offset: 0x00003940
		// (set) Token: 0x06000132 RID: 306 RVA: 0x0000575E File Offset: 0x0000395E
		public Size2 SourceSize
		{
			get
			{
				int width;
				int height;
				this.GetSourceSize(out width, out height);
				return new Size2(width, height);
			}
			set
			{
				this.SetSourceSize(value.Width, value.Height);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005772 File Offset: 0x00003972
		public SwapChain2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000577B File Offset: 0x0000397B
		public new static explicit operator SwapChain2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChain2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00005794 File Offset: 0x00003994
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000057AA File Offset: 0x000039AA
		public int MaximumFrameLatency
		{
			get
			{
				int result;
				this.GetMaximumFrameLatency(out result);
				return result;
			}
			set
			{
				this.SetMaximumFrameLatency(value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000057B3 File Offset: 0x000039B3
		public IntPtr FrameLatencyWaitableObject
		{
			get
			{
				return this.GetFrameLatencyWaitableObject();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000138 RID: 312 RVA: 0x000057BC File Offset: 0x000039BC
		// (set) Token: 0x06000139 RID: 313 RVA: 0x000057D2 File Offset: 0x000039D2
		public RawMatrix3x2 MatrixTransform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetMatrixTransform(out result);
				return result;
			}
			set
			{
				this.SetMatrixTransform(ref value);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000057DC File Offset: 0x000039DC
		internal unsafe void SetSourceSize(int width, int height)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, width, height, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005818 File Offset: 0x00003A18
		internal unsafe void GetSourceSize(out int widthRef, out int heightRef)
		{
			Result result;
			fixed (int* ptr = &heightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005868 File Offset: 0x00003A68
		internal unsafe void SetMaximumFrameLatency(int maxLatency)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, maxLatency, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000058A4 File Offset: 0x00003AA4
		internal unsafe void GetMaximumFrameLatency(out int maxLatencyRef)
		{
			Result result;
			fixed (int* ptr = &maxLatencyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000058E5 File Offset: 0x00003AE5
		internal unsafe IntPtr GetFrameLatencyWaitableObject()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005908 File Offset: 0x00003B08
		internal unsafe void SetMatrixTransform(ref RawMatrix3x2 matrixRef)
		{
			Result result;
			fixed (RawMatrix3x2* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000594C File Offset: 0x00003B4C
		internal unsafe void GetMatrixTransform(out RawMatrix3x2 matrixRef)
		{
			matrixRef = default(RawMatrix3x2);
			Result result;
			fixed (RawMatrix3x2* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
