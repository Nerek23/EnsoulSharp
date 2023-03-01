using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000074 RID: 116
	public struct AdapterDescription1
	{
		// Token: 0x060001EE RID: 494 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref AdapterDescription1.__Native @ref)
		{
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000079D4 File Offset: 0x00005BD4
		internal unsafe void __MarshalFrom(ref AdapterDescription1.__Native @ref)
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
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00007A7C File Offset: 0x00005C7C
		internal unsafe void __MarshalTo(ref AdapterDescription1.__Native @ref)
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
			}
		}

		// Token: 0x0400023F RID: 575
		public string Description;

		// Token: 0x04000240 RID: 576
		public int VendorId;

		// Token: 0x04000241 RID: 577
		public int DeviceId;

		// Token: 0x04000242 RID: 578
		public int SubsystemId;

		// Token: 0x04000243 RID: 579
		public int Revision;

		// Token: 0x04000244 RID: 580
		public PointerSize DedicatedVideoMemory;

		// Token: 0x04000245 RID: 581
		public PointerSize DedicatedSystemMemory;

		// Token: 0x04000246 RID: 582
		public PointerSize SharedSystemMemory;

		// Token: 0x04000247 RID: 583
		public long Luid;

		// Token: 0x04000248 RID: 584
		public AdapterFlags Flags;

		// Token: 0x02000075 RID: 117
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		internal struct __Native
		{
			// Token: 0x04000249 RID: 585
			public char Description;

			// Token: 0x0400024A RID: 586
			public char __Description1;

			// Token: 0x0400024B RID: 587
			public char __Description2;

			// Token: 0x0400024C RID: 588
			public char __Description3;

			// Token: 0x0400024D RID: 589
			public char __Description4;

			// Token: 0x0400024E RID: 590
			public char __Description5;

			// Token: 0x0400024F RID: 591
			public char __Description6;

			// Token: 0x04000250 RID: 592
			public char __Description7;

			// Token: 0x04000251 RID: 593
			public char __Description8;

			// Token: 0x04000252 RID: 594
			public char __Description9;

			// Token: 0x04000253 RID: 595
			public char __Description10;

			// Token: 0x04000254 RID: 596
			public char __Description11;

			// Token: 0x04000255 RID: 597
			public char __Description12;

			// Token: 0x04000256 RID: 598
			public char __Description13;

			// Token: 0x04000257 RID: 599
			public char __Description14;

			// Token: 0x04000258 RID: 600
			public char __Description15;

			// Token: 0x04000259 RID: 601
			public char __Description16;

			// Token: 0x0400025A RID: 602
			public char __Description17;

			// Token: 0x0400025B RID: 603
			public char __Description18;

			// Token: 0x0400025C RID: 604
			public char __Description19;

			// Token: 0x0400025D RID: 605
			public char __Description20;

			// Token: 0x0400025E RID: 606
			public char __Description21;

			// Token: 0x0400025F RID: 607
			public char __Description22;

			// Token: 0x04000260 RID: 608
			public char __Description23;

			// Token: 0x04000261 RID: 609
			public char __Description24;

			// Token: 0x04000262 RID: 610
			public char __Description25;

			// Token: 0x04000263 RID: 611
			public char __Description26;

			// Token: 0x04000264 RID: 612
			public char __Description27;

			// Token: 0x04000265 RID: 613
			public char __Description28;

			// Token: 0x04000266 RID: 614
			public char __Description29;

			// Token: 0x04000267 RID: 615
			public char __Description30;

			// Token: 0x04000268 RID: 616
			public char __Description31;

			// Token: 0x04000269 RID: 617
			public char __Description32;

			// Token: 0x0400026A RID: 618
			public char __Description33;

			// Token: 0x0400026B RID: 619
			public char __Description34;

			// Token: 0x0400026C RID: 620
			public char __Description35;

			// Token: 0x0400026D RID: 621
			public char __Description36;

			// Token: 0x0400026E RID: 622
			public char __Description37;

			// Token: 0x0400026F RID: 623
			public char __Description38;

			// Token: 0x04000270 RID: 624
			public char __Description39;

			// Token: 0x04000271 RID: 625
			public char __Description40;

			// Token: 0x04000272 RID: 626
			public char __Description41;

			// Token: 0x04000273 RID: 627
			public char __Description42;

			// Token: 0x04000274 RID: 628
			public char __Description43;

			// Token: 0x04000275 RID: 629
			public char __Description44;

			// Token: 0x04000276 RID: 630
			public char __Description45;

			// Token: 0x04000277 RID: 631
			public char __Description46;

			// Token: 0x04000278 RID: 632
			public char __Description47;

			// Token: 0x04000279 RID: 633
			public char __Description48;

			// Token: 0x0400027A RID: 634
			public char __Description49;

			// Token: 0x0400027B RID: 635
			public char __Description50;

			// Token: 0x0400027C RID: 636
			public char __Description51;

			// Token: 0x0400027D RID: 637
			public char __Description52;

			// Token: 0x0400027E RID: 638
			public char __Description53;

			// Token: 0x0400027F RID: 639
			public char __Description54;

			// Token: 0x04000280 RID: 640
			public char __Description55;

			// Token: 0x04000281 RID: 641
			public char __Description56;

			// Token: 0x04000282 RID: 642
			public char __Description57;

			// Token: 0x04000283 RID: 643
			public char __Description58;

			// Token: 0x04000284 RID: 644
			public char __Description59;

			// Token: 0x04000285 RID: 645
			public char __Description60;

			// Token: 0x04000286 RID: 646
			public char __Description61;

			// Token: 0x04000287 RID: 647
			public char __Description62;

			// Token: 0x04000288 RID: 648
			public char __Description63;

			// Token: 0x04000289 RID: 649
			public char __Description64;

			// Token: 0x0400028A RID: 650
			public char __Description65;

			// Token: 0x0400028B RID: 651
			public char __Description66;

			// Token: 0x0400028C RID: 652
			public char __Description67;

			// Token: 0x0400028D RID: 653
			public char __Description68;

			// Token: 0x0400028E RID: 654
			public char __Description69;

			// Token: 0x0400028F RID: 655
			public char __Description70;

			// Token: 0x04000290 RID: 656
			public char __Description71;

			// Token: 0x04000291 RID: 657
			public char __Description72;

			// Token: 0x04000292 RID: 658
			public char __Description73;

			// Token: 0x04000293 RID: 659
			public char __Description74;

			// Token: 0x04000294 RID: 660
			public char __Description75;

			// Token: 0x04000295 RID: 661
			public char __Description76;

			// Token: 0x04000296 RID: 662
			public char __Description77;

			// Token: 0x04000297 RID: 663
			public char __Description78;

			// Token: 0x04000298 RID: 664
			public char __Description79;

			// Token: 0x04000299 RID: 665
			public char __Description80;

			// Token: 0x0400029A RID: 666
			public char __Description81;

			// Token: 0x0400029B RID: 667
			public char __Description82;

			// Token: 0x0400029C RID: 668
			public char __Description83;

			// Token: 0x0400029D RID: 669
			public char __Description84;

			// Token: 0x0400029E RID: 670
			public char __Description85;

			// Token: 0x0400029F RID: 671
			public char __Description86;

			// Token: 0x040002A0 RID: 672
			public char __Description87;

			// Token: 0x040002A1 RID: 673
			public char __Description88;

			// Token: 0x040002A2 RID: 674
			public char __Description89;

			// Token: 0x040002A3 RID: 675
			public char __Description90;

			// Token: 0x040002A4 RID: 676
			public char __Description91;

			// Token: 0x040002A5 RID: 677
			public char __Description92;

			// Token: 0x040002A6 RID: 678
			public char __Description93;

			// Token: 0x040002A7 RID: 679
			public char __Description94;

			// Token: 0x040002A8 RID: 680
			public char __Description95;

			// Token: 0x040002A9 RID: 681
			public char __Description96;

			// Token: 0x040002AA RID: 682
			public char __Description97;

			// Token: 0x040002AB RID: 683
			public char __Description98;

			// Token: 0x040002AC RID: 684
			public char __Description99;

			// Token: 0x040002AD RID: 685
			public char __Description100;

			// Token: 0x040002AE RID: 686
			public char __Description101;

			// Token: 0x040002AF RID: 687
			public char __Description102;

			// Token: 0x040002B0 RID: 688
			public char __Description103;

			// Token: 0x040002B1 RID: 689
			public char __Description104;

			// Token: 0x040002B2 RID: 690
			public char __Description105;

			// Token: 0x040002B3 RID: 691
			public char __Description106;

			// Token: 0x040002B4 RID: 692
			public char __Description107;

			// Token: 0x040002B5 RID: 693
			public char __Description108;

			// Token: 0x040002B6 RID: 694
			public char __Description109;

			// Token: 0x040002B7 RID: 695
			public char __Description110;

			// Token: 0x040002B8 RID: 696
			public char __Description111;

			// Token: 0x040002B9 RID: 697
			public char __Description112;

			// Token: 0x040002BA RID: 698
			public char __Description113;

			// Token: 0x040002BB RID: 699
			public char __Description114;

			// Token: 0x040002BC RID: 700
			public char __Description115;

			// Token: 0x040002BD RID: 701
			public char __Description116;

			// Token: 0x040002BE RID: 702
			public char __Description117;

			// Token: 0x040002BF RID: 703
			public char __Description118;

			// Token: 0x040002C0 RID: 704
			public char __Description119;

			// Token: 0x040002C1 RID: 705
			public char __Description120;

			// Token: 0x040002C2 RID: 706
			public char __Description121;

			// Token: 0x040002C3 RID: 707
			public char __Description122;

			// Token: 0x040002C4 RID: 708
			public char __Description123;

			// Token: 0x040002C5 RID: 709
			public char __Description124;

			// Token: 0x040002C6 RID: 710
			public char __Description125;

			// Token: 0x040002C7 RID: 711
			public char __Description126;

			// Token: 0x040002C8 RID: 712
			public char __Description127;

			// Token: 0x040002C9 RID: 713
			public int VendorId;

			// Token: 0x040002CA RID: 714
			public int DeviceId;

			// Token: 0x040002CB RID: 715
			public int SubsystemId;

			// Token: 0x040002CC RID: 716
			public int Revision;

			// Token: 0x040002CD RID: 717
			public IntPtr DedicatedVideoMemory;

			// Token: 0x040002CE RID: 718
			public IntPtr DedicatedSystemMemory;

			// Token: 0x040002CF RID: 719
			public IntPtr SharedSystemMemory;

			// Token: 0x040002D0 RID: 720
			public long Luid;

			// Token: 0x040002D1 RID: 721
			public AdapterFlags Flags;
		}
	}
}
