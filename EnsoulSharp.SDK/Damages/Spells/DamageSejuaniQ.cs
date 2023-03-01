using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A3 RID: 675
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sejuani", SpellSlot.Q, 0)]
	public class DamageSejuaniQ : DamageSpell
	{
		// Token: 0x06000E02 RID: 3586 RVA: 0x00040D24 File Offset: 0x0003EF24
		public DamageSejuaniQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00040D3A File Offset: 0x0003EF3A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSejuaniQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007B2 RID: 1970
		private static readonly double[] damages = new double[]
		{
			90.0,
			140.0,
			190.0,
			240.0,
			290.0
		};
	}
}
