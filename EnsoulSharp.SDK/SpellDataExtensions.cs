using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000013 RID: 19
	public static class SpellDataExtensions
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00006218 File Offset: 0x00004418
		public static bool IsReady(this SpellDataInst spell, int t = 0)
		{
			if (spell == null)
			{
				return false;
			}
			if (spell.Slot == SpellSlot.Unknown || t != 0)
			{
				return spell.State == SpellState.Ready || (spell.State == SpellState.Cooldown && spell.CooldownExpires - Game.Time <= (float)t / 1000f);
			}
			return spell.State == SpellState.Ready;
		}
	}
}
