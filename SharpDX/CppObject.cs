using System;

namespace SharpDX
{
	// Token: 0x0200000F RID: 15
	public class CppObject : DisposeBase, ICallbackable, IDisposable
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000028AF File Offset: 0x00000AAF
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000028B7 File Offset: 0x00000AB7
		public object Tag { get; set; }

		// Token: 0x06000050 RID: 80 RVA: 0x000028C0 File Offset: 0x00000AC0
		public CppObject(IntPtr pointer)
		{
			this.NativePointer = pointer;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000028CF File Offset: 0x00000ACF
		protected CppObject()
		{
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000028D7 File Offset: 0x00000AD7
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000028E4 File Offset: 0x00000AE4
		public unsafe IntPtr NativePointer
		{
			get
			{
				return (IntPtr)this._nativePointer;
			}
			set
			{
				void* ptr = (void*)value;
				if (this._nativePointer != ptr)
				{
					this.NativePointerUpdating();
					void* nativePointer = this._nativePointer;
					this._nativePointer = ptr;
					this.NativePointerUpdated((IntPtr)nativePointer);
				}
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002921 File Offset: 0x00000B21
		public static explicit operator IntPtr(CppObject cppObject)
		{
			if (cppObject != null)
			{
				return cppObject.NativePointer;
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002932 File Offset: 0x00000B32
		protected void FromTemp(CppObject temp)
		{
			this.NativePointer = temp.NativePointer;
			temp.NativePointer = IntPtr.Zero;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000294B File Offset: 0x00000B4B
		protected void FromTemp(IntPtr temp)
		{
			this.NativePointer = temp;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000022F0 File Offset: 0x000004F0
		protected virtual void NativePointerUpdating()
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000022F0 File Offset: 0x000004F0
		protected virtual void NativePointerUpdated(IntPtr oldNativePointer)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000022F0 File Offset: 0x000004F0
		protected override void Dispose(bool disposing)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002954 File Offset: 0x00000B54
		public static T FromPointer<T>(IntPtr comObjectPtr) where T : CppObject
		{
			if (!(comObjectPtr == IntPtr.Zero))
			{
				return (T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					comObjectPtr
				}));
			}
			return default(T);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000299B File Offset: 0x00000B9B
		internal static T FromPointerUnsafe<T>(IntPtr comObjectPtr)
		{
			if (!(comObjectPtr == IntPtr.Zero))
			{
				return (T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					comObjectPtr
				}));
			}
			return (T)((object)null);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000029D4 File Offset: 0x00000BD4
		public static IntPtr ToCallbackPtr<TCallback>(ICallbackable callback) where TCallback : ICallbackable
		{
			if (callback == null)
			{
				return IntPtr.Zero;
			}
			if (callback is CppObject)
			{
				return ((CppObject)callback).NativePointer;
			}
			ShadowContainer shadowContainer = callback.Shadow as ShadowContainer;
			if (shadowContainer == null)
			{
				shadowContainer = new ShadowContainer();
				shadowContainer.Initialize(callback);
			}
			return shadowContainer.Find(typeof(TCallback));
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002A2A File Offset: 0x00000C2A
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002A2A File Offset: 0x00000C2A
		IDisposable ICallbackable.Shadow
		{
			get
			{
				throw new InvalidOperationException("Invalid access to Callback. This is used internally.");
			}
			set
			{
				throw new InvalidOperationException("Invalid access to Callback. This is used internally.");
			}
		}

		// Token: 0x0400000E RID: 14
		protected internal unsafe void* _nativePointer;
	}
}
