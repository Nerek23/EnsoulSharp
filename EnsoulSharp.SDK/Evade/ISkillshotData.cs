using System;

namespace EnsoulSharp.SDK.Evade
{
	// Token: 0x020000E4 RID: 228
	public interface ISkillshotData : ICloneable
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060008B4 RID: 2228
		int DangerLevel { get; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060008B5 RID: 2229
		float Delay { get; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060008B6 RID: 2230
		float Radius { get; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060008B7 RID: 2231
		float Range { get; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060008B8 RID: 2232
		string ChampionName { get; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060008B9 RID: 2233
		string SpellName { get; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060008BA RID: 2234
		string[] ExtraSpellName { get; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060008BB RID: 2235
		string MissileName { get; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060008BC RID: 2236
		string[] ExtraMissileName { get; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060008BD RID: 2237
		EvadeSkillshotType Type { get; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060008BE RID: 2238
		SpellSlot Slot { get; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060008BF RID: 2239
		SkillshotCollisionObjectType[] CollisionObjects { get; }
	}
}
