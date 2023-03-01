using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001D RID: 29
	public interface IPrediction
	{
		// Token: 0x06000135 RID: 309
		PredictionOutput GetPrediction(PredictionInput input);

		// Token: 0x06000136 RID: 310
		PredictionOutput GetPrediction(PredictionInput input, bool ft, bool checkCollision);
	}
}
