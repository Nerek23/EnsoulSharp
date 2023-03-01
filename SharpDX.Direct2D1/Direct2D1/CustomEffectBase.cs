using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001B1 RID: 433
	public abstract class CustomEffectBase : CallbackBase, CustomEffect, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000853 RID: 2131 RVA: 0x00009E0F File Offset: 0x0000800F
		public virtual void Initialize(EffectContext effectContext, TransformGraph transformGraph)
		{
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00009E0F File Offset: 0x0000800F
		public virtual void PrepareForRender(ChangeType changeType)
		{
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00009E0F File Offset: 0x0000800F
		public virtual void SetGraph(TransformGraph transformGraph)
		{
		}
	}
}
