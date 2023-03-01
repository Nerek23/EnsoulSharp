using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F6 RID: 246
	public class MeshContainer : DisposeBase
	{
		// Token: 0x06000743 RID: 1859 RVA: 0x00019F19 File Offset: 0x00018119
		internal void __MarshalFree(ref MeshContainer.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00019F24 File Offset: 0x00018124
		internal void __MarshalFrom(ref MeshContainer.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.MeshData = @ref.MeshData;
			this.MaterialPointer = @ref.MaterialPointer;
			this.PEffects = @ref.PEffects;
			this.MaterialCount = @ref.MaterialCount;
			this.PAdjacency = @ref.PAdjacency;
			this.PSkinInfo = @ref.PSkinInfo;
			this.PNextMeshContainer = @ref.PNextMeshContainer;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00019FAC File Offset: 0x000181AC
		internal void __MarshalTo(ref MeshContainer.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.MeshData = this.MeshData;
			@ref.MaterialPointer = this.MaterialPointer;
			@ref.PEffects = this.PEffects;
			@ref.MaterialCount = this.MaterialCount;
			@ref.PAdjacency = this.PAdjacency;
			@ref.PSkinInfo = this.PSkinInfo;
			@ref.PNextMeshContainer = this.PNextMeshContainer;
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x0001A030 File Offset: 0x00018230
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x0001A0A4 File Offset: 0x000182A4
		public unsafe ExtendedMaterial[] Materials
		{
			get
			{
				ExtendedMaterial[] array = new ExtendedMaterial[this.MaterialCount];
				ExtendedMaterial.__Native[] array2 = new ExtendedMaterial.__Native[this.MaterialCount];
				if (this.MaterialCount > 0)
				{
					Utilities.Read<ExtendedMaterial.__Native>(this.MaterialPointer, array2, 0, this.MaterialCount);
					for (int i = 0; i < array2.Length; i++)
					{
						ExtendedMaterial.__Native _Native = array2[i];
						ExtendedMaterial extendedMaterial = default(ExtendedMaterial);
						extendedMaterial.__MarshalFrom(ref _Native);
						array[i] = extendedMaterial;
					}
				}
				return array;
			}
			set
			{
				this.DisposeMaterials();
				this.MaterialCount = value.Length;
				this.MaterialPointer = Marshal.AllocHGlobal(Utilities.SizeOf<ExtendedMaterial.__Native>() * this.MaterialCount);
				for (int i = 0; i < value.Length; i++)
				{
					value[i].__MarshalTo(ref *(ExtendedMaterial.__Native*)((byte*)((void*)this.MaterialPointer) + (IntPtr)i * (IntPtr)sizeof(ExtendedMaterial.__Native)));
				}
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0001A106 File Offset: 0x00018306
		protected override void Dispose(bool disposing)
		{
			this.DisposeMaterials();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0001A110 File Offset: 0x00018310
		private unsafe void DisposeMaterials()
		{
			if (this.MaterialPointer != IntPtr.Zero)
			{
				for (int i = 0; i < this.MaterialCount; i++)
				{
					((ExtendedMaterial.__Native*)((byte*)((void*)this.MaterialPointer) + (IntPtr)i * (IntPtr)sizeof(ExtendedMaterial.__Native)))->__MarshalFree();
				}
				Marshal.FreeHGlobal(this.MaterialPointer);
				this.MaterialPointer = IntPtr.Zero;
				this.MaterialCount = 0;
			}
		}

		// Token: 0x04000DB0 RID: 3504
		public string Name;

		// Token: 0x04000DB1 RID: 3505
		public MeshData MeshData;

		// Token: 0x04000DB2 RID: 3506
		internal IntPtr MaterialPointer;

		// Token: 0x04000DB3 RID: 3507
		public IntPtr PEffects;

		// Token: 0x04000DB4 RID: 3508
		internal int MaterialCount;

		// Token: 0x04000DB5 RID: 3509
		public IntPtr PAdjacency;

		// Token: 0x04000DB6 RID: 3510
		public IntPtr PSkinInfo;

		// Token: 0x04000DB7 RID: 3511
		public IntPtr PNextMeshContainer;

		// Token: 0x020000F7 RID: 247
		internal struct __Native
		{
			// Token: 0x0600074B RID: 1867 RVA: 0x0001A177 File Offset: 0x00018377
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000DB8 RID: 3512
			public IntPtr Name;

			// Token: 0x04000DB9 RID: 3513
			public MeshData MeshData;

			// Token: 0x04000DBA RID: 3514
			public IntPtr MaterialPointer;

			// Token: 0x04000DBB RID: 3515
			public IntPtr PEffects;

			// Token: 0x04000DBC RID: 3516
			public int MaterialCount;

			// Token: 0x04000DBD RID: 3517
			public IntPtr PAdjacency;

			// Token: 0x04000DBE RID: 3518
			public IntPtr PSkinInfo;

			// Token: 0x04000DBF RID: 3519
			public IntPtr PNextMeshContainer;
		}
	}
}
