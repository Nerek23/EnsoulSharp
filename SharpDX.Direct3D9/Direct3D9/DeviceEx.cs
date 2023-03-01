using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000018 RID: 24
	[Guid("B18B10CE-2649-405a-870F-95F777D4313A")]
	public class DeviceEx : Device
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00008471 File Offset: 0x00006671
		public DeviceEx(Direct3DEx direct3D, int adapter, DeviceType deviceType, IntPtr controlHandle, CreateFlags createFlags, params PresentParameters[] presentParameters) : base(IntPtr.Zero)
		{
			direct3D.CreateDeviceEx(adapter, deviceType, controlHandle, (int)createFlags, presentParameters, null, this);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008490 File Offset: 0x00006690
		public DeviceEx(Direct3DEx direct3D, int adapter, DeviceType deviceType, IntPtr controlHandle, CreateFlags createFlags, PresentParameters presentParameters) : base(IntPtr.Zero)
		{
			direct3D.CreateDeviceEx(adapter, deviceType, controlHandle, (int)createFlags, new PresentParameters[]
			{
				presentParameters
			}, null, this);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000084C8 File Offset: 0x000066C8
		public DeviceEx(Direct3DEx direct3D, int adapter, DeviceType deviceType, IntPtr controlHandle, CreateFlags createFlags, PresentParameters presentParameters, DisplayModeEx fullScreenDisplayMode) : base(IntPtr.Zero)
		{
			PresentParameters[] presentationParametersRef = new PresentParameters[]
			{
				presentParameters
			};
			DisplayModeEx[] fullscreenDisplayModeRef;
			if (fullScreenDisplayMode != null)
			{
				(fullscreenDisplayModeRef = new DisplayModeEx[1])[0] = fullScreenDisplayMode;
			}
			else
			{
				fullscreenDisplayModeRef = null;
			}
			direct3D.CreateDeviceEx(adapter, deviceType, controlHandle, (int)createFlags, presentationParametersRef, fullscreenDisplayModeRef, this);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000850E File Offset: 0x0000670E
		public DeviceEx(Direct3DEx direct3D, int adapter, DeviceType deviceType, IntPtr controlHandle, CreateFlags createFlags, PresentParameters[] presentParameters, DisplayModeEx[] fullScreenDisplayMode) : base(IntPtr.Zero)
		{
			direct3D.CreateDeviceEx(adapter, deviceType, controlHandle, (int)createFlags, presentParameters, fullScreenDisplayMode, this);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000852C File Offset: 0x0000672C
		public DeviceState CheckDeviceState(IntPtr windowHandle)
		{
			return (DeviceState)this.CheckDeviceState_(windowHandle).Code;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008548 File Offset: 0x00006748
		public ResourceResidency CheckResourceResidency(params Resource[] resources)
		{
			return (ResourceResidency)this.CheckResourceResidency(resources, resources.Length).Code;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00008567 File Offset: 0x00006767
		public DisplayModeEx GetDisplayModeEx(int swapChain)
		{
			return this.GetDisplayModeEx(swapChain, IntPtr.Zero);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008578 File Offset: 0x00006778
		public unsafe DisplayModeEx GetDisplayModeEx(int swapChain, out DisplayRotation rotation)
		{
			fixed (DisplayRotation* ptr = &rotation)
			{
				void* value = (void*)ptr;
				return this.GetDisplayModeEx(swapChain, (IntPtr)value);
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00008597 File Offset: 0x00006797
		public void PresentEx(Present flags)
		{
			this.PresentEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (int)flags);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000085B4 File Offset: 0x000067B4
		public void PresentEx(Present flags, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			this.PresentEx(flags, sourceRectangle, destinationRectangle, IntPtr.Zero);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000085C4 File Offset: 0x000067C4
		public unsafe void PresentEx(Present flags, RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride)
		{
			this.PresentEx(new IntPtr((void*)(&sourceRectangle)), new IntPtr((void*)(&destinationRectangle)), windowOverride, IntPtr.Zero, (int)flags);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000085E4 File Offset: 0x000067E4
		public unsafe void PresentEx(Present flags, RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride, IntPtr dirtyRegionRGNData)
		{
			this.PresentEx(new IntPtr((void*)(&sourceRectangle)), new IntPtr((void*)(&destinationRectangle)), windowOverride, dirtyRegionRGNData, (int)flags);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00008601 File Offset: 0x00006801
		public void ResetEx(ref PresentParameters presentationParametersRef)
		{
			this.ResetEx(ref presentationParametersRef, IntPtr.Zero);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008610 File Offset: 0x00006810
		public unsafe void ResetEx(ref PresentParameters presentationParametersRef, DisplayModeEx fullScreenDisplayMode)
		{
			DisplayModeEx.__Native _Native = DisplayModeEx.__NewNative();
			fullScreenDisplayMode.__MarshalTo(ref _Native);
			this.ResetEx(ref presentationParametersRef, new IntPtr((void*)(&_Native)));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000863A File Offset: 0x0000683A
		public DeviceEx(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00008643 File Offset: 0x00006843
		public new static explicit operator DeviceEx(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new DeviceEx(nativePointer);
			}
			return null;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000865C File Offset: 0x0000685C
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00008672 File Offset: 0x00006872
		public int GPUThreadPriority
		{
			get
			{
				int result;
				this.GetGPUThreadPriority(out result);
				return result;
			}
			set
			{
				this.SetGPUThreadPriority(value);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x0000867C File Offset: 0x0000687C
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00008692 File Offset: 0x00006892
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

		// Token: 0x060001FB RID: 507 RVA: 0x0000869C File Offset: 0x0000689C
		public unsafe void SetConvolutionMonoKernel(int width, int height, float[] rows, float[] columns)
		{
			Result result;
			fixed (float[] array = rows)
			{
				void* ptr;
				if (rows == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (float[] array2 = columns)
				{
					void* ptr2;
					if (columns == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, width, height, ptr, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)119 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00008714 File Offset: 0x00006914
		public unsafe void ComposeRects(Surface srcRef, Surface dstRef, VertexBuffer srcRectDescsRef, int numRects, VertexBuffer dstRectDescsRef, ComposeRectOperation operation, int xoffset, int yoffset)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, (void*)((srcRef == null) ? IntPtr.Zero : srcRef.NativePointer), (void*)((dstRef == null) ? IntPtr.Zero : dstRef.NativePointer), (void*)((srcRectDescsRef == null) ? IntPtr.Zero : srcRectDescsRef.NativePointer), numRects, (void*)((dstRectDescsRef == null) ? IntPtr.Zero : dstRectDescsRef.NativePointer), operation, xoffset, yoffset, *(*(IntPtr*)this._nativePointer + (IntPtr)120 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000087AC File Offset: 0x000069AC
		internal unsafe void PresentEx(IntPtr sourceRectRef, IntPtr destRectRef, IntPtr hDestWindowOverride, IntPtr dirtyRegionRef, int dwFlags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)sourceRectRef, (void*)destRectRef, (void*)hDestWindowOverride, (void*)dirtyRegionRef, dwFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)121 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00008800 File Offset: 0x00006A00
		internal unsafe void GetGPUThreadPriority(out int priorityRef)
		{
			Result result;
			fixed (int* ptr = &priorityRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)122 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00008844 File Offset: 0x00006A44
		internal unsafe void SetGPUThreadPriority(int priority)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, priority, *(*(IntPtr*)this._nativePointer + (IntPtr)123 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00008880 File Offset: 0x00006A80
		public unsafe void WaitForVBlank(int iSwapChain)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, iSwapChain, *(*(IntPtr*)this._nativePointer + (IntPtr)124 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000088BC File Offset: 0x00006ABC
		internal unsafe Result CheckResourceResidency(Resource[] resourceArrayRef, int numResources)
		{
			IntPtr* ptr = null;
			if (resourceArrayRef != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)resourceArrayRef.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < resourceArrayRef.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((resourceArrayRef[i] == null) ? IntPtr.Zero : resourceArrayRef[i].NativePointer);
				}
			}
			return calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)125 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00008930 File Offset: 0x00006B30
		internal unsafe Result CheckResourceResidency(ComArray<Resource> resourceArrayRef, int numResources)
		{
			return calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((resourceArrayRef == null) ? IntPtr.Zero : resourceArrayRef.NativePointer), numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)125 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000896B File Offset: 0x00006B6B
		private unsafe Result CheckResourceResidency(IntPtr resourceArrayRef, int numResources)
		{
			return calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)resourceArrayRef, numResources, *(*(IntPtr*)this._nativePointer + (IntPtr)125 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00008998 File Offset: 0x00006B98
		internal unsafe void SetMaximumFrameLatency(int maxLatency)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, maxLatency, *(*(IntPtr*)this._nativePointer + (IntPtr)126 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000089D4 File Offset: 0x00006BD4
		internal unsafe void GetMaximumFrameLatency(out int maxLatencyRef)
		{
			Result result;
			fixed (int* ptr = &maxLatencyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)127 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00008A15 File Offset: 0x00006C15
		internal unsafe Result CheckDeviceState_(IntPtr hDestinationWindow)
		{
			return calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)hDestinationWindow, *(*(IntPtr*)this._nativePointer + (IntPtr)128 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00008A44 File Offset: 0x00006C44
		internal unsafe Surface CreateRenderTargetEx(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, RawBool lockable, IntPtr sharedHandleRef, int usage)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Int32), this._nativePointer, width, height, format, multiSample, multisampleQuality, lockable, &zero, (void*)sharedHandleRef, usage, *(*(IntPtr*)this._nativePointer + (IntPtr)129 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00008AB0 File Offset: 0x00006CB0
		internal unsafe Surface CreateOffscreenPlainSurfaceEx(int width, int height, Format format, Pool pool, IntPtr sharedHandleRef, int usage)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, width, height, format, pool, &zero, (void*)sharedHandleRef, usage, *(*(IntPtr*)this._nativePointer + (IntPtr)130 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00008B18 File Offset: 0x00006D18
		internal unsafe Surface CreateDepthStencilSurfaceEx(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, RawBool discard, IntPtr sharedHandleRef, int usage)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Int32), this._nativePointer, width, height, format, multiSample, multisampleQuality, discard, &zero, (void*)sharedHandleRef, usage, *(*(IntPtr*)this._nativePointer + (IntPtr)131 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00008B84 File Offset: 0x00006D84
		internal unsafe void ResetEx(ref PresentParameters presentationParametersRef, IntPtr fullscreenDisplayModeRef)
		{
			Result result;
			fixed (PresentParameters* ptr = &presentationParametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (void*)fullscreenDisplayModeRef, *(*(IntPtr*)this._nativePointer + (IntPtr)132 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00008BD0 File Offset: 0x00006DD0
		internal unsafe DisplayModeEx GetDisplayModeEx(int iSwapChain, IntPtr rotationRef)
		{
			DisplayModeEx.__Native _Native = DisplayModeEx.__NewNative();
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, iSwapChain, &_Native, (void*)rotationRef, *(*(IntPtr*)this._nativePointer + (IntPtr)133 * (IntPtr)sizeof(void*)));
			DisplayModeEx displayModeEx = new DisplayModeEx();
			displayModeEx.__MarshalFrom(ref _Native);
			result.CheckError();
			return displayModeEx;
		}
	}
}
