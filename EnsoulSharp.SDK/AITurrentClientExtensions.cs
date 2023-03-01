using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000035 RID: 53
	public static class AITurrentClientExtensions
	{
		// Token: 0x06000282 RID: 642 RVA: 0x0001053C File Offset: 0x0000E73C
		public static TurretType GetTurretType(this AITurretClient turret)
		{
			string characterName = turret.CharacterName;
			if (AITurrentClientExtensions.TurretsTierOne.Contains(characterName))
			{
				return TurretType.TierOne;
			}
			if (AITurrentClientExtensions.TurretsTierTwo.Contains(characterName))
			{
				return TurretType.TierOne;
			}
			if (AITurrentClientExtensions.TurretsTierThree.Contains(characterName))
			{
				return TurretType.TierOne;
			}
			if (!AITurrentClientExtensions.TurretsTierFour.Contains(characterName))
			{
				return TurretType.Unknown;
			}
			return TurretType.TierOne;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00010590 File Offset: 0x0000E790
		public static bool IsFountainTurret(this AITurretClient turret)
		{
			string characterName = turret.CharacterName;
			return AITurrentClientExtensions.TurretsFierFive.Contains(characterName);
		}

		// Token: 0x04000121 RID: 289
		private static readonly HashSet<string> TurretsTierOne = new HashSet<string>
		{
			"SRUAP_Turret_Order1",
			"SRUAP_Turret_Chaos1",
			"TT_OrderTurret5",
			"TT_ChaosTurret5",
			"HA_AP_OrderTurret",
			"HA_AP_ChaosTurret"
		};

		// Token: 0x04000122 RID: 290
		private static readonly HashSet<string> TurretsTierTwo = new HashSet<string>
		{
			"SRUAP_Turret_Order2",
			"SRUAP_Turret_Chaos2",
			"TT_OrderTurret2",
			"TT_ChaosTurret2",
			"HA_AP_OrderTurret2",
			"HA_AP_ChaosTurret2"
		};

		// Token: 0x04000123 RID: 291
		private static readonly HashSet<string> TurretsTierThree = new HashSet<string>
		{
			"SRUAP_Turret_Order3",
			"SRUAP_Turret_Chaos3",
			"TT_OrderTurret1",
			"TT_ChaosTurret1",
			"HA_AP_OrderTurret3",
			"HA_AP_ChaosTurret3"
		};

		// Token: 0x04000124 RID: 292
		private static readonly HashSet<string> TurretsTierFour = new HashSet<string>
		{
			"SRUAP_Turret_Order4",
			"SRUAP_Turret_Chaos4",
			"TT_OrderTurret3",
			"TT_ChaosTurret3"
		};

		// Token: 0x04000125 RID: 293
		private static readonly HashSet<string> TurretsFierFive = new HashSet<string>
		{
			"SRUAP_Turret_Order5",
			"SRUAP_Turret_Chaos5"
		};
	}
}
