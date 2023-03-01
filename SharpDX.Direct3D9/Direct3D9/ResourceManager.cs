using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000106 RID: 262
	public struct ResourceManager
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x0001A560 File Offset: 0x00018760
		public ResourceStats[] Stats
		{
			get
			{
				ResourceStats[] result;
				if ((result = this._Stats) == null)
				{
					result = (this._Stats = new ResourceStats[8]);
				}
				return result;
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001A586 File Offset: 0x00018786
		internal void __MarshalFree(ref ResourceManager.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001A590 File Offset: 0x00018790
		internal unsafe void __MarshalFrom(ref ResourceManager.__Native @ref)
		{
			fixed (ResourceStats* ptr = &this.Stats[0])
			{
				void* value = (void*)ptr;
				fixed (ResourceStats* ptr2 = &@ref.Stats)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 8 * sizeof(ResourceStats));
				}
			}
		}

		// Token: 0x04000E14 RID: 3604
		internal ResourceStats[] _Stats;

		// Token: 0x02000107 RID: 263
		internal struct __Native
		{
			// Token: 0x0600075A RID: 1882 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000E15 RID: 3605
			public ResourceStats Stats;

			// Token: 0x04000E16 RID: 3606
			private ResourceStats __Stats1;

			// Token: 0x04000E17 RID: 3607
			private ResourceStats __Stats2;

			// Token: 0x04000E18 RID: 3608
			private ResourceStats __Stats3;

			// Token: 0x04000E19 RID: 3609
			private ResourceStats __Stats4;

			// Token: 0x04000E1A RID: 3610
			private ResourceStats __Stats5;

			// Token: 0x04000E1B RID: 3611
			private ResourceStats __Stats6;

			// Token: 0x04000E1C RID: 3612
			private ResourceStats __Stats7;
		}
	}
}
