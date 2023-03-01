using System;
using System.Collections.Generic;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000020 RID: 32
	public interface ITargetSelector : IDisposable
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000174 RID: 372
		// (set) Token: 0x06000175 RID: 373
		AIHeroClient SelectedTarget { get; set; }

		// Token: 0x06000176 RID: 374
		int GetDefaultPriority(AIHeroClient target);

		// Token: 0x06000177 RID: 375
		int GetPriority(AIHeroClient target);

		// Token: 0x06000178 RID: 376
		AIHeroClient GetTarget(IEnumerable<AIHeroClient> possibleTargets, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null);

		// Token: 0x06000179 RID: 377
		AIHeroClient GetTarget(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null);

		// Token: 0x0600017A RID: 378
		List<AIHeroClient> GetTargets(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null);
	}
}
