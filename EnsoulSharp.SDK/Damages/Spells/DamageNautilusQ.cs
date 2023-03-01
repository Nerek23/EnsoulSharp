using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000245 RID: 581
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nautilus", SpellSlot.Q, 0)]
	public class DamageNautilusQ : DamageSpell
	{
		// Token: 0x06000CE9 RID: 3305 RVA: 0x0003EE80 File Offset: 0x0003D080
		public DamageNautilusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0003EE96 File Offset: 0x0003D096
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNautilusQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400074A RID: 1866
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
