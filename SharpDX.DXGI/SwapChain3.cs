using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006F RID: 111
	[Guid("94d99bdb-f1f8-4ab0-b236-7da0170edab1")]
	public class SwapChain3 : SwapChain2
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x00007589 File Offset: 0x00005789
		public SwapChain3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00007592 File Offset: 0x00005792
		public new static explicit operator SwapChain3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChain3(nativePtr);
			}
			return null;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001DB RID: 475 RVA: 0x000075A9 File Offset: 0x000057A9
		public int CurrentBackBufferIndex
		{
			get
			{
				return this.GetCurrentBackBufferIndex();
			}
		}

		// Token: 0x17000038 RID: 56
		// (set) Token: 0x060001DC RID: 476 RVA: 0x000075B1 File Offset: 0x000057B1
		public ColorSpaceType ColorSpace1
		{
			set
			{
				this.SetColorSpace1(value);
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000075BA File Offset: 0x000057BA
		internal unsafe int GetCurrentBackBufferIndex()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000075DC File Offset: 0x000057DC
		public unsafe SwapChainColorSpaceSupportFlags CheckColorSpaceSupport(ColorSpaceType colorSpace)
		{
			SwapChainColorSpaceSupportFlags result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, colorSpace, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000761C File Offset: 0x0000581C
		internal unsafe void SetColorSpace1(ColorSpaceType colorSpace)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, colorSpace, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00007658 File Offset: 0x00005858
		public unsafe void ResizeBuffers1(int bufferCount, int width, int height, Format format, SwapChainFlags swapChainFlags, int[] creationNodeMaskRef, IUnknown[] presentQueueOut)
		{
			IntPtr* ptr = null;
			if (presentQueueOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)presentQueueOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (presentQueueOut != null)
			{
				for (int i = 0; i < presentQueueOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<IUnknown>(presentQueueOut[i]);
				}
			}
			Result result;
			fixed (int[] array = creationNodeMaskRef)
			{
				void* ptr2;
				if (creationNodeMaskRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, bufferCount, width, height, format, swapChainFlags, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
