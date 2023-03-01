using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000168 RID: 360
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("DrMundo", SpellSlot.Q, 0)]
	public class DamageDrMundoQ : DamageSpell
	{
		// Token: 0x06000A50 RID: 2640 RVA: 0x0003A68B File Offset: 0x0003888B
		public DamageDrMundoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0003A6A4 File Offset: 0x000388A4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double val = DamageDrMundoQ.currentdamages[level] / 100.0 * (double)target.Health;
			if (target.Type == GameObjectType.AIMinionClient && target.IsJungle())
			{
				return Math.Min(DamageDrMundoQ.maxdamages[level], Math.Max(DamageDrMundoQ.mindamages[level], val));
			}
			return Math.Max(DamageDrMundoQ.mindamages[level], val);
		}

		// Token: 0x0400065E RID: 1630
		private static readonly double[] mindamages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};

		// Token: 0x0400065F RID: 1631
		private static readonly double[] maxdamages = new double[]
		{
			150.0,
			225.0,
			300.0,
			375.0,
			450.0
		};

		// Token: 0x04000660 RID: 1632
		private static readonly double[] currentdamages = new double[]
		{
			20.0,
			22.5,
			25.0,
			27.5,
			30.0
		};
	}
}
