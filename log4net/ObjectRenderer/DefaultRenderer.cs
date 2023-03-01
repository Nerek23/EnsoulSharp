using System;
using System.Collections;
using System.IO;
using log4net.Util;

namespace log4net.ObjectRenderer
{
	// Token: 0x02000065 RID: 101
	public sealed class DefaultRenderer : IObjectRenderer
	{
		// Token: 0x06000374 RID: 884 RVA: 0x0000B390 File Offset: 0x0000A390
		public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
		{
			if (rendererMap == null)
			{
				throw new ArgumentNullException("rendererMap");
			}
			if (obj == null)
			{
				writer.Write(SystemInfo.NullText);
				return;
			}
			Array array = obj as Array;
			if (array != null)
			{
				this.RenderArray(rendererMap, array, writer);
				return;
			}
			IEnumerable enumerable = obj as IEnumerable;
			if (enumerable != null)
			{
				ICollection collection = obj as ICollection;
				if (collection != null && collection.Count == 0)
				{
					writer.Write("{}");
					return;
				}
				IDictionary dictionary = obj as IDictionary;
				if (dictionary != null)
				{
					this.RenderEnumerator(rendererMap, dictionary.GetEnumerator(), writer);
					return;
				}
				this.RenderEnumerator(rendererMap, enumerable.GetEnumerator(), writer);
				return;
			}
			else
			{
				IEnumerator enumerator = obj as IEnumerator;
				if (enumerator != null)
				{
					this.RenderEnumerator(rendererMap, enumerator, writer);
					return;
				}
				if (obj is DictionaryEntry)
				{
					this.RenderDictionaryEntry(rendererMap, (DictionaryEntry)obj, writer);
					return;
				}
				string text = obj.ToString();
				writer.Write((text == null) ? SystemInfo.NullText : text);
				return;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000B468 File Offset: 0x0000A468
		private void RenderArray(RendererMap rendererMap, Array array, TextWriter writer)
		{
			if (array.Rank != 1)
			{
				writer.Write(array.ToString());
				return;
			}
			writer.Write(array.GetType().Name + " {");
			int length = array.Length;
			if (length > 0)
			{
				rendererMap.FindAndRender(array.GetValue(0), writer);
				for (int i = 1; i < length; i++)
				{
					writer.Write(", ");
					rendererMap.FindAndRender(array.GetValue(i), writer);
				}
			}
			writer.Write("}");
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000B4F0 File Offset: 0x0000A4F0
		private void RenderEnumerator(RendererMap rendererMap, IEnumerator enumerator, TextWriter writer)
		{
			writer.Write("{");
			if (enumerator != null && enumerator.MoveNext())
			{
				rendererMap.FindAndRender(enumerator.Current, writer);
				while (enumerator.MoveNext())
				{
					writer.Write(", ");
					rendererMap.FindAndRender(enumerator.Current, writer);
				}
			}
			writer.Write("}");
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000B54D File Offset: 0x0000A54D
		private void RenderDictionaryEntry(RendererMap rendererMap, DictionaryEntry entry, TextWriter writer)
		{
			rendererMap.FindAndRender(entry.Key, writer);
			writer.Write("=");
			rendererMap.FindAndRender(entry.Value, writer);
		}
	}
}
