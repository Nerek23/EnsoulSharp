using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using log4net.Repository;

namespace log4net.Util
{
	// Token: 0x02000023 RID: 35
	public abstract class PatternConverter
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00004D5F File Offset: 0x00003D5F
		public virtual PatternConverter Next
		{
			get
			{
				return this.m_next;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00004D67 File Offset: 0x00003D67
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00004D80 File Offset: 0x00003D80
		public virtual FormattingInfo FormattingInfo
		{
			get
			{
				return new FormattingInfo(this.m_min, this.m_max, this.m_leftAlign);
			}
			set
			{
				this.m_min = value.Min;
				this.m_max = value.Max;
				this.m_leftAlign = value.LeftAlign;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00004DA6 File Offset: 0x00003DA6
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00004DAE File Offset: 0x00003DAE
		public virtual string Option
		{
			get
			{
				return this.m_option;
			}
			set
			{
				this.m_option = value;
			}
		}

		// Token: 0x06000167 RID: 359
		protected abstract void Convert(TextWriter writer, object state);

		// Token: 0x06000168 RID: 360 RVA: 0x00004DB7 File Offset: 0x00003DB7
		public virtual PatternConverter SetNext(PatternConverter patternConverter)
		{
			this.m_next = patternConverter;
			return this.m_next;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00004DC8 File Offset: 0x00003DC8
		public virtual void Format(TextWriter writer, object state)
		{
			if (this.m_min < 0 && this.m_max == 2147483647)
			{
				this.Convert(writer, state);
				return;
			}
			string value = null;
			ReusableStringWriter formatWriter = this.m_formatWriter;
			int num;
			lock (formatWriter)
			{
				this.m_formatWriter.Reset(1024, 256);
				this.Convert(this.m_formatWriter, state);
				StringBuilder stringBuilder = this.m_formatWriter.GetStringBuilder();
				num = stringBuilder.Length;
				if (num > this.m_max)
				{
					value = stringBuilder.ToString(num - this.m_max, this.m_max);
					num = this.m_max;
				}
				else
				{
					value = stringBuilder.ToString();
				}
			}
			if (num >= this.m_min)
			{
				writer.Write(value);
				return;
			}
			if (this.m_leftAlign)
			{
				writer.Write(value);
				PatternConverter.SpacePad(writer, this.m_min - num);
				return;
			}
			PatternConverter.SpacePad(writer, this.m_min - num);
			writer.Write(value);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004ED0 File Offset: 0x00003ED0
		protected static void SpacePad(TextWriter writer, int length)
		{
			while (length >= 32)
			{
				writer.Write(PatternConverter.SPACES[5]);
				length -= 32;
			}
			for (int i = 4; i >= 0; i--)
			{
				if ((length & 1 << i) != 0)
				{
					writer.Write(PatternConverter.SPACES[i]);
				}
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00004F1A File Offset: 0x00003F1A
		protected static void WriteDictionary(TextWriter writer, ILoggerRepository repository, IDictionary value)
		{
			PatternConverter.WriteDictionary(writer, repository, value.GetEnumerator());
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00004F2C File Offset: 0x00003F2C
		protected static void WriteDictionary(TextWriter writer, ILoggerRepository repository, IDictionaryEnumerator value)
		{
			writer.Write("{");
			bool flag = true;
			while (value.MoveNext())
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					writer.Write(", ");
				}
				PatternConverter.WriteObject(writer, repository, value.Key);
				writer.Write("=");
				PatternConverter.WriteObject(writer, repository, value.Value);
			}
			writer.Write("}");
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004F92 File Offset: 0x00003F92
		protected static void WriteObject(TextWriter writer, ILoggerRepository repository, object value)
		{
			if (repository != null)
			{
				repository.RendererMap.FindAndRender(value, writer);
				return;
			}
			if (value == null)
			{
				writer.Write(SystemInfo.NullText);
				return;
			}
			writer.Write(value.ToString());
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00004FC0 File Offset: 0x00003FC0
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00004FC8 File Offset: 0x00003FC8
		public PropertiesDictionary Properties
		{
			get
			{
				return this.properties;
			}
			set
			{
				this.properties = value;
			}
		}

		// Token: 0x04000046 RID: 70
		private static readonly string[] SPACES = new string[]
		{
			" ",
			"  ",
			"    ",
			"        ",
			"                ",
			"                                "
		};

		// Token: 0x04000047 RID: 71
		private PatternConverter m_next;

		// Token: 0x04000048 RID: 72
		private int m_min = -1;

		// Token: 0x04000049 RID: 73
		private int m_max = int.MaxValue;

		// Token: 0x0400004A RID: 74
		private bool m_leftAlign;

		// Token: 0x0400004B RID: 75
		private string m_option;

		// Token: 0x0400004C RID: 76
		private ReusableStringWriter m_formatWriter = new ReusableStringWriter(CultureInfo.InvariantCulture);

		// Token: 0x0400004D RID: 77
		private const int c_renderBufferSize = 256;

		// Token: 0x0400004E RID: 78
		private const int c_renderBufferMaxCapacity = 1024;

		// Token: 0x0400004F RID: 79
		private PropertiesDictionary properties;
	}
}
