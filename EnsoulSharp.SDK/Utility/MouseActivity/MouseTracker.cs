using System;
using System.Windows.Forms;
using EnsoulSharp.SDK.Utils;

namespace EnsoulSharp.SDK.Utility.MouseActivity
{
	// Token: 0x02000088 RID: 136
	internal class MouseTracker
	{
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000512 RID: 1298 RVA: 0x000250B0 File Offset: 0x000232B0
		// (remove) Token: 0x06000513 RID: 1299 RVA: 0x000250E4 File Offset: 0x000232E4
		public static event MouseTracker.OnMouseTrackerDelegates OnMouseTracker;

		// Token: 0x06000514 RID: 1300 RVA: 0x00025118 File Offset: 0x00023318
		public MouseTracker()
		{
			Logging.Write(false, true, ".ctor")(LogLevel.Info, "China server bypass report windows control successful.", Array.Empty<object>());
			MouseTracker.mouseHookListener = new MouseHookListener();
			MouseTracker.mouseHookListener.Enabled = true;
			MouseTracker.mouseHookListener.MouseUp += MouseTracker.OnMouseUp;
			MouseTracker.mouseHookListener.MouseDown += MouseTracker.OnMouseDown;
			MouseTracker.mouseHookListener.MouseMove += MouseTracker.OnMouseMove;
			MouseTracker.mouseHookListener.MouseDoubleClick += MouseTracker.OnMouseDoubleClick;
			MouseTracker.mouseHookListener.MouseWheel += MouseTracker.OnMouseWheel;
			AppDomain.CurrentDomain.DomainUnload += MouseTracker.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += MouseTracker.OnDispose;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000251F8 File Offset: 0x000233F8
		private static void OnMouseUp(object sender, MouseEventArgs args)
		{
			if (args.Button == MouseButtons.None)
			{
				return;
			}
			SingleMouseKey key = SingleMouseKey.None;
			if ((args.Button & MouseButtons.Left) != MouseButtons.None)
			{
				key = SingleMouseKey.LeftClick;
			}
			else if ((args.Button & MouseButtons.Right) != MouseButtons.None)
			{
				key = SingleMouseKey.RightClick;
			}
			else if ((args.Button & MouseButtons.Middle) != MouseButtons.None)
			{
				key = SingleMouseKey.MiddleClick;
			}
			else if ((args.Button & MouseButtons.XButton1) != MouseButtons.None)
			{
				key = SingleMouseKey.XButton1Click;
			}
			else if ((args.Button & MouseButtons.XButton2) != MouseButtons.None)
			{
				key = SingleMouseKey.XButton2Click;
			}
			SingleMouseEventArgs args2 = new SingleMouseEventArgs
			{
				Type = SingleMouseType.MouseUp,
				Key = key
			};
			MouseTracker.OnMouseTrackerDelegates onMouseTracker = MouseTracker.OnMouseTracker;
			if (onMouseTracker == null)
			{
				return;
			}
			onMouseTracker(args2);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0002528C File Offset: 0x0002348C
		private static void OnMouseDown(object sender, MouseEventArgs args)
		{
			if (args.Button == MouseButtons.None)
			{
				return;
			}
			SingleMouseKey key = SingleMouseKey.None;
			if ((args.Button & MouseButtons.Left) != MouseButtons.None)
			{
				key = SingleMouseKey.LeftClick;
			}
			else if ((args.Button & MouseButtons.Right) != MouseButtons.None)
			{
				key = SingleMouseKey.RightClick;
			}
			else if ((args.Button & MouseButtons.Middle) != MouseButtons.None)
			{
				key = SingleMouseKey.MiddleClick;
			}
			else if ((args.Button & MouseButtons.XButton1) != MouseButtons.None)
			{
				key = SingleMouseKey.XButton1Click;
			}
			else if ((args.Button & MouseButtons.XButton2) != MouseButtons.None)
			{
				key = SingleMouseKey.XButton2Click;
			}
			SingleMouseEventArgs args2 = new SingleMouseEventArgs
			{
				Type = SingleMouseType.MouseDown,
				Key = key
			};
			MouseTracker.OnMouseTrackerDelegates onMouseTracker = MouseTracker.OnMouseTracker;
			if (onMouseTracker == null)
			{
				return;
			}
			onMouseTracker(args2);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00025320 File Offset: 0x00023520
		private static void OnMouseMove(object sender, MouseEventArgs args)
		{
			EnsoulSharp.SDK.Utils.Cursor.SetCursorPosition(args.X, args.Y);
			SingleMouseEventArgs args2 = new SingleMouseEventArgs
			{
				Type = SingleMouseType.MouseMove
			};
			MouseTracker.OnMouseTrackerDelegates onMouseTracker = MouseTracker.OnMouseTracker;
			if (onMouseTracker == null)
			{
				return;
			}
			onMouseTracker(args2);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0002535C File Offset: 0x0002355C
		private static void OnMouseWheel(object sender, MouseEventArgs args)
		{
			SingleMouseEventArgs args2 = new SingleMouseEventArgs
			{
				Type = SingleMouseType.MouseWheel
			};
			MouseTracker.OnMouseTrackerDelegates onMouseTracker = MouseTracker.OnMouseTracker;
			if (onMouseTracker == null)
			{
				return;
			}
			onMouseTracker(args2);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00025388 File Offset: 0x00023588
		private static void OnMouseDoubleClick(object sender, MouseEventArgs args)
		{
			SingleMouseEventArgs args2 = new SingleMouseEventArgs
			{
				Type = SingleMouseType.MouseDoubleClick,
				Key = SingleMouseKey.LeftClick
			};
			MouseTracker.OnMouseTrackerDelegates onMouseTracker = MouseTracker.OnMouseTracker;
			if (onMouseTracker == null)
			{
				return;
			}
			onMouseTracker(args2);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x000253B9 File Offset: 0x000235B9
		private static void OnDispose(object sender, EventArgs args)
		{
			if (MouseTracker.mouseHookListener != null)
			{
				MouseTracker.mouseHookListener.Enabled = false;
				MouseTracker.mouseHookListener.Dispose();
				MouseTracker.mouseHookListener = null;
			}
		}

		// Token: 0x040002C8 RID: 712
		internal static MouseHookListener mouseHookListener;

		// Token: 0x020004D4 RID: 1236
		// (Invoke) Token: 0x0600166D RID: 5741
		public delegate void OnMouseTrackerDelegates(SingleMouseEventArgs args);
	}
}
