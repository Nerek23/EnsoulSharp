using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000342 RID: 834
	public class ColorManagement : Effect
	{
		// Token: 0x06000E39 RID: 3641 RVA: 0x00026E2D File Offset: 0x0002502D
		public ColorManagement(DeviceContext context) : base(context, Effect.ColorManagement)
		{
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00026E3B File Offset: 0x0002503B
		// (set) Token: 0x06000E3B RID: 3643 RVA: 0x00026E58 File Offset: 0x00025058
		public ColorContext SourceContext
		{
			get
			{
				if (this.sourceContext == null)
				{
					this.sourceContext = base.GetComObjectValue<ColorContext>(0);
				}
				return this.sourceContext;
			}
			set
			{
				this.sourceContext = value;
				base.SetValue<ColorContext>(0, this.sourceContext);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x00026E6E File Offset: 0x0002506E
		// (set) Token: 0x06000E3D RID: 3645 RVA: 0x00026E77 File Offset: 0x00025077
		public ColorManagementRenderingIntent SourceIntent
		{
			get
			{
				return base.GetEnumValue<ColorManagementRenderingIntent>(1);
			}
			set
			{
				base.SetEnumValue<ColorManagementRenderingIntent>(1, value);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00026E81 File Offset: 0x00025081
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x00026E9E File Offset: 0x0002509E
		public ColorContext DestinationContext
		{
			get
			{
				if (this.destinationContext == null)
				{
					this.destinationContext = base.GetComObjectValue<ColorContext>(2);
				}
				return this.destinationContext;
			}
			set
			{
				this.destinationContext = value;
				base.SetValue<ColorContext>(2, this.destinationContext);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00026EB4 File Offset: 0x000250B4
		// (set) Token: 0x06000E41 RID: 3649 RVA: 0x00026EBD File Offset: 0x000250BD
		public ColorManagementRenderingIntent DestinationIntent
		{
			get
			{
				return base.GetEnumValue<ColorManagementRenderingIntent>(3);
			}
			set
			{
				base.SetEnumValue<ColorManagementRenderingIntent>(3, value);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00026EC7 File Offset: 0x000250C7
		// (set) Token: 0x06000E43 RID: 3651 RVA: 0x00026ED0 File Offset: 0x000250D0
		public ColorManagementAlphaMode AlphaMode
		{
			get
			{
				return base.GetEnumValue<ColorManagementAlphaMode>(4);
			}
			set
			{
				base.SetEnumValue<ColorManagementAlphaMode>(4, value);
			}
		}

		// Token: 0x04000B35 RID: 2869
		private ColorContext sourceContext;

		// Token: 0x04000B36 RID: 2870
		private ColorContext destinationContext;
	}
}
