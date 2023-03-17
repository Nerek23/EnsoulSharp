using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x0200007B RID: 123
	public static class DelayAction
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x000236E4 File Offset: 0x000218E4
		static DelayAction()
		{
			Game.OnUpdate += DelayAction.OnUpdate;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00023704 File Offset: 0x00021904
		public static void Add(int time, DelayAction.Callback func)
		{
			DelayAction.Action item = new DelayAction.Action(time, func);
			DelayAction.ActionList.Add(item);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00023728 File Offset: 0x00021928
		private static void OnUpdate(EventArgs args)
		{
			for (int i = DelayAction.ActionList.Count - 1; i >= 0; i--)
			{
				if (DelayAction.ActionList[i].Time <= Variables.GameTimeTickCount)
				{
					try
					{
						DelayAction.Callback callbackObject = DelayAction.ActionList[i].CallbackObject;
						if (callbackObject != null)
						{
							callbackObject();
						}
					}
					catch (Exception)
					{
					}
					DelayAction.ActionList.RemoveAt(i);
				}
			}
		}

		// Token: 0x04000291 RID: 657
		private static readonly List<DelayAction.Action> ActionList = new List<DelayAction.Action>();

		// Token: 0x020004C8 RID: 1224
		// (Invoke) Token: 0x06001649 RID: 5705
		public delegate void Callback();

		// Token: 0x020004C9 RID: 1225
		internal struct Action
		{
			// Token: 0x0600164C RID: 5708 RVA: 0x0004E5AF File Offset: 0x0004C7AF
			public Action(int time, DelayAction.Callback callback)
			{
				this.Time = time + Variables.GameTimeTickCount;
				this.CallbackObject = callback;
			}

			// Token: 0x04000C6A RID: 3178
			public DelayAction.Callback CallbackObject;

			// Token: 0x04000C6B RID: 3179
			public int Time;
		}
	}
}
