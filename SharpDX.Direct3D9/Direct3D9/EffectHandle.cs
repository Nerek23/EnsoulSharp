using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000026 RID: 38
	public class EffectHandle : DisposeBase
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000A5C0 File Offset: 0x000087C0
		public EffectHandle()
		{
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000A5C8 File Offset: 0x000087C8
		public EffectHandle(IntPtr pointer)
		{
			this.pointer = pointer;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000A5D7 File Offset: 0x000087D7
		public unsafe EffectHandle(void* pointer)
		{
			this.pointer = new IntPtr(pointer);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000A5EB File Offset: 0x000087EB
		public EffectHandle(string name)
		{
			this.pointer = EffectHandle.AllocateString(name);
			this.isStringToRelease = false;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000A608 File Offset: 0x00008808
		public static void ClearCache()
		{
			Dictionary<string, IntPtr> allocatedStrings = EffectHandle.AllocatedStrings;
			lock (allocatedStrings)
			{
				foreach (IntPtr hglobal in EffectHandle.AllocatedStrings.Values)
				{
					Marshal.FreeHGlobal(hglobal);
				}
				EffectHandle.AllocatedStrings.Clear();
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00002374 File Offset: 0x00000574
		internal static void __MarshalFree(ref EffectHandle __from, ref EffectHandle.__Native @ref)
		{
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000A690 File Offset: 0x00008890
		internal static void __MarshalFrom(ref EffectHandle __from, ref EffectHandle.__Native @ref)
		{
			if (@ref.Pointer == IntPtr.Zero)
			{
				__from = null;
				return;
			}
			__from.pointer = @ref.Pointer;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000A6B5 File Offset: 0x000088B5
		internal static void __MarshalTo(ref EffectHandle __from, ref EffectHandle.__Native @ref)
		{
			if (__from == null)
			{
				@ref.Pointer = IntPtr.Zero;
				return;
			}
			@ref.Pointer = __from.pointer;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000A6D4 File Offset: 0x000088D4
		protected override void Dispose(bool disposing)
		{
			if (this.isStringToRelease)
			{
				Marshal.FreeHGlobal(this.pointer);
				this.pointer = IntPtr.Zero;
				this.isStringToRelease = false;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000A6FC File Offset: 0x000088FC
		private static IntPtr AllocateString(string name)
		{
			Dictionary<string, IntPtr> allocatedStrings = EffectHandle.AllocatedStrings;
			IntPtr intPtr;
			lock (allocatedStrings)
			{
				if (!EffectHandle.AllocatedStrings.TryGetValue(name, out intPtr))
				{
					intPtr = Marshal.StringToHGlobalAnsi(name);
					EffectHandle.AllocatedStrings.Add(name, intPtr);
				}
			}
			return intPtr;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000A758 File Offset: 0x00008958
		public static implicit operator IntPtr(EffectHandle value)
		{
			return value.pointer;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000A760 File Offset: 0x00008960
		public static implicit operator EffectHandle(IntPtr value)
		{
			return new EffectHandle(value);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000A768 File Offset: 0x00008968
		public unsafe static implicit operator void*(EffectHandle value)
		{
			return (void*)value.pointer;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000A775 File Offset: 0x00008975
		public unsafe static implicit operator EffectHandle(void* value)
		{
			return new EffectHandle(value);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000A77D File Offset: 0x0000897D
		public static implicit operator EffectHandle(string name)
		{
			return new EffectHandle(name);
		}

		// Token: 0x040004D3 RID: 1235
		private const bool UseCacheStrings = true;

		// Token: 0x040004D4 RID: 1236
		private static readonly Dictionary<string, IntPtr> AllocatedStrings = new Dictionary<string, IntPtr>();

		// Token: 0x040004D5 RID: 1237
		private IntPtr pointer;

		// Token: 0x040004D6 RID: 1238
		private bool isStringToRelease;

		// Token: 0x02000027 RID: 39
		internal struct __Native
		{
			// Token: 0x0600029A RID: 666 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x0600029B RID: 667 RVA: 0x0000A791 File Offset: 0x00008991
			public static implicit operator IntPtr(EffectHandle.__Native value)
			{
				return value.Pointer;
			}

			// Token: 0x0600029C RID: 668 RVA: 0x0000A79C File Offset: 0x0000899C
			public static implicit operator EffectHandle.__Native(IntPtr value)
			{
				return new EffectHandle.__Native
				{
					Pointer = value
				};
			}

			// Token: 0x0600029D RID: 669 RVA: 0x0000A7BA File Offset: 0x000089BA
			public unsafe static implicit operator void*(EffectHandle.__Native value)
			{
				return (void*)value.Pointer;
			}

			// Token: 0x0600029E RID: 670 RVA: 0x0000A7C8 File Offset: 0x000089C8
			public unsafe static implicit operator EffectHandle.__Native(void* value)
			{
				return new EffectHandle.__Native
				{
					Pointer = (IntPtr)value
				};
			}

			// Token: 0x040004D7 RID: 1239
			public IntPtr Pointer;
		}
	}
}
