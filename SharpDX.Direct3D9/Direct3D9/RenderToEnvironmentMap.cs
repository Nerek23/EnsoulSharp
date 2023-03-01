using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BC RID: 188
	[Guid("313f1b4b-c7b0-4fa2-9d9d-8d380b64385e")]
	public class RenderToEnvironmentMap : ComObject
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x00002623 File Offset: 0x00000823
		public RenderToEnvironmentMap(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00013F22 File Offset: 0x00012122
		public new static explicit operator RenderToEnvironmentMap(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new RenderToEnvironmentMap(nativePointer);
			}
			return null;
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x00013F3C File Offset: 0x0001213C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x00013F54 File Offset: 0x00012154
		public RenderToEnvironmentMapDescription Description
		{
			get
			{
				RenderToEnvironmentMapDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00013F6C File Offset: 0x0001216C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00013FC4 File Offset: 0x000121C4
		internal unsafe void GetDescription(out RenderToEnvironmentMapDescription descRef)
		{
			descRef = default(RenderToEnvironmentMapDescription);
			Result result;
			fixed (RenderToEnvironmentMapDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001400C File Offset: 0x0001220C
		public unsafe void BeginCube(CubeTexture cubeTexRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((cubeTexRef == null) ? IntPtr.Zero : cubeTexRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00014058 File Offset: 0x00012258
		public unsafe void BeginSphere(Texture texRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((texRef == null) ? IntPtr.Zero : texRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x000140A4 File Offset: 0x000122A4
		public unsafe void BeginHemisphere(Texture texZPosRef, Texture texZNegRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((texZPosRef == null) ? IntPtr.Zero : texZPosRef.NativePointer), (void*)((texZNegRef == null) ? IntPtr.Zero : texZNegRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00014108 File Offset: 0x00012308
		public unsafe void BeginParabolic(Texture texZPosRef, Texture texZNegRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((texZPosRef == null) ? IntPtr.Zero : texZPosRef.NativePointer), (void*)((texZNegRef == null) ? IntPtr.Zero : texZNegRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001416C File Offset: 0x0001236C
		public unsafe void Face(CubeMapFace face, int mipFilter)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, face, mipFilter, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000141A8 File Offset: 0x000123A8
		public unsafe void End(int mipFilter)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, mipFilter, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000141E4 File Offset: 0x000123E4
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001421C File Offset: 0x0001241C
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
