using System;

namespace EnsoulSharp
{
	// Token: 0x02000026 RID: 38
	[Flags]
	public enum GameObjectCharacterState
	{
		// Token: 0x04000179 RID: 377
		CanAttack = 1,
		// Token: 0x0400017A RID: 378
		CanCast = 4,
		// Token: 0x0400017B RID: 379
		CanMove = 8,
		// Token: 0x0400017C RID: 380
		Immovable = 16,
		// Token: 0x0400017D RID: 381
		IsStealthed = 32,
		// Token: 0x0400017E RID: 382
		IsRevealSpecificUnit = 64,
		// Token: 0x0400017F RID: 383
		IsTaunted = 128,
		// Token: 0x04000180 RID: 384
		IsFeared = 256,
		// Token: 0x04000181 RID: 385
		IsFleeing = 512,
		// Token: 0x04000182 RID: 386
		IsSuppressed = 1024,
		// Token: 0x04000183 RID: 387
		IsAsleep = 2048,
		// Token: 0x04000184 RID: 388
		IsNearSight = 4096,
		// Token: 0x04000185 RID: 389
		IsGhosted = 8192,
		// Token: 0x04000186 RID: 390
		IsGhostedForAllies = 16384,
		// Token: 0x04000187 RID: 391
		IsCharmed = 131072,
		// Token: 0x04000188 RID: 392
		IsNoRender = 262144,
		// Token: 0x04000189 RID: 393
		IsForceRenderParticles = 524288,
		// Token: 0x0400018A RID: 394
		IsSlowed = 16777216,
		// Token: 0x0400018B RID: 395
		IsSelectable = 33554432,
		// Token: 0x0400018C RID: 396
		IsGrounded = 134217728,
		// Token: 0x0400018D RID: 397
		IsDodgingMissiles = 268435456,
		// Token: 0x0400018E RID: 398
		IsCursorAllowedWhileUntargetable = 536870912,
		// Token: 0x0400018F RID: 399
		IsObscured = 1073741824,
		// Token: 0x04000190 RID: 400
		IsClickproofToEnemies = -2147483648
	}
}
