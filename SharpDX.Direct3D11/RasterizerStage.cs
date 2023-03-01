using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001F RID: 31
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class RasterizerStage : CppObject
	{
		// Token: 0x060001BA RID: 442 RVA: 0x00007DE4 File Offset: 0x00005FE4
		public T[] GetViewports<T>() where T : struct
		{
			if (Utilities.SizeOf<T>() != Utilities.SizeOf<RawViewportF>())
			{
				throw new ArgumentException("Type T must have same size and layout as RawViewPortF", "viewports");
			}
			int num = 0;
			this.GetViewports(ref num, IntPtr.Zero);
			T[] array = new T[num];
			this.GetViewports<T>(array);
			return array;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00007E2C File Offset: 0x0000602C
		public unsafe void GetViewports<T>(T[] viewports) where T : struct
		{
			if (Utilities.SizeOf<T>() != Utilities.SizeOf<RawViewportF>())
			{
				throw new ArgumentException("Type T must have same size and layout as RawViewPortF", "viewports");
			}
			int num = viewports.Length;
			fixed (T* ptr = &viewports[0])
			{
				void* value = (void*)ptr;
				this.GetViewports(ref num, new IntPtr(value));
				return;
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00007E74 File Offset: 0x00006074
		public T[] GetScissorRectangles<T>() where T : struct
		{
			int num = 0;
			this.GetScissorRects(ref num, IntPtr.Zero);
			T[] array = new T[num];
			this.GetScissorRectangles<T>(array);
			return array;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00007EA0 File Offset: 0x000060A0
		public unsafe void GetScissorRectangles<T>(T[] scissorRectangles) where T : struct
		{
			if (Utilities.SizeOf<T>() != Utilities.SizeOf<RawRectangle>())
			{
				throw new ArgumentException("Type T must have same size and layout as RawRectangle", "scissorRectangles");
			}
			int num = scissorRectangles.Length;
			fixed (T* ptr = &scissorRectangles[0])
			{
				void* value = (void*)ptr;
				this.GetScissorRects(ref num, new IntPtr(value));
				return;
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00007EE8 File Offset: 0x000060E8
		public unsafe void SetScissorRectangle(int left, int top, int right, int bottom)
		{
			RawRectangle rawRectangle = new RawRectangle
			{
				Left = left,
				Top = top,
				Right = right,
				Bottom = bottom
			};
			this.SetScissorRects(1, new IntPtr((void*)(&rawRectangle)));
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00007F30 File Offset: 0x00006130
		public unsafe void SetScissorRectangles<T>(params T[] scissorRectangles) where T : struct
		{
			if (Utilities.SizeOf<T>() != Utilities.SizeOf<RawRectangle>())
			{
				throw new ArgumentException("Type T must have same size and layout as RawRectangle", "viewports");
			}
			void* ptr2;
			if (scissorRectangles != null)
			{
				fixed (T* ptr = &scissorRectangles[0])
				{
					ptr2 = (void*)ptr;
				}
			}
			else
			{
				ptr2 = null;
			}
			void* value = ptr2;
			this.SetScissorRects((scissorRectangles == null) ? 0 : scissorRectangles.Length, (IntPtr)value);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007F80 File Offset: 0x00006180
		public unsafe void SetViewport(float x, float y, float width, float height, float minZ = 0f, float maxZ = 1f)
		{
			RawViewportF rawViewportF = new RawViewportF
			{
				X = x,
				Y = y,
				Width = width,
				Height = height,
				MinDepth = minZ,
				MaxDepth = maxZ
			};
			this.SetViewports(1, new IntPtr((void*)(&rawViewportF)));
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00007FDC File Offset: 0x000061DC
		public unsafe void SetViewport(RawViewportF viewport)
		{
			int numViewports = 1;
			fixed (RawViewportF* value = &viewport)
			{
				this.SetViewports(numViewports, new IntPtr((void*)value));
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00007FFC File Offset: 0x000061FC
		public unsafe void SetViewports(RawViewportF[] viewports, int count = 0)
		{
			void* ptr2;
			if (viewports != null)
			{
				fixed (RawViewportF* ptr = &viewports[0])
				{
					ptr2 = (void*)ptr;
				}
			}
			else
			{
				ptr2 = null;
			}
			void* value = ptr2;
			this.SetViewports((viewports == null) ? 0 : ((count <= 0) ? viewports.Length : count), (IntPtr)value);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00008036 File Offset: 0x00006236
		public unsafe void SetViewports(RawViewportF* viewports, int count = 0)
		{
			this.SetViewports(count, (IntPtr)((void*)viewports));
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000543D File Offset: 0x0000363D
		public RasterizerStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00008045 File Offset: 0x00006245
		public static explicit operator RasterizerStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RasterizerStage(nativePtr);
			}
			return null;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000805C File Offset: 0x0000625C
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00008072 File Offset: 0x00006272
		public RasterizerState State
		{
			get
			{
				RasterizerState result;
				this.GetState(out result);
				return result;
			}
			set
			{
				this.SetState(value);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000807C File Offset: 0x0000627C
		internal unsafe void SetState(RasterizerState rasterizerStateRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RasterizerState>(rasterizerStateRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000080BA File Offset: 0x000062BA
		internal unsafe void SetViewports(int numViewports, IntPtr viewportsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, numViewports, (void*)viewportsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000080E1 File Offset: 0x000062E1
		internal unsafe void SetScissorRects(int numRects, IntPtr rectsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, numRects, (void*)rectsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008108 File Offset: 0x00006308
		internal unsafe void GetState(out RasterizerState rasterizerStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)94 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				rasterizerStateOut = new RasterizerState(zero);
				return;
			}
			rasterizerStateOut = null;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00008158 File Offset: 0x00006358
		internal unsafe void GetViewports(ref int numViewportsRef, IntPtr viewportsRef)
		{
			fixed (int* ptr = &numViewportsRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (void*)viewportsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)95 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00008194 File Offset: 0x00006394
		internal unsafe void GetScissorRects(ref int numRectsRef, IntPtr rectsRef)
		{
			fixed (int* ptr = &numRectsRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (void*)rectsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)96 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
