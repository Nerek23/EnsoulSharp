using System;
using System.Collections.Generic;
using SharpDX;

namespace EnsoulSharp.SDK.Evade
{
	// Token: 0x020000E2 RID: 226
	public interface IEvadeManager
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060008A4 RID: 2212
		// (set) Token: 0x060008A5 RID: 2213
		bool Evading { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060008A6 RID: 2214
		// (set) Token: 0x060008A7 RID: 2215
		Vector2 EvadePosition { get; set; }

		// Token: 0x060008A8 RID: 2216
		bool IsDangerPosition(AIHeroClient source, Vector2 pos, float radius);

		// Token: 0x060008A9 RID: 2217
		bool IsDangerPath(AIHeroClient source, Vector2 endPosition);

		// Token: 0x060008AA RID: 2218
		bool IsDangerPath(AIHeroClient source, List<Vector2> path);
	}
}
