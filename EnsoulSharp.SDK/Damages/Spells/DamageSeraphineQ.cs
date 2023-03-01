using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DF RID: 735
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Seraphine", SpellSlot.Q, 0)]
	public class DamageSeraphineQ : DamageSpell
	{
		// Token: 0x06000EB6 RID: 3766 RVA: 0x00042122 File Offset: 0x00040322
		public DamageSeraphineQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00042138 File Offset: 0x00040338
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageSeraphineQ.damages[level] + DamageSeraphineQ.damagePercents[level] * (double)source.TotalMagicalDamage;
			float num2 = 100f - target.HealthPercent;
			if (num2 >= 75f)
			{
				num *= 1.5;
			}
			else if ((double)num2 >= 67.5)
			{
				num *= 1.4500000476837158;
			}
			else if (num2 >= 60f)
			{
				num *= 1.399999976158142;
			}
			else if (num2 >= 60f)
			{
				num *= 1.399999976158142;
			}
			else if ((double)num2 >= 52.5)
			{
				num *= 1.350000023841858;
			}
			else if (num2 >= 45f)
			{
				num *= 1.2999999523162842;
			}
			else if ((double)num2 >= 37.5)
			{
				num *= 1.25;
			}
			else if (num2 >= 30f)
			{
				num *= 1.2000000476837158;
			}
			else if ((double)num2 >= 22.5)
			{
				num *= 1.149999976158142;
			}
			else if (num2 >= 15f)
			{
				num *= 1.100000023841858;
			}
			else if ((double)num2 >= 7.5)
			{
				num *= 1.0499999523162842;
			}
			return num;
		}

		// Token: 0x040007F6 RID: 2038
		private static readonly double[] damages = new double[]
		{
			55.0,
			70.0,
			85.0,
			100.0,
			115.0
		};

		// Token: 0x040007F7 RID: 2039
		private static readonly double[] damagePercents = new double[]
		{
			0.45,
			0.5,
			0.55,
			0.6,
			0.65
		};
	}
}
