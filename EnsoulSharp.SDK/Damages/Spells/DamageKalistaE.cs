using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CC RID: 460
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kalista", SpellSlot.E, 0)]
	public class DamageKalistaE : DamageSpell
	{
		// Token: 0x06000B81 RID: 2945 RVA: 0x0003C739 File Offset: 0x0003A939
		public DamageKalistaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0003C750 File Offset: 0x0003A950
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			int buffCount = target.GetBuffCount("kalistaexpungemarker");
			if (buffCount > 0)
			{
				double num = DamageKalistaE.damages[level] + 0.7 * (double)source.TotalAttackDamage;
				double num2 = DamageKalistaE.buffdamages[level] + DamageKalistaE.buffdamagePercents[level] * (double)source.TotalAttackDamage;
				return num + (double)(buffCount - 1) * num2;
			}
			return 0.0;
		}

		// Token: 0x040006CB RID: 1739
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};

		// Token: 0x040006CC RID: 1740
		private static readonly double[] buffdamages = new double[]
		{
			10.0,
			14.0,
			19.0,
			25.0,
			32.0
		};

		// Token: 0x040006CD RID: 1741
		private static readonly double[] buffdamagePercents = new double[]
		{
			0.232,
			0.275,
			0.319,
			0.363,
			0.406
		};
	}
}
