using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001AA RID: 426
	[Guid("0d85573c-01e3-4f7d-bfd9-0d60608bf3c3")]
	public class ComputeTransformNative : TransformNative, ComputeTransform, Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000834 RID: 2100 RVA: 0x00018028 File Offset: 0x00016228
		public void SetComputeInformation(ComputeInformation computeInfo)
		{
			this.SetComputeInfo_(computeInfo);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00018034 File Offset: 0x00016234
		public RawInt3 CalculateThreadgroups(RawRectangle outputRect)
		{
			RawInt3 result;
			this.CalculateThreadgroups_(outputRect, out result.X, out result.Y, out result.Z);
			return result;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0001805E File Offset: 0x0001625E
		public ComputeTransformNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00018067 File Offset: 0x00016267
		public new static explicit operator ComputeTransformNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComputeTransformNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700013B RID: 315
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x00018028 File Offset: 0x00016228
		public ComputeInformation ComputeInfo_
		{
			set
			{
				this.SetComputeInfo_(value);
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00018080 File Offset: 0x00016280
		internal unsafe void SetComputeInfo_(ComputeInformation computeInfo)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ComputeInformation>(computeInfo);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x000180CC File Offset: 0x000162CC
		internal unsafe void CalculateThreadgroups_(RawRectangle outputRect, out int dimensionX, out int dimensionY, out int dimensionZ)
		{
			Result result;
			fixed (int* ptr = &dimensionZ)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &dimensionY)
				{
					void* ptr4 = (void*)ptr3;
					fixed (int* ptr5 = &dimensionX)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &outputRect, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}
	}
}
