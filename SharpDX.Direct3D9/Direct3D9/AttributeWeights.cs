using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000D3 RID: 211
	public struct AttributeWeights
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x000193B4 File Offset: 0x000175B4
		public float[] TextureCoordinate
		{
			get
			{
				float[] result;
				if ((result = this._TextureCoordinate) == null)
				{
					result = (this._TextureCoordinate = new float[8]);
				}
				return result;
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000193DA File Offset: 0x000175DA
		internal void __MarshalFree(ref AttributeWeights.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000193E4 File Offset: 0x000175E4
		internal unsafe void __MarshalFrom(ref AttributeWeights.__Native @ref)
		{
			this.Position = @ref.Position;
			this.Boundary = @ref.Boundary;
			this.Normal = @ref.Normal;
			this.Diffuse = @ref.Diffuse;
			this.Specular = @ref.Specular;
			fixed (float* ptr = &this.TextureCoordinate[0])
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &@ref.TextureCoordinate)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 32);
				}
			}
			this.Tangent = @ref.Tangent;
			this.Binormal = @ref.Binormal;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00019478 File Offset: 0x00017678
		internal unsafe void __MarshalTo(ref AttributeWeights.__Native @ref)
		{
			@ref.Position = this.Position;
			@ref.Boundary = this.Boundary;
			@ref.Normal = this.Normal;
			@ref.Diffuse = this.Diffuse;
			@ref.Specular = this.Specular;
			fixed (float* ptr = &@ref.TextureCoordinate)
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &this.TextureCoordinate[0])
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 32);
				}
			}
			@ref.Tangent = this.Tangent;
			@ref.Binormal = this.Binormal;
		}

		// Token: 0x040009DE RID: 2526
		public float Position;

		// Token: 0x040009DF RID: 2527
		public float Boundary;

		// Token: 0x040009E0 RID: 2528
		public float Normal;

		// Token: 0x040009E1 RID: 2529
		public float Diffuse;

		// Token: 0x040009E2 RID: 2530
		public float Specular;

		// Token: 0x040009E3 RID: 2531
		internal float[] _TextureCoordinate;

		// Token: 0x040009E4 RID: 2532
		public float Tangent;

		// Token: 0x040009E5 RID: 2533
		public float Binormal;

		// Token: 0x020000D4 RID: 212
		internal struct __Native
		{
			// Token: 0x06000716 RID: 1814 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x040009E6 RID: 2534
			public float Position;

			// Token: 0x040009E7 RID: 2535
			public float Boundary;

			// Token: 0x040009E8 RID: 2536
			public float Normal;

			// Token: 0x040009E9 RID: 2537
			public float Diffuse;

			// Token: 0x040009EA RID: 2538
			public float Specular;

			// Token: 0x040009EB RID: 2539
			public float TextureCoordinate;

			// Token: 0x040009EC RID: 2540
			private float __TextureCoordinate1;

			// Token: 0x040009ED RID: 2541
			private float __TextureCoordinate2;

			// Token: 0x040009EE RID: 2542
			private float __TextureCoordinate3;

			// Token: 0x040009EF RID: 2543
			private float __TextureCoordinate4;

			// Token: 0x040009F0 RID: 2544
			private float __TextureCoordinate5;

			// Token: 0x040009F1 RID: 2545
			private float __TextureCoordinate6;

			// Token: 0x040009F2 RID: 2546
			private float __TextureCoordinate7;

			// Token: 0x040009F3 RID: 2547
			public float Tangent;

			// Token: 0x040009F4 RID: 2548
			public float Binormal;
		}
	}
}
