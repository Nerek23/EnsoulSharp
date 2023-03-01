using System;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000C4 RID: 196
	public class WindowsKeys
	{
		// Token: 0x06000772 RID: 1906 RVA: 0x0002CCFC File Offset: 0x0002AEFC
		public WindowsKeys(GameWndEventArgs args)
		{
			this.args1 = args;
			this.Cursor = EnsoulSharp.SDK.Utils.Cursor.Position;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0002CD16 File Offset: 0x0002AF16
		public WindowsKeys(GameEvent.WindowndEventArgs args)
		{
			this.args2 = args;
			this.Cursor = EnsoulSharp.SDK.Utils.Cursor.Position;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0002CD30 File Offset: 0x0002AF30
		public char Char
		{
			get
			{
				if (this.args1 == null)
				{
					return Convert.ToChar(this.args2.WParam);
				}
				return Convert.ToChar(this.args1.WParam);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0002CD5B File Offset: 0x0002AF5B
		public Vector2 Cursor { get; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0002CD63 File Offset: 0x0002AF63
		public Keys Key
		{
			get
			{
				if (this.args1 == null)
				{
					return (Keys)this.args2.WParam;
				}
				return (Keys)this.args1.WParam;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x0002CD84 File Offset: 0x0002AF84
		public WindowsKeyMessages Msg
		{
			get
			{
				if (this.args1 == null)
				{
					return (WindowsKeyMessages)this.args2.Msg;
				}
				return (WindowsKeyMessages)this.args1.Msg;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002CDA5 File Offset: 0x0002AFA5
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0002CDC2 File Offset: 0x0002AFC2
		public bool Process
		{
			get
			{
				GameWndEventArgs gameWndEventArgs = this.args1;
				if (gameWndEventArgs == null)
				{
					return this.args2.Process;
				}
				return gameWndEventArgs.Process;
			}
			set
			{
				if (this.args1 != null)
				{
					this.args1.Process = value;
					return;
				}
				this.args2.Process = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0002CDE8 File Offset: 0x0002AFE8
		public Keys SideButton
		{
			get
			{
				if (this.args1 != null)
				{
					byte[] bytes = BitConverter.GetBytes(this.args1.WParam);
					if (bytes.Length > 2)
					{
						int num = (int)bytes[2];
						Keys result = Keys.None;
						if (num != 1)
						{
							if (num == 2)
							{
								result = Keys.XButton2;
							}
						}
						else
						{
							result = Keys.XButton1;
						}
						return result;
					}
				}
				else
				{
					byte[] bytes2 = BitConverter.GetBytes(this.args2.WParam);
					if (bytes2.Length > 2)
					{
						int num2 = (int)bytes2[2];
						Keys result2 = Keys.None;
						if (num2 != 1)
						{
							if (num2 == 2)
							{
								result2 = Keys.XButton2;
							}
						}
						else
						{
							result2 = Keys.XButton1;
						}
						return result2;
					}
				}
				return Keys.None;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0002CE63 File Offset: 0x0002B063
		public Keys SingleKey
		{
			get
			{
				if (this.args1 == null)
				{
					return (Keys)this.args2.WParam;
				}
				return (Keys)this.args1.WParam;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0002CE84 File Offset: 0x0002B084
		public uint WParam
		{
			get
			{
				GameWndEventArgs gameWndEventArgs = this.args1;
				if (gameWndEventArgs == null)
				{
					return this.args2.WParam;
				}
				return gameWndEventArgs.WParam;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x0002CEA1 File Offset: 0x0002B0A1
		public int LParam
		{
			get
			{
				GameWndEventArgs gameWndEventArgs = this.args1;
				if (gameWndEventArgs == null)
				{
					return this.args2.LParam;
				}
				return gameWndEventArgs.LParam;
			}
		}

		// Token: 0x0400057A RID: 1402
		private readonly GameWndEventArgs args1;

		// Token: 0x0400057B RID: 1403
		private readonly GameEvent.WindowndEventArgs args2;
	}
}
