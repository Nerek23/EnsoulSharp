using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000028 RID: 40
	public class EffectInstance
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600029F RID: 671 RVA: 0x0000A7EB File Offset: 0x000089EB
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x0000A7F3 File Offset: 0x000089F3
		public EffectDefault[] Defaults { get; set; }

		// Token: 0x060002A1 RID: 673 RVA: 0x0000A7FC File Offset: 0x000089FC
		internal void __MarshalFree(ref EffectInstance.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000A804 File Offset: 0x00008A04
		internal void __MarshalFrom(ref EffectInstance.__Native @ref)
		{
			this.EffectFilename = ((@ref.EffectFilename == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.EffectFilename));
			EffectDefault.__Native[] array = new EffectDefault.__Native[@ref.DefaultCount];
			Utilities.Read<EffectDefault.__Native>(@ref.DefaultPointer, array, 0, array.Length);
			this.Defaults = new EffectDefault[array.Length];
			for (int i = 0; i < this.Defaults.Length; i++)
			{
				this.Defaults[i] = default(EffectDefault);
				this.Defaults[i].__MarshalFrom(ref array[i]);
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		internal unsafe void __MarshalTo(ref EffectInstance.__Native @ref)
		{
			@ref.EffectFilename = ((this.EffectFilename == null) ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(this.EffectFilename));
			EffectDefault.__Native* ptr = (EffectDefault.__Native*)((void*)Marshal.AllocHGlobal(this.Defaults.Length * sizeof(EffectDefault.__Native)));
			for (int i = 0; i < this.Defaults.Length; i++)
			{
				this.Defaults[i].__MarshalTo(ref ptr[i]);
			}
			@ref.DefaultCount = this.Defaults.Length;
			@ref.DefaultPointer = (IntPtr)((void*)ptr);
		}

		// Token: 0x040004D9 RID: 1241
		public string EffectFilename;

		// Token: 0x040004DA RID: 1242
		internal int DefaultCount;

		// Token: 0x040004DB RID: 1243
		internal IntPtr DefaultPointer;

		// Token: 0x02000029 RID: 41
		internal struct __Native
		{
			// Token: 0x060002A5 RID: 677 RVA: 0x0000A930 File Offset: 0x00008B30
			internal void __MarshalFree()
			{
				if (this.EffectFilename != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.EffectFilename);
				}
				if (this.DefaultPointer != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.DefaultPointer);
				}
			}

			// Token: 0x040004DC RID: 1244
			public IntPtr EffectFilename;

			// Token: 0x040004DD RID: 1245
			public int DefaultCount;

			// Token: 0x040004DE RID: 1246
			public IntPtr DefaultPointer;
		}
	}
}
