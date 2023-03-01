using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000012 RID: 18
	[Guid("e9550983-360b-4f53-b391-afd695078691")]
	public class IVirtualSurfaceImageSourceNative : ISurfaceImageSourceNative
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003D2C File Offset: 0x00001F2C
		public RawRectangle[] UpdateRectangles
		{
			get
			{
				int updateRectCount = this.GetUpdateRectCount();
				RawRectangle[] array = new RawRectangle[updateRectCount];
				this.GetUpdateRects(array, updateRectCount);
				return array;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000098 RID: 152 RVA: 0x00003D50 File Offset: 0x00001F50
		// (remove) Token: 0x06000099 RID: 153 RVA: 0x00003D89 File Offset: 0x00001F89
		public event EventHandler<EventArgs> UpdatesNeeded
		{
			add
			{
				if (this.callback == null)
				{
					this.callback = new IVirtualSurfaceImageSourceNative.VirtualSurfaceUpdatesCallbackNativeCallback(this);
					this.RegisterForUpdatesNeeded(this.callback);
				}
				this.updatesNeeded = (EventHandler<EventArgs>)Delegate.Combine(this.updatesNeeded, value);
			}
			remove
			{
				this.updatesNeeded = (EventHandler<EventArgs>)Delegate.Remove(this.updatesNeeded, value);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003DA2 File Offset: 0x00001FA2
		private void OnUpdatesNeeded()
		{
			if (this.updatesNeeded != null)
			{
				this.updatesNeeded(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003DBD File Offset: 0x00001FBD
		public IVirtualSurfaceImageSourceNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003DC6 File Offset: 0x00001FC6
		public new static explicit operator IVirtualSurfaceImageSourceNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new IVirtualSurfaceImageSourceNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00003DE0 File Offset: 0x00001FE0
		public RawRectangle VisibleBounds
		{
			get
			{
				RawRectangle result;
				this.GetVisibleBounds(out result);
				return result;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003DF8 File Offset: 0x00001FF8
		public unsafe void Invalidate(RawRectangle updateRect)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawRectangle), this._nativePointer, updateRect, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003E30 File Offset: 0x00002030
		internal unsafe int GetUpdateRectCount()
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003E6C File Offset: 0x0000206C
		internal unsafe void GetUpdateRects(RawRectangle[] updates, int count)
		{
			Result result;
			fixed (RawRectangle[] array = updates)
			{
				void* ptr;
				if (updates == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003EC0 File Offset: 0x000020C0
		internal unsafe void GetVisibleBounds(out RawRectangle bounds)
		{
			bounds = default(RawRectangle);
			Result result;
			fixed (RawRectangle* ptr = &bounds)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003F08 File Offset: 0x00002108
		internal unsafe void RegisterForUpdatesNeeded(IVirtualSurfaceUpdatesCallbackNative callback)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IVirtualSurfaceUpdatesCallbackNative>(callback);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003F54 File Offset: 0x00002154
		public unsafe void Resize(int newWidth, int newHeight)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, newWidth, newHeight, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0400000A RID: 10
		private IVirtualSurfaceUpdatesCallbackNative callback;

		// Token: 0x0400000B RID: 11
		private EventHandler<EventArgs> updatesNeeded;

		// Token: 0x02000013 RID: 19
		private class VirtualSurfaceUpdatesCallbackNativeCallback : CallbackBase, IVirtualSurfaceUpdatesCallbackNative, IUnknown, ICallbackable, IDisposable
		{
			// Token: 0x060000A4 RID: 164 RVA: 0x00003F8E File Offset: 0x0000218E
			public VirtualSurfaceUpdatesCallbackNativeCallback(IVirtualSurfaceImageSourceNative eventCallbackArg)
			{
				this.eventCallback = eventCallbackArg;
			}

			// Token: 0x060000A5 RID: 165 RVA: 0x00003F9D File Offset: 0x0000219D
			public void UpdatesNeeded()
			{
				this.eventCallback.OnUpdatesNeeded();
			}

			// Token: 0x0400000C RID: 12
			private IVirtualSurfaceImageSourceNative eventCallback;
		}
	}
}
