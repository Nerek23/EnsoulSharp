using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200011A RID: 282
	public struct WeldEpsilons
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0001A6C0 File Offset: 0x000188C0
		public float[] Texcoord
		{
			get
			{
				float[] result;
				if ((result = this._Texcoord) == null)
				{
					result = (this._Texcoord = new float[8]);
				}
				return result;
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001A6E6 File Offset: 0x000188E6
		internal void __MarshalFree(ref WeldEpsilons.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001A6F0 File Offset: 0x000188F0
		internal unsafe void __MarshalFrom(ref WeldEpsilons.__Native @ref)
		{
			this.Position = @ref.Position;
			this.BlendWeights = @ref.BlendWeights;
			this.Normal = @ref.Normal;
			this.PSize = @ref.PSize;
			this.Specular = @ref.Specular;
			this.Diffuse = @ref.Diffuse;
			fixed (float* ptr = &this.Texcoord[0])
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &@ref.Texcoord)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 32);
				}
			}
			this.Tangent = @ref.Tangent;
			this.Binormal = @ref.Binormal;
			this.TessFactor = @ref.TessFactor;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001A79C File Offset: 0x0001899C
		internal unsafe void __MarshalTo(ref WeldEpsilons.__Native @ref)
		{
			@ref.Position = this.Position;
			@ref.BlendWeights = this.BlendWeights;
			@ref.Normal = this.Normal;
			@ref.PSize = this.PSize;
			@ref.Specular = this.Specular;
			@ref.Diffuse = this.Diffuse;
			fixed (float* ptr = &@ref.Texcoord)
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &this.Texcoord[0])
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 32);
				}
			}
			@ref.Tangent = this.Tangent;
			@ref.Binormal = this.Binormal;
			@ref.TessFactor = this.TessFactor;
		}

		// Token: 0x04000E73 RID: 3699
		public float Position;

		// Token: 0x04000E74 RID: 3700
		public float BlendWeights;

		// Token: 0x04000E75 RID: 3701
		public float Normal;

		// Token: 0x04000E76 RID: 3702
		public float PSize;

		// Token: 0x04000E77 RID: 3703
		public float Specular;

		// Token: 0x04000E78 RID: 3704
		public float Diffuse;

		// Token: 0x04000E79 RID: 3705
		internal float[] _Texcoord;

		// Token: 0x04000E7A RID: 3706
		public float Tangent;

		// Token: 0x04000E7B RID: 3707
		public float Binormal;

		// Token: 0x04000E7C RID: 3708
		public float TessFactor;

		// Token: 0x0200011B RID: 283
		internal struct __Native
		{
			// Token: 0x06000765 RID: 1893 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000E7D RID: 3709
			public float Position;

			// Token: 0x04000E7E RID: 3710
			public float BlendWeights;

			// Token: 0x04000E7F RID: 3711
			public float Normal;

			// Token: 0x04000E80 RID: 3712
			public float PSize;

			// Token: 0x04000E81 RID: 3713
			public float Specular;

			// Token: 0x04000E82 RID: 3714
			public float Diffuse;

			// Token: 0x04000E83 RID: 3715
			public float Texcoord;

			// Token: 0x04000E84 RID: 3716
			private float __Texcoord1;

			// Token: 0x04000E85 RID: 3717
			private float __Texcoord2;

			// Token: 0x04000E86 RID: 3718
			private float __Texcoord3;

			// Token: 0x04000E87 RID: 3719
			private float __Texcoord4;

			// Token: 0x04000E88 RID: 3720
			private float __Texcoord5;

			// Token: 0x04000E89 RID: 3721
			private float __Texcoord6;

			// Token: 0x04000E8A RID: 3722
			private float __Texcoord7;

			// Token: 0x04000E8B RID: 3723
			public float Tangent;

			// Token: 0x04000E8C RID: 3724
			public float Binormal;

			// Token: 0x04000E8D RID: 3725
			public float TessFactor;
		}
	}
}
