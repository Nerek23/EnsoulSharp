using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000078 RID: 120
	public struct AdapterDescription3
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref AdapterDescription3.__Native @ref)
		{
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00007D1C File Offset: 0x00005F1C
		internal unsafe void __MarshalFrom(ref AdapterDescription3.__Native @ref)
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

		// Token: 0x060001F6 RID: 502 RVA: 0x00007DDC File Offset: 0x00005FDC
		internal unsafe void __MarshalTo(ref AdapterDescription3.__Native @ref)
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

		// Token: 0x04000369 RID: 873
		public string Description;

		// Token: 0x0400036A RID: 874
		public int VendorId;

		// Token: 0x0400036B RID: 875
		public int DeviceId;

		// Token: 0x0400036C RID: 876
		public int SubsystemId;

		// Token: 0x0400036D RID: 877
		public int Revision;

		// Token: 0x0400036E RID: 878
		public PointerSize DedicatedVideoMemory;

		// Token: 0x0400036F RID: 879
		public PointerSize DedicatedSystemMemory;

		// Token: 0x04000370 RID: 880
		public PointerSize SharedSystemMemory;

		// Token: 0x04000371 RID: 881
		public long Luid;

		// Token: 0x04000372 RID: 882
		public AdapterFlags3 Flags;

		// Token: 0x04000373 RID: 883
		public GraphicsPreemptionGranularity GraphicsPreemptionGranularity;

		// Token: 0x04000374 RID: 884
		public ComputePreemptionGranularity ComputePreemptionGranularity;

		// Token: 0x02000079 RID: 121
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		internal struct __Native
		{
			// Token: 0x04000375 RID: 885
			public char Description;

			// Token: 0x04000376 RID: 886
			public char __Description1;

			// Token: 0x04000377 RID: 887
			public char __Description2;

			// Token: 0x04000378 RID: 888
			public char __Description3;

			// Token: 0x04000379 RID: 889
			public char __Description4;

			// Token: 0x0400037A RID: 890
			public char __Description5;

			// Token: 0x0400037B RID: 891
			public char __Description6;

			// Token: 0x0400037C RID: 892
			public char __Description7;

			// Token: 0x0400037D RID: 893
			public char __Description8;

			// Token: 0x0400037E RID: 894
			public char __Description9;

			// Token: 0x0400037F RID: 895
			public char __Description10;

			// Token: 0x04000380 RID: 896
			public char __Description11;

			// Token: 0x04000381 RID: 897
			public char __Description12;

			// Token: 0x04000382 RID: 898
			public char __Description13;

			// Token: 0x04000383 RID: 899
			public char __Description14;

			// Token: 0x04000384 RID: 900
			public char __Description15;

			// Token: 0x04000385 RID: 901
			public char __Description16;

			// Token: 0x04000386 RID: 902
			public char __Description17;

			// Token: 0x04000387 RID: 903
			public char __Description18;

			// Token: 0x04000388 RID: 904
			public char __Description19;

			// Token: 0x04000389 RID: 905
			public char __Description20;

			// Token: 0x0400038A RID: 906
			public char __Description21;

			// Token: 0x0400038B RID: 907
			public char __Description22;

			// Token: 0x0400038C RID: 908
			public char __Description23;

			// Token: 0x0400038D RID: 909
			public char __Description24;

			// Token: 0x0400038E RID: 910
			public char __Description25;

			// Token: 0x0400038F RID: 911
			public char __Description26;

			// Token: 0x04000390 RID: 912
			public char __Description27;

			// Token: 0x04000391 RID: 913
			public char __Description28;

			// Token: 0x04000392 RID: 914
			public char __Description29;

			// Token: 0x04000393 RID: 915
			public char __Description30;

			// Token: 0x04000394 RID: 916
			public char __Description31;

			// Token: 0x04000395 RID: 917
			public char __Description32;

			// Token: 0x04000396 RID: 918
			public char __Description33;

			// Token: 0x04000397 RID: 919
			public char __Description34;

			// Token: 0x04000398 RID: 920
			public char __Description35;

			// Token: 0x04000399 RID: 921
			public char __Description36;

			// Token: 0x0400039A RID: 922
			public char __Description37;

			// Token: 0x0400039B RID: 923
			public char __Description38;

			// Token: 0x0400039C RID: 924
			public char __Description39;

			// Token: 0x0400039D RID: 925
			public char __Description40;

			// Token: 0x0400039E RID: 926
			public char __Description41;

			// Token: 0x0400039F RID: 927
			public char __Description42;

			// Token: 0x040003A0 RID: 928
			public char __Description43;

			// Token: 0x040003A1 RID: 929
			public char __Description44;

			// Token: 0x040003A2 RID: 930
			public char __Description45;

			// Token: 0x040003A3 RID: 931
			public char __Description46;

			// Token: 0x040003A4 RID: 932
			public char __Description47;

			// Token: 0x040003A5 RID: 933
			public char __Description48;

			// Token: 0x040003A6 RID: 934
			public char __Description49;

			// Token: 0x040003A7 RID: 935
			public char __Description50;

			// Token: 0x040003A8 RID: 936
			public char __Description51;

			// Token: 0x040003A9 RID: 937
			public char __Description52;

			// Token: 0x040003AA RID: 938
			public char __Description53;

			// Token: 0x040003AB RID: 939
			public char __Description54;

			// Token: 0x040003AC RID: 940
			public char __Description55;

			// Token: 0x040003AD RID: 941
			public char __Description56;

			// Token: 0x040003AE RID: 942
			public char __Description57;

			// Token: 0x040003AF RID: 943
			public char __Description58;

			// Token: 0x040003B0 RID: 944
			public char __Description59;

			// Token: 0x040003B1 RID: 945
			public char __Description60;

			// Token: 0x040003B2 RID: 946
			public char __Description61;

			// Token: 0x040003B3 RID: 947
			public char __Description62;

			// Token: 0x040003B4 RID: 948
			public char __Description63;

			// Token: 0x040003B5 RID: 949
			public char __Description64;

			// Token: 0x040003B6 RID: 950
			public char __Description65;

			// Token: 0x040003B7 RID: 951
			public char __Description66;

			// Token: 0x040003B8 RID: 952
			public char __Description67;

			// Token: 0x040003B9 RID: 953
			public char __Description68;

			// Token: 0x040003BA RID: 954
			public char __Description69;

			// Token: 0x040003BB RID: 955
			public char __Description70;

			// Token: 0x040003BC RID: 956
			public char __Description71;

			// Token: 0x040003BD RID: 957
			public char __Description72;

			// Token: 0x040003BE RID: 958
			public char __Description73;

			// Token: 0x040003BF RID: 959
			public char __Description74;

			// Token: 0x040003C0 RID: 960
			public char __Description75;

			// Token: 0x040003C1 RID: 961
			public char __Description76;

			// Token: 0x040003C2 RID: 962
			public char __Description77;

			// Token: 0x040003C3 RID: 963
			public char __Description78;

			// Token: 0x040003C4 RID: 964
			public char __Description79;

			// Token: 0x040003C5 RID: 965
			public char __Description80;

			// Token: 0x040003C6 RID: 966
			public char __Description81;

			// Token: 0x040003C7 RID: 967
			public char __Description82;

			// Token: 0x040003C8 RID: 968
			public char __Description83;

			// Token: 0x040003C9 RID: 969
			public char __Description84;

			// Token: 0x040003CA RID: 970
			public char __Description85;

			// Token: 0x040003CB RID: 971
			public char __Description86;

			// Token: 0x040003CC RID: 972
			public char __Description87;

			// Token: 0x040003CD RID: 973
			public char __Description88;

			// Token: 0x040003CE RID: 974
			public char __Description89;

			// Token: 0x040003CF RID: 975
			public char __Description90;

			// Token: 0x040003D0 RID: 976
			public char __Description91;

			// Token: 0x040003D1 RID: 977
			public char __Description92;

			// Token: 0x040003D2 RID: 978
			public char __Description93;

			// Token: 0x040003D3 RID: 979
			public char __Description94;

			// Token: 0x040003D4 RID: 980
			public char __Description95;

			// Token: 0x040003D5 RID: 981
			public char __Description96;

			// Token: 0x040003D6 RID: 982
			public char __Description97;

			// Token: 0x040003D7 RID: 983
			public char __Description98;

			// Token: 0x040003D8 RID: 984
			public char __Description99;

			// Token: 0x040003D9 RID: 985
			public char __Description100;

			// Token: 0x040003DA RID: 986
			public char __Description101;

			// Token: 0x040003DB RID: 987
			public char __Description102;

			// Token: 0x040003DC RID: 988
			public char __Description103;

			// Token: 0x040003DD RID: 989
			public char __Description104;

			// Token: 0x040003DE RID: 990
			public char __Description105;

			// Token: 0x040003DF RID: 991
			public char __Description106;

			// Token: 0x040003E0 RID: 992
			public char __Description107;

			// Token: 0x040003E1 RID: 993
			public char __Description108;

			// Token: 0x040003E2 RID: 994
			public char __Description109;

			// Token: 0x040003E3 RID: 995
			public char __Description110;

			// Token: 0x040003E4 RID: 996
			public char __Description111;

			// Token: 0x040003E5 RID: 997
			public char __Description112;

			// Token: 0x040003E6 RID: 998
			public char __Description113;

			// Token: 0x040003E7 RID: 999
			public char __Description114;

			// Token: 0x040003E8 RID: 1000
			public char __Description115;

			// Token: 0x040003E9 RID: 1001
			public char __Description116;

			// Token: 0x040003EA RID: 1002
			public char __Description117;

			// Token: 0x040003EB RID: 1003
			public char __Description118;

			// Token: 0x040003EC RID: 1004
			public char __Description119;

			// Token: 0x040003ED RID: 1005
			public char __Description120;

			// Token: 0x040003EE RID: 1006
			public char __Description121;

			// Token: 0x040003EF RID: 1007
			public char __Description122;

			// Token: 0x040003F0 RID: 1008
			public char __Description123;

			// Token: 0x040003F1 RID: 1009
			public char __Description124;

			// Token: 0x040003F2 RID: 1010
			public char __Description125;

			// Token: 0x040003F3 RID: 1011
			public char __Description126;

			// Token: 0x040003F4 RID: 1012
			public char __Description127;

			// Token: 0x040003F5 RID: 1013
			public int VendorId;

			// Token: 0x040003F6 RID: 1014
			public int DeviceId;

			// Token: 0x040003F7 RID: 1015
			public int SubsystemId;

			// Token: 0x040003F8 RID: 1016
			public int Revision;

			// Token: 0x040003F9 RID: 1017
			public IntPtr DedicatedVideoMemory;

			// Token: 0x040003FA RID: 1018
			public IntPtr DedicatedSystemMemory;

			// Token: 0x040003FB RID: 1019
			public IntPtr SharedSystemMemory;

			// Token: 0x040003FC RID: 1020
			public long Luid;

			// Token: 0x040003FD RID: 1021
			public AdapterFlags3 Flags;

			// Token: 0x040003FE RID: 1022
			public GraphicsPreemptionGranularity GraphicsPreemptionGranularity;

			// Token: 0x040003FF RID: 1023
			public ComputePreemptionGranularity ComputePreemptionGranularity;
		}
	}
}
