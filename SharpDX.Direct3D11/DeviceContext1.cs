using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000021 RID: 33
	[Guid("bb2c6faa-b5fb-4082-8e6b-388b8cfa90e1")]
	public class DeviceContext1 : DeviceContext
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x000083D0 File Offset: 0x000065D0
		public DeviceContext1(Device1 device) : base(IntPtr.Zero)
		{
			device.CreateDeferredContext1(0, this);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000083E5 File Offset: 0x000065E5
		public void ClearView(ResourceView viewRef, RawColor4 color, params RawRectangle[] rectangles)
		{
			this.ClearView(viewRef, color, rectangles, rectangles.Length);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000083F3 File Offset: 0x000065F3
		public DeviceContext1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000083FC File Offset: 0x000065FC
		public new static explicit operator DeviceContext1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext1(nativePtr);
			}
			return null;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00008414 File Offset: 0x00006614
		public unsafe void CopySubresourceRegion1(Resource dstResourceRef, int dstSubresource, int dstX, int dstY, int dstZ, Resource srcResourceRef, int srcSubresource, ResourceRegion? srcBoxRef, int copyFlags)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(srcResourceRef);
			ResourceRegion value3;
			if (srcBoxRef != null)
			{
				value3 = srcBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, (void*)value, dstSubresource, dstX, dstY, dstZ, (void*)value2, srcSubresource, (srcBoxRef == null) ? null : (&value3), copyFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)115 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00008494 File Offset: 0x00006694
		public unsafe void UpdateSubresource1(Resource dstResourceRef, int dstSubresource, ResourceRegion? dstBoxRef, IntPtr srcDataRef, int srcRowPitch, int srcDepthPitch, int copyFlags)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			ResourceRegion value2;
			if (dstBoxRef != null)
			{
				value2 = dstBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, (void*)value, dstSubresource, (dstBoxRef == null) ? null : (&value2), (void*)srcDataRef, srcRowPitch, srcDepthPitch, copyFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)116 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00008504 File Offset: 0x00006704
		public unsafe void DiscardResource(Resource resourceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)117 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00008544 File Offset: 0x00006744
		public unsafe void DiscardView(ResourceView resourceViewRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ResourceView>(resourceViewRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)118 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00008584 File Offset: 0x00006784
		public unsafe void VSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)119 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000862C File Offset: 0x0000682C
		public unsafe void HSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)120 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000086D4 File Offset: 0x000068D4
		public unsafe void DSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)121 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000877C File Offset: 0x0000697C
		public unsafe void GSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)122 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008824 File Offset: 0x00006A24
		public unsafe void PSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)123 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x000088CC File Offset: 0x00006ACC
		public unsafe void CSSetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Buffer>(constantBuffersOut[i]);
				}
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)124 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008974 File Offset: 0x00006B74
		public unsafe void VSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)125 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008A40 File Offset: 0x00006C40
		public unsafe void HSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)126 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008B0C File Offset: 0x00006D0C
		public unsafe void DSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)127 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public unsafe void GSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)128 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008CA4 File Offset: 0x00006EA4
		public unsafe void PSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)129 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00008D70 File Offset: 0x00006F70
		public unsafe void CSGetConstantBuffers1(int startSlot, int numBuffers, Buffer[] constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = numConstantsRef)
			{
				void* ptr2;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr3;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)130 * (IntPtr)sizeof(void*)));
				}
			}
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008E3C File Offset: 0x0000703C
		public unsafe void SwapDeviceContextState(DeviceContextState stateRef, out DeviceContextState previousStateOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DeviceContextState>(stateRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)131 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				previousStateOut = new DeviceContextState(zero);
				return;
			}
			previousStateOut = null;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00008EA0 File Offset: 0x000070A0
		public unsafe void ClearView(ResourceView viewRef, RawColor4 color, RawRectangle[] rectRef, int numRects)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ResourceView>(viewRef);
			fixed (RawRectangle[] array = rectRef)
			{
				void* ptr;
				if (rectRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, &color, ptr, numRects, *(*(IntPtr*)this._nativePointer + (IntPtr)132 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008F04 File Offset: 0x00007104
		public unsafe void DiscardView1(ResourceView resourceViewRef, RawRectangle[] rectsRef, int numRects)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ResourceView>(resourceViewRef);
			fixed (RawRectangle[] array = rectsRef)
			{
				void* ptr;
				if (rectsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numRects, *(*(IntPtr*)this._nativePointer + (IntPtr)133 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00008F64 File Offset: 0x00007164
		public unsafe void VSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)119 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008FE0 File Offset: 0x000071E0
		private unsafe void VSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)119 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00009024 File Offset: 0x00007224
		public unsafe void HSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)120 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000090A0 File Offset: 0x000072A0
		private unsafe void HSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)120 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000090E4 File Offset: 0x000072E4
		public unsafe void DSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)121 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00009160 File Offset: 0x00007360
		private unsafe void DSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)121 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000091A4 File Offset: 0x000073A4
		public unsafe void GSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)122 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00009220 File Offset: 0x00007420
		private unsafe void GSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)122 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00009264 File Offset: 0x00007464
		public unsafe void PSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)123 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000092E0 File Offset: 0x000074E0
		private unsafe void PSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)123 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00009324 File Offset: 0x00007524
		public unsafe void CSSetConstantBuffers1(int startSlot, int numBuffers, ComArray<Buffer> constantBuffersOut, int[] firstConstantRef, int[] numConstantsRef)
		{
			fixed (int[] array = numConstantsRef)
			{
				void* ptr;
				if (numConstantsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = firstConstantRef)
				{
					void* ptr2;
					if (firstConstantRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)((constantBuffersOut != null) ? constantBuffersOut.NativePointer : IntPtr.Zero), ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)124 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000093A0 File Offset: 0x000075A0
		private unsafe void CSSetConstantBuffers1(int startSlot, int numBuffers, IntPtr constantBuffersOut, IntPtr firstConstantRef, IntPtr numConstantsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, (void*)firstConstantRef, (void*)numConstantsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)124 * (IntPtr)sizeof(void*)));
		}
	}
}
