using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001A RID: 26
	public interface IHealthPrediction : IDisposable
	{
		// Token: 0x06000123 RID: 291
		AIBaseClient GetAggroTurret(AIMinionClient minion);

		// Token: 0x06000124 RID: 292
		float GetPrediction(AIBaseClient unit, int time, int delay = 70, HealthPredictionType type = HealthPredictionType.Default);

		// Token: 0x06000125 RID: 293
		bool HasMinionAggro(AIMinionClient minion);

		// Token: 0x06000126 RID: 294
		bool HasTurretAggro(AIMinionClient minion);

		// Token: 0x06000127 RID: 295
		int TurretAggroStartTick(AIMinionClient minion);
	}
}
