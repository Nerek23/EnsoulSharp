using System;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using SharpDX.DXGI;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001F RID: 31
	public static class Render
	{
		// Token: 0x06000147 RID: 327 RVA: 0x000093F4 File Offset: 0x000075F4
		static Render()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				Render.D3D9Sprite = new Sprite(Render.D3D9Device);
				Drawing.OnDraw += Render.OnD3D9Draw;
				Drawing.OnFlushDraw += Render.OnD3D9FlushDraw;
				Drawing.OnBeginScene += Render.OnD3D9BeginScene;
				Drawing.OnEndScene += Render.OnD3D9EndScene;
				Drawing.OnPresent += Render.OnD3D9Present;
				Drawing.OnPreReset += Render.OnD3D9PreReset;
				Drawing.OnPostReset += Render.OnD3D9PostReset;
			}
			else
			{
				Render.D2DFactory = new SharpDX.Direct2D1.Factory();
				Render.BackBuffer = Drawing.SwapChain.GetBackBuffer<Texture2D>(0);
				Render.Surface = Render.BackBuffer.QueryInterface<SharpDX.DXGI.Surface>();
				Render.D3D11RenderTarget = new RenderTarget(Render.D2DFactory, Render.Surface, new RenderTargetProperties(new PixelFormat(SharpDX.DXGI.Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));
				Render.DirectWriteFactory = new SharpDX.DirectWrite.Factory();
				Drawing.OnDraw += Render.OnD3D11Draw;
				Drawing.OnFlushDraw += Render.OnD3D11FlushDraw;
				Drawing.OnD3D11Present += Render.OnD3D11Present;
				Drawing.OnD3D11PreResizeBuffers += Render.OnD3D11PreReset;
				Drawing.OnD3D11PostResizeBuffers += Render.OnD3D11PostReset;
			}
			Drawing.OnRenderMouseOvers += Render.OnD3DRenderMouseOvers;
			AppDomain.CurrentDomain.DomainUnload += Render.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += Render.OnDispose;
			Logging.Write(false, true, ".cctor")(LogLevel.Info, Render.Platform + " event load successful.", Array.Empty<object>());
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000148 RID: 328 RVA: 0x000095B0 File Offset: 0x000077B0
		public static SharpDX.Direct3D9.Device D3D9Device
		{
			get
			{
				return Drawing.Direct3DDevice9;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000149 RID: 329 RVA: 0x000095B7 File Offset: 0x000077B7
		// (set) Token: 0x0600014A RID: 330 RVA: 0x000095BE File Offset: 0x000077BE
		public static Sprite D3D9Sprite { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000095C6 File Offset: 0x000077C6
		public static SharpDX.Direct3D11.Device D3D11Device
		{
			get
			{
				return Drawing.Direct3DDevice11;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600014C RID: 332 RVA: 0x000095CD File Offset: 0x000077CD
		// (set) Token: 0x0600014D RID: 333 RVA: 0x000095D4 File Offset: 0x000077D4
		public static RenderTarget D3D11RenderTarget { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600014E RID: 334 RVA: 0x000095DC File Offset: 0x000077DC
		// (set) Token: 0x0600014F RID: 335 RVA: 0x000095E3 File Offset: 0x000077E3
		public static SharpDX.Direct2D1.Factory D2DFactory { get; private set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000095EB File Offset: 0x000077EB
		// (set) Token: 0x06000151 RID: 337 RVA: 0x000095F2 File Offset: 0x000077F2
		public static SharpDX.DXGI.Surface Surface { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000095FA File Offset: 0x000077FA
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00009601 File Offset: 0x00007801
		public static Texture2D BackBuffer { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00009609 File Offset: 0x00007809
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00009610 File Offset: 0x00007810
		public static SharpDX.DirectWrite.Factory DirectWriteFactory { get; private set; }

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000156 RID: 342 RVA: 0x00009618 File Offset: 0x00007818
		// (remove) Token: 0x06000157 RID: 343 RVA: 0x0000964C File Offset: 0x0000784C
		public static event Render.OnDrawNativeDelegate OnDraw;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000158 RID: 344 RVA: 0x00009680 File Offset: 0x00007880
		// (remove) Token: 0x06000159 RID: 345 RVA: 0x000096B4 File Offset: 0x000078B4
		public static event Render.OnBeginSceneNativeDelegate OnBeginScene;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600015A RID: 346 RVA: 0x000096E8 File Offset: 0x000078E8
		// (remove) Token: 0x0600015B RID: 347 RVA: 0x0000971C File Offset: 0x0000791C
		public static event Render.OnEndSceneNativeDelegate OnEndScene;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600015C RID: 348 RVA: 0x00009750 File Offset: 0x00007950
		// (remove) Token: 0x0600015D RID: 349 RVA: 0x00009784 File Offset: 0x00007984
		public static event Render.OnPresentNativeDelegate OnPresent;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600015E RID: 350 RVA: 0x000097B8 File Offset: 0x000079B8
		// (remove) Token: 0x0600015F RID: 351 RVA: 0x000097EC File Offset: 0x000079EC
		public static event Render.OnPreResetNativeDelegate OnPreReset;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000160 RID: 352 RVA: 0x00009820 File Offset: 0x00007A20
		// (remove) Token: 0x06000161 RID: 353 RVA: 0x00009854 File Offset: 0x00007A54
		public static event Render.OnPostResetNativeDelegate OnPostReset;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000162 RID: 354 RVA: 0x00009888 File Offset: 0x00007A88
		// (remove) Token: 0x06000163 RID: 355 RVA: 0x000098BC File Offset: 0x00007ABC
		public static event Render.OnRenderMouseOversNativeDelegate OnRenderMouseOvers;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000164 RID: 356 RVA: 0x000098F0 File Offset: 0x00007AF0
		// (remove) Token: 0x06000165 RID: 357 RVA: 0x00009924 File Offset: 0x00007B24
		public static event Render.OnFlushDrawDelegate OnFlushDraw;

		// Token: 0x06000166 RID: 358 RVA: 0x00009957 File Offset: 0x00007B57
		private static void OnD3D9Draw(EventArgs args)
		{
			Render.OnDrawNativeDelegate onDraw = Render.OnDraw;
			if (onDraw == null)
			{
				return;
			}
			onDraw(args);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00009969 File Offset: 0x00007B69
		private static void OnD3D9FlushDraw(EventArgs args)
		{
			Render.OnFlushDrawDelegate onFlushDraw = Render.OnFlushDraw;
			if (onFlushDraw == null)
			{
				return;
			}
			onFlushDraw(args);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000997B File Offset: 0x00007B7B
		private static void OnD3D9BeginScene(EventArgs args)
		{
			Render.OnBeginSceneNativeDelegate onBeginScene = Render.OnBeginScene;
			if (onBeginScene == null)
			{
				return;
			}
			onBeginScene(args);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000998D File Offset: 0x00007B8D
		private static void OnD3D9EndScene(EventArgs args)
		{
			if (Render.D3D9Device == null || Render.D3D9Device.IsDisposed)
			{
				return;
			}
			Render.D3D9Device.SetRenderState(RenderState.AlphaBlendEnable, true);
			Render.OnEndSceneNativeDelegate onEndScene = Render.OnEndScene;
			if (onEndScene == null)
			{
				return;
			}
			onEndScene(args);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000099C0 File Offset: 0x00007BC0
		private static void OnD3D9Present(EventArgs args)
		{
			Render.OnPresentNativeDelegate onPresent = Render.OnPresent;
			if (onPresent == null)
			{
				return;
			}
			onPresent(args);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000099D2 File Offset: 0x00007BD2
		private static void OnD3D9PreReset(EventArgs args)
		{
			if (Render.D3D9Sprite != null && Render.D3D9Sprite.IsDisposed)
			{
				Render.D3D9Sprite.OnLostDevice();
			}
			Render.OnPreResetNativeDelegate onPreReset = Render.OnPreReset;
			if (onPreReset == null)
			{
				return;
			}
			onPreReset(args);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00009A01 File Offset: 0x00007C01
		private static void OnD3D9PostReset(EventArgs args)
		{
			if (Render.D3D9Sprite != null && Render.D3D9Sprite.IsDisposed)
			{
				Render.D3D9Sprite.OnResetDevice();
			}
			Render.OnPostResetNativeDelegate onPostReset = Render.OnPostReset;
			if (onPostReset == null)
			{
				return;
			}
			onPostReset(args);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00009A30 File Offset: 0x00007C30
		private static void OnD3D11Draw(EventArgs args)
		{
			if (Render.OnDraw != null)
			{
				Render.D3D11RenderTarget.BeginDraw();
				Render.OnDraw(args);
				Render.D3D11RenderTarget.EndDraw();
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00009A58 File Offset: 0x00007C58
		private static void OnD3D11FlushDraw(EventArgs args)
		{
			if (Render.OnFlushDraw != null)
			{
				Render.D3D11RenderTarget.BeginDraw();
				Render.OnFlushDraw(args);
				Render.D3D11RenderTarget.EndDraw();
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00009A80 File Offset: 0x00007C80
		private static void OnD3D11Present(EventArgs args)
		{
			if (Render.OnEndScene != null)
			{
				Render.D3D11RenderTarget.BeginDraw();
				Render.OnEndScene(args);
				Render.D3D11RenderTarget.EndDraw();
			}
			if (Render.OnPresent != null)
			{
				Render.D3D11RenderTarget.BeginDraw();
				Render.OnPresent(args);
				Render.D3D11RenderTarget.EndDraw();
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00009ADC File Offset: 0x00007CDC
		private static void OnD3D11PreReset(EventArgs args)
		{
			if (Render.BackBuffer != null && !Render.BackBuffer.IsDisposed)
			{
				Render.BackBuffer.Dispose();
				Render.BackBuffer = null;
			}
			if (Render.Surface != null && !Render.Surface.IsDisposed)
			{
				Render.Surface.Dispose();
				Render.Surface = null;
			}
			if (Render.D3D11RenderTarget != null && !Render.D3D11RenderTarget.IsDisposed)
			{
				Render.D3D11RenderTarget.Dispose();
				Render.D3D11RenderTarget = null;
			}
			Render.OnPreResetNativeDelegate onPreReset = Render.OnPreReset;
			if (onPreReset == null)
			{
				return;
			}
			onPreReset(args);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00009B62 File Offset: 0x00007D62
		private static void OnD3D11PostReset(EventArgs args)
		{
			Render.OnPostResetNativeDelegate onPostReset = Render.OnPostReset;
			if (onPostReset == null)
			{
				return;
			}
			onPostReset(args);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00009B74 File Offset: 0x00007D74
		private static void OnD3DRenderMouseOvers(EventArgs args)
		{
			Render.OnRenderMouseOversNativeDelegate onRenderMouseOvers = Render.OnRenderMouseOvers;
			if (onRenderMouseOvers == null)
			{
				return;
			}
			onRenderMouseOvers(args);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00009B88 File Offset: 0x00007D88
		private static void OnDispose(object sender, EventArgs args)
		{
			if (Drawing.Platform == X3DPlatform.Direct3D9)
			{
				if (Render.D3D9Sprite != null && !Render.D3D9Sprite.IsDisposed)
				{
					Render.D3D9Sprite.Dispose();
					Render.D3D9Sprite = null;
					return;
				}
			}
			else
			{
				if (Render.D2DFactory != null && !Render.D2DFactory.IsDisposed)
				{
					Render.D2DFactory.Dispose();
					Render.D2DFactory = null;
				}
				if (Render.DirectWriteFactory != null && !Render.DirectWriteFactory.IsDisposed)
				{
					Render.DirectWriteFactory.Dispose();
					Render.DirectWriteFactory = null;
				}
				BrushCache.OnDispose();
			}
		}

		// Token: 0x0400009F RID: 159
		public static X3DPlatform Platform = Drawing.Platform;

		// Token: 0x0200043F RID: 1087
		// (Invoke) Token: 0x0600142E RID: 5166
		public delegate void OnDrawNativeDelegate(EventArgs args);

		// Token: 0x02000440 RID: 1088
		// (Invoke) Token: 0x06001432 RID: 5170
		public delegate void OnBeginSceneNativeDelegate(EventArgs args);

		// Token: 0x02000441 RID: 1089
		// (Invoke) Token: 0x06001436 RID: 5174
		public delegate void OnEndSceneNativeDelegate(EventArgs args);

		// Token: 0x02000442 RID: 1090
		// (Invoke) Token: 0x0600143A RID: 5178
		public delegate void OnPresentNativeDelegate(EventArgs args);

		// Token: 0x02000443 RID: 1091
		// (Invoke) Token: 0x0600143E RID: 5182
		public delegate void OnPreResetNativeDelegate(EventArgs args);

		// Token: 0x02000444 RID: 1092
		// (Invoke) Token: 0x06001442 RID: 5186
		public delegate void OnPostResetNativeDelegate(EventArgs args);

		// Token: 0x02000445 RID: 1093
		// (Invoke) Token: 0x06001446 RID: 5190
		public delegate void OnRenderMouseOversNativeDelegate(EventArgs args);

		// Token: 0x02000446 RID: 1094
		// (Invoke) Token: 0x0600144A RID: 5194
		public delegate void OnFlushDrawDelegate(EventArgs args);
	}
}
