using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000AD RID: 173
	internal static class D3D11
	{
		// Token: 0x0600035A RID: 858 RVA: 0x0000D534 File Offset: 0x0000B734
		public unsafe static Result CreateDevice(Adapter adapterRef, DriverType driverType, IntPtr software, DeviceCreationFlags flags, FeatureLevel[] featureLevelsRef, int featureLevels, int sDKVersion, Device deviceOut, out FeatureLevel featureLevelRef, out DeviceContext immediateContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			IntPtr value = CppObject.ToCallbackPtr<Adapter>(adapterRef);
			Result result;
			fixed (FeatureLevel* ptr = &featureLevelRef)
			{
				void* param = (void*)ptr;
				fixed (FeatureLevel[] array = featureLevelsRef)
				{
					void* param2;
					if (featureLevelsRef == null || array.Length == 0)
					{
						param2 = null;
					}
					else
					{
						param2 = (void*)(&array[0]);
					}
					result = D3D11.D3D11CreateDevice_((void*)value, (int)driverType, (void*)software, (int)flags, param2, featureLevels, sDKVersion, (void*)(&zero2), param, (void*)(&zero3));
				}
			}
			deviceOut.NativePointer = zero2;
			if (zero3 != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext(zero3);
				return result;
			}
			immediateContextOut = null;
			return result;
		}

		// Token: 0x0600035B RID: 859
		[DllImport("d3d11.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3D11CreateDevice")]
		private unsafe static extern int D3D11CreateDevice_(void* param0, int param1, void* param2, int param3, void* param4, int param5, int param6, void* param7, void* param8, void* param9);

		// Token: 0x0600035C RID: 860 RVA: 0x0000D5CC File Offset: 0x0000B7CC
		public unsafe static void On12CreateDevice(IUnknown deviceRef, DeviceCreationFlags flags, FeatureLevel[] featureLevelsRef, int featureLevels, IUnknown[] commandQueuesOut, int numQueues, int nodeMask, out Device deviceOut, out DeviceContext immediateContextOut, out FeatureLevel chosenFeatureLevelRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (commandQueuesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)commandQueuesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			if (commandQueuesOut != null)
			{
				for (int i = 0; i < commandQueuesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<IUnknown>(commandQueuesOut[i]);
				}
			}
			Result result;
			fixed (FeatureLevel* ptr2 = &chosenFeatureLevelRef)
			{
				void* param = (void*)ptr2;
				fixed (FeatureLevel[] array = featureLevelsRef)
				{
					void* param2;
					if (featureLevelsRef == null || array.Length == 0)
					{
						param2 = null;
					}
					else
					{
						param2 = (void*)(&array[0]);
					}
					result = D3D11.D3D11On12CreateDevice_((void*)value, (int)flags, param2, featureLevels, (void*)ptr, numQueues, nodeMask, (void*)(&zero), (void*)(&zero2), param);
				}
			}
			if (zero != IntPtr.Zero)
			{
				deviceOut = new Device(zero);
			}
			else
			{
				deviceOut = null;
			}
			if (zero2 != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext(zero2);
			}
			else
			{
				immediateContextOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600035D RID: 861
		[DllImport("d3d11.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3D11On12CreateDevice")]
		private unsafe static extern int D3D11On12CreateDevice_(void* param0, int param1, void* param2, int param3, void* param4, int param5, int param6, void* param7, void* param8, void* param9);

		// Token: 0x04000898 RID: 2200
		public const int SdkVersion = 7;
	}
}
