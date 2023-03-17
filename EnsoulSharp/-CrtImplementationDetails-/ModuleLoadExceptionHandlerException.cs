using System;
using System.Runtime.Serialization;
using System.Security;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000174 RID: 372
	[Serializable]
	internal class ModuleLoadExceptionHandlerException : ModuleLoadException
	{
		// Token: 0x060006BB RID: 1723 RVA: 0x000109E8 File Offset: 0x0000FDE8
		protected ModuleLoadExceptionHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.NestedException = (Exception)info.GetValue("NestedException", typeof(Exception));
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00011008 File Offset: 0x00010408
		public ModuleLoadExceptionHandlerException(string message, Exception innerException, Exception nestedException) : base(message, innerException)
		{
			this.NestedException = nestedException;
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000108EC File Offset: 0x0000FCEC
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x00010900 File Offset: 0x0000FD00
		public Exception NestedException
		{
			get
			{
				return this.<backing_store>NestedException;
			}
			set
			{
				this.<backing_store>NestedException = value;
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00010914 File Offset: 0x0000FD14
		public override string ToString()
		{
			string text;
			if (this.InnerException != null)
			{
				text = this.InnerException.ToString();
			}
			else
			{
				text = string.Empty;
			}
			string text2;
			if (this.NestedException != null)
			{
				text2 = this.NestedException.ToString();
			}
			else
			{
				text2 = string.Empty;
			}
			object[] array = new object[4];
			array[0] = this.GetType();
			string text3;
			if (this.Message != null)
			{
				text3 = this.Message;
			}
			else
			{
				text3 = string.Empty;
			}
			array[1] = text3;
			string text4;
			if (text != null)
			{
				text4 = text;
			}
			else
			{
				text4 = string.Empty;
			}
			array[2] = text4;
			string text5;
			if (text2 != null)
			{
				text5 = text2;
			}
			else
			{
				text5 = string.Empty;
			}
			array[3] = text5;
			return string.Format("\n{0}: {1}\n--- Start of primary exception ---\n{2}\n--- End of primary exception ---\n\n--- Start of nested exception ---\n{3}\n--- End of nested exception ---\n", array);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000109B8 File Offset: 0x0000FDB8
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("NestedException", this.NestedException, typeof(Exception));
		}

		// Token: 0x04000410 RID: 1040
		private const string formatString = "\n{0}: {1}\n--- Start of primary exception ---\n{2}\n--- End of primary exception ---\n\n--- Start of nested exception ---\n{3}\n--- End of nested exception ---\n";

		// Token: 0x04000411 RID: 1041
		private Exception <backing_store>NestedException;
	}
}
