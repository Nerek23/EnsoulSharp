using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000349 RID: 841
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ziggs", SpellSlot.W, 0)]
	public class DamageZiggsW : DamageSpell
	{
		// Token: 0x06000FF3 RID: 4083 RVA: 0x000444E1 File Offset: 0x000426E1
		public DamageZiggsW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x000444F7 File Offset: 0x000426F7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZiggsW.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086D RID: 2157
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
