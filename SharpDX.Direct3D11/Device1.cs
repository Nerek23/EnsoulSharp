using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000014 RID: 20
	[Guid("a04bfb29-08ef-43d6-a49c-a9bdbdcbe686")]
	public class Device1 : Device
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00004708 File Offset: 0x00002908
		public DeviceContextState CreateDeviceContextState<T>(CreateDeviceContextStateFlags flags, FeatureLevel[] featureLevelsRef, out FeatureLevel chosenFeatureLevelRef) where T : ComObject
		{
			DeviceContextState deviceContextState = new DeviceContextState(IntPtr.Zero);
			this.CreateDeviceContextState(flags, featureLevelsRef, featureLevelsRef.Length, 7, Utilities.GetGuidFromType(typeof(T)), out chosenFeatureLevelRef, deviceContextState);
			return deviceContextState;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004740 File Offset: 0x00002940
		public T OpenSharedResource1<T>(IntPtr resourceHandle) where T : ComObject
		{
			IntPtr comObjectPtr;
			this.OpenSharedResource1(resourceHandle, Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000476C File Offset: 0x0000296C
		public T OpenSharedResource1<T>(string name, SharedResourceFlags desiredAccess) where T : ComObject
		{
			IntPtr comObjectPtr;
			this.OpenSharedResourceByName(name, desiredAccess, Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004798 File Offset: 0x00002998
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.ImmediateContext1__ != null)
			{
				this.ImmediateContext1__.Dispose();
				this.ImmediateContext1__ = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000047BE File Offset: 0x000029BE
		public Device1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000047C7 File Offset: 0x000029C7
		public new static explicit operator Device1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000047DE File Offset: 0x000029DE
		public DeviceContext1 ImmediateContext1
		{
			get
			{
				if (this.ImmediateContext1__ == null)
				{
					this.GetImmediateContext1(out this.ImmediateContext1__);
				}
				return this.ImmediateContext1__;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000047FC File Offset: 0x000029FC
		internal unsafe void GetImmediateContext1(out DeviceContext1 immediateContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext1(zero);
				return;
			}
			immediateContextOut = null;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000484C File Offset: 0x00002A4C
		internal unsafe void CreateDeferredContext1(int contextFlags, DeviceContext1 deferredContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, contextFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
			deferredContextOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004898 File Offset: 0x00002A98
		internal unsafe void CreateBlendState1(ref BlendStateDescription1 blendStateDescRef, BlendState1 blendStateOut)
		{
			BlendStateDescription1.__Native _Native = default(BlendStateDescription1.__Native);
			IntPtr zero = IntPtr.Zero;
			blendStateDescRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
			blendStateOut.NativePointer = zero;
			blendStateDescRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000048FC File Offset: 0x00002AFC
		internal unsafe void CreateRasterizerState1(ref RasterizerStateDescription1 rasterizerDescRef, RasterizerState1 rasterizerStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RasterizerStateDescription1* ptr = &rasterizerDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
			}
			rasterizerStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004950 File Offset: 0x00002B50
		internal unsafe void CreateDeviceContextState(CreateDeviceContextStateFlags flags, FeatureLevel[] featureLevelsRef, int featureLevels, int sDKVersion, Guid emulatedInterface, out FeatureLevel chosenFeatureLevelRef, DeviceContextState contextStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (FeatureLevel* ptr = &chosenFeatureLevelRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (FeatureLevel[] array = featureLevelsRef)
				{
					void* ptr3;
					if (featureLevelsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, flags, ptr3, featureLevels, sDKVersion, &emulatedInterface, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
				}
			}
			contextStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000049CC File Offset: 0x00002BCC
		internal unsafe void OpenSharedResource1(IntPtr hResource, Guid returnedInterface, out IntPtr resourceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &resourceOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hResource, &returnedInterface, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004A18 File Offset: 0x00002C18
		internal unsafe void OpenSharedResourceByName(string lpName, SharedResourceFlags dwDesiredAccess, Guid returnedInterface, out IntPtr resourceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &resourceOut)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = lpName)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr3, dwDesiredAccess, &returnedInterface, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x04000030 RID: 48
		protected internal DeviceContext1 ImmediateContext1__;
	}
}
