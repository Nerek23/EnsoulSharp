using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C1 RID: 193
	[Guid("ba0b762d-7d28-43ec-b9dc-2f84443b0614")]
	public class Sprite : ComObject
	{
		// Token: 0x060005D3 RID: 1491 RVA: 0x00002623 File Offset: 0x00000823
		public Sprite(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000151F4 File Offset: 0x000133F4
		public new static explicit operator Sprite(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Sprite(nativePointer);
			}
			return null;
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0001520C File Offset: 0x0001340C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00015224 File Offset: 0x00013424
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x0001523A File Offset: 0x0001343A
		public RawMatrix Transform
		{
			get
			{
				RawMatrix result;
				this.GetTransform(out result);
				return result;
			}
			set
			{
				this.SetTransform(ref value);
			}
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00015244 File Offset: 0x00013444
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001529C File Offset: 0x0001349C
		internal unsafe void GetTransform(out RawMatrix transformRef)
		{
			transformRef = default(RawMatrix);
			Result result;
			fixed (RawMatrix* ptr = &transformRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000152E4 File Offset: 0x000134E4
		internal unsafe void SetTransform(ref RawMatrix transformRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &transformRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00015324 File Offset: 0x00013524
		public unsafe void SetWorldViewRH(ref RawMatrix worldRef, ref RawMatrix viewRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &worldRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawMatrix* ptr3 = &viewRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00015370 File Offset: 0x00013570
		public unsafe void SetWorldViewLH(ref RawMatrix worldRef, ref RawMatrix viewRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &worldRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawMatrix* ptr3 = &viewRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000153BC File Offset: 0x000135BC
		public unsafe void Begin(SpriteFlags flags = SpriteFlags.None)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000153F4 File Offset: 0x000135F4
		internal unsafe void Draw(Texture textureRef, IntPtr srcRectRef, IntPtr centerRef, IntPtr positionRef, RawColorBGRA color)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawColorBGRA), this._nativePointer, (void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), (void*)srcRectRef, (void*)centerRef, (void*)positionRef, color, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00015458 File Offset: 0x00013658
		public unsafe void Flush()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00015490 File Offset: 0x00013690
		public unsafe void End()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000154C8 File Offset: 0x000136C8
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00015500 File Offset: 0x00013700
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00015538 File Offset: 0x00013738
		public Sprite(Device device)
		{
			D3DX9.CreateSprite(device, this);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00015547 File Offset: 0x00013747
		public void Draw(Texture textureRef, RawColorBGRA color)
		{
			this.Draw(textureRef, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, color);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00015560 File Offset: 0x00013760
		public unsafe void Draw(Texture textureRef, RawColorBGRA color, RawRectangle? srcRectRef = null, RawVector3? centerRef = null, RawVector3? positionRef = null)
		{
			RawRectangle rawRectangle = default(RawRectangle);
			if (srcRectRef != null)
			{
				rawRectangle = srcRectRef.Value;
			}
			RawVector3 value;
			if (centerRef != null)
			{
				value = centerRef.Value;
			}
			RawVector3 value2;
			if (positionRef != null)
			{
				value2 = positionRef.Value;
			}
			this.Draw(textureRef, (srcRectRef != null) ? ((IntPtr)((void*)(&rawRectangle))) : IntPtr.Zero, (centerRef != null) ? ((IntPtr)((void*)(&value))) : IntPtr.Zero, (positionRef != null) ? ((IntPtr)((void*)(&value2))) : IntPtr.Zero, color);
		}
	}
}
