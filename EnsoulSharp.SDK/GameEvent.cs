using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200002E RID: 46
	[Export(typeof(GameEvent))]
	public class GameEvent
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000CF7C File Offset: 0x0000B17C
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0000CF83 File Offset: 0x0000B183
		public static int TickPreSecond
		{
			get
			{
				return GameEvent._tickPreSecond;
			}
			set
			{
				if (value <= 0)
				{
					Logging.Write(false, true, "TickPreSecond")(LogLevel.Error, "TickPreSecond Cant be <= 0, please check the value and then set it bigger than 0", Array.Empty<object>());
					GameEvent._tickPreSecond = 1;
					return;
				}
				GameEvent._tickPreSecond = value;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000CFB2 File Offset: 0x0000B1B2
		public GameEvent()
		{
			Game.OnUpdate += GameEvent.OnGameLoadUpdate;
			GameEvent.OnGameLoad += delegate()
			{
				Game.OnWndProc += GameEvent.OnWndProc;
				MouseTracker.OnMouseTracker += GameEvent.OnMouseTracker;
			};
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000249 RID: 585 RVA: 0x0000CFF0 File Offset: 0x0000B1F0
		// (remove) Token: 0x0600024A RID: 586 RVA: 0x0000D024 File Offset: 0x0000B224
		public static event GameEvent.OnGameLoadDelegate OnGameLoad;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600024B RID: 587 RVA: 0x0000D058 File Offset: 0x0000B258
		// (remove) Token: 0x0600024C RID: 588 RVA: 0x0000D08C File Offset: 0x0000B28C
		public static event GameEvent.OnGameEndDelegate OnGameEnd;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600024D RID: 589 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		// (remove) Token: 0x0600024E RID: 590 RVA: 0x0000D0F4 File Offset: 0x0000B2F4
		public static event GameEvent.OnGameTickDelegate OnGameTick;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600024F RID: 591 RVA: 0x0000D128 File Offset: 0x0000B328
		// (remove) Token: 0x06000250 RID: 592 RVA: 0x0000D15C File Offset: 0x0000B35C
		public static event GameEvent.OnWindowsProcDelegate OnGameWndProc;

		// Token: 0x06000251 RID: 593 RVA: 0x0000D190 File Offset: 0x0000B390
		private static void OnWndProc(GameWndEventArgs args)
		{
			if (!Library.GameCache.IsRiot && (args.Msg == 513U || args.Msg == 514U || args.Msg == 516U || args.Msg == 517U || args.Msg == 523U || args.Msg == 524U || args.Msg == 519U || args.Msg == 520U || args.Msg == 522U || args.Msg == 515U))
			{
				return;
			}
			GameEvent.WindowndEventArgs windowndEventArgs = new GameEvent.WindowndEventArgs(args.Process, args.HWnd, args.Msg, args.WParam, args.LParam);
			GameEvent.OnWindowsProcDelegate onGameWndProc = GameEvent.OnGameWndProc;
			if (onGameWndProc != null)
			{
				onGameWndProc(windowndEventArgs);
			}
			args.Process = windowndEventArgs.Process;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000D270 File Offset: 0x0000B470
		private static void OnMouseTracker(SingleMouseEventArgs args)
		{
			if (Library.GameCache.IsRiot)
			{
				return;
			}
			if (args.WindowsKey == WindowsKeyMessages.NULL)
			{
				return;
			}
			GameEvent.WindowndEventArgs args2 = new GameEvent.WindowndEventArgs(true, Game.Window, (uint)args.WindowsKey, 0U, 0);
			GameEvent.OnWindowsProcDelegate onGameWndProc = GameEvent.OnGameWndProc;
			if (onGameWndProc == null)
			{
				return;
			}
			onGameWndProc(args2);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
		private static void OnGameLoadUpdate(EventArgs args)
		{
			if (Game.State == GameState.Running)
			{
				foreach (Action action in GameEvent.AlwaysLoadActions)
				{
					action();
				}
				GameEvent.AlwaysLoadActions.Clear();
				if (GameEvent.OnGameLoad != null)
				{
					foreach (Delegate @delegate in (from o in GameEvent.OnGameLoad.GetInvocationList()
					where !GameEvent.LoadCompleteDelegate.Contains(o)
					select o).ToArray<Delegate>())
					{
						GameEvent.LoadCompleteDelegate.Add(@delegate);
						GameEvent.OnGameLoadDelegate onGameLoadDelegate = @delegate as GameEvent.OnGameLoadDelegate;
						if (onGameLoadDelegate != null)
						{
							onGameLoadDelegate();
						}
					}
				}
				if (GameEvent.OnGameTick != null)
				{
					if (Variables.GameTimeTickCount - GameEvent.lastTick < 1000 / GameEvent.TickPreSecond)
					{
						return;
					}
					Delegate[] array = GameEvent.OnGameTick.GetInvocationList();
					for (int i = 0; i < array.Length; i++)
					{
						GameEvent.OnGameTickDelegate onGameTickDelegate = array[i] as GameEvent.OnGameTickDelegate;
						if (onGameTickDelegate != null)
						{
							onGameTickDelegate(EventArgs.Empty);
						}
					}
					GameEvent.lastTick = Variables.GameTimeTickCount;
					return;
				}
			}
			else if (Game.State >= GameState.Finished)
			{
				if (GameEvent._alreadyCall)
				{
					return;
				}
				GameEvent.OnGameEndDelegate onGameEnd = GameEvent.OnGameEnd;
				if (onGameEnd != null)
				{
					onGameEnd();
				}
				GameEvent._alreadyCall = true;
			}
		}

		// Token: 0x0400010A RID: 266
		private static int lastTick;

		// Token: 0x0400010B RID: 267
		private static int _tickPreSecond = 50;

		// Token: 0x0400010C RID: 268
		private static bool _alreadyCall;

		// Token: 0x0400010D RID: 269
		internal static List<Action> AlwaysLoadActions = new List<Action>();

		// Token: 0x0400010E RID: 270
		internal static List<Delegate> LoadCompleteDelegate = new List<Delegate>();

		// Token: 0x0200045F RID: 1119
		// (Invoke) Token: 0x060014BC RID: 5308
		public delegate void OnGameEndDelegate();

		// Token: 0x02000460 RID: 1120
		// (Invoke) Token: 0x060014C0 RID: 5312
		public delegate void OnGameLoadDelegate();

		// Token: 0x02000461 RID: 1121
		// (Invoke) Token: 0x060014C4 RID: 5316
		public delegate void OnGameTickDelegate(EventArgs args);

		// Token: 0x02000462 RID: 1122
		// (Invoke) Token: 0x060014C8 RID: 5320
		public delegate void OnWindowsProcDelegate(GameEvent.WindowndEventArgs args);

		// Token: 0x02000463 RID: 1123
		public class WindowndEventArgs : EventArgs
		{
			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x060014CB RID: 5323 RVA: 0x0004B967 File Offset: 0x00049B67
			public int LParam
			{
				get
				{
					return this.m_lParam;
				}
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x060014CC RID: 5324 RVA: 0x0004B96F File Offset: 0x00049B6F
			public uint WParam
			{
				get
				{
					return this.m_wParam;
				}
			}

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x060014CD RID: 5325 RVA: 0x0004B977 File Offset: 0x00049B77
			public uint Msg
			{
				get
				{
					return this.m_uMsg;
				}
			}

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x060014CE RID: 5326 RVA: 0x0004B97F File Offset: 0x00049B7F
			public IntPtr HWnd
			{
				get
				{
					return this.m_hWnd;
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x060014CF RID: 5327 RVA: 0x0004B987 File Offset: 0x00049B87
			// (set) Token: 0x060014D0 RID: 5328 RVA: 0x0004B98F File Offset: 0x00049B8F
			public bool Process { get; set; }

			// Token: 0x060014D1 RID: 5329 RVA: 0x0004B998 File Offset: 0x00049B98
			internal WindowndEventArgs(bool process, IntPtr hWnd, uint uMsg, uint wParam, int lParam)
			{
				this.Process = process;
				this.m_hWnd = hWnd;
				this.m_uMsg = uMsg;
				this.m_wParam = wParam;
				this.m_lParam = lParam;
			}

			// Token: 0x04000B4A RID: 2890
			private readonly int m_lParam;

			// Token: 0x04000B4B RID: 2891
			private readonly uint m_uMsg;

			// Token: 0x04000B4C RID: 2892
			private readonly uint m_wParam;

			// Token: 0x04000B4D RID: 2893
			private readonly IntPtr m_hWnd;
		}
	}
}
