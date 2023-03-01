using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000076 RID: 118
	public struct AdapterDescription2
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref AdapterDescription2.__Native @ref)
		{
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007B60 File Offset: 0x00005D60
		internal unsafe void __MarshalFrom(ref AdapterDescription2.__Native @ref)
		{
			fixed (char* ptr = &@ref.Description)
			{
				void* value = (void*)ptr;
				this.Description = Utilities.PtrToStringUni((IntPtr)value, 127);
			}
			this.VendorId = @ref.VendorId;
			this.DeviceId = @ref.DeviceId;
			this.SubsystemId = @ref.SubsystemId;
			this.Revision = @ref.Revision;
			this.DedicatedVideoMemory = @ref.DedicatedVideoMemory;
			this.DedicatedSystemMemory = @ref.DedicatedSystemMemory;
			this.SharedSystemMemory = @ref.SharedSystemMemory;
			this.Luid = @ref.Luid;
			this.Flags = @ref.Flags;
			this.GraphicsPreemptionGranularity = @ref.GraphicsPreemptionGranularity;
			this.ComputePreemptionGranularity = @ref.ComputePreemptionGranularity;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00007C20 File Offset: 0x00005E20
		internal unsafe void __MarshalTo(ref AdapterDescription2.__Native @ref)
		{
			fixed (string text = this.Description)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (char* ptr2 = &@ref.Description)
				{
					char* ptr3 = ptr2;
					string description = this.Description;
					int num = Math.Min(((description != null) ? description.Length : 0) * 2, 254);
					Utilities.CopyMemory((IntPtr)((void*)ptr3), (IntPtr)((void*)ptr), num);
					ptr3[num] = '\0';
					text = null;
				}
				@ref.VendorId = this.VendorId;
				@ref.DeviceId = this.DeviceId;
				@ref.SubsystemId = this.SubsystemId;
				@ref.Revision = this.Revision;
				@ref.DedicatedVideoMemory = this.DedicatedVideoMemory;
				@ref.DedicatedSystemMemory = this.DedicatedSystemMemory;
				@ref.SharedSystemMemory = this.SharedSystemMemory;
				@ref.Luid = this.Luid;
				@ref.Flags = this.Flags;
				@ref.GraphicsPreemptionGranularity = this.GraphicsPreemptionGranularity;
				@ref.ComputePreemptionGranularity = this.ComputePreemptionGranularity;
			}
		}

		// Token: 0x040002D2 RID: 722
		public string Description;

		// Token: 0x040002D3 RID: 723
		public int VendorId;

		// Token: 0x040002D4 RID: 724
		public int DeviceId;

		// Token: 0x040002D5 RID: 725
		public int SubsystemId;

		// Token: 0x040002D6 RID: 726
		public int Revision;

		// Token: 0x040002D7 RID: 727
		public PointerSize DedicatedVideoMemory;

		// Token: 0x040002D8 RID: 728
		public PointerSize DedicatedSystemMemory;

		// Token: 0x040002D9 RID: 729
		public PointerSize SharedSystemMemory;

		// Token: 0x040002DA RID: 730
		public long Luid;

		// Token: 0x040002DB RID: 731
		public AdapterFlags Flags;

		// Token: 0x040002DC RID: 732
		public GraphicsPreemptionGranularity GraphicsPreemptionGranularity;

		// Token: 0x040002DD RID: 733
		public ComputePreemptionGranularity ComputePreemptionGranularity;

		// Token: 0x02000077 RID: 119
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		internal struct __Native
		{
			// Token: 0x040002DE RID: 734
			public char Description;

			// Token: 0x040002DF RID: 735
			public char __Description1;

			// Token: 0x040002E0 RID: 736
			public char __Description2;

			// Token: 0x040002E1 RID: 737
			public char __Description3;

			// Token: 0x040002E2 RID: 738
			public char __Description4;

			// Token: 0x040002E3 RID: 739
			public char __Description5;

			// Token: 0x040002E4 RID: 740
			public char __Description6;

			// Token: 0x040002E5 RID: 741
			public char __Description7;

			// Token: 0x040002E6 RID: 742
			public char __Description8;

			// Token: 0x040002E7 RID: 743
			public char __Description9;

			// Token: 0x040002E8 RID: 744
			public char __Description10;

			// Token: 0x040002E9 RID: 745
			public char __Description11;

			// Token: 0x040002EA RID: 746
			public char __Description12;

			// Token: 0x040002EB RID: 747
			public char __Description13;

			// Token: 0x040002EC RID: 748
			public char __Description14;

			// Token: 0x040002ED RID: 749
			public char __Description15;

			// Token: 0x040002EE RID: 750
			public char __Description16;

			// Token: 0x040002EF RID: 751
			public char __Description17;

			// Token: 0x040002F0 RID: 752
			public char __Description18;

			// Token: 0x040002F1 RID: 753
			public char __Description19;

			// Token: 0x040002F2 RID: 754
			public char __Description20;

			// Token: 0x040002F3 RID: 755
			public char __Description21;

			// Token: 0x040002F4 RID: 756
			public char __Description22;

			// Token: 0x040002F5 RID: 757
			public char __Description23;

			// Token: 0x040002F6 RID: 758
			public char __Description24;

			// Token: 0x040002F7 RID: 759
			public char __Description25;

			// Token: 0x040002F8 RID: 760
			public char __Description26;

			// Token: 0x040002F9 RID: 761
			public char __Description27;

			// Token: 0x040002FA RID: 762
			public char __Description28;

			// Token: 0x040002FB RID: 763
			public char __Description29;

			// Token: 0x040002FC RID: 764
			public char __Description30;

			// Token: 0x040002FD RID: 765
			public char __Description31;

			// Token: 0x040002FE RID: 766
			public char __Description32;

			// Token: 0x040002FF RID: 767
			public char __Description33;

			// Token: 0x04000300 RID: 768
			public char __Description34;

			// Token: 0x04000301 RID: 769
			public char __Description35;

			// Token: 0x04000302 RID: 770
			public char __Description36;

			// Token: 0x04000303 RID: 771
			public char __Description37;

			// Token: 0x04000304 RID: 772
			public char __Description38;

			// Token: 0x04000305 RID: 773
			public char __Description39;

			// Token: 0x04000306 RID: 774
			public char __Description40;

			// Token: 0x04000307 RID: 775
			public char __Description41;

			// Token: 0x04000308 RID: 776
			public char __Description42;

			// Token: 0x04000309 RID: 777
			public char __Description43;

			// Token: 0x0400030A RID: 778
			public char __Description44;

			// Token: 0x0400030B RID: 779
			public char __Description45;

			// Token: 0x0400030C RID: 780
			public char __Description46;

			// Token: 0x0400030D RID: 781
			public char __Description47;

			// Token: 0x0400030E RID: 782
			public char __Description48;

			// Token: 0x0400030F RID: 783
			public char __Description49;

			// Token: 0x04000310 RID: 784
			public char __Description50;

			// Token: 0x04000311 RID: 785
			public char __Description51;

			// Token: 0x04000312 RID: 786
			public char __Description52;

			// Token: 0x04000313 RID: 787
			public char __Description53;

			// Token: 0x04000314 RID: 788
			public char __Description54;

			// Token: 0x04000315 RID: 789
			public char __Description55;

			// Token: 0x04000316 RID: 790
			public char __Description56;

			// Token: 0x04000317 RID: 791
			public char __Description57;

			// Token: 0x04000318 RID: 792
			public char __Description58;

			// Token: 0x04000319 RID: 793
			public char __Description59;

			// Token: 0x0400031A RID: 794
			public char __Description60;

			// Token: 0x0400031B RID: 795
			public char __Description61;

			// Token: 0x0400031C RID: 796
			public char __Description62;

			// Token: 0x0400031D RID: 797
			public char __Description63;

			// Token: 0x0400031E RID: 798
			public char __Description64;

			// Token: 0x0400031F RID: 799
			public char __Description65;

			// Token: 0x04000320 RID: 800
			public char __Description66;

			// Token: 0x04000321 RID: 801
			public char __Description67;

			// Token: 0x04000322 RID: 802
			public char __Description68;

			// Token: 0x04000323 RID: 803
			public char __Description69;

			// Token: 0x04000324 RID: 804
			public char __Description70;

			// Token: 0x04000325 RID: 805
			public char __Description71;

			// Token: 0x04000326 RID: 806
			public char __Description72;

			// Token: 0x04000327 RID: 807
			public char __Description73;

			// Token: 0x04000328 RID: 808
			public char __Description74;

			// Token: 0x04000329 RID: 809
			public char __Description75;

			// Token: 0x0400032A RID: 810
			public char __Description76;

			// Token: 0x0400032B RID: 811
			public char __Description77;

			// Token: 0x0400032C RID: 812
			public char __Description78;

			// Token: 0x0400032D RID: 813
			public char __Description79;

			// Token: 0x0400032E RID: 814
			public char __Description80;

			// Token: 0x0400032F RID: 815
			public char __Description81;

			// Token: 0x04000330 RID: 816
			public char __Description82;

			// Token: 0x04000331 RID: 817
			public char __Description83;

			// Token: 0x04000332 RID: 818
			public char __Description84;

			// Token: 0x04000333 RID: 819
			public char __Description85;

			// Token: 0x04000334 RID: 820
			public char __Description86;

			// Token: 0x04000335 RID: 821
			public char __Description87;

			// Token: 0x04000336 RID: 822
			public char __Description88;

			// Token: 0x04000337 RID: 823
			public char __Description89;

			// Token: 0x04000338 RID: 824
			public char __Description90;

			// Token: 0x04000339 RID: 825
			public char __Description91;

			// Token: 0x0400033A RID: 826
			public char __Description92;

			// Token: 0x0400033B RID: 827
			public char __Description93;

			// Token: 0x0400033C RID: 828
			public char __Description94;

			// Token: 0x0400033D RID: 829
			public char __Description95;

			// Token: 0x0400033E RID: 830
			public char __Description96;

			// Token: 0x0400033F RID: 831
			public char __Description97;

			// Token: 0x04000340 RID: 832
			public char __Description98;

			// Token: 0x04000341 RID: 833
			public char __Description99;

			// Token: 0x04000342 RID: 834
			public char __Description100;

			// Token: 0x04000343 RID: 835
			public char __Description101;

			// Token: 0x04000344 RID: 836
			public char __Description102;

			// Token: 0x04000345 RID: 837
			public char __Description103;

			// Token: 0x04000346 RID: 838
			public char __Description104;

			// Token: 0x04000347 RID: 839
			public char __Description105;

			// Token: 0x04000348 RID: 840
			public char __Description106;

			// Token: 0x04000349 RID: 841
			public char __Description107;

			// Token: 0x0400034A RID: 842
			public char __Description108;

			// Token: 0x0400034B RID: 843
			public char __Description109;

			// Token: 0x0400034C RID: 844
			public char __Description110;

			// Token: 0x0400034D RID: 845
			public char __Description111;

			// Token: 0x0400034E RID: 846
			public char __Description112;

			// Token: 0x0400034F RID: 847
			public char __Description113;

			// Token: 0x04000350 RID: 848
			public char __Description114;

			// Token: 0x04000351 RID: 849
			public char __Description115;

			// Token: 0x04000352 RID: 850
			public char __Description116;

			// Token: 0x04000353 RID: 851
			public char __Description117;

			// Token: 0x04000354 RID: 852
			public char __Description118;

			// Token: 0x04000355 RID: 853
			public char __Description119;

			// Token: 0x04000356 RID: 854
			public char __Description120;

			// Token: 0x04000357 RID: 855
			public char __Description121;

			// Token: 0x04000358 RID: 856
			public char __Description122;

			// Token: 0x04000359 RID: 857
			public char __Description123;

			// Token: 0x0400035A RID: 858
			public char __Description124;

			// Token: 0x0400035B RID: 859
			public char __Description125;

			// Token: 0x0400035C RID: 860
			public char __Description126;

			// Token: 0x0400035D RID: 861
			public char __Description127;

			// Token: 0x0400035E RID: 862
			public int VendorId;

			// Token: 0x0400035F RID: 863
			public int DeviceId;

			// Token: 0x04000360 RID: 864
			public int SubsystemId;

			// Token: 0x04000361 RID: 865
			public int Revision;

			// Token: 0x04000362 RID: 866
			public IntPtr DedicatedVideoMemory;

			// Token: 0x04000363 RID: 867
			public IntPtr DedicatedSystemMemory;

			// Token: 0x04000364 RID: 868
			public IntPtr SharedSystemMemory;

			// Token: 0x04000365 RID: 869
			public long Luid;

			// Token: 0x04000366 RID: 870
			public AdapterFlags Flags;

			// Token: 0x04000367 RID: 871
			public GraphicsPreemptionGranularity GraphicsPreemptionGranularity;

			// Token: 0x04000368 RID: 872
			public ComputePreemptionGranularity ComputePreemptionGranularity;
		}
	}
}
