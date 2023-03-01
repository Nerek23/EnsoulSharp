using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000034 RID: 52
	public static class SpellSlotExtensions
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00010510 File Offset: 0x0000E710
		public static bool IsReady(this SpellSlot slot, int t = 0)
		{
			SpellDataInst spell = GameObjects.Player.Spellbook.GetSpell(slot);
			return spell != null && spell.IsReady(t);
		}
	}
}
