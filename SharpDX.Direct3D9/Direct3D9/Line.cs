using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B6 RID: 182
	[Guid("d379ba7f-9042-4ac4-9f5e-58192a4c6bd8")]
	public class Line : ComObject
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00002623 File Offset: 0x00000823
		public Line(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00012845 File Offset: 0x00010A45
		public new static explicit operator Line(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Line(nativePointer);
			}
			return null;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0001285C File Offset: 0x00010A5C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00012872 File Offset: 0x00010A72
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x0001287A File Offset: 0x00010A7A
		public int Pattern
		{
			get
			{
				return this.GetPattern();
			}
			set
			{
				this.SetPattern(value);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00012883 File Offset: 0x00010A83
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x0001288B File Offset: 0x00010A8B
		public float PatternScale
		{
			get
			{
				return this.GetPatternScale();
			}
			set
			{
				this.SetPatternScale(value);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00012894 File Offset: 0x00010A94
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x0001289C File Offset: 0x00010A9C
		public float Width
		{
			get
			{
				return this.GetWidth();
			}
			set
			{
				this.SetWidth(value);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x000128A5 File Offset: 0x00010AA5
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x000128AD File Offset: 0x00010AAD
		public RawBool Antialias
		{
			get
			{
				return this.GetAntialias();
			}
			set
			{
				this.SetAntialias(value);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x000128B6 File Offset: 0x00010AB6
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x000128BE File Offset: 0x00010ABE
		public RawBool GLLines
		{
			get
			{
				return this.GetGLLines();
			}
			set
			{
				this.SetGLLines(value);
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000128C8 File Offset: 0x00010AC8
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00012920 File Offset: 0x00010B20
		public unsafe void Begin()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00012958 File Offset: 0x00010B58
		internal unsafe void Draw(IntPtr vertexListRef, int dwVertexListCount, RawColorBGRA color)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawColorBGRA), this._nativePointer, (void*)vertexListRef, dwVertexListCount, color, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00012998 File Offset: 0x00010B98
		internal unsafe void DrawTransform(IntPtr vertexListRef, int dwVertexListCount, ref RawMatrix transformRef, RawColorBGRA color)
		{
			Result result;
			fixed (RawMatrix* ptr = &transformRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawColorBGRA), this._nativePointer, (void*)vertexListRef, dwVertexListCount, ptr2, color, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x000129E4 File Offset: 0x00010BE4
		internal unsafe void SetPattern(int dwPattern)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, dwPattern, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0001113E File Offset: 0x0000F33E
		internal unsafe int GetPattern()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00012A1C File Offset: 0x00010C1C
		internal unsafe void SetPatternScale(float fPatternScale)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, fPatternScale, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00012A55 File Offset: 0x00010C55
		internal unsafe float GetPatternScale()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00012A78 File Offset: 0x00010C78
		internal unsafe void SetWidth(float fWidth)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, fWidth, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00012AB1 File Offset: 0x00010CB1
		internal unsafe float GetWidth()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00012AD4 File Offset: 0x00010CD4
		internal unsafe void SetAntialias(RawBool bAntialias)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bAntialias, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00012B0D File Offset: 0x00010D0D
		internal unsafe RawBool GetAntialias()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00012B30 File Offset: 0x00010D30
		internal unsafe void SetGLLines(RawBool bGLLines)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bGLLines, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00012B69 File Offset: 0x00010D69
		internal unsafe RawBool GetGLLines()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00012B8C File Offset: 0x00010D8C
		public unsafe void End()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00012BC4 File Offset: 0x00010DC4
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00012BFC File Offset: 0x00010DFC
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00012C34 File Offset: 0x00010E34
		public Line(Device device)
		{
			D3DX9.CreateLine(device, this);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00012C44 File Offset: 0x00010E44
		public unsafe void Draw(RawVector2[] vertices, RawColorBGRA color)
		{
			fixed (RawVector2[] array = vertices)
			{
				void* value;
				if (vertices == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.Draw((IntPtr)value, vertices.Length, color);
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00012C7C File Offset: 0x00010E7C
		public unsafe void Draw<T>(T[] vertices, RawColorBGRA color) where T : struct
		{
			if (Utilities.SizeOf<T>() != sizeof(RawVector2))
			{
				throw new ArgumentException("Invalid size for T. Must be 2 floats (8 bytes)");
			}
			fixed (T* value = &vertices[0])
			{
				this.Draw((IntPtr)((void*)value), vertices.Length, color);
				return;
			}
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00012CBC File Offset: 0x00010EBC
		public unsafe void DrawTransform(RawVector3[] vertices, RawMatrix transform, RawColorBGRA color)
		{
			fixed (RawVector3[] array = vertices)
			{
				void* value;
				if (vertices == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.DrawTransform((IntPtr)value, vertices.Length, ref transform, color);
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00012CF8 File Offset: 0x00010EF8
		public unsafe void DrawTransform<T>(T[] vertices, RawMatrix transform, RawColorBGRA color) where T : struct
		{
			if (Utilities.SizeOf<T>() != sizeof(RawVector3))
			{
				throw new ArgumentException("Invalid size for T. Must be 3 floats (12 bytes)");
			}
			fixed (T* value = &vertices[0])
			{
				this.DrawTransform((IntPtr)((void*)value), vertices.Length, ref transform, color);
				return;
			}
		}
	}
}
