using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EnsoulSharp.SDK.Utility.MouseActivity.WinApi;

namespace EnsoulSharp.SDK.Utility.MouseActivity
{
	// Token: 0x02000086 RID: 134
	internal class MouseEventExtArgs : MouseEventArgs
	{
		// Token: 0x060004E9 RID: 1257 RVA: 0x000249C0 File Offset: 0x00022BC0
		internal static MouseEventExtArgs FromRawData(int wParam, IntPtr lParam)
		{
			MouseStruct mouseStruct = (MouseStruct)Marshal.PtrToStructure(lParam, typeof(MouseStruct));
			MouseButtons buttons = MouseButtons.None;
			short delta = 0;
			int clicks = 0;
			bool isMouseKeyDown = false;
			bool isMouseKeyUp = false;
			switch (wParam)
			{
			case 513:
				isMouseKeyDown = true;
				buttons = MouseButtons.Left;
				clicks = 1;
				break;
			case 514:
				isMouseKeyUp = true;
				buttons = MouseButtons.Left;
				clicks = 1;
				break;
			case 515:
				isMouseKeyDown = true;
				buttons = MouseButtons.Left;
				clicks = 2;
				break;
			case 516:
				isMouseKeyDown = true;
				buttons = MouseButtons.Right;
				clicks = 1;
				break;
			case 517:
				isMouseKeyUp = true;
				buttons = MouseButtons.Right;
				clicks = 1;
				break;
			case 518:
				isMouseKeyDown = true;
				buttons = MouseButtons.Right;
				clicks = 2;
				break;
			case 519:
				isMouseKeyDown = true;
				buttons = MouseButtons.Middle;
				clicks = 1;
				break;
			case 520:
				isMouseKeyUp = true;
				buttons = MouseButtons.Middle;
				clicks = 1;
				break;
			case 521:
				isMouseKeyDown = true;
				buttons = MouseButtons.Middle;
				clicks = 2;
				break;
			case 522:
				delta = mouseStruct.MouseData;
				break;
			case 523:
				buttons = ((mouseStruct.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
				isMouseKeyDown = true;
				clicks = 1;
				break;
			case 524:
				buttons = ((mouseStruct.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
				isMouseKeyUp = true;
				clicks = 1;
				break;
			case 525:
				isMouseKeyDown = true;
				buttons = ((mouseStruct.MouseData == 1) ? MouseButtons.XButton1 : MouseButtons.XButton2);
				clicks = 2;
				break;
			}
			return new MouseEventExtArgs(buttons, clicks, mouseStruct.Point, (int)delta, isMouseKeyDown, isMouseKeyUp);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00024B2B File Offset: 0x00022D2B
		internal MouseEventExtArgs(MouseButtons buttons, int clicks, Point point, int delta, bool isMouseKeyDown, bool isMouseKeyUp) : base(buttons, clicks, point.X, point.Y, delta)
		{
			this.IsMouseKeyDown = isMouseKeyDown;
			this.IsMouseKeyUp = isMouseKeyUp;
			this.WheelScrolled = (delta != 0);
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00024B5E File Offset: 0x00022D5E
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x00024B66 File Offset: 0x00022D66
		public bool Handled { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00024B6F File Offset: 0x00022D6F
		public bool IsMouseKeyDown { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x00024B77 File Offset: 0x00022D77
		public bool IsMouseKeyUp { get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00024B7F File Offset: 0x00022D7F
		public bool WheelScrolled { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x00024B87 File Offset: 0x00022D87
		internal Point Point
		{
			get
			{
				return new Point(base.X, base.Y);
			}
		}
	}
}
