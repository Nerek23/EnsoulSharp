using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000EB RID: 235
	public struct GammaRamp
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00019B70 File Offset: 0x00017D70
		public short[] Red
		{
			get
			{
				short[] result;
				if ((result = this._Red) == null)
				{
					result = (this._Red = new short[256]);
				}
				return result;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00019B9C File Offset: 0x00017D9C
		public short[] Green
		{
			get
			{
				short[] result;
				if ((result = this._Green) == null)
				{
					result = (this._Green = new short[256]);
				}
				return result;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00019BC8 File Offset: 0x00017DC8
		public short[] Blue
		{
			get
			{
				short[] result;
				if ((result = this._Blue) == null)
				{
					result = (this._Blue = new short[256]);
				}
				return result;
			}
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00019BF2 File Offset: 0x00017DF2
		internal void __MarshalFree(ref GammaRamp.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00019BFC File Offset: 0x00017DFC
		internal unsafe void __MarshalFrom(ref GammaRamp.__Native @ref)
		{
			fixed (short* ptr = &this.Red[0])
			{
				void* value = (void*)ptr;
				fixed (short* ptr2 = &@ref.Red)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 512);
				}
			}
			fixed (short* ptr = &this.Green[0])
			{
				void* value3 = (void*)ptr;
				fixed (short* ptr2 = &@ref.Green)
				{
					void* value4 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value3, (IntPtr)value4, 512);
				}
			}
			fixed (short* ptr = &this.Blue[0])
			{
				void* value5 = (void*)ptr;
				fixed (short* ptr2 = &@ref.Blue)
				{
					void* value6 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value5, (IntPtr)value6, 512);
				}
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00019CB4 File Offset: 0x00017EB4
		internal unsafe void __MarshalTo(ref GammaRamp.__Native @ref)
		{
			fixed (short* ptr = &@ref.Red)
			{
				void* value = (void*)ptr;
				fixed (short* ptr2 = &this.Red[0])
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 512);
				}
			}
			fixed (short* ptr = &@ref.Green)
			{
				void* value3 = (void*)ptr;
				fixed (short* ptr2 = &this.Green[0])
				{
					void* value4 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value3, (IntPtr)value4, 512);
				}
			}
			fixed (short* ptr = &@ref.Blue)
			{
				void* value5 = (void*)ptr;
				fixed (short* ptr2 = &this.Blue[0])
				{
					void* value6 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value5, (IntPtr)value6, 512);
				}
			}
		}

		// Token: 0x04000A81 RID: 2689
		internal short[] _Red;

		// Token: 0x04000A82 RID: 2690
		internal short[] _Green;

		// Token: 0x04000A83 RID: 2691
		internal short[] _Blue;

		// Token: 0x020000EC RID: 236
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal struct __Native
		{
			// Token: 0x06000739 RID: 1849 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000A84 RID: 2692
			public short Red;

			// Token: 0x04000A85 RID: 2693
			private short __Red1;

			// Token: 0x04000A86 RID: 2694
			private short __Red2;

			// Token: 0x04000A87 RID: 2695
			private short __Red3;

			// Token: 0x04000A88 RID: 2696
			private short __Red4;

			// Token: 0x04000A89 RID: 2697
			private short __Red5;

			// Token: 0x04000A8A RID: 2698
			private short __Red6;

			// Token: 0x04000A8B RID: 2699
			private short __Red7;

			// Token: 0x04000A8C RID: 2700
			private short __Red8;

			// Token: 0x04000A8D RID: 2701
			private short __Red9;

			// Token: 0x04000A8E RID: 2702
			private short __Red10;

			// Token: 0x04000A8F RID: 2703
			private short __Red11;

			// Token: 0x04000A90 RID: 2704
			private short __Red12;

			// Token: 0x04000A91 RID: 2705
			private short __Red13;

			// Token: 0x04000A92 RID: 2706
			private short __Red14;

			// Token: 0x04000A93 RID: 2707
			private short __Red15;

			// Token: 0x04000A94 RID: 2708
			private short __Red16;

			// Token: 0x04000A95 RID: 2709
			private short __Red17;

			// Token: 0x04000A96 RID: 2710
			private short __Red18;

			// Token: 0x04000A97 RID: 2711
			private short __Red19;

			// Token: 0x04000A98 RID: 2712
			private short __Red20;

			// Token: 0x04000A99 RID: 2713
			private short __Red21;

			// Token: 0x04000A9A RID: 2714
			private short __Red22;

			// Token: 0x04000A9B RID: 2715
			private short __Red23;

			// Token: 0x04000A9C RID: 2716
			private short __Red24;

			// Token: 0x04000A9D RID: 2717
			private short __Red25;

			// Token: 0x04000A9E RID: 2718
			private short __Red26;

			// Token: 0x04000A9F RID: 2719
			private short __Red27;

			// Token: 0x04000AA0 RID: 2720
			private short __Red28;

			// Token: 0x04000AA1 RID: 2721
			private short __Red29;

			// Token: 0x04000AA2 RID: 2722
			private short __Red30;

			// Token: 0x04000AA3 RID: 2723
			private short __Red31;

			// Token: 0x04000AA4 RID: 2724
			private short __Red32;

			// Token: 0x04000AA5 RID: 2725
			private short __Red33;

			// Token: 0x04000AA6 RID: 2726
			private short __Red34;

			// Token: 0x04000AA7 RID: 2727
			private short __Red35;

			// Token: 0x04000AA8 RID: 2728
			private short __Red36;

			// Token: 0x04000AA9 RID: 2729
			private short __Red37;

			// Token: 0x04000AAA RID: 2730
			private short __Red38;

			// Token: 0x04000AAB RID: 2731
			private short __Red39;

			// Token: 0x04000AAC RID: 2732
			private short __Red40;

			// Token: 0x04000AAD RID: 2733
			private short __Red41;

			// Token: 0x04000AAE RID: 2734
			private short __Red42;

			// Token: 0x04000AAF RID: 2735
			private short __Red43;

			// Token: 0x04000AB0 RID: 2736
			private short __Red44;

			// Token: 0x04000AB1 RID: 2737
			private short __Red45;

			// Token: 0x04000AB2 RID: 2738
			private short __Red46;

			// Token: 0x04000AB3 RID: 2739
			private short __Red47;

			// Token: 0x04000AB4 RID: 2740
			private short __Red48;

			// Token: 0x04000AB5 RID: 2741
			private short __Red49;

			// Token: 0x04000AB6 RID: 2742
			private short __Red50;

			// Token: 0x04000AB7 RID: 2743
			private short __Red51;

			// Token: 0x04000AB8 RID: 2744
			private short __Red52;

			// Token: 0x04000AB9 RID: 2745
			private short __Red53;

			// Token: 0x04000ABA RID: 2746
			private short __Red54;

			// Token: 0x04000ABB RID: 2747
			private short __Red55;

			// Token: 0x04000ABC RID: 2748
			private short __Red56;

			// Token: 0x04000ABD RID: 2749
			private short __Red57;

			// Token: 0x04000ABE RID: 2750
			private short __Red58;

			// Token: 0x04000ABF RID: 2751
			private short __Red59;

			// Token: 0x04000AC0 RID: 2752
			private short __Red60;

			// Token: 0x04000AC1 RID: 2753
			private short __Red61;

			// Token: 0x04000AC2 RID: 2754
			private short __Red62;

			// Token: 0x04000AC3 RID: 2755
			private short __Red63;

			// Token: 0x04000AC4 RID: 2756
			private short __Red64;

			// Token: 0x04000AC5 RID: 2757
			private short __Red65;

			// Token: 0x04000AC6 RID: 2758
			private short __Red66;

			// Token: 0x04000AC7 RID: 2759
			private short __Red67;

			// Token: 0x04000AC8 RID: 2760
			private short __Red68;

			// Token: 0x04000AC9 RID: 2761
			private short __Red69;

			// Token: 0x04000ACA RID: 2762
			private short __Red70;

			// Token: 0x04000ACB RID: 2763
			private short __Red71;

			// Token: 0x04000ACC RID: 2764
			private short __Red72;

			// Token: 0x04000ACD RID: 2765
			private short __Red73;

			// Token: 0x04000ACE RID: 2766
			private short __Red74;

			// Token: 0x04000ACF RID: 2767
			private short __Red75;

			// Token: 0x04000AD0 RID: 2768
			private short __Red76;

			// Token: 0x04000AD1 RID: 2769
			private short __Red77;

			// Token: 0x04000AD2 RID: 2770
			private short __Red78;

			// Token: 0x04000AD3 RID: 2771
			private short __Red79;

			// Token: 0x04000AD4 RID: 2772
			private short __Red80;

			// Token: 0x04000AD5 RID: 2773
			private short __Red81;

			// Token: 0x04000AD6 RID: 2774
			private short __Red82;

			// Token: 0x04000AD7 RID: 2775
			private short __Red83;

			// Token: 0x04000AD8 RID: 2776
			private short __Red84;

			// Token: 0x04000AD9 RID: 2777
			private short __Red85;

			// Token: 0x04000ADA RID: 2778
			private short __Red86;

			// Token: 0x04000ADB RID: 2779
			private short __Red87;

			// Token: 0x04000ADC RID: 2780
			private short __Red88;

			// Token: 0x04000ADD RID: 2781
			private short __Red89;

			// Token: 0x04000ADE RID: 2782
			private short __Red90;

			// Token: 0x04000ADF RID: 2783
			private short __Red91;

			// Token: 0x04000AE0 RID: 2784
			private short __Red92;

			// Token: 0x04000AE1 RID: 2785
			private short __Red93;

			// Token: 0x04000AE2 RID: 2786
			private short __Red94;

			// Token: 0x04000AE3 RID: 2787
			private short __Red95;

			// Token: 0x04000AE4 RID: 2788
			private short __Red96;

			// Token: 0x04000AE5 RID: 2789
			private short __Red97;

			// Token: 0x04000AE6 RID: 2790
			private short __Red98;

			// Token: 0x04000AE7 RID: 2791
			private short __Red99;

			// Token: 0x04000AE8 RID: 2792
			private short __Red100;

			// Token: 0x04000AE9 RID: 2793
			private short __Red101;

			// Token: 0x04000AEA RID: 2794
			private short __Red102;

			// Token: 0x04000AEB RID: 2795
			private short __Red103;

			// Token: 0x04000AEC RID: 2796
			private short __Red104;

			// Token: 0x04000AED RID: 2797
			private short __Red105;

			// Token: 0x04000AEE RID: 2798
			private short __Red106;

			// Token: 0x04000AEF RID: 2799
			private short __Red107;

			// Token: 0x04000AF0 RID: 2800
			private short __Red108;

			// Token: 0x04000AF1 RID: 2801
			private short __Red109;

			// Token: 0x04000AF2 RID: 2802
			private short __Red110;

			// Token: 0x04000AF3 RID: 2803
			private short __Red111;

			// Token: 0x04000AF4 RID: 2804
			private short __Red112;

			// Token: 0x04000AF5 RID: 2805
			private short __Red113;

			// Token: 0x04000AF6 RID: 2806
			private short __Red114;

			// Token: 0x04000AF7 RID: 2807
			private short __Red115;

			// Token: 0x04000AF8 RID: 2808
			private short __Red116;

			// Token: 0x04000AF9 RID: 2809
			private short __Red117;

			// Token: 0x04000AFA RID: 2810
			private short __Red118;

			// Token: 0x04000AFB RID: 2811
			private short __Red119;

			// Token: 0x04000AFC RID: 2812
			private short __Red120;

			// Token: 0x04000AFD RID: 2813
			private short __Red121;

			// Token: 0x04000AFE RID: 2814
			private short __Red122;

			// Token: 0x04000AFF RID: 2815
			private short __Red123;

			// Token: 0x04000B00 RID: 2816
			private short __Red124;

			// Token: 0x04000B01 RID: 2817
			private short __Red125;

			// Token: 0x04000B02 RID: 2818
			private short __Red126;

			// Token: 0x04000B03 RID: 2819
			private short __Red127;

			// Token: 0x04000B04 RID: 2820
			private short __Red128;

			// Token: 0x04000B05 RID: 2821
			private short __Red129;

			// Token: 0x04000B06 RID: 2822
			private short __Red130;

			// Token: 0x04000B07 RID: 2823
			private short __Red131;

			// Token: 0x04000B08 RID: 2824
			private short __Red132;

			// Token: 0x04000B09 RID: 2825
			private short __Red133;

			// Token: 0x04000B0A RID: 2826
			private short __Red134;

			// Token: 0x04000B0B RID: 2827
			private short __Red135;

			// Token: 0x04000B0C RID: 2828
			private short __Red136;

			// Token: 0x04000B0D RID: 2829
			private short __Red137;

			// Token: 0x04000B0E RID: 2830
			private short __Red138;

			// Token: 0x04000B0F RID: 2831
			private short __Red139;

			// Token: 0x04000B10 RID: 2832
			private short __Red140;

			// Token: 0x04000B11 RID: 2833
			private short __Red141;

			// Token: 0x04000B12 RID: 2834
			private short __Red142;

			// Token: 0x04000B13 RID: 2835
			private short __Red143;

			// Token: 0x04000B14 RID: 2836
			private short __Red144;

			// Token: 0x04000B15 RID: 2837
			private short __Red145;

			// Token: 0x04000B16 RID: 2838
			private short __Red146;

			// Token: 0x04000B17 RID: 2839
			private short __Red147;

			// Token: 0x04000B18 RID: 2840
			private short __Red148;

			// Token: 0x04000B19 RID: 2841
			private short __Red149;

			// Token: 0x04000B1A RID: 2842
			private short __Red150;

			// Token: 0x04000B1B RID: 2843
			private short __Red151;

			// Token: 0x04000B1C RID: 2844
			private short __Red152;

			// Token: 0x04000B1D RID: 2845
			private short __Red153;

			// Token: 0x04000B1E RID: 2846
			private short __Red154;

			// Token: 0x04000B1F RID: 2847
			private short __Red155;

			// Token: 0x04000B20 RID: 2848
			private short __Red156;

			// Token: 0x04000B21 RID: 2849
			private short __Red157;

			// Token: 0x04000B22 RID: 2850
			private short __Red158;

			// Token: 0x04000B23 RID: 2851
			private short __Red159;

			// Token: 0x04000B24 RID: 2852
			private short __Red160;

			// Token: 0x04000B25 RID: 2853
			private short __Red161;

			// Token: 0x04000B26 RID: 2854
			private short __Red162;

			// Token: 0x04000B27 RID: 2855
			private short __Red163;

			// Token: 0x04000B28 RID: 2856
			private short __Red164;

			// Token: 0x04000B29 RID: 2857
			private short __Red165;

			// Token: 0x04000B2A RID: 2858
			private short __Red166;

			// Token: 0x04000B2B RID: 2859
			private short __Red167;

			// Token: 0x04000B2C RID: 2860
			private short __Red168;

			// Token: 0x04000B2D RID: 2861
			private short __Red169;

			// Token: 0x04000B2E RID: 2862
			private short __Red170;

			// Token: 0x04000B2F RID: 2863
			private short __Red171;

			// Token: 0x04000B30 RID: 2864
			private short __Red172;

			// Token: 0x04000B31 RID: 2865
			private short __Red173;

			// Token: 0x04000B32 RID: 2866
			private short __Red174;

			// Token: 0x04000B33 RID: 2867
			private short __Red175;

			// Token: 0x04000B34 RID: 2868
			private short __Red176;

			// Token: 0x04000B35 RID: 2869
			private short __Red177;

			// Token: 0x04000B36 RID: 2870
			private short __Red178;

			// Token: 0x04000B37 RID: 2871
			private short __Red179;

			// Token: 0x04000B38 RID: 2872
			private short __Red180;

			// Token: 0x04000B39 RID: 2873
			private short __Red181;

			// Token: 0x04000B3A RID: 2874
			private short __Red182;

			// Token: 0x04000B3B RID: 2875
			private short __Red183;

			// Token: 0x04000B3C RID: 2876
			private short __Red184;

			// Token: 0x04000B3D RID: 2877
			private short __Red185;

			// Token: 0x04000B3E RID: 2878
			private short __Red186;

			// Token: 0x04000B3F RID: 2879
			private short __Red187;

			// Token: 0x04000B40 RID: 2880
			private short __Red188;

			// Token: 0x04000B41 RID: 2881
			private short __Red189;

			// Token: 0x04000B42 RID: 2882
			private short __Red190;

			// Token: 0x04000B43 RID: 2883
			private short __Red191;

			// Token: 0x04000B44 RID: 2884
			private short __Red192;

			// Token: 0x04000B45 RID: 2885
			private short __Red193;

			// Token: 0x04000B46 RID: 2886
			private short __Red194;

			// Token: 0x04000B47 RID: 2887
			private short __Red195;

			// Token: 0x04000B48 RID: 2888
			private short __Red196;

			// Token: 0x04000B49 RID: 2889
			private short __Red197;

			// Token: 0x04000B4A RID: 2890
			private short __Red198;

			// Token: 0x04000B4B RID: 2891
			private short __Red199;

			// Token: 0x04000B4C RID: 2892
			private short __Red200;

			// Token: 0x04000B4D RID: 2893
			private short __Red201;

			// Token: 0x04000B4E RID: 2894
			private short __Red202;

			// Token: 0x04000B4F RID: 2895
			private short __Red203;

			// Token: 0x04000B50 RID: 2896
			private short __Red204;

			// Token: 0x04000B51 RID: 2897
			private short __Red205;

			// Token: 0x04000B52 RID: 2898
			private short __Red206;

			// Token: 0x04000B53 RID: 2899
			private short __Red207;

			// Token: 0x04000B54 RID: 2900
			private short __Red208;

			// Token: 0x04000B55 RID: 2901
			private short __Red209;

			// Token: 0x04000B56 RID: 2902
			private short __Red210;

			// Token: 0x04000B57 RID: 2903
			private short __Red211;

			// Token: 0x04000B58 RID: 2904
			private short __Red212;

			// Token: 0x04000B59 RID: 2905
			private short __Red213;

			// Token: 0x04000B5A RID: 2906
			private short __Red214;

			// Token: 0x04000B5B RID: 2907
			private short __Red215;

			// Token: 0x04000B5C RID: 2908
			private short __Red216;

			// Token: 0x04000B5D RID: 2909
			private short __Red217;

			// Token: 0x04000B5E RID: 2910
			private short __Red218;

			// Token: 0x04000B5F RID: 2911
			private short __Red219;

			// Token: 0x04000B60 RID: 2912
			private short __Red220;

			// Token: 0x04000B61 RID: 2913
			private short __Red221;

			// Token: 0x04000B62 RID: 2914
			private short __Red222;

			// Token: 0x04000B63 RID: 2915
			private short __Red223;

			// Token: 0x04000B64 RID: 2916
			private short __Red224;

			// Token: 0x04000B65 RID: 2917
			private short __Red225;

			// Token: 0x04000B66 RID: 2918
			private short __Red226;

			// Token: 0x04000B67 RID: 2919
			private short __Red227;

			// Token: 0x04000B68 RID: 2920
			private short __Red228;

			// Token: 0x04000B69 RID: 2921
			private short __Red229;

			// Token: 0x04000B6A RID: 2922
			private short __Red230;

			// Token: 0x04000B6B RID: 2923
			private short __Red231;

			// Token: 0x04000B6C RID: 2924
			private short __Red232;

			// Token: 0x04000B6D RID: 2925
			private short __Red233;

			// Token: 0x04000B6E RID: 2926
			private short __Red234;

			// Token: 0x04000B6F RID: 2927
			private short __Red235;

			// Token: 0x04000B70 RID: 2928
			private short __Red236;

			// Token: 0x04000B71 RID: 2929
			private short __Red237;

			// Token: 0x04000B72 RID: 2930
			private short __Red238;

			// Token: 0x04000B73 RID: 2931
			private short __Red239;

			// Token: 0x04000B74 RID: 2932
			private short __Red240;

			// Token: 0x04000B75 RID: 2933
			private short __Red241;

			// Token: 0x04000B76 RID: 2934
			private short __Red242;

			// Token: 0x04000B77 RID: 2935
			private short __Red243;

			// Token: 0x04000B78 RID: 2936
			private short __Red244;

			// Token: 0x04000B79 RID: 2937
			private short __Red245;

			// Token: 0x04000B7A RID: 2938
			private short __Red246;

			// Token: 0x04000B7B RID: 2939
			private short __Red247;

			// Token: 0x04000B7C RID: 2940
			private short __Red248;

			// Token: 0x04000B7D RID: 2941
			private short __Red249;

			// Token: 0x04000B7E RID: 2942
			private short __Red250;

			// Token: 0x04000B7F RID: 2943
			private short __Red251;

			// Token: 0x04000B80 RID: 2944
			private short __Red252;

			// Token: 0x04000B81 RID: 2945
			private short __Red253;

			// Token: 0x04000B82 RID: 2946
			private short __Red254;

			// Token: 0x04000B83 RID: 2947
			private short __Red255;

			// Token: 0x04000B84 RID: 2948
			public short Green;

			// Token: 0x04000B85 RID: 2949
			private short __Green1;

			// Token: 0x04000B86 RID: 2950
			private short __Green2;

			// Token: 0x04000B87 RID: 2951
			private short __Green3;

			// Token: 0x04000B88 RID: 2952
			private short __Green4;

			// Token: 0x04000B89 RID: 2953
			private short __Green5;

			// Token: 0x04000B8A RID: 2954
			private short __Green6;

			// Token: 0x04000B8B RID: 2955
			private short __Green7;

			// Token: 0x04000B8C RID: 2956
			private short __Green8;

			// Token: 0x04000B8D RID: 2957
			private short __Green9;

			// Token: 0x04000B8E RID: 2958
			private short __Green10;

			// Token: 0x04000B8F RID: 2959
			private short __Green11;

			// Token: 0x04000B90 RID: 2960
			private short __Green12;

			// Token: 0x04000B91 RID: 2961
			private short __Green13;

			// Token: 0x04000B92 RID: 2962
			private short __Green14;

			// Token: 0x04000B93 RID: 2963
			private short __Green15;

			// Token: 0x04000B94 RID: 2964
			private short __Green16;

			// Token: 0x04000B95 RID: 2965
			private short __Green17;

			// Token: 0x04000B96 RID: 2966
			private short __Green18;

			// Token: 0x04000B97 RID: 2967
			private short __Green19;

			// Token: 0x04000B98 RID: 2968
			private short __Green20;

			// Token: 0x04000B99 RID: 2969
			private short __Green21;

			// Token: 0x04000B9A RID: 2970
			private short __Green22;

			// Token: 0x04000B9B RID: 2971
			private short __Green23;

			// Token: 0x04000B9C RID: 2972
			private short __Green24;

			// Token: 0x04000B9D RID: 2973
			private short __Green25;

			// Token: 0x04000B9E RID: 2974
			private short __Green26;

			// Token: 0x04000B9F RID: 2975
			private short __Green27;

			// Token: 0x04000BA0 RID: 2976
			private short __Green28;

			// Token: 0x04000BA1 RID: 2977
			private short __Green29;

			// Token: 0x04000BA2 RID: 2978
			private short __Green30;

			// Token: 0x04000BA3 RID: 2979
			private short __Green31;

			// Token: 0x04000BA4 RID: 2980
			private short __Green32;

			// Token: 0x04000BA5 RID: 2981
			private short __Green33;

			// Token: 0x04000BA6 RID: 2982
			private short __Green34;

			// Token: 0x04000BA7 RID: 2983
			private short __Green35;

			// Token: 0x04000BA8 RID: 2984
			private short __Green36;

			// Token: 0x04000BA9 RID: 2985
			private short __Green37;

			// Token: 0x04000BAA RID: 2986
			private short __Green38;

			// Token: 0x04000BAB RID: 2987
			private short __Green39;

			// Token: 0x04000BAC RID: 2988
			private short __Green40;

			// Token: 0x04000BAD RID: 2989
			private short __Green41;

			// Token: 0x04000BAE RID: 2990
			private short __Green42;

			// Token: 0x04000BAF RID: 2991
			private short __Green43;

			// Token: 0x04000BB0 RID: 2992
			private short __Green44;

			// Token: 0x04000BB1 RID: 2993
			private short __Green45;

			// Token: 0x04000BB2 RID: 2994
			private short __Green46;

			// Token: 0x04000BB3 RID: 2995
			private short __Green47;

			// Token: 0x04000BB4 RID: 2996
			private short __Green48;

			// Token: 0x04000BB5 RID: 2997
			private short __Green49;

			// Token: 0x04000BB6 RID: 2998
			private short __Green50;

			// Token: 0x04000BB7 RID: 2999
			private short __Green51;

			// Token: 0x04000BB8 RID: 3000
			private short __Green52;

			// Token: 0x04000BB9 RID: 3001
			private short __Green53;

			// Token: 0x04000BBA RID: 3002
			private short __Green54;

			// Token: 0x04000BBB RID: 3003
			private short __Green55;

			// Token: 0x04000BBC RID: 3004
			private short __Green56;

			// Token: 0x04000BBD RID: 3005
			private short __Green57;

			// Token: 0x04000BBE RID: 3006
			private short __Green58;

			// Token: 0x04000BBF RID: 3007
			private short __Green59;

			// Token: 0x04000BC0 RID: 3008
			private short __Green60;

			// Token: 0x04000BC1 RID: 3009
			private short __Green61;

			// Token: 0x04000BC2 RID: 3010
			private short __Green62;

			// Token: 0x04000BC3 RID: 3011
			private short __Green63;

			// Token: 0x04000BC4 RID: 3012
			private short __Green64;

			// Token: 0x04000BC5 RID: 3013
			private short __Green65;

			// Token: 0x04000BC6 RID: 3014
			private short __Green66;

			// Token: 0x04000BC7 RID: 3015
			private short __Green67;

			// Token: 0x04000BC8 RID: 3016
			private short __Green68;

			// Token: 0x04000BC9 RID: 3017
			private short __Green69;

			// Token: 0x04000BCA RID: 3018
			private short __Green70;

			// Token: 0x04000BCB RID: 3019
			private short __Green71;

			// Token: 0x04000BCC RID: 3020
			private short __Green72;

			// Token: 0x04000BCD RID: 3021
			private short __Green73;

			// Token: 0x04000BCE RID: 3022
			private short __Green74;

			// Token: 0x04000BCF RID: 3023
			private short __Green75;

			// Token: 0x04000BD0 RID: 3024
			private short __Green76;

			// Token: 0x04000BD1 RID: 3025
			private short __Green77;

			// Token: 0x04000BD2 RID: 3026
			private short __Green78;

			// Token: 0x04000BD3 RID: 3027
			private short __Green79;

			// Token: 0x04000BD4 RID: 3028
			private short __Green80;

			// Token: 0x04000BD5 RID: 3029
			private short __Green81;

			// Token: 0x04000BD6 RID: 3030
			private short __Green82;

			// Token: 0x04000BD7 RID: 3031
			private short __Green83;

			// Token: 0x04000BD8 RID: 3032
			private short __Green84;

			// Token: 0x04000BD9 RID: 3033
			private short __Green85;

			// Token: 0x04000BDA RID: 3034
			private short __Green86;

			// Token: 0x04000BDB RID: 3035
			private short __Green87;

			// Token: 0x04000BDC RID: 3036
			private short __Green88;

			// Token: 0x04000BDD RID: 3037
			private short __Green89;

			// Token: 0x04000BDE RID: 3038
			private short __Green90;

			// Token: 0x04000BDF RID: 3039
			private short __Green91;

			// Token: 0x04000BE0 RID: 3040
			private short __Green92;

			// Token: 0x04000BE1 RID: 3041
			private short __Green93;

			// Token: 0x04000BE2 RID: 3042
			private short __Green94;

			// Token: 0x04000BE3 RID: 3043
			private short __Green95;

			// Token: 0x04000BE4 RID: 3044
			private short __Green96;

			// Token: 0x04000BE5 RID: 3045
			private short __Green97;

			// Token: 0x04000BE6 RID: 3046
			private short __Green98;

			// Token: 0x04000BE7 RID: 3047
			private short __Green99;

			// Token: 0x04000BE8 RID: 3048
			private short __Green100;

			// Token: 0x04000BE9 RID: 3049
			private short __Green101;

			// Token: 0x04000BEA RID: 3050
			private short __Green102;

			// Token: 0x04000BEB RID: 3051
			private short __Green103;

			// Token: 0x04000BEC RID: 3052
			private short __Green104;

			// Token: 0x04000BED RID: 3053
			private short __Green105;

			// Token: 0x04000BEE RID: 3054
			private short __Green106;

			// Token: 0x04000BEF RID: 3055
			private short __Green107;

			// Token: 0x04000BF0 RID: 3056
			private short __Green108;

			// Token: 0x04000BF1 RID: 3057
			private short __Green109;

			// Token: 0x04000BF2 RID: 3058
			private short __Green110;

			// Token: 0x04000BF3 RID: 3059
			private short __Green111;

			// Token: 0x04000BF4 RID: 3060
			private short __Green112;

			// Token: 0x04000BF5 RID: 3061
			private short __Green113;

			// Token: 0x04000BF6 RID: 3062
			private short __Green114;

			// Token: 0x04000BF7 RID: 3063
			private short __Green115;

			// Token: 0x04000BF8 RID: 3064
			private short __Green116;

			// Token: 0x04000BF9 RID: 3065
			private short __Green117;

			// Token: 0x04000BFA RID: 3066
			private short __Green118;

			// Token: 0x04000BFB RID: 3067
			private short __Green119;

			// Token: 0x04000BFC RID: 3068
			private short __Green120;

			// Token: 0x04000BFD RID: 3069
			private short __Green121;

			// Token: 0x04000BFE RID: 3070
			private short __Green122;

			// Token: 0x04000BFF RID: 3071
			private short __Green123;

			// Token: 0x04000C00 RID: 3072
			private short __Green124;

			// Token: 0x04000C01 RID: 3073
			private short __Green125;

			// Token: 0x04000C02 RID: 3074
			private short __Green126;

			// Token: 0x04000C03 RID: 3075
			private short __Green127;

			// Token: 0x04000C04 RID: 3076
			private short __Green128;

			// Token: 0x04000C05 RID: 3077
			private short __Green129;

			// Token: 0x04000C06 RID: 3078
			private short __Green130;

			// Token: 0x04000C07 RID: 3079
			private short __Green131;

			// Token: 0x04000C08 RID: 3080
			private short __Green132;

			// Token: 0x04000C09 RID: 3081
			private short __Green133;

			// Token: 0x04000C0A RID: 3082
			private short __Green134;

			// Token: 0x04000C0B RID: 3083
			private short __Green135;

			// Token: 0x04000C0C RID: 3084
			private short __Green136;

			// Token: 0x04000C0D RID: 3085
			private short __Green137;

			// Token: 0x04000C0E RID: 3086
			private short __Green138;

			// Token: 0x04000C0F RID: 3087
			private short __Green139;

			// Token: 0x04000C10 RID: 3088
			private short __Green140;

			// Token: 0x04000C11 RID: 3089
			private short __Green141;

			// Token: 0x04000C12 RID: 3090
			private short __Green142;

			// Token: 0x04000C13 RID: 3091
			private short __Green143;

			// Token: 0x04000C14 RID: 3092
			private short __Green144;

			// Token: 0x04000C15 RID: 3093
			private short __Green145;

			// Token: 0x04000C16 RID: 3094
			private short __Green146;

			// Token: 0x04000C17 RID: 3095
			private short __Green147;

			// Token: 0x04000C18 RID: 3096
			private short __Green148;

			// Token: 0x04000C19 RID: 3097
			private short __Green149;

			// Token: 0x04000C1A RID: 3098
			private short __Green150;

			// Token: 0x04000C1B RID: 3099
			private short __Green151;

			// Token: 0x04000C1C RID: 3100
			private short __Green152;

			// Token: 0x04000C1D RID: 3101
			private short __Green153;

			// Token: 0x04000C1E RID: 3102
			private short __Green154;

			// Token: 0x04000C1F RID: 3103
			private short __Green155;

			// Token: 0x04000C20 RID: 3104
			private short __Green156;

			// Token: 0x04000C21 RID: 3105
			private short __Green157;

			// Token: 0x04000C22 RID: 3106
			private short __Green158;

			// Token: 0x04000C23 RID: 3107
			private short __Green159;

			// Token: 0x04000C24 RID: 3108
			private short __Green160;

			// Token: 0x04000C25 RID: 3109
			private short __Green161;

			// Token: 0x04000C26 RID: 3110
			private short __Green162;

			// Token: 0x04000C27 RID: 3111
			private short __Green163;

			// Token: 0x04000C28 RID: 3112
			private short __Green164;

			// Token: 0x04000C29 RID: 3113
			private short __Green165;

			// Token: 0x04000C2A RID: 3114
			private short __Green166;

			// Token: 0x04000C2B RID: 3115
			private short __Green167;

			// Token: 0x04000C2C RID: 3116
			private short __Green168;

			// Token: 0x04000C2D RID: 3117
			private short __Green169;

			// Token: 0x04000C2E RID: 3118
			private short __Green170;

			// Token: 0x04000C2F RID: 3119
			private short __Green171;

			// Token: 0x04000C30 RID: 3120
			private short __Green172;

			// Token: 0x04000C31 RID: 3121
			private short __Green173;

			// Token: 0x04000C32 RID: 3122
			private short __Green174;

			// Token: 0x04000C33 RID: 3123
			private short __Green175;

			// Token: 0x04000C34 RID: 3124
			private short __Green176;

			// Token: 0x04000C35 RID: 3125
			private short __Green177;

			// Token: 0x04000C36 RID: 3126
			private short __Green178;

			// Token: 0x04000C37 RID: 3127
			private short __Green179;

			// Token: 0x04000C38 RID: 3128
			private short __Green180;

			// Token: 0x04000C39 RID: 3129
			private short __Green181;

			// Token: 0x04000C3A RID: 3130
			private short __Green182;

			// Token: 0x04000C3B RID: 3131
			private short __Green183;

			// Token: 0x04000C3C RID: 3132
			private short __Green184;

			// Token: 0x04000C3D RID: 3133
			private short __Green185;

			// Token: 0x04000C3E RID: 3134
			private short __Green186;

			// Token: 0x04000C3F RID: 3135
			private short __Green187;

			// Token: 0x04000C40 RID: 3136
			private short __Green188;

			// Token: 0x04000C41 RID: 3137
			private short __Green189;

			// Token: 0x04000C42 RID: 3138
			private short __Green190;

			// Token: 0x04000C43 RID: 3139
			private short __Green191;

			// Token: 0x04000C44 RID: 3140
			private short __Green192;

			// Token: 0x04000C45 RID: 3141
			private short __Green193;

			// Token: 0x04000C46 RID: 3142
			private short __Green194;

			// Token: 0x04000C47 RID: 3143
			private short __Green195;

			// Token: 0x04000C48 RID: 3144
			private short __Green196;

			// Token: 0x04000C49 RID: 3145
			private short __Green197;

			// Token: 0x04000C4A RID: 3146
			private short __Green198;

			// Token: 0x04000C4B RID: 3147
			private short __Green199;

			// Token: 0x04000C4C RID: 3148
			private short __Green200;

			// Token: 0x04000C4D RID: 3149
			private short __Green201;

			// Token: 0x04000C4E RID: 3150
			private short __Green202;

			// Token: 0x04000C4F RID: 3151
			private short __Green203;

			// Token: 0x04000C50 RID: 3152
			private short __Green204;

			// Token: 0x04000C51 RID: 3153
			private short __Green205;

			// Token: 0x04000C52 RID: 3154
			private short __Green206;

			// Token: 0x04000C53 RID: 3155
			private short __Green207;

			// Token: 0x04000C54 RID: 3156
			private short __Green208;

			// Token: 0x04000C55 RID: 3157
			private short __Green209;

			// Token: 0x04000C56 RID: 3158
			private short __Green210;

			// Token: 0x04000C57 RID: 3159
			private short __Green211;

			// Token: 0x04000C58 RID: 3160
			private short __Green212;

			// Token: 0x04000C59 RID: 3161
			private short __Green213;

			// Token: 0x04000C5A RID: 3162
			private short __Green214;

			// Token: 0x04000C5B RID: 3163
			private short __Green215;

			// Token: 0x04000C5C RID: 3164
			private short __Green216;

			// Token: 0x04000C5D RID: 3165
			private short __Green217;

			// Token: 0x04000C5E RID: 3166
			private short __Green218;

			// Token: 0x04000C5F RID: 3167
			private short __Green219;

			// Token: 0x04000C60 RID: 3168
			private short __Green220;

			// Token: 0x04000C61 RID: 3169
			private short __Green221;

			// Token: 0x04000C62 RID: 3170
			private short __Green222;

			// Token: 0x04000C63 RID: 3171
			private short __Green223;

			// Token: 0x04000C64 RID: 3172
			private short __Green224;

			// Token: 0x04000C65 RID: 3173
			private short __Green225;

			// Token: 0x04000C66 RID: 3174
			private short __Green226;

			// Token: 0x04000C67 RID: 3175
			private short __Green227;

			// Token: 0x04000C68 RID: 3176
			private short __Green228;

			// Token: 0x04000C69 RID: 3177
			private short __Green229;

			// Token: 0x04000C6A RID: 3178
			private short __Green230;

			// Token: 0x04000C6B RID: 3179
			private short __Green231;

			// Token: 0x04000C6C RID: 3180
			private short __Green232;

			// Token: 0x04000C6D RID: 3181
			private short __Green233;

			// Token: 0x04000C6E RID: 3182
			private short __Green234;

			// Token: 0x04000C6F RID: 3183
			private short __Green235;

			// Token: 0x04000C70 RID: 3184
			private short __Green236;

			// Token: 0x04000C71 RID: 3185
			private short __Green237;

			// Token: 0x04000C72 RID: 3186
			private short __Green238;

			// Token: 0x04000C73 RID: 3187
			private short __Green239;

			// Token: 0x04000C74 RID: 3188
			private short __Green240;

			// Token: 0x04000C75 RID: 3189
			private short __Green241;

			// Token: 0x04000C76 RID: 3190
			private short __Green242;

			// Token: 0x04000C77 RID: 3191
			private short __Green243;

			// Token: 0x04000C78 RID: 3192
			private short __Green244;

			// Token: 0x04000C79 RID: 3193
			private short __Green245;

			// Token: 0x04000C7A RID: 3194
			private short __Green246;

			// Token: 0x04000C7B RID: 3195
			private short __Green247;

			// Token: 0x04000C7C RID: 3196
			private short __Green248;

			// Token: 0x04000C7D RID: 3197
			private short __Green249;

			// Token: 0x04000C7E RID: 3198
			private short __Green250;

			// Token: 0x04000C7F RID: 3199
			private short __Green251;

			// Token: 0x04000C80 RID: 3200
			private short __Green252;

			// Token: 0x04000C81 RID: 3201
			private short __Green253;

			// Token: 0x04000C82 RID: 3202
			private short __Green254;

			// Token: 0x04000C83 RID: 3203
			private short __Green255;

			// Token: 0x04000C84 RID: 3204
			public short Blue;

			// Token: 0x04000C85 RID: 3205
			private short __Blue1;

			// Token: 0x04000C86 RID: 3206
			private short __Blue2;

			// Token: 0x04000C87 RID: 3207
			private short __Blue3;

			// Token: 0x04000C88 RID: 3208
			private short __Blue4;

			// Token: 0x04000C89 RID: 3209
			private short __Blue5;

			// Token: 0x04000C8A RID: 3210
			private short __Blue6;

			// Token: 0x04000C8B RID: 3211
			private short __Blue7;

			// Token: 0x04000C8C RID: 3212
			private short __Blue8;

			// Token: 0x04000C8D RID: 3213
			private short __Blue9;

			// Token: 0x04000C8E RID: 3214
			private short __Blue10;

			// Token: 0x04000C8F RID: 3215
			private short __Blue11;

			// Token: 0x04000C90 RID: 3216
			private short __Blue12;

			// Token: 0x04000C91 RID: 3217
			private short __Blue13;

			// Token: 0x04000C92 RID: 3218
			private short __Blue14;

			// Token: 0x04000C93 RID: 3219
			private short __Blue15;

			// Token: 0x04000C94 RID: 3220
			private short __Blue16;

			// Token: 0x04000C95 RID: 3221
			private short __Blue17;

			// Token: 0x04000C96 RID: 3222
			private short __Blue18;

			// Token: 0x04000C97 RID: 3223
			private short __Blue19;

			// Token: 0x04000C98 RID: 3224
			private short __Blue20;

			// Token: 0x04000C99 RID: 3225
			private short __Blue21;

			// Token: 0x04000C9A RID: 3226
			private short __Blue22;

			// Token: 0x04000C9B RID: 3227
			private short __Blue23;

			// Token: 0x04000C9C RID: 3228
			private short __Blue24;

			// Token: 0x04000C9D RID: 3229
			private short __Blue25;

			// Token: 0x04000C9E RID: 3230
			private short __Blue26;

			// Token: 0x04000C9F RID: 3231
			private short __Blue27;

			// Token: 0x04000CA0 RID: 3232
			private short __Blue28;

			// Token: 0x04000CA1 RID: 3233
			private short __Blue29;

			// Token: 0x04000CA2 RID: 3234
			private short __Blue30;

			// Token: 0x04000CA3 RID: 3235
			private short __Blue31;

			// Token: 0x04000CA4 RID: 3236
			private short __Blue32;

			// Token: 0x04000CA5 RID: 3237
			private short __Blue33;

			// Token: 0x04000CA6 RID: 3238
			private short __Blue34;

			// Token: 0x04000CA7 RID: 3239
			private short __Blue35;

			// Token: 0x04000CA8 RID: 3240
			private short __Blue36;

			// Token: 0x04000CA9 RID: 3241
			private short __Blue37;

			// Token: 0x04000CAA RID: 3242
			private short __Blue38;

			// Token: 0x04000CAB RID: 3243
			private short __Blue39;

			// Token: 0x04000CAC RID: 3244
			private short __Blue40;

			// Token: 0x04000CAD RID: 3245
			private short __Blue41;

			// Token: 0x04000CAE RID: 3246
			private short __Blue42;

			// Token: 0x04000CAF RID: 3247
			private short __Blue43;

			// Token: 0x04000CB0 RID: 3248
			private short __Blue44;

			// Token: 0x04000CB1 RID: 3249
			private short __Blue45;

			// Token: 0x04000CB2 RID: 3250
			private short __Blue46;

			// Token: 0x04000CB3 RID: 3251
			private short __Blue47;

			// Token: 0x04000CB4 RID: 3252
			private short __Blue48;

			// Token: 0x04000CB5 RID: 3253
			private short __Blue49;

			// Token: 0x04000CB6 RID: 3254
			private short __Blue50;

			// Token: 0x04000CB7 RID: 3255
			private short __Blue51;

			// Token: 0x04000CB8 RID: 3256
			private short __Blue52;

			// Token: 0x04000CB9 RID: 3257
			private short __Blue53;

			// Token: 0x04000CBA RID: 3258
			private short __Blue54;

			// Token: 0x04000CBB RID: 3259
			private short __Blue55;

			// Token: 0x04000CBC RID: 3260
			private short __Blue56;

			// Token: 0x04000CBD RID: 3261
			private short __Blue57;

			// Token: 0x04000CBE RID: 3262
			private short __Blue58;

			// Token: 0x04000CBF RID: 3263
			private short __Blue59;

			// Token: 0x04000CC0 RID: 3264
			private short __Blue60;

			// Token: 0x04000CC1 RID: 3265
			private short __Blue61;

			// Token: 0x04000CC2 RID: 3266
			private short __Blue62;

			// Token: 0x04000CC3 RID: 3267
			private short __Blue63;

			// Token: 0x04000CC4 RID: 3268
			private short __Blue64;

			// Token: 0x04000CC5 RID: 3269
			private short __Blue65;

			// Token: 0x04000CC6 RID: 3270
			private short __Blue66;

			// Token: 0x04000CC7 RID: 3271
			private short __Blue67;

			// Token: 0x04000CC8 RID: 3272
			private short __Blue68;

			// Token: 0x04000CC9 RID: 3273
			private short __Blue69;

			// Token: 0x04000CCA RID: 3274
			private short __Blue70;

			// Token: 0x04000CCB RID: 3275
			private short __Blue71;

			// Token: 0x04000CCC RID: 3276
			private short __Blue72;

			// Token: 0x04000CCD RID: 3277
			private short __Blue73;

			// Token: 0x04000CCE RID: 3278
			private short __Blue74;

			// Token: 0x04000CCF RID: 3279
			private short __Blue75;

			// Token: 0x04000CD0 RID: 3280
			private short __Blue76;

			// Token: 0x04000CD1 RID: 3281
			private short __Blue77;

			// Token: 0x04000CD2 RID: 3282
			private short __Blue78;

			// Token: 0x04000CD3 RID: 3283
			private short __Blue79;

			// Token: 0x04000CD4 RID: 3284
			private short __Blue80;

			// Token: 0x04000CD5 RID: 3285
			private short __Blue81;

			// Token: 0x04000CD6 RID: 3286
			private short __Blue82;

			// Token: 0x04000CD7 RID: 3287
			private short __Blue83;

			// Token: 0x04000CD8 RID: 3288
			private short __Blue84;

			// Token: 0x04000CD9 RID: 3289
			private short __Blue85;

			// Token: 0x04000CDA RID: 3290
			private short __Blue86;

			// Token: 0x04000CDB RID: 3291
			private short __Blue87;

			// Token: 0x04000CDC RID: 3292
			private short __Blue88;

			// Token: 0x04000CDD RID: 3293
			private short __Blue89;

			// Token: 0x04000CDE RID: 3294
			private short __Blue90;

			// Token: 0x04000CDF RID: 3295
			private short __Blue91;

			// Token: 0x04000CE0 RID: 3296
			private short __Blue92;

			// Token: 0x04000CE1 RID: 3297
			private short __Blue93;

			// Token: 0x04000CE2 RID: 3298
			private short __Blue94;

			// Token: 0x04000CE3 RID: 3299
			private short __Blue95;

			// Token: 0x04000CE4 RID: 3300
			private short __Blue96;

			// Token: 0x04000CE5 RID: 3301
			private short __Blue97;

			// Token: 0x04000CE6 RID: 3302
			private short __Blue98;

			// Token: 0x04000CE7 RID: 3303
			private short __Blue99;

			// Token: 0x04000CE8 RID: 3304
			private short __Blue100;

			// Token: 0x04000CE9 RID: 3305
			private short __Blue101;

			// Token: 0x04000CEA RID: 3306
			private short __Blue102;

			// Token: 0x04000CEB RID: 3307
			private short __Blue103;

			// Token: 0x04000CEC RID: 3308
			private short __Blue104;

			// Token: 0x04000CED RID: 3309
			private short __Blue105;

			// Token: 0x04000CEE RID: 3310
			private short __Blue106;

			// Token: 0x04000CEF RID: 3311
			private short __Blue107;

			// Token: 0x04000CF0 RID: 3312
			private short __Blue108;

			// Token: 0x04000CF1 RID: 3313
			private short __Blue109;

			// Token: 0x04000CF2 RID: 3314
			private short __Blue110;

			// Token: 0x04000CF3 RID: 3315
			private short __Blue111;

			// Token: 0x04000CF4 RID: 3316
			private short __Blue112;

			// Token: 0x04000CF5 RID: 3317
			private short __Blue113;

			// Token: 0x04000CF6 RID: 3318
			private short __Blue114;

			// Token: 0x04000CF7 RID: 3319
			private short __Blue115;

			// Token: 0x04000CF8 RID: 3320
			private short __Blue116;

			// Token: 0x04000CF9 RID: 3321
			private short __Blue117;

			// Token: 0x04000CFA RID: 3322
			private short __Blue118;

			// Token: 0x04000CFB RID: 3323
			private short __Blue119;

			// Token: 0x04000CFC RID: 3324
			private short __Blue120;

			// Token: 0x04000CFD RID: 3325
			private short __Blue121;

			// Token: 0x04000CFE RID: 3326
			private short __Blue122;

			// Token: 0x04000CFF RID: 3327
			private short __Blue123;

			// Token: 0x04000D00 RID: 3328
			private short __Blue124;

			// Token: 0x04000D01 RID: 3329
			private short __Blue125;

			// Token: 0x04000D02 RID: 3330
			private short __Blue126;

			// Token: 0x04000D03 RID: 3331
			private short __Blue127;

			// Token: 0x04000D04 RID: 3332
			private short __Blue128;

			// Token: 0x04000D05 RID: 3333
			private short __Blue129;

			// Token: 0x04000D06 RID: 3334
			private short __Blue130;

			// Token: 0x04000D07 RID: 3335
			private short __Blue131;

			// Token: 0x04000D08 RID: 3336
			private short __Blue132;

			// Token: 0x04000D09 RID: 3337
			private short __Blue133;

			// Token: 0x04000D0A RID: 3338
			private short __Blue134;

			// Token: 0x04000D0B RID: 3339
			private short __Blue135;

			// Token: 0x04000D0C RID: 3340
			private short __Blue136;

			// Token: 0x04000D0D RID: 3341
			private short __Blue137;

			// Token: 0x04000D0E RID: 3342
			private short __Blue138;

			// Token: 0x04000D0F RID: 3343
			private short __Blue139;

			// Token: 0x04000D10 RID: 3344
			private short __Blue140;

			// Token: 0x04000D11 RID: 3345
			private short __Blue141;

			// Token: 0x04000D12 RID: 3346
			private short __Blue142;

			// Token: 0x04000D13 RID: 3347
			private short __Blue143;

			// Token: 0x04000D14 RID: 3348
			private short __Blue144;

			// Token: 0x04000D15 RID: 3349
			private short __Blue145;

			// Token: 0x04000D16 RID: 3350
			private short __Blue146;

			// Token: 0x04000D17 RID: 3351
			private short __Blue147;

			// Token: 0x04000D18 RID: 3352
			private short __Blue148;

			// Token: 0x04000D19 RID: 3353
			private short __Blue149;

			// Token: 0x04000D1A RID: 3354
			private short __Blue150;

			// Token: 0x04000D1B RID: 3355
			private short __Blue151;

			// Token: 0x04000D1C RID: 3356
			private short __Blue152;

			// Token: 0x04000D1D RID: 3357
			private short __Blue153;

			// Token: 0x04000D1E RID: 3358
			private short __Blue154;

			// Token: 0x04000D1F RID: 3359
			private short __Blue155;

			// Token: 0x04000D20 RID: 3360
			private short __Blue156;

			// Token: 0x04000D21 RID: 3361
			private short __Blue157;

			// Token: 0x04000D22 RID: 3362
			private short __Blue158;

			// Token: 0x04000D23 RID: 3363
			private short __Blue159;

			// Token: 0x04000D24 RID: 3364
			private short __Blue160;

			// Token: 0x04000D25 RID: 3365
			private short __Blue161;

			// Token: 0x04000D26 RID: 3366
			private short __Blue162;

			// Token: 0x04000D27 RID: 3367
			private short __Blue163;

			// Token: 0x04000D28 RID: 3368
			private short __Blue164;

			// Token: 0x04000D29 RID: 3369
			private short __Blue165;

			// Token: 0x04000D2A RID: 3370
			private short __Blue166;

			// Token: 0x04000D2B RID: 3371
			private short __Blue167;

			// Token: 0x04000D2C RID: 3372
			private short __Blue168;

			// Token: 0x04000D2D RID: 3373
			private short __Blue169;

			// Token: 0x04000D2E RID: 3374
			private short __Blue170;

			// Token: 0x04000D2F RID: 3375
			private short __Blue171;

			// Token: 0x04000D30 RID: 3376
			private short __Blue172;

			// Token: 0x04000D31 RID: 3377
			private short __Blue173;

			// Token: 0x04000D32 RID: 3378
			private short __Blue174;

			// Token: 0x04000D33 RID: 3379
			private short __Blue175;

			// Token: 0x04000D34 RID: 3380
			private short __Blue176;

			// Token: 0x04000D35 RID: 3381
			private short __Blue177;

			// Token: 0x04000D36 RID: 3382
			private short __Blue178;

			// Token: 0x04000D37 RID: 3383
			private short __Blue179;

			// Token: 0x04000D38 RID: 3384
			private short __Blue180;

			// Token: 0x04000D39 RID: 3385
			private short __Blue181;

			// Token: 0x04000D3A RID: 3386
			private short __Blue182;

			// Token: 0x04000D3B RID: 3387
			private short __Blue183;

			// Token: 0x04000D3C RID: 3388
			private short __Blue184;

			// Token: 0x04000D3D RID: 3389
			private short __Blue185;

			// Token: 0x04000D3E RID: 3390
			private short __Blue186;

			// Token: 0x04000D3F RID: 3391
			private short __Blue187;

			// Token: 0x04000D40 RID: 3392
			private short __Blue188;

			// Token: 0x04000D41 RID: 3393
			private short __Blue189;

			// Token: 0x04000D42 RID: 3394
			private short __Blue190;

			// Token: 0x04000D43 RID: 3395
			private short __Blue191;

			// Token: 0x04000D44 RID: 3396
			private short __Blue192;

			// Token: 0x04000D45 RID: 3397
			private short __Blue193;

			// Token: 0x04000D46 RID: 3398
			private short __Blue194;

			// Token: 0x04000D47 RID: 3399
			private short __Blue195;

			// Token: 0x04000D48 RID: 3400
			private short __Blue196;

			// Token: 0x04000D49 RID: 3401
			private short __Blue197;

			// Token: 0x04000D4A RID: 3402
			private short __Blue198;

			// Token: 0x04000D4B RID: 3403
			private short __Blue199;

			// Token: 0x04000D4C RID: 3404
			private short __Blue200;

			// Token: 0x04000D4D RID: 3405
			private short __Blue201;

			// Token: 0x04000D4E RID: 3406
			private short __Blue202;

			// Token: 0x04000D4F RID: 3407
			private short __Blue203;

			// Token: 0x04000D50 RID: 3408
			private short __Blue204;

			// Token: 0x04000D51 RID: 3409
			private short __Blue205;

			// Token: 0x04000D52 RID: 3410
			private short __Blue206;

			// Token: 0x04000D53 RID: 3411
			private short __Blue207;

			// Token: 0x04000D54 RID: 3412
			private short __Blue208;

			// Token: 0x04000D55 RID: 3413
			private short __Blue209;

			// Token: 0x04000D56 RID: 3414
			private short __Blue210;

			// Token: 0x04000D57 RID: 3415
			private short __Blue211;

			// Token: 0x04000D58 RID: 3416
			private short __Blue212;

			// Token: 0x04000D59 RID: 3417
			private short __Blue213;

			// Token: 0x04000D5A RID: 3418
			private short __Blue214;

			// Token: 0x04000D5B RID: 3419
			private short __Blue215;

			// Token: 0x04000D5C RID: 3420
			private short __Blue216;

			// Token: 0x04000D5D RID: 3421
			private short __Blue217;

			// Token: 0x04000D5E RID: 3422
			private short __Blue218;

			// Token: 0x04000D5F RID: 3423
			private short __Blue219;

			// Token: 0x04000D60 RID: 3424
			private short __Blue220;

			// Token: 0x04000D61 RID: 3425
			private short __Blue221;

			// Token: 0x04000D62 RID: 3426
			private short __Blue222;

			// Token: 0x04000D63 RID: 3427
			private short __Blue223;

			// Token: 0x04000D64 RID: 3428
			private short __Blue224;

			// Token: 0x04000D65 RID: 3429
			private short __Blue225;

			// Token: 0x04000D66 RID: 3430
			private short __Blue226;

			// Token: 0x04000D67 RID: 3431
			private short __Blue227;

			// Token: 0x04000D68 RID: 3432
			private short __Blue228;

			// Token: 0x04000D69 RID: 3433
			private short __Blue229;

			// Token: 0x04000D6A RID: 3434
			private short __Blue230;

			// Token: 0x04000D6B RID: 3435
			private short __Blue231;

			// Token: 0x04000D6C RID: 3436
			private short __Blue232;

			// Token: 0x04000D6D RID: 3437
			private short __Blue233;

			// Token: 0x04000D6E RID: 3438
			private short __Blue234;

			// Token: 0x04000D6F RID: 3439
			private short __Blue235;

			// Token: 0x04000D70 RID: 3440
			private short __Blue236;

			// Token: 0x04000D71 RID: 3441
			private short __Blue237;

			// Token: 0x04000D72 RID: 3442
			private short __Blue238;

			// Token: 0x04000D73 RID: 3443
			private short __Blue239;

			// Token: 0x04000D74 RID: 3444
			private short __Blue240;

			// Token: 0x04000D75 RID: 3445
			private short __Blue241;

			// Token: 0x04000D76 RID: 3446
			private short __Blue242;

			// Token: 0x04000D77 RID: 3447
			private short __Blue243;

			// Token: 0x04000D78 RID: 3448
			private short __Blue244;

			// Token: 0x04000D79 RID: 3449
			private short __Blue245;

			// Token: 0x04000D7A RID: 3450
			private short __Blue246;

			// Token: 0x04000D7B RID: 3451
			private short __Blue247;

			// Token: 0x04000D7C RID: 3452
			private short __Blue248;

			// Token: 0x04000D7D RID: 3453
			private short __Blue249;

			// Token: 0x04000D7E RID: 3454
			private short __Blue250;

			// Token: 0x04000D7F RID: 3455
			private short __Blue251;

			// Token: 0x04000D80 RID: 3456
			private short __Blue252;

			// Token: 0x04000D81 RID: 3457
			private short __Blue253;

			// Token: 0x04000D82 RID: 3458
			private short __Blue254;

			// Token: 0x04000D83 RID: 3459
			private short __Blue255;
		}
	}
}
