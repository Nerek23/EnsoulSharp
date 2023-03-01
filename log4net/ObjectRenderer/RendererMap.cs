using System;
using System.Collections;
using System.Globalization;
using System.IO;
using log4net.Util;

namespace log4net.ObjectRenderer
{
	// Token: 0x02000067 RID: 103
	public class RendererMap
	{
		// Token: 0x06000379 RID: 889 RVA: 0x0000B576 File Offset: 0x0000A576
		public RendererMap()
		{
			this.m_map = Hashtable.Synchronized(new Hashtable());
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000B59C File Offset: 0x0000A59C
		public string FindAndRender(object obj)
		{
			string text = obj as string;
			if (text != null)
			{
				return text;
			}
			string result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				this.FindAndRender(obj, stringWriter);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000B5EC File Offset: 0x0000A5EC
		public void FindAndRender(object obj, TextWriter writer)
		{
			if (obj == null)
			{
				writer.Write(SystemInfo.NullText);
				return;
			}
			string text = obj as string;
			if (text != null)
			{
				writer.Write(text);
				return;
			}
			try
			{
				this.Get(obj.GetType()).RenderObject(this, obj, writer);
			}
			catch (Exception ex)
			{
				LogLog.Error(RendererMap.declaringType, "Exception while rendering object of type [" + obj.GetType().FullName + "]", ex);
				string str = "";
				if (obj != null && obj.GetType() != null)
				{
					str = obj.GetType().FullName;
				}
				writer.Write("<log4net.Error>Exception rendering object type [" + str + "]");
				if (ex != null)
				{
					string str2 = null;
					try
					{
						str2 = ex.ToString();
					}
					catch
					{
					}
					writer.Write("<stackTrace>" + str2 + "</stackTrace>");
				}
				writer.Write("</log4net.Error>");
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000B6E4 File Offset: 0x0000A6E4
		public IObjectRenderer Get(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			return this.Get(obj.GetType());
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000B6F8 File Offset: 0x0000A6F8
		public IObjectRenderer Get(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			IObjectRenderer objectRenderer = (IObjectRenderer)this.m_cache[type];
			if (objectRenderer == null)
			{
				Type type2 = type;
				while (type2 != null)
				{
					objectRenderer = this.SearchTypeAndInterfaces(type2);
					if (objectRenderer != null)
					{
						break;
					}
					type2 = type2.BaseType;
				}
				if (objectRenderer == null)
				{
					objectRenderer = RendererMap.s_defaultRenderer;
				}
				this.m_cache[type] = objectRenderer;
			}
			return objectRenderer;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000B768 File Offset: 0x0000A768
		private IObjectRenderer SearchTypeAndInterfaces(Type type)
		{
			IObjectRenderer objectRenderer = (IObjectRenderer)this.m_map[type];
			if (objectRenderer != null)
			{
				return objectRenderer;
			}
			foreach (Type type2 in type.GetInterfaces())
			{
				objectRenderer = this.SearchTypeAndInterfaces(type2);
				if (objectRenderer != null)
				{
					return objectRenderer;
				}
			}
			return null;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000B7B3 File Offset: 0x0000A7B3
		public IObjectRenderer DefaultRenderer
		{
			get
			{
				return RendererMap.s_defaultRenderer;
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000B7BA File Offset: 0x0000A7BA
		public void Clear()
		{
			this.m_map.Clear();
			this.m_cache.Clear();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000B7D2 File Offset: 0x0000A7D2
		public void Put(Type typeToRender, IObjectRenderer renderer)
		{
			this.m_cache.Clear();
			if (typeToRender == null)
			{
				throw new ArgumentNullException("typeToRender");
			}
			if (renderer == null)
			{
				throw new ArgumentNullException("renderer");
			}
			this.m_map[typeToRender] = renderer;
		}

		// Token: 0x040000CE RID: 206
		private static readonly Type declaringType = typeof(RendererMap);

		// Token: 0x040000CF RID: 207
		private Hashtable m_map;

		// Token: 0x040000D0 RID: 208
		private Hashtable m_cache = new Hashtable();

		// Token: 0x040000D1 RID: 209
		private static IObjectRenderer s_defaultRenderer = new DefaultRenderer();
	}
}
