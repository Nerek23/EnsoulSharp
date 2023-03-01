using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000005 RID: 5
	public struct BlendStateDescription
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002188 File Offset: 0x00000388
		public static BlendStateDescription Default()
		{
			BlendStateDescription result = new BlendStateDescription
			{
				AlphaToCoverageEnable = false,
				IndependentBlendEnable = false
			};
			RenderTargetBlendDescription[] renderTarget = result.RenderTarget;
			for (int i = 0; i < renderTarget.Length; i++)
			{
				renderTarget[i].IsBlendEnabled = false;
				renderTarget[i].SourceBlend = BlendOption.One;
				renderTarget[i].DestinationBlend = BlendOption.Zero;
				renderTarget[i].BlendOperation = BlendOperation.Add;
				renderTarget[i].SourceAlphaBlend = BlendOption.One;
				renderTarget[i].DestinationAlphaBlend = BlendOption.Zero;
				renderTarget[i].AlphaBlendOperation = BlendOperation.Add;
				renderTarget[i].RenderTargetWriteMask = ColorWriteMaskFlags.All;
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002240 File Offset: 0x00000440
		public BlendStateDescription Clone()
		{
			BlendStateDescription result = new BlendStateDescription
			{
				AlphaToCoverageEnable = this.AlphaToCoverageEnable,
				IndependentBlendEnable = this.IndependentBlendEnable
			};
			RenderTargetBlendDescription[] renderTarget = this.RenderTarget;
			RenderTargetBlendDescription[] renderTarget2 = result.RenderTarget;
			for (int i = 0; i < renderTarget.Length; i++)
			{
				renderTarget2[i] = renderTarget[i];
			}
			return result;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022A4 File Offset: 0x000004A4
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000022CA File Offset: 0x000004CA
		public RenderTargetBlendDescription[] RenderTarget
		{
			get
			{
				RenderTargetBlendDescription[] result;
				if ((result = this._RenderTarget) == null)
				{
					result = (this._RenderTarget = new RenderTargetBlendDescription[8]);
				}
				return result;
			}
			private set
			{
				this._RenderTarget = value;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref BlendStateDescription.__Native @ref)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022D8 File Offset: 0x000004D8
		internal unsafe void __MarshalFrom(ref BlendStateDescription.__Native @ref)
		{
			this.AlphaToCoverageEnable = @ref.AlphaToCoverageEnable;
			this.IndependentBlendEnable = @ref.IndependentBlendEnable;
			fixed (RenderTargetBlendDescription* ptr = &this.RenderTarget[0])
			{
				void* value = (void*)ptr;
				fixed (RenderTargetBlendDescription* ptr2 = &@ref.RenderTarget)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 8 * sizeof(RenderTargetBlendDescription));
					ptr = null;
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002338 File Offset: 0x00000538
		internal unsafe void __MarshalTo(ref BlendStateDescription.__Native @ref)
		{
			@ref.AlphaToCoverageEnable = this.AlphaToCoverageEnable;
			@ref.IndependentBlendEnable = this.IndependentBlendEnable;
			fixed (RenderTargetBlendDescription* ptr = &this.RenderTarget[0])
			{
				void* value = (void*)ptr;
				fixed (RenderTargetBlendDescription* ptr2 = &@ref.RenderTarget)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 8 * sizeof(RenderTargetBlendDescription));
					ptr = null;
				}
			}
		}

		// Token: 0x04000001 RID: 1
		public RawBool AlphaToCoverageEnable;

		// Token: 0x04000002 RID: 2
		public RawBool IndependentBlendEnable;

		// Token: 0x04000003 RID: 3
		internal RenderTargetBlendDescription[] _RenderTarget;

		// Token: 0x02000006 RID: 6
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000004 RID: 4
			public RawBool AlphaToCoverageEnable;

			// Token: 0x04000005 RID: 5
			public RawBool IndependentBlendEnable;

			// Token: 0x04000006 RID: 6
			public RenderTargetBlendDescription RenderTarget;

			// Token: 0x04000007 RID: 7
			public RenderTargetBlendDescription __RenderTarget1;

			// Token: 0x04000008 RID: 8
			public RenderTargetBlendDescription __RenderTarget2;

			// Token: 0x04000009 RID: 9
			public RenderTargetBlendDescription __RenderTarget3;

			// Token: 0x0400000A RID: 10
			public RenderTargetBlendDescription __RenderTarget4;

			// Token: 0x0400000B RID: 11
			public RenderTargetBlendDescription __RenderTarget5;

			// Token: 0x0400000C RID: 12
			public RenderTargetBlendDescription __RenderTarget6;

			// Token: 0x0400000D RID: 13
			public RenderTargetBlendDescription __RenderTarget7;
		}
	}
}
