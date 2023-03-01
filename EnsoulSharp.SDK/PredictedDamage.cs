using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000027 RID: 39
	public class PredictedDamage
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000B536 File Offset: 0x00009736
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000B53E File Offset: 0x0000973E
		public int SourceNetworkId { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000B547 File Offset: 0x00009747
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x0000B54F File Offset: 0x0000974F
		public int TargetNetworkId { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000B558 File Offset: 0x00009758
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x0000B560 File Offset: 0x00009760
		public int StartTick { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000B569 File Offset: 0x00009769
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x0000B571 File Offset: 0x00009771
		public int ProjectileSpeed { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000B57A File Offset: 0x0000977A
		// (set) Token: 0x060001AB RID: 427 RVA: 0x0000B582 File Offset: 0x00009782
		public float AnimationTime { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000B58B File Offset: 0x0000978B
		// (set) Token: 0x060001AD RID: 429 RVA: 0x0000B593 File Offset: 0x00009793
		public float TargetBoundingRadius { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000B59C File Offset: 0x0000979C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x0000B5A4 File Offset: 0x000097A4
		public float Damage { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000B5AD File Offset: 0x000097AD
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x0000B5B5 File Offset: 0x000097B5
		public float Delay { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000B5BE File Offset: 0x000097BE
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x0000B5C6 File Offset: 0x000097C6
		public AIBaseClient Source { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000B5CF File Offset: 0x000097CF
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000B5D7 File Offset: 0x000097D7
		public AIBaseClient Target { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000B5E0 File Offset: 0x000097E0
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000B5E8 File Offset: 0x000097E8
		public bool IsSkillshot { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000B5F1 File Offset: 0x000097F1
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000B5F9 File Offset: 0x000097F9
		public bool Processed { get; set; }
	}
}
