using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CC RID: 460
	[Guid("d37f57e4-6908-459f-a199-e72f24f79987")]
	public class DeviceContext1 : DeviceContext
	{
		// Token: 0x06000931 RID: 2353 RVA: 0x0001A557 File Offset: 0x00018757
		public DeviceContext1(Device1 device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001A56C File Offset: 0x0001876C
		public DeviceContext1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001A575 File Offset: 0x00018775
		public new static explicit operator DeviceContext1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001A58C File Offset: 0x0001878C
		internal unsafe void CreateFilledGeometryRealization(Geometry geometry, float flatteningTolerance, GeometryRealization geometryRealization)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, flatteningTolerance, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)92 * (IntPtr)sizeof(void*)));
			geometryRealization.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001A5E8 File Offset: 0x000187E8
		internal unsafe void CreateStrokedGeometryRealization(Geometry geometry, float flatteningTolerance, float strokeWidth, StrokeStyle strokeStyle, GeometryRealization geometryRealization)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Single,System.Single,System.Void*,System.Void*), this._nativePointer, (void*)value, flatteningTolerance, strokeWidth, (void*)value2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)93 * (IntPtr)sizeof(void*)));
			geometryRealization.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001A65C File Offset: 0x0001885C
		public unsafe void DrawGeometryRealization(GeometryRealization geometryRealization, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GeometryRealization>(geometryRealization);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)94 * (IntPtr)sizeof(void*)));
		}
	}
}
