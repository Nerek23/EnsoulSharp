using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000007 RID: 7
	public struct BlendStateDescription1
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002398 File Offset: 0x00000598
		public static BlendStateDescription1 Default()
		{
			BlendStateDescription1 result = new BlendStateDescription1
			{
				AlphaToCoverageEnable = false,
				IndependentBlendEnable = false
			};
			RenderTargetBlendDescription1[] renderTarget = result.RenderTarget;
			for (int i = 0; i < renderTarget.Length; i++)
			{
				renderTarget[i].IsBlendEnabled = false;
				renderTarget[i].IsLogicOperationEnabled = false;
				renderTarget[i].SourceBlend = BlendOption.One;
				renderTarget[i].DestinationBlend = BlendOption.Zero;
				renderTarget[i].BlendOperation = BlendOperation.Add;
				renderTarget[i].SourceAlphaBlend = BlendOption.One;
				renderTarget[i].DestinationAlphaBlend = BlendOption.Zero;
				renderTarget[i].AlphaBlendOperation = BlendOperation.Add;
				renderTarget[i].RenderTargetWriteMask = ColorWriteMaskFlags.All;
				renderTarget[i].LogicOperation = LogicOperation.Noop;
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002474 File Offset: 0x00000674
		public BlendStateDescription1 Clone()
		{
			BlendStateDescription1 result = new BlendStateDescription1
			{
				AlphaToCoverageEnable = this.AlphaToCoverageEnable,
				IndependentBlendEnable = this.IndependentBlendEnable
			};
			RenderTargetBlendDescription1[] renderTarget = this.RenderTarget;
			RenderTargetBlendDescription1[] renderTarget2 = result.RenderTarget;
			for (int i = 0; i < renderTarget.Length; i++)
			{
				renderTarget2[i] = renderTarget[i];
			}
			return result;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000024D8 File Offset: 0x000006D8
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000024FE File Offset: 0x000006FE
		public RenderTargetBlendDescription1[] RenderTarget
		{
			get
			{
				RenderTargetBlendDescription1[] result;
				if ((result = this._RenderTarget) == null)
				{
					result = (this._RenderTarget = new RenderTargetBlendDescription1[8]);
				}
				return result;
			}
			private set
			{
				this._RenderTarget = value;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref BlendStateDescription1.__Native @ref)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002508 File Offset: 0x00000708
		internal unsafe void __MarshalFrom(ref BlendStateDescription1.__Native @ref)
		{
			this.AlphaToCoverageEnable = @ref.AlphaToCoverageEnable;
			this.IndependentBlendEnable = @ref.IndependentBlendEnable;
			fixed (RenderTargetBlendDescription1* ptr = &this.RenderTarget[0])
			{
				void* value = (void*)ptr;
				fixed (RenderTargetBlendDescription1* ptr2 = &@ref.RenderTarget)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 8 * sizeof(RenderTargetBlendDescription1));
					ptr = null;
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002568 File Offset: 0x00000768
		internal unsafe void __MarshalTo(ref BlendStateDescription1.__Native @ref)
		{
			@ref.AlphaToCoverageEnable = this.AlphaToCoverageEnable;
			@ref.IndependentBlendEnable = this.IndependentBlendEnable;
			fixed (RenderTargetBlendDescription1* ptr = &this.RenderTarget[0])
			{
				void* value = (void*)ptr;
				fixed (RenderTargetBlendDescription1* ptr2 = &@ref.RenderTarget)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 8 * sizeof(RenderTargetBlendDescription1));
					ptr = null;
				}
			}
		}

		// Token: 0x0400000E RID: 14
		public RawBool AlphaToCoverageEnable;

		// Token: 0x0400000F RID: 15
		public RawBool IndependentBlendEnable;

		// Token: 0x04000010 RID: 16
		internal RenderTargetBlendDescription1[] _RenderTarget;

		// Token: 0x02000008 RID: 8
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000011 RID: 17
			public RawBool AlphaToCoverageEnable;

			// Token: 0x04000012 RID: 18
			public RawBool IndependentBlendEnable;

			// Token: 0x04000013 RID: 19
			public RenderTargetBlendDescription1 RenderTarget;

			// Token: 0x04000014 RID: 20
			public RenderTargetBlendDescription1 __RenderTarget1;

			// Token: 0x04000015 RID: 21
			public RenderTargetBlendDescription1 __RenderTarget2;

			// Token: 0x04000016 RID: 22
			public RenderTargetBlendDescription1 __RenderTarget3;

			// Token: 0x04000017 RID: 23
			public RenderTargetBlendDescription1 __RenderTarget4;

			// Token: 0x04000018 RID: 24
			public RenderTargetBlendDescription1 __RenderTarget5;

			// Token: 0x04000019 RID: 25
			public RenderTargetBlendDescription1 __RenderTarget6;

			// Token: 0x0400001A RID: 26
			public RenderTargetBlendDescription1 __RenderTarget7;
		}
	}
}
