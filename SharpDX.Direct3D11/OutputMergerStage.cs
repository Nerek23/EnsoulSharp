using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001E RID: 30
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class OutputMergerStage : CppObject
	{
		// Token: 0x06000183 RID: 387 RVA: 0x00007308 File Offset: 0x00005508
		public void GetRenderTargets(out DepthStencilView depthStencilViewRef)
		{
			this.GetRenderTargets(0, new RenderTargetView[0], out depthStencilViewRef);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00007318 File Offset: 0x00005518
		public RenderTargetView[] GetRenderTargets(int numViews)
		{
			RenderTargetView[] array = new RenderTargetView[numViews];
			DepthStencilView depthStencilView;
			this.GetRenderTargets(numViews, array, out depthStencilView);
			if (depthStencilView != null)
			{
				depthStencilView.Dispose();
			}
			return array;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00007340 File Offset: 0x00005540
		public RenderTargetView[] GetRenderTargets(int numViews, out DepthStencilView depthStencilViewRef)
		{
			RenderTargetView[] array = new RenderTargetView[numViews];
			this.GetRenderTargets(numViews, array, out depthStencilViewRef);
			return array;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00007360 File Offset: 0x00005560
		public BlendState GetBlendState(out RawColor4 blendFactor, out int sampleMaskRef)
		{
			BlendState result;
			this.GetBlendState(out result, out blendFactor, out sampleMaskRef);
			return result;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00007378 File Offset: 0x00005578
		public DepthStencilState GetDepthStencilState(out int stencilRefRef)
		{
			DepthStencilState result;
			this.GetDepthStencilState(out result, out stencilRefRef);
			return result;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00007390 File Offset: 0x00005590
		public UnorderedAccessView[] GetUnorderedAccessViews(int startSlot, int count)
		{
			UnorderedAccessView[] array = new UnorderedAccessView[count];
			DepthStencilView depthStencilView;
			this.GetRenderTargetsAndUnorderedAccessViews(0, new RenderTargetView[0], out depthStencilView, startSlot, count, array);
			depthStencilView.Dispose();
			return array;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000073BD File Offset: 0x000055BD
		public void ResetTargets()
		{
			this.SetRenderTargets(0, IntPtr.Zero, null);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000073CC File Offset: 0x000055CC
		public void SetTargets(params RenderTargetView[] renderTargetViews)
		{
			this.SetTargets(null, renderTargetViews);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000073D6 File Offset: 0x000055D6
		public void SetTargets(RenderTargetView renderTargetView)
		{
			this.SetTargets(null, renderTargetView);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000073E0 File Offset: 0x000055E0
		public void SetTargets(DepthStencilView depthStencilView, params RenderTargetView[] renderTargetViews)
		{
			this.SetRenderTargets((renderTargetViews == null) ? 0 : renderTargetViews.Length, renderTargetViews, depthStencilView);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000073F3 File Offset: 0x000055F3
		public void SetTargets(DepthStencilView depthStencilView, int renderTargetCount, RenderTargetView[] renderTargetViews)
		{
			this.SetRenderTargets(renderTargetCount, renderTargetViews, depthStencilView);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00007400 File Offset: 0x00005600
		public unsafe void SetTargets(DepthStencilView depthStencilView, RenderTargetView renderTargetView)
		{
			IntPtr intPtr = (renderTargetView == null) ? IntPtr.Zero : renderTargetView.NativePointer;
			this.SetRenderTargets(1, new IntPtr((void*)(&intPtr)), depthStencilView);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000742E File Offset: 0x0000562E
		public void SetTargets(DepthStencilView depthStencilView, ComArray<RenderTargetView> renderTargetViews)
		{
			this.SetRenderTargets((renderTargetViews == null) ? 0 : renderTargetViews.Length, (renderTargetViews == null) ? IntPtr.Zero : renderTargetViews.NativePointer, depthStencilView);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007453 File Offset: 0x00005653
		public void SetTargets(ComArray<RenderTargetView> renderTargetViews)
		{
			this.SetRenderTargets((renderTargetViews == null) ? 0 : renderTargetViews.Length, (renderTargetViews == null) ? IntPtr.Zero : renderTargetViews.NativePointer, null);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007478 File Offset: 0x00005678
		public void SetTargets(RenderTargetView renderTargetView, int startSlot, UnorderedAccessView[] unorderedAccessViews)
		{
			this.SetTargets(startSlot, unorderedAccessViews, new RenderTargetView[]
			{
				renderTargetView
			});
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000748C File Offset: 0x0000568C
		public void SetTargets(int startSlot, UnorderedAccessView[] unorderedAccessViews, params RenderTargetView[] renderTargetViews)
		{
			this.SetTargets(null, startSlot, unorderedAccessViews, renderTargetViews);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00007498 File Offset: 0x00005698
		public void SetTargets(DepthStencilView depthStencilView, RenderTargetView renderTargetView, int startSlot, UnorderedAccessView[] unorderedAccessViews)
		{
			this.SetTargets(depthStencilView, startSlot, unorderedAccessViews, new RenderTargetView[]
			{
				renderTargetView
			});
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000074B0 File Offset: 0x000056B0
		public void SetTargets(DepthStencilView depthStencilView, int startSlot, UnorderedAccessView[] unorderedAccessViews, params RenderTargetView[] renderTargetViews)
		{
			int[] array = new int[unorderedAccessViews.Length];
			for (int i = 0; i < unorderedAccessViews.Length; i++)
			{
				array[i] = -1;
			}
			this.SetTargets(depthStencilView, startSlot, unorderedAccessViews, array, renderTargetViews);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000074E4 File Offset: 0x000056E4
		public void SetTargets(RenderTargetView renderTargetView, int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] initialLengths)
		{
			this.SetTargets(startSlot, unorderedAccessViews, initialLengths, new RenderTargetView[]
			{
				renderTargetView
			});
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000074FA File Offset: 0x000056FA
		public void SetTargets(int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] initialLengths, params RenderTargetView[] renderTargetViews)
		{
			this.SetTargets(null, startSlot, unorderedAccessViews, initialLengths, renderTargetViews);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007508 File Offset: 0x00005708
		public void SetTargets(DepthStencilView depthStencilView, RenderTargetView renderTargetView, int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] initialLengths)
		{
			this.SetTargets(depthStencilView, startSlot, unorderedAccessViews, initialLengths, new RenderTargetView[]
			{
				renderTargetView
			});
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000752B File Offset: 0x0000572B
		public void SetTargets(DepthStencilView depthStencilView, int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] initialLengths, params RenderTargetView[] renderTargetViews)
		{
			this.SetRenderTargetsAndUnorderedAccessViews(renderTargetViews.Length, renderTargetViews, depthStencilView, startSlot, unorderedAccessViews.Length, unorderedAccessViews, initialLengths);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007544 File Offset: 0x00005744
		private unsafe void SetRenderTargets(int numViews, RenderTargetView[] renderTargetViews, DepthStencilView depthStencilViewRef)
		{
			IntPtr* ptr = null;
			if (numViews > 0)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)numViews) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < numViews; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((renderTargetViews[i] == null) ? IntPtr.Zero : renderTargetViews[i].NativePointer);
				}
			}
			this.SetRenderTargets(numViews, (IntPtr)((void*)ptr), depthStencilViewRef);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000075A0 File Offset: 0x000057A0
		public unsafe void SetRenderTargets(DepthStencilView depthStencilView, RenderTargetView renderTargetView)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (renderTargetView != null)
			{
				intPtr = renderTargetView.NativePointer;
			}
			this.SetRenderTargetsAndKeepUAV(1, new IntPtr((void*)(&intPtr)), depthStencilView);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000075CD File Offset: 0x000057CD
		public void SetRenderTargets(RenderTargetView renderTargetView)
		{
			this.SetRenderTargets(null, renderTargetView);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000075D8 File Offset: 0x000057D8
		public unsafe void SetRenderTargets(DepthStencilView depthStencilView, params RenderTargetView[] renderTargetViews)
		{
			IntPtr* ptr = null;
			int numRTVs = 0;
			if (renderTargetViews != null)
			{
				numRTVs = renderTargetViews.Length;
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)renderTargetViews.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < renderTargetViews.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((renderTargetViews[i] == null) ? IntPtr.Zero : renderTargetViews[i].NativePointer);
				}
			}
			this.SetRenderTargetsAndKeepUAV(numRTVs, new IntPtr((void*)ptr), depthStencilView);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000763B File Offset: 0x0000583B
		public void SetUnorderedAccessView(int startSlot, UnorderedAccessView unorderedAccessView)
		{
			this.SetUnorderedAccessView(startSlot, unorderedAccessView, -1);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00007646 File Offset: 0x00005846
		public void SetUnorderedAccessView(int startSlot, UnorderedAccessView unorderedAccessView, int uavInitialCount)
		{
			this.SetUnorderedAccessViews(startSlot, new UnorderedAccessView[]
			{
				unorderedAccessView
			}, new int[]
			{
				uavInitialCount
			});
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007664 File Offset: 0x00005864
		public void SetUnorderedAccessViews(int startSlot, params UnorderedAccessView[] unorderedAccessViews)
		{
			int[] array = new int[unorderedAccessViews.Length];
			for (int i = 0; i < unorderedAccessViews.Length; i++)
			{
				array[i] = -1;
			}
			this.SetUnorderedAccessViews(startSlot, unorderedAccessViews, array);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00007698 File Offset: 0x00005898
		public unsafe void SetUnorderedAccessViews(int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] uavInitialCounts)
		{
			IntPtr* ptr = null;
			if (unorderedAccessViews != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)unorderedAccessViews.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < unorderedAccessViews.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((unorderedAccessViews[i] == null) ? IntPtr.Zero : unorderedAccessViews[i].NativePointer);
				}
			}
			fixed (int[] array = uavInitialCounts)
			{
				void* value;
				if (uavInitialCounts == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetUnorderedAccessViewsKeepRTV(startSlot, (unorderedAccessViews != null) ? unorderedAccessViews.Length : 0, (IntPtr)((void*)ptr), (IntPtr)value);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00007720 File Offset: 0x00005920
		internal unsafe void SetRenderTargetsAndUnorderedAccessViews(int numRTVs, RenderTargetView[] renderTargetViewsOut, DepthStencilView depthStencilViewRef, int uAVStartSlot, int numUAVs, UnorderedAccessView[] unorderedAccessViewsOut, int[] uAVInitialCountsRef)
		{
			IntPtr* ptr = null;
			if (renderTargetViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)renderTargetViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < renderTargetViewsOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((renderTargetViewsOut[i] == null) ? IntPtr.Zero : renderTargetViewsOut[i].NativePointer);
				}
			}
			IntPtr* ptr2 = null;
			if (unorderedAccessViewsOut != null)
			{
				ptr2 = stackalloc IntPtr[checked(unchecked((UIntPtr)unorderedAccessViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int j = 0; j < unorderedAccessViewsOut.Length; j++)
				{
					ptr2[(IntPtr)j * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((unorderedAccessViewsOut[j] == null) ? IntPtr.Zero : unorderedAccessViewsOut[j].NativePointer);
				}
			}
			fixed (int[] array = uAVInitialCountsRef)
			{
				void* value;
				if (uAVInitialCountsRef == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetRenderTargetsAndUnorderedAccessViews(numRTVs, (IntPtr)((void*)ptr), depthStencilViewRef, uAVStartSlot, numUAVs, (IntPtr)((void*)ptr2), (IntPtr)value);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000077F8 File Offset: 0x000059F8
		internal unsafe void SetRenderTargetsAndUnorderedAccessViews(int numRTVs, ComArray<RenderTargetView> renderTargetViewsOut, DepthStencilView depthStencilViewRef, int uAVStartSlot, int numUAVs, ComArray<UnorderedAccessView> unorderedAccessViewsOut, int[] uAVInitialCountsRef)
		{
			fixed (int[] array = uAVInitialCountsRef)
			{
				void* value;
				if (uAVInitialCountsRef == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetRenderTargetsAndUnorderedAccessViews(numRTVs, (renderTargetViewsOut == null) ? IntPtr.Zero : renderTargetViewsOut.NativePointer, depthStencilViewRef, uAVStartSlot, numUAVs, (unorderedAccessViewsOut == null) ? IntPtr.Zero : unorderedAccessViewsOut.NativePointer, (IntPtr)value);
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00007854 File Offset: 0x00005A54
		internal void SetRenderTargetsAndKeepUAV(int numRTVs, IntPtr rtvs, DepthStencilView depthStencilViewRef)
		{
			this.SetRenderTargetsAndUnorderedAccessViews(numRTVs, rtvs, depthStencilViewRef, 0, -1, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000786B File Offset: 0x00005A6B
		internal void SetUnorderedAccessViewsKeepRTV(int startSlot, int numBuffers, IntPtr unorderedAccessBuffer, IntPtr uavCount)
		{
			this.SetRenderTargetsAndUnorderedAccessViews(-1, IntPtr.Zero, null, startSlot, numBuffers, unorderedAccessBuffer, uavCount);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000787F File Offset: 0x00005A7F
		public void SetBlendState(BlendState blendStateRef, RawColor4? blendFactor, uint sampleMask)
		{
			this.SetBlendState(blendStateRef, blendFactor, (int)sampleMask);
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000788C File Offset: 0x00005A8C
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x000078B0 File Offset: 0x00005AB0
		public RawColor4 BlendFactor
		{
			get
			{
				BlendState blendState;
				RawColor4 result;
				int num;
				this.GetBlendState(out blendState, out result, out num);
				if (blendState != null)
				{
					blendState.Dispose();
				}
				return result;
			}
			set
			{
				BlendState blendState;
				RawColor4 rawColor;
				int sampleMask;
				this.GetBlendState(out blendState, out rawColor, out sampleMask);
				this.SetBlendState(blendState, new RawColor4?(value), sampleMask);
				if (blendState != null)
				{
					blendState.Dispose();
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000078E0 File Offset: 0x00005AE0
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00007904 File Offset: 0x00005B04
		public int BlendSampleMask
		{
			get
			{
				BlendState blendState;
				RawColor4 rawColor;
				int result;
				this.GetBlendState(out blendState, out rawColor, out result);
				if (blendState != null)
				{
					blendState.Dispose();
				}
				return result;
			}
			set
			{
				BlendState blendState;
				RawColor4 value2;
				int num;
				this.GetBlendState(out blendState, out value2, out num);
				this.SetBlendState(blendState, new RawColor4?(value2), value);
				if (blendState != null)
				{
					blendState.Dispose();
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00007934 File Offset: 0x00005B34
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00007950 File Offset: 0x00005B50
		public BlendState BlendState
		{
			get
			{
				BlendState result;
				RawColor4 rawColor;
				int num;
				this.GetBlendState(out result, out rawColor, out num);
				return result;
			}
			set
			{
				BlendState blendState;
				RawColor4 value2;
				int sampleMask;
				this.GetBlendState(out blendState, out value2, out sampleMask);
				if (blendState != null)
				{
					blendState.Dispose();
				}
				this.SetBlendState(value, new RawColor4?(value2), sampleMask);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00007980 File Offset: 0x00005B80
		// (set) Token: 0x060001AD RID: 429 RVA: 0x000079A4 File Offset: 0x00005BA4
		public int DepthStencilReference
		{
			get
			{
				DepthStencilState depthStencilState;
				int result;
				this.GetDepthStencilState(out depthStencilState, out result);
				if (depthStencilState != null)
				{
					depthStencilState.Dispose();
				}
				return result;
			}
			set
			{
				DepthStencilState depthStencilState;
				int num;
				this.GetDepthStencilState(out depthStencilState, out num);
				this.SetDepthStencilState(depthStencilState, value);
				if (depthStencilState != null)
				{
					depthStencilState.Dispose();
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000079CC File Offset: 0x00005BCC
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000079E4 File Offset: 0x00005BE4
		public DepthStencilState DepthStencilState
		{
			get
			{
				DepthStencilState result;
				int num;
				this.GetDepthStencilState(out result, out num);
				return result;
			}
			set
			{
				DepthStencilState depthStencilState;
				int stencilRef;
				this.GetDepthStencilState(out depthStencilState, out stencilRef);
				if (depthStencilState != null)
				{
					depthStencilState.Dispose();
				}
				this.SetDepthStencilState(value, stencilRef);
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000543D File Offset: 0x0000363D
		public OutputMergerStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00007A0C File Offset: 0x00005C0C
		public static explicit operator OutputMergerStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new OutputMergerStage(nativePtr);
			}
			return null;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00007A24 File Offset: 0x00005C24
		internal unsafe void SetRenderTargets(int numViews, IntPtr renderTargetViewsOut, DepthStencilView depthStencilViewRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DepthStencilView>(depthStencilViewRef);
			calli(System.Void(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numViews, (void*)renderTargetViewsOut, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00007A6C File Offset: 0x00005C6C
		internal unsafe void SetRenderTargetsAndUnorderedAccessViews(int numRTVs, IntPtr renderTargetViewsOut, DepthStencilView depthStencilViewRef, int uAVStartSlot, int numUAVs, IntPtr unorderedAccessViewsOut, IntPtr uAVInitialCountsRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DepthStencilView>(depthStencilViewRef);
			calli(System.Void(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, numRTVs, (void*)renderTargetViewsOut, (void*)value, uAVStartSlot, numUAVs, (void*)unorderedAccessViewsOut, (void*)uAVInitialCountsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00007AC4 File Offset: 0x00005CC4
		public unsafe void SetBlendState(BlendState blendStateRef, RawColor4? blendFactor = null, int sampleMask = -1)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BlendState>(blendStateRef);
			RawColor4 value2;
			if (blendFactor != null)
			{
				value2 = blendFactor.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (blendFactor == null) ? null : (&value2), sampleMask, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007B24 File Offset: 0x00005D24
		public unsafe void SetDepthStencilState(DepthStencilState depthStencilStateRef, int stencilRef = 0)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DepthStencilState>(depthStencilStateRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, stencilRef, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00007B64 File Offset: 0x00005D64
		internal unsafe void GetRenderTargets(int numViews, RenderTargetView[] renderTargetViewsOut, out DepthStencilView depthStencilViewOut)
		{
			IntPtr* ptr = null;
			if (renderTargetViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)renderTargetViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numViews, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)89 * (IntPtr)sizeof(void*)));
			if (renderTargetViewsOut != null)
			{
				for (int i = 0; i < renderTargetViewsOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						renderTargetViewsOut[i] = new RenderTargetView(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						renderTargetViewsOut[i] = null;
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				depthStencilViewOut = new DepthStencilView(zero);
				return;
			}
			depthStencilViewOut = null;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00007C0C File Offset: 0x00005E0C
		internal unsafe void GetRenderTargetsAndUnorderedAccessViews(int numRTVs, RenderTargetView[] renderTargetViewsOut, out DepthStencilView depthStencilViewOut, int uAVStartSlot, int numUAVs, UnorderedAccessView[] unorderedAccessViewsOut)
		{
			IntPtr* ptr = null;
			IntPtr zero;
			IntPtr* ptr2;
			checked
			{
				if (renderTargetViewsOut != null)
				{
					ptr = stackalloc IntPtr[unchecked((UIntPtr)renderTargetViewsOut.Length) * (UIntPtr)sizeof(IntPtr)];
				}
				zero = IntPtr.Zero;
				ptr2 = null;
				if (unorderedAccessViewsOut != null)
				{
					ptr2 = stackalloc IntPtr[unchecked((UIntPtr)unorderedAccessViewsOut.Length) * (UIntPtr)sizeof(IntPtr)];
				}
			}
			calli(System.Void(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, numRTVs, ptr, &zero, uAVStartSlot, numUAVs, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)90 * (IntPtr)sizeof(void*)));
			if (renderTargetViewsOut != null)
			{
				for (int i = 0; i < renderTargetViewsOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						renderTargetViewsOut[i] = new RenderTargetView(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						renderTargetViewsOut[i] = null;
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				depthStencilViewOut = new DepthStencilView(zero);
			}
			else
			{
				depthStencilViewOut = null;
			}
			if (unorderedAccessViewsOut != null)
			{
				for (int j = 0; j < unorderedAccessViewsOut.Length; j++)
				{
					if (ptr2[(IntPtr)j * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						unorderedAccessViewsOut[j] = new UnorderedAccessView(ptr2[(IntPtr)j * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						unorderedAccessViewsOut[j] = null;
					}
				}
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00007D20 File Offset: 0x00005F20
		internal unsafe void GetBlendState(out BlendState blendStateOut, out RawColor4 blendFactor, out int sampleMaskRef)
		{
			IntPtr zero = IntPtr.Zero;
			blendFactor = default(RawColor4);
			fixed (int* ptr = &sampleMaskRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawColor4* ptr3 = &blendFactor)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)91 * (IntPtr)sizeof(void*)));
				}
			}
			if (zero != IntPtr.Zero)
			{
				blendStateOut = new BlendState(zero);
				return;
			}
			blendStateOut = null;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00007D8C File Offset: 0x00005F8C
		internal unsafe void GetDepthStencilState(out DepthStencilState depthStencilStateOut, out int stencilRefRef)
		{
			IntPtr zero = IntPtr.Zero;
			fixed (int* ptr = &stencilRefRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)92 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				depthStencilStateOut = new DepthStencilState(zero);
				return;
			}
			depthStencilStateOut = null;
		}

		// Token: 0x04000085 RID: 133
		public const int SimultaneousRenderTargetCount = 8;
	}
}
