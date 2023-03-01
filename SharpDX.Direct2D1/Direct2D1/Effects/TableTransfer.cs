using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000360 RID: 864
	public class TableTransfer : Effect
	{
		// Token: 0x06000F7A RID: 3962 RVA: 0x0002762D File Offset: 0x0002582D
		public TableTransfer(DeviceContext context) : base(context, Effect.TableTransfer)
		{
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000F7B RID: 3963 RVA: 0x0002763C File Offset: 0x0002583C
		// (set) Token: 0x06000F7C RID: 3964 RVA: 0x00027674 File Offset: 0x00025874
		public unsafe float[] RedTable
		{
			get
			{
				float[] array = new float[256];
				int index = 0;
				PropertyType type = PropertyType.Blob;
				fixed (float* value = &array[0])
				{
					base.GetValue(index, type, new IntPtr((void*)value), 1024);
					return array;
				}
			}
			set
			{
				if (value.Length != 256)
				{
					throw new ArgumentException("Invalid table size. Excepting Length 256.");
				}
				int index = 0;
				PropertyType type = PropertyType.Blob;
				fixed (float* value2 = &value[0])
				{
					base.SetValue(index, type, new IntPtr((void*)value2), 1024);
					return;
				}
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000F7D RID: 3965 RVA: 0x00026CE3 File Offset: 0x00024EE3
		// (set) Token: 0x06000F7E RID: 3966 RVA: 0x00026CEC File Offset: 0x00024EEC
		public bool RedDisable
		{
			get
			{
				return base.GetBoolValue(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000F7F RID: 3967 RVA: 0x000276B4 File Offset: 0x000258B4
		// (set) Token: 0x06000F80 RID: 3968 RVA: 0x000276EC File Offset: 0x000258EC
		public unsafe float[] GreenTable
		{
			get
			{
				float[] array = new float[256];
				int index = 2;
				PropertyType type = PropertyType.Blob;
				fixed (float* value = &array[0])
				{
					base.GetValue(index, type, new IntPtr((void*)value), 1024);
					return array;
				}
			}
			set
			{
				if (value.Length != 256)
				{
					throw new ArgumentException("Invalid table size. Excepting Length 256.");
				}
				int index = 2;
				PropertyType type = PropertyType.Blob;
				fixed (float* value2 = &value[0])
				{
					base.SetValue(index, type, new IntPtr((void*)value2), 1024);
					return;
				}
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x00026D7E File Offset: 0x00024F7E
		// (set) Token: 0x06000F82 RID: 3970 RVA: 0x00026D87 File Offset: 0x00024F87
		public bool GreenDisable
		{
			get
			{
				return base.GetBoolValue(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0002772C File Offset: 0x0002592C
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x00027764 File Offset: 0x00025964
		public unsafe float[] BlueTable
		{
			get
			{
				float[] array = new float[256];
				int index = 4;
				PropertyType type = PropertyType.Blob;
				fixed (float* value = &array[0])
				{
					base.GetValue(index, type, new IntPtr((void*)value), 1024);
					return array;
				}
			}
			set
			{
				if (value.Length != 256)
				{
					throw new ArgumentException("Invalid table size. Excepting Length 256.");
				}
				int index = 4;
				PropertyType type = PropertyType.Blob;
				fixed (float* value2 = &value[0])
				{
					base.SetValue(index, type, new IntPtr((void*)value2), 1024);
					return;
				}
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x00027144 File Offset: 0x00025344
		// (set) Token: 0x06000F86 RID: 3974 RVA: 0x0002714D File Offset: 0x0002534D
		public bool BlueDisable
		{
			get
			{
				return base.GetBoolValue(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x000277A4 File Offset: 0x000259A4
		// (set) Token: 0x06000F88 RID: 3976 RVA: 0x000277DC File Offset: 0x000259DC
		public unsafe float[] AlphaTable
		{
			get
			{
				float[] array = new float[256];
				int index = 6;
				PropertyType type = PropertyType.Blob;
				fixed (float* value = &array[0])
				{
					base.GetValue(index, type, new IntPtr((void*)value), 1024);
					return array;
				}
			}
			set
			{
				if (value.Length != 256)
				{
					throw new ArgumentException("Invalid table size. Excepting Length 256.");
				}
				int index = 6;
				PropertyType type = PropertyType.Blob;
				fixed (float* value2 = &value[0])
				{
					base.SetValue(index, type, new IntPtr((void*)value2), 1024);
					return;
				}
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000F89 RID: 3977 RVA: 0x00027157 File Offset: 0x00025357
		// (set) Token: 0x06000F8A RID: 3978 RVA: 0x00027160 File Offset: 0x00025360
		public bool AlphaDisable
		{
			get
			{
				return base.GetBoolValue(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x000270B2 File Offset: 0x000252B2
		// (set) Token: 0x06000F8C RID: 3980 RVA: 0x000270BB File Offset: 0x000252BB
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(8);
			}
			set
			{
				base.SetValue(8, value);
			}
		}
	}
}
