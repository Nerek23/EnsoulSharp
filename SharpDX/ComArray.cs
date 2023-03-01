using System;
using System.Collections;

namespace SharpDX
{
	// Token: 0x02000004 RID: 4
	public class ComArray : DisposeBase, IEnumerable
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002160 File Offset: 0x00000360
		public ComArray(params ComObject[] array)
		{
			this.values = array;
			this.nativeBuffer = IntPtr.Zero;
			if (this.values != null)
			{
				int num = array.Length;
				this.values = new ComObject[num];
				this.nativeBuffer = Utilities.AllocateMemory(num * Utilities.SizeOf<IntPtr>(), 16);
				for (int i = 0; i < num; i++)
				{
					this.Set(i, array[i]);
				}
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021C7 File Offset: 0x000003C7
		public ComArray(int size)
		{
			this.values = new ComObject[size];
			this.nativeBuffer = Utilities.AllocateMemory(size * Utilities.SizeOf<IntPtr>(), 16);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021EF File Offset: 0x000003EF
		public IntPtr NativePointer
		{
			get
			{
				return this.nativeBuffer;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021F7 File Offset: 0x000003F7
		public int Length
		{
			get
			{
				if (this.values != null)
				{
					return this.values.Length;
				}
				return 0;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000220B File Offset: 0x0000040B
		public ComObject Get(int index)
		{
			return this.values[index];
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002215 File Offset: 0x00000415
		internal unsafe void SetFromNative(int index, ComObject value)
		{
			this.values[index] = value;
			value.NativePointer = *(IntPtr*)((byte*)((void*)this.nativeBuffer) + (IntPtr)index * (IntPtr)sizeof(IntPtr));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000223C File Offset: 0x0000043C
		public unsafe void Set(int index, ComObject value)
		{
			this.values[index] = value;
			*(IntPtr*)((byte*)((void*)this.nativeBuffer) + (IntPtr)index * (IntPtr)sizeof(IntPtr)) = value.NativePointer;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002263 File Offset: 0x00000463
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.values = null;
			}
			Utilities.FreeMemory(this.nativeBuffer);
			this.nativeBuffer = IntPtr.Zero;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002285 File Offset: 0x00000485
		public IEnumerator GetEnumerator()
		{
			return this.values.GetEnumerator();
		}

		// Token: 0x04000003 RID: 3
		protected ComObject[] values;

		// Token: 0x04000004 RID: 4
		private IntPtr nativeBuffer;
	}
}
