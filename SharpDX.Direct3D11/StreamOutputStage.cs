using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000020 RID: 32
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class StreamOutputStage : CppObject
	{
		// Token: 0x060001CE RID: 462 RVA: 0x000081D0 File Offset: 0x000063D0
		internal unsafe void SetTargets(int numBuffers, Buffer[] sOTargetsOut, int[] offsetsRef)
		{
			IntPtr* ptr = null;
			if (sOTargetsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)sOTargetsOut.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < sOTargetsOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((sOTargetsOut[i] == null) ? IntPtr.Zero : sOTargetsOut[i].NativePointer);
				}
			}
			fixed (int[] array = offsetsRef)
			{
				void* value;
				if (offsetsRef == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetTargets(numBuffers, new IntPtr((void*)ptr), new IntPtr(value));
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000824C File Offset: 0x0000644C
		public unsafe void SetTarget(Buffer buffer, int offsets)
		{
			IntPtr intPtr = (buffer != null) ? buffer.NativePointer : IntPtr.Zero;
			this.SetTargets(1, new IntPtr((void*)(&intPtr)), new IntPtr((void*)(&offsets)));
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00008284 File Offset: 0x00006484
		public void SetTargets(StreamOutputBufferBinding[] bufferBindings)
		{
			if (bufferBindings == null)
			{
				this.SetTargets(0, null, null);
				return;
			}
			Buffer[] array = new Buffer[bufferBindings.Length];
			int[] array2 = new int[bufferBindings.Length];
			for (int i = 0; i < bufferBindings.Length; i++)
			{
				array[i] = bufferBindings[i].Buffer;
				array2[i] = bufferBindings[i].Offset;
			}
			this.SetTargets(bufferBindings.Length, array, array2);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000082E8 File Offset: 0x000064E8
		public Buffer[] GetTargets(int numBuffers)
		{
			Buffer[] array = new Buffer[numBuffers];
			this.GetTargets(numBuffers, array);
			return array;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000543D File Offset: 0x0000363D
		public StreamOutputStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00008305 File Offset: 0x00006505
		public static explicit operator StreamOutputStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new StreamOutputStage(nativePtr);
			}
			return null;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000831C File Offset: 0x0000651C
		internal unsafe void SetTargets(int numBuffers, IntPtr sOTargetsOut, IntPtr offsetsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numBuffers, (void*)sOTargetsOut, (void*)offsetsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000834C File Offset: 0x0000654C
		internal unsafe void GetTargets(int numBuffers, Buffer[] sOTargetsOut)
		{
			IntPtr* ptr = null;
			if (sOTargetsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)sOTargetsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)93 * (IntPtr)sizeof(void*)));
			if (sOTargetsOut != null)
			{
				for (int i = 0; i < sOTargetsOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						sOTargetsOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						sOTargetsOut[i] = null;
					}
				}
			}
		}
	}
}
