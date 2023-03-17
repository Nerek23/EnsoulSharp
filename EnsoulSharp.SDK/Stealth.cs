using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000031 RID: 49
	public static class Stealth
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000FF64 File Offset: 0x0000E164
		static Stealth()
		{
			GameObject.OnIntegerPropertyChange += Stealth.EventStealth;
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000269 RID: 617 RVA: 0x0000FF78 File Offset: 0x0000E178
		// (remove) Token: 0x0600026A RID: 618 RVA: 0x0000FFAC File Offset: 0x0000E1AC
		public static event Stealth.OnStealthEvent OnStealth;

		// Token: 0x0600026B RID: 619 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
		private static void EventStealth(GameObject sender, GameObjectIntegerPropertyChangeEventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			AIHeroClient aiheroClient = sender as AIHeroClient;
			if (aiheroClient == null || !args.Property.Equals("ActionState"))
			{
				return;
			}
			GameObjectCharacterState oldValue = (GameObjectCharacterState)args.OldValue;
			GameObjectCharacterState newValue = (GameObjectCharacterState)args.NewValue;
			if (!oldValue.HasFlag(GameObjectCharacterState.IsStealthed) && newValue.HasFlag(GameObjectCharacterState.IsStealthed))
			{
				Stealth.FireOnStealth(new Stealth.OnStealthEventArgs
				{
					Sender = aiheroClient,
					Time = Game.Time,
					IsStealthed = true
				});
				return;
			}
			if (oldValue.HasFlag(GameObjectCharacterState.IsStealthed) && !newValue.HasFlag(GameObjectCharacterState.IsStealthed))
			{
				Stealth.FireOnStealth(new Stealth.OnStealthEventArgs
				{
					Sender = aiheroClient,
					IsStealthed = false
				});
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000100BC File Offset: 0x0000E2BC
		private static void FireOnStealth(Stealth.OnStealthEventArgs args)
		{
			Stealth.OnStealthEvent onStealth = Stealth.OnStealth;
			if (onStealth == null)
			{
				return;
			}
			onStealth(args);
		}

		// Token: 0x02000477 RID: 1143
		// (Invoke) Token: 0x06001506 RID: 5382
		public delegate void OnStealthEvent(Stealth.OnStealthEventArgs args);

		// Token: 0x02000478 RID: 1144
		public class OnStealthEventArgs : EventArgs
		{
			// Token: 0x04000B82 RID: 2946
			public bool IsStealthed;

			// Token: 0x04000B83 RID: 2947
			public AIHeroClient Sender;

			// Token: 0x04000B84 RID: 2948
			public float Time;
		}
	}
}
