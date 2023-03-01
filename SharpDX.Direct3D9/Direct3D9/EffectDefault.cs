using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000024 RID: 36
	public struct EffectDefault
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000A4DA File Offset: 0x000086DA
		public DataStream Value
		{
			get
			{
				return new DataStream(this.BufferPointer, (long)this.BufferSize, true, true);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000A4F0 File Offset: 0x000086F0
		internal void __MarshalFree(ref EffectDefault.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000A4F8 File Offset: 0x000086F8
		internal void __MarshalFrom(ref EffectDefault.__Native @ref)
		{
			this.ParameterName = ((@ref.ParameterName == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.ParameterName));
			this.Type = @ref.Type;
			this.BufferSize = @ref.BufferSize;
			this.BufferPointer = @ref.BufferPointer;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000A550 File Offset: 0x00008750
		internal void __MarshalTo(ref EffectDefault.__Native @ref)
		{
			@ref.ParameterName = ((this.ParameterName == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.ParameterName));
			@ref.Type = this.Type;
			@ref.BufferSize = this.BufferSize;
			@ref.BufferPointer = this.BufferPointer;
		}

		// Token: 0x040004CB RID: 1227
		public string ParameterName;

		// Token: 0x040004CC RID: 1228
		public EffectDefaultType Type;

		// Token: 0x040004CD RID: 1229
		internal int BufferSize;

		// Token: 0x040004CE RID: 1230
		internal IntPtr BufferPointer;

		// Token: 0x02000025 RID: 37
		internal struct __Native
		{
			// Token: 0x06000289 RID: 649 RVA: 0x0000A5A1 File Offset: 0x000087A1
			internal void __MarshalFree()
			{
				if (this.ParameterName != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.ParameterName);
				}
			}

			// Token: 0x040004CF RID: 1231
			public IntPtr ParameterName;

			// Token: 0x040004D0 RID: 1232
			public EffectDefaultType Type;

			// Token: 0x040004D1 RID: 1233
			public int BufferSize;

			// Token: 0x040004D2 RID: 1234
			public IntPtr BufferPointer;
		}
	}
}
