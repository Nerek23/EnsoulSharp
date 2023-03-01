using System;
using System.Windows.Forms;
using EnsoulSharp.SDK.Utility.MouseActivity.WinApi;

namespace EnsoulSharp.SDK.Utility.MouseActivity
{
	// Token: 0x02000087 RID: 135
	internal class MouseHookListener : IDisposable
	{
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060004F1 RID: 1265 RVA: 0x00024B9C File Offset: 0x00022D9C
		// (remove) Token: 0x060004F2 RID: 1266 RVA: 0x00024BD4 File Offset: 0x00022DD4
		public event MouseEventHandler MouseDown;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060004F3 RID: 1267 RVA: 0x00024C0C File Offset: 0x00022E0C
		// (remove) Token: 0x060004F4 RID: 1268 RVA: 0x00024C44 File Offset: 0x00022E44
		public event MouseEventHandler MouseUp;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060004F5 RID: 1269 RVA: 0x00024C7C File Offset: 0x00022E7C
		// (remove) Token: 0x060004F6 RID: 1270 RVA: 0x00024CB4 File Offset: 0x00022EB4
		public event MouseEventHandler MouseMove;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060004F7 RID: 1271 RVA: 0x00024CEC File Offset: 0x00022EEC
		// (remove) Token: 0x060004F8 RID: 1272 RVA: 0x00024D24 File Offset: 0x00022F24
		public event MouseEventHandler MouseWheel;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060004F9 RID: 1273 RVA: 0x00024D5C File Offset: 0x00022F5C
		// (remove) Token: 0x060004FA RID: 1274 RVA: 0x00024D94 File Offset: 0x00022F94
		public event MouseEventHandler MouseDoubleClick;

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00024DC9 File Offset: 0x00022FC9
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x00024DD1 File Offset: 0x00022FD1
		public int HookHandle { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00024DDA File Offset: 0x00022FDA
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x00024DE2 File Offset: 0x00022FE2
		public HookCallback HookCallbackReferenceKeeper { get; set; }

		// Token: 0x060004FF RID: 1279 RVA: 0x00024DEB File Offset: 0x00022FEB
		public MouseHookListener()
		{
			this.m_Hooker = new Hooker();
			this.m_PreviousPosition = new Point(-1, -1);
			this.m_SuppressButtonUpFlags = MouseButtons.None;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00024E14 File Offset: 0x00023014
		~MouseHookListener()
		{
			if (this.HookHandle != 0)
			{
				Hooker.UnhookWindowsHookEx(this.HookHandle);
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00024E50 File Offset: 0x00023050
		public bool ProcessCallback(int wParam, IntPtr lParam)
		{
			MouseEventExtArgs mouseEventExtArgs = MouseEventExtArgs.FromRawData(wParam, lParam);
			if (mouseEventExtArgs.IsMouseKeyDown)
			{
				this.ProcessMouseDown(ref mouseEventExtArgs);
			}
			if (mouseEventExtArgs.Clicks == 2 && !mouseEventExtArgs.Handled)
			{
				this.InvokeMouseEventHandler(this.MouseDoubleClick, mouseEventExtArgs);
			}
			if (mouseEventExtArgs.IsMouseKeyUp)
			{
				this.ProcessMouseUp(ref mouseEventExtArgs);
			}
			if (this.HasMoved(mouseEventExtArgs.Point))
			{
				this.ProcessMouseMove(ref mouseEventExtArgs);
			}
			if (mouseEventExtArgs.WheelScrolled)
			{
				this.InvokeMouseEventHandler(this.MouseWheel, mouseEventExtArgs);
			}
			return !mouseEventExtArgs.Handled;
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00024ED7 File Offset: 0x000230D7
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x00024EE2 File Offset: 0x000230E2
		public bool Enabled
		{
			get
			{
				return this.HookHandle != 0;
			}
			set
			{
				if (value)
				{
					this.Start();
				}
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00024EED File Offset: 0x000230ED
		public int GetHookId()
		{
			return 7;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00024EF0 File Offset: 0x000230F0
		public int HookCallback(int nCode, int wParam, IntPtr lParam)
		{
			if (nCode == 0 && !this.ProcessCallback(wParam, lParam))
			{
				return -1;
			}
			return this.CallNextHook(nCode, wParam, lParam);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00024F0C File Offset: 0x0002310C
		private void Start()
		{
			this.HookCallbackReferenceKeeper = new HookCallback(this.HookCallback);
			try
			{
				this.HookHandle = this.m_Hooker.Subscribe(this.GetHookId(), this.HookCallbackReferenceKeeper);
			}
			catch
			{
				this.HookCallbackReferenceKeeper = null;
				this.HookHandle = 0;
				throw;
			}
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00024F6C File Offset: 0x0002316C
		private void Stop()
		{
			try
			{
				this.m_Hooker.Unsubscribe(this.HookHandle);
			}
			finally
			{
				this.HookCallbackReferenceKeeper = null;
				this.HookHandle = 0;
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00024FAC File Offset: 0x000231AC
		private int CallNextHook(int nCode, int wParam, IntPtr lParam)
		{
			return Hooker.CallNextHookEx(this.HookHandle, nCode, wParam, lParam);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00024FBC File Offset: 0x000231BC
		private void ProcessMouseDown(ref MouseEventExtArgs e)
		{
			this.InvokeMouseEventHandler(this.MouseDown, e);
			if (e.Handled)
			{
				this.SetSupressButtonUpFlag(e.Button);
				e.Handled = true;
			}
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00024FEA File Offset: 0x000231EA
		private bool HasMoved(Point actualPoint)
		{
			return this.m_PreviousPosition != actualPoint;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00024FF8 File Offset: 0x000231F8
		private void ProcessMouseMove(ref MouseEventExtArgs e)
		{
			this.m_PreviousPosition = e.Point;
			this.InvokeMouseEventHandler(this.MouseMove, e);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00025015 File Offset: 0x00023215
		private void ProcessMouseUp(ref MouseEventExtArgs e)
		{
			if (!this.HasSupressButtonUpFlag(e.Button))
			{
				this.InvokeMouseEventHandler(this.MouseUp, e);
				return;
			}
			this.RemoveSupressButtonUpFlag(e.Button);
			e.Handled = true;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0002504A File Offset: 0x0002324A
		private void RemoveSupressButtonUpFlag(MouseButtons button)
		{
			this.m_SuppressButtonUpFlags ^= button;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0002505A File Offset: 0x0002325A
		private bool HasSupressButtonUpFlag(MouseButtons button)
		{
			return (this.m_SuppressButtonUpFlags & button) > MouseButtons.None;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00025067 File Offset: 0x00023267
		private void SetSupressButtonUpFlag(MouseButtons button)
		{
			this.m_SuppressButtonUpFlags |= button;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00025077 File Offset: 0x00023277
		private void InvokeMouseEventHandler(MouseEventHandler handler, MouseEventArgs e)
		{
			if (handler != null)
			{
				handler(this, e);
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00025084 File Offset: 0x00023284
		public void Dispose()
		{
			this.MouseDown = null;
			this.MouseUp = null;
			this.MouseMove = null;
			this.MouseWheel = null;
			this.MouseDoubleClick = null;
			this.Stop();
		}

		// Token: 0x040002BE RID: 702
		private Point m_PreviousPosition;

		// Token: 0x040002BF RID: 703
		private MouseButtons m_SuppressButtonUpFlags;

		// Token: 0x040002C0 RID: 704
		private readonly Hooker m_Hooker;
	}
}
