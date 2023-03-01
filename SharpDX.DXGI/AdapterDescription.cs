using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000072 RID: 114
	public struct AdapterDescription
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref AdapterDescription.__Native @ref)
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00007860 File Offset: 0x00005A60
		internal unsafe void __MarshalFrom(ref AdapterDescription.__Native @ref)
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
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000078FC File Offset: 0x00005AFC
		internal unsafe void __MarshalTo(ref AdapterDescription.__Native @ref)
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
			}
		}

		// Token: 0x040001AE RID: 430
		public string Description;

		// Token: 0x040001AF RID: 431
		public int VendorId;

		// Token: 0x040001B0 RID: 432
		public int DeviceId;

		// Token: 0x040001B1 RID: 433
		public int SubsystemId;

		// Token: 0x040001B2 RID: 434
		public int Revision;

		// Token: 0x040001B3 RID: 435
		public PointerSize DedicatedVideoMemory;

		// Token: 0x040001B4 RID: 436
		public PointerSize DedicatedSystemMemory;

		// Token: 0x040001B5 RID: 437
		public PointerSize SharedSystemMemory;

		// Token: 0x040001B6 RID: 438
		public long Luid;

		// Token: 0x02000073 RID: 115
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		internal struct __Native
		{
			// Token: 0x040001B7 RID: 439
			public char Description;

			// Token: 0x040001B8 RID: 440
			public char __Description1;

			// Token: 0x040001B9 RID: 441
			public char __Description2;

			// Token: 0x040001BA RID: 442
			public char __Description3;

			// Token: 0x040001BB RID: 443
			public char __Description4;

			// Token: 0x040001BC RID: 444
			public char __Description5;

			// Token: 0x040001BD RID: 445
			public char __Description6;

			// Token: 0x040001BE RID: 446
			public char __Description7;

			// Token: 0x040001BF RID: 447
			public char __Description8;

			// Token: 0x040001C0 RID: 448
			public char __Description9;

			// Token: 0x040001C1 RID: 449
			public char __Description10;

			// Token: 0x040001C2 RID: 450
			public char __Description11;

			// Token: 0x040001C3 RID: 451
			public char __Description12;

			// Token: 0x040001C4 RID: 452
			public char __Description13;

			// Token: 0x040001C5 RID: 453
			public char __Description14;

			// Token: 0x040001C6 RID: 454
			public char __Description15;

			// Token: 0x040001C7 RID: 455
			public char __Description16;

			// Token: 0x040001C8 RID: 456
			public char __Description17;

			// Token: 0x040001C9 RID: 457
			public char __Description18;

			// Token: 0x040001CA RID: 458
			public char __Description19;

			// Token: 0x040001CB RID: 459
			public char __Description20;

			// Token: 0x040001CC RID: 460
			public char __Description21;

			// Token: 0x040001CD RID: 461
			public char __Description22;

			// Token: 0x040001CE RID: 462
			public char __Description23;

			// Token: 0x040001CF RID: 463
			public char __Description24;

			// Token: 0x040001D0 RID: 464
			public char __Description25;

			// Token: 0x040001D1 RID: 465
			public char __Description26;

			// Token: 0x040001D2 RID: 466
			public char __Description27;

			// Token: 0x040001D3 RID: 467
			public char __Description28;

			// Token: 0x040001D4 RID: 468
			public char __Description29;

			// Token: 0x040001D5 RID: 469
			public char __Description30;

			// Token: 0x040001D6 RID: 470
			public char __Description31;

			// Token: 0x040001D7 RID: 471
			public char __Description32;

			// Token: 0x040001D8 RID: 472
			public char __Description33;

			// Token: 0x040001D9 RID: 473
			public char __Description34;

			// Token: 0x040001DA RID: 474
			public char __Description35;

			// Token: 0x040001DB RID: 475
			public char __Description36;

			// Token: 0x040001DC RID: 476
			public char __Description37;

			// Token: 0x040001DD RID: 477
			public char __Description38;

			// Token: 0x040001DE RID: 478
			public char __Description39;

			// Token: 0x040001DF RID: 479
			public char __Description40;

			// Token: 0x040001E0 RID: 480
			public char __Description41;

			// Token: 0x040001E1 RID: 481
			public char __Description42;

			// Token: 0x040001E2 RID: 482
			public char __Description43;

			// Token: 0x040001E3 RID: 483
			public char __Description44;

			// Token: 0x040001E4 RID: 484
			public char __Description45;

			// Token: 0x040001E5 RID: 485
			public char __Description46;

			// Token: 0x040001E6 RID: 486
			public char __Description47;

			// Token: 0x040001E7 RID: 487
			public char __Description48;

			// Token: 0x040001E8 RID: 488
			public char __Description49;

			// Token: 0x040001E9 RID: 489
			public char __Description50;

			// Token: 0x040001EA RID: 490
			public char __Description51;

			// Token: 0x040001EB RID: 491
			public char __Description52;

			// Token: 0x040001EC RID: 492
			public char __Description53;

			// Token: 0x040001ED RID: 493
			public char __Description54;

			// Token: 0x040001EE RID: 494
			public char __Description55;

			// Token: 0x040001EF RID: 495
			public char __Description56;

			// Token: 0x040001F0 RID: 496
			public char __Description57;

			// Token: 0x040001F1 RID: 497
			public char __Description58;

			// Token: 0x040001F2 RID: 498
			public char __Description59;

			// Token: 0x040001F3 RID: 499
			public char __Description60;

			// Token: 0x040001F4 RID: 500
			public char __Description61;

			// Token: 0x040001F5 RID: 501
			public char __Description62;

			// Token: 0x040001F6 RID: 502
			public char __Description63;

			// Token: 0x040001F7 RID: 503
			public char __Description64;

			// Token: 0x040001F8 RID: 504
			public char __Description65;

			// Token: 0x040001F9 RID: 505
			public char __Description66;

			// Token: 0x040001FA RID: 506
			public char __Description67;

			// Token: 0x040001FB RID: 507
			public char __Description68;

			// Token: 0x040001FC RID: 508
			public char __Description69;

			// Token: 0x040001FD RID: 509
			public char __Description70;

			// Token: 0x040001FE RID: 510
			public char __Description71;

			// Token: 0x040001FF RID: 511
			public char __Description72;

			// Token: 0x04000200 RID: 512
			public char __Description73;

			// Token: 0x04000201 RID: 513
			public char __Description74;

			// Token: 0x04000202 RID: 514
			public char __Description75;

			// Token: 0x04000203 RID: 515
			public char __Description76;

			// Token: 0x04000204 RID: 516
			public char __Description77;

			// Token: 0x04000205 RID: 517
			public char __Description78;

			// Token: 0x04000206 RID: 518
			public char __Description79;

			// Token: 0x04000207 RID: 519
			public char __Description80;

			// Token: 0x04000208 RID: 520
			public char __Description81;

			// Token: 0x04000209 RID: 521
			public char __Description82;

			// Token: 0x0400020A RID: 522
			public char __Description83;

			// Token: 0x0400020B RID: 523
			public char __Description84;

			// Token: 0x0400020C RID: 524
			public char __Description85;

			// Token: 0x0400020D RID: 525
			public char __Description86;

			// Token: 0x0400020E RID: 526
			public char __Description87;

			// Token: 0x0400020F RID: 527
			public char __Description88;

			// Token: 0x04000210 RID: 528
			public char __Description89;

			// Token: 0x04000211 RID: 529
			public char __Description90;

			// Token: 0x04000212 RID: 530
			public char __Description91;

			// Token: 0x04000213 RID: 531
			public char __Description92;

			// Token: 0x04000214 RID: 532
			public char __Description93;

			// Token: 0x04000215 RID: 533
			public char __Description94;

			// Token: 0x04000216 RID: 534
			public char __Description95;

			// Token: 0x04000217 RID: 535
			public char __Description96;

			// Token: 0x04000218 RID: 536
			public char __Description97;

			// Token: 0x04000219 RID: 537
			public char __Description98;

			// Token: 0x0400021A RID: 538
			public char __Description99;

			// Token: 0x0400021B RID: 539
			public char __Description100;

			// Token: 0x0400021C RID: 540
			public char __Description101;

			// Token: 0x0400021D RID: 541
			public char __Description102;

			// Token: 0x0400021E RID: 542
			public char __Description103;

			// Token: 0x0400021F RID: 543
			public char __Description104;

			// Token: 0x04000220 RID: 544
			public char __Description105;

			// Token: 0x04000221 RID: 545
			public char __Description106;

			// Token: 0x04000222 RID: 546
			public char __Description107;

			// Token: 0x04000223 RID: 547
			public char __Description108;

			// Token: 0x04000224 RID: 548
			public char __Description109;

			// Token: 0x04000225 RID: 549
			public char __Description110;

			// Token: 0x04000226 RID: 550
			public char __Description111;

			// Token: 0x04000227 RID: 551
			public char __Description112;

			// Token: 0x04000228 RID: 552
			public char __Description113;

			// Token: 0x04000229 RID: 553
			public char __Description114;

			// Token: 0x0400022A RID: 554
			public char __Description115;

			// Token: 0x0400022B RID: 555
			public char __Description116;

			// Token: 0x0400022C RID: 556
			public char __Description117;

			// Token: 0x0400022D RID: 557
			public char __Description118;

			// Token: 0x0400022E RID: 558
			public char __Description119;

			// Token: 0x0400022F RID: 559
			public char __Description120;

			// Token: 0x04000230 RID: 560
			public char __Description121;

			// Token: 0x04000231 RID: 561
			public char __Description122;

			// Token: 0x04000232 RID: 562
			public char __Description123;

			// Token: 0x04000233 RID: 563
			public char __Description124;

			// Token: 0x04000234 RID: 564
			public char __Description125;

			// Token: 0x04000235 RID: 565
			public char __Description126;

			// Token: 0x04000236 RID: 566
			public char __Description127;

			// Token: 0x04000237 RID: 567
			public int VendorId;

			// Token: 0x04000238 RID: 568
			public int DeviceId;

			// Token: 0x04000239 RID: 569
			public int SubsystemId;

			// Token: 0x0400023A RID: 570
			public int Revision;

			// Token: 0x0400023B RID: 571
			public IntPtr DedicatedVideoMemory;

			// Token: 0x0400023C RID: 572
			public IntPtr DedicatedSystemMemory;

			// Token: 0x0400023D RID: 573
			public IntPtr SharedSystemMemory;

			// Token: 0x0400023E RID: 574
			public long Luid;
		}
	}
}
