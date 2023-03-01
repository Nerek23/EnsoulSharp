using System;
using System.Runtime.CompilerServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E5 RID: 229
	public struct FontDescription
	{
		// Token: 0x06000727 RID: 1831 RVA: 0x00019899 File Offset: 0x00017A99
		internal void __MarshalFree(ref FontDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x000198A4 File Offset: 0x00017AA4
		internal unsafe void __MarshalFrom(ref FontDescription.__Native @ref)
		{
			this.Height = @ref.Height;
			this.Width = @ref.Width;
			this.Weight = @ref.Weight;
			this.MipLevels = @ref.MipLevels;
			this.Italic = @ref.Italic;
			this.CharacterSet = @ref.CharacterSet;
			this.OutputPrecision = @ref.OutputPrecision;
			this.Quality = @ref.Quality;
			this.PitchAndFamily = @ref.PitchAndFamily;
			fixed (char* ptr = &@ref.FaceName)
			{
				char* value = ptr;
				this.FaceName = Utilities.PtrToStringUni((IntPtr)((void*)value), 32);
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00019940 File Offset: 0x00017B40
		internal unsafe void __MarshalTo(ref FontDescription.__Native @ref)
		{
			@ref.Height = this.Height;
			@ref.Width = this.Width;
			@ref.Weight = this.Weight;
			@ref.MipLevels = this.MipLevels;
			@ref.Italic = this.Italic;
			@ref.CharacterSet = this.CharacterSet;
			@ref.OutputPrecision = this.OutputPrecision;
			@ref.Quality = this.Quality;
			@ref.PitchAndFamily = this.PitchAndFamily;
			fixed (string faceName = this.FaceName)
			{
				char* ptr = faceName;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (char* ptr2 = &@ref.FaceName)
				{
					Utilities.CopyMemory((IntPtr)((void*)ptr2), (IntPtr)((void*)ptr), this.FaceName.Length * 2);
				}
			}
		}

		// Token: 0x04000A40 RID: 2624
		public int Height;

		// Token: 0x04000A41 RID: 2625
		public int Width;

		// Token: 0x04000A42 RID: 2626
		public FontWeight Weight;

		// Token: 0x04000A43 RID: 2627
		public int MipLevels;

		// Token: 0x04000A44 RID: 2628
		public RawBool Italic;

		// Token: 0x04000A45 RID: 2629
		public FontCharacterSet CharacterSet;

		// Token: 0x04000A46 RID: 2630
		public FontPrecision OutputPrecision;

		// Token: 0x04000A47 RID: 2631
		public FontQuality Quality;

		// Token: 0x04000A48 RID: 2632
		public FontPitchAndFamily PitchAndFamily;

		// Token: 0x04000A49 RID: 2633
		public string FaceName;

		// Token: 0x020000E6 RID: 230
		internal struct __Native
		{
			// Token: 0x0600072A RID: 1834 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000A4A RID: 2634
			public int Height;

			// Token: 0x04000A4B RID: 2635
			public int Width;

			// Token: 0x04000A4C RID: 2636
			public FontWeight Weight;

			// Token: 0x04000A4D RID: 2637
			public int MipLevels;

			// Token: 0x04000A4E RID: 2638
			public RawBool Italic;

			// Token: 0x04000A4F RID: 2639
			public FontCharacterSet CharacterSet;

			// Token: 0x04000A50 RID: 2640
			public FontPrecision OutputPrecision;

			// Token: 0x04000A51 RID: 2641
			public FontQuality Quality;

			// Token: 0x04000A52 RID: 2642
			public FontPitchAndFamily PitchAndFamily;

			// Token: 0x04000A53 RID: 2643
			public char FaceName;

			// Token: 0x04000A54 RID: 2644
			private char __FaceName1;

			// Token: 0x04000A55 RID: 2645
			private char __FaceName2;

			// Token: 0x04000A56 RID: 2646
			private char __FaceName3;

			// Token: 0x04000A57 RID: 2647
			private char __FaceName4;

			// Token: 0x04000A58 RID: 2648
			private char __FaceName5;

			// Token: 0x04000A59 RID: 2649
			private char __FaceName6;

			// Token: 0x04000A5A RID: 2650
			private char __FaceName7;

			// Token: 0x04000A5B RID: 2651
			private char __FaceName8;

			// Token: 0x04000A5C RID: 2652
			private char __FaceName9;

			// Token: 0x04000A5D RID: 2653
			private char __FaceName10;

			// Token: 0x04000A5E RID: 2654
			private char __FaceName11;

			// Token: 0x04000A5F RID: 2655
			private char __FaceName12;

			// Token: 0x04000A60 RID: 2656
			private char __FaceName13;

			// Token: 0x04000A61 RID: 2657
			private char __FaceName14;

			// Token: 0x04000A62 RID: 2658
			private char __FaceName15;

			// Token: 0x04000A63 RID: 2659
			private char __FaceName16;

			// Token: 0x04000A64 RID: 2660
			private char __FaceName17;

			// Token: 0x04000A65 RID: 2661
			private char __FaceName18;

			// Token: 0x04000A66 RID: 2662
			private char __FaceName19;

			// Token: 0x04000A67 RID: 2663
			private char __FaceName20;

			// Token: 0x04000A68 RID: 2664
			private char __FaceName21;

			// Token: 0x04000A69 RID: 2665
			private char __FaceName22;

			// Token: 0x04000A6A RID: 2666
			private char __FaceName23;

			// Token: 0x04000A6B RID: 2667
			private char __FaceName24;

			// Token: 0x04000A6C RID: 2668
			private char __FaceName25;

			// Token: 0x04000A6D RID: 2669
			private char __FaceName26;

			// Token: 0x04000A6E RID: 2670
			private char __FaceName27;

			// Token: 0x04000A6F RID: 2671
			private char __FaceName28;

			// Token: 0x04000A70 RID: 2672
			private char __FaceName29;

			// Token: 0x04000A71 RID: 2673
			private char __FaceName30;

			// Token: 0x04000A72 RID: 2674
			private char __FaceName31;
		}
	}
}
