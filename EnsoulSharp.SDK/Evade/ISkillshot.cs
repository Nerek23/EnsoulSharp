using System;
using SharpDX;

namespace EnsoulSharp.SDK.Evade
{
	// Token: 0x020000E3 RID: 227
	public interface ISkillshot
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060008AB RID: 2219
		float StartTime { get; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060008AC RID: 2220
		float EndTime { get; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060008AD RID: 2221
		Vector2 StartPosition { get; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060008AE RID: 2222
		Vector2 EndPosition { get; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060008AF RID: 2223
		Vector2 CurrentPosition { get; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060008B0 RID: 2224
		ISkillshotData ISkillshotData { get; }

		// Token: 0x060008B1 RID: 2225
		bool IsInSide(Vector2 position, float radius, bool checkCollision = true);

		// Token: 0x060008B2 RID: 2226
		float GetSpellHitTime(Vector2 position);

		// Token: 0x060008B3 RID: 2227
		bool WillHit(AIHeroClient source, Vector2 position, float delay);
	}
}
