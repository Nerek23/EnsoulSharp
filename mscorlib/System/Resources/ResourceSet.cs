using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Resources
{
	/// <summary>Stores all the resources localized for one particular culture, ignoring all other cultures, including any fallback rules.</summary>
	// Token: 0x0200036D RID: 877
	[ComVisible(true)]
	[Serializable]
	public class ResourceSet : IDisposable, IEnumerable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.ResourceSet" /> class with default properties.</summary>
		// Token: 0x06002C47 RID: 11335 RVA: 0x000A8AD5 File Offset: 0x000A6CD5
		protected ResourceSet()
		{
			this.CommonInit();
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x000A8AE3 File Offset: 0x000A6CE3
		internal ResourceSet(bool junk)
		{
		}

		/// <summary>Creates a new instance of the <see cref="T:System.Resources.ResourceSet" /> class using the system default <see cref="T:System.Resources.ResourceReader" /> that opens and reads resources from the given file.</summary>
		/// <param name="fileName">Resource file to read.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="fileName" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002C49 RID: 11337 RVA: 0x000A8AEB File Offset: 0x000A6CEB
		public ResourceSet(string fileName)
		{
			this.Reader = new ResourceReader(fileName);
			this.CommonInit();
			this.ReadResources();
		}

		/// <summary>Creates a new instance of the <see cref="T:System.Resources.ResourceSet" /> class using the system default <see cref="T:System.Resources.ResourceReader" /> that reads resources from the given stream.</summary>
		/// <param name="stream">The <see cref="T:System.IO.Stream" /> of resources to be read. The stream should refer to an existing resources file.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="stream" /> is not readable.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="stream" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002C4A RID: 11338 RVA: 0x000A8B0B File Offset: 0x000A6D0B
		[SecurityCritical]
		public ResourceSet(Stream stream)
		{
			this.Reader = new ResourceReader(stream);
			this.CommonInit();
			this.ReadResources();
		}

		/// <summary>Creates a new instance of the <see cref="T:System.Resources.ResourceSet" /> class using the specified resource reader.</summary>
		/// <param name="reader">The reader that will be used.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="reader" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002C4B RID: 11339 RVA: 0x000A8B2B File Offset: 0x000A6D2B
		public ResourceSet(IResourceReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.Reader = reader;
			this.CommonInit();
			this.ReadResources();
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x000A8B54 File Offset: 0x000A6D54
		private void CommonInit()
		{
			this.Table = new Hashtable();
		}

		/// <summary>Closes and releases any resources used by this <see cref="T:System.Resources.ResourceSet" />.</summary>
		// Token: 0x06002C4D RID: 11341 RVA: 0x000A8B61 File Offset: 0x000A6D61
		public virtual void Close()
		{
			this.Dispose(true);
		}

		/// <summary>Releases resources (other than memory) associated with the current instance, closing internal managed objects if requested.</summary>
		/// <param name="disposing">Indicates whether the objects contained in the current instance should be explicitly closed.</param>
		// Token: 0x06002C4E RID: 11342 RVA: 0x000A8B6C File Offset: 0x000A6D6C
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				IResourceReader reader = this.Reader;
				this.Reader = null;
				if (reader != null)
				{
					reader.Close();
				}
			}
			this.Reader = null;
			this._caseInsensitiveTable = null;
			this.Table = null;
		}

		/// <summary>Disposes of the resources (other than memory) used by the current instance of <see cref="T:System.Resources.ResourceSet" />.</summary>
		// Token: 0x06002C4F RID: 11343 RVA: 0x000A8BA8 File Offset: 0x000A6DA8
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>Returns the preferred resource reader class for this kind of <see cref="T:System.Resources.ResourceSet" />.</summary>
		/// <returns>The <see cref="T:System.Type" /> for the preferred resource reader for this kind of <see cref="T:System.Resources.ResourceSet" />.</returns>
		// Token: 0x06002C50 RID: 11344 RVA: 0x000A8BB1 File Offset: 0x000A6DB1
		public virtual Type GetDefaultReader()
		{
			return typeof(ResourceReader);
		}

		/// <summary>Returns the preferred resource writer class for this kind of <see cref="T:System.Resources.ResourceSet" />.</summary>
		/// <returns>The <see cref="T:System.Type" /> for the preferred resource writer for this kind of <see cref="T:System.Resources.ResourceSet" />.</returns>
		// Token: 0x06002C51 RID: 11345 RVA: 0x000A8BBD File Offset: 0x000A6DBD
		public virtual Type GetDefaultWriter()
		{
			return typeof(ResourceWriter);
		}

		/// <summary>Returns an <see cref="T:System.Collections.IDictionaryEnumerator" /> that can iterate through the <see cref="T:System.Resources.ResourceSet" />.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionaryEnumerator" /> for this <see cref="T:System.Resources.ResourceSet" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The resource set has been closed or disposed.</exception>
		// Token: 0x06002C52 RID: 11346 RVA: 0x000A8BC9 File Offset: 0x000A6DC9
		[ComVisible(false)]
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> object to avoid a race condition with <see langword="Dispose" />. This member is not intended to be used directly from your code.</summary>
		/// <returns>An enumerator for the current <see cref="T:System.Resources.ResourceSet" /> object.</returns>
		// Token: 0x06002C53 RID: 11347 RVA: 0x000A8BD1 File Offset: 0x000A6DD1
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x000A8BDC File Offset: 0x000A6DDC
		private IDictionaryEnumerator GetEnumeratorHelper()
		{
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			return table.GetEnumerator();
		}

		/// <summary>Searches for a <see cref="T:System.String" /> resource with the specified name.</summary>
		/// <param name="name">Name of the resource to search for.</param>
		/// <returns>The value of a resource, if the value is a <see cref="T:System.String" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The resource specified by <paramref name="name" /> is not a <see cref="T:System.String" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The object has been closed or disposed.</exception>
		// Token: 0x06002C55 RID: 11349 RVA: 0x000A8C0C File Offset: 0x000A6E0C
		public virtual string GetString(string name)
		{
			object objectInternal = this.GetObjectInternal(name);
			string result;
			try
			{
				result = (string)objectInternal;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			return result;
		}

		/// <summary>Searches for a <see cref="T:System.String" /> resource with the specified name in a case-insensitive manner, if requested.</summary>
		/// <param name="name">Name of the resource to search for.</param>
		/// <param name="ignoreCase">Indicates whether the case of the case of the specified name should be ignored.</param>
		/// <returns>The value of a resource, if the value is a <see cref="T:System.String" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The resource specified by <paramref name="name" /> is not a <see cref="T:System.String" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The object has been closed or disposed.</exception>
		// Token: 0x06002C56 RID: 11350 RVA: 0x000A8C58 File Offset: 0x000A6E58
		public virtual string GetString(string name, bool ignoreCase)
		{
			object obj = this.GetObjectInternal(name);
			string text;
			try
			{
				text = (string)obj;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			if (text != null || !ignoreCase)
			{
				return text;
			}
			obj = this.GetCaseInsensitiveObjectInternal(name);
			string result;
			try
			{
				result = (string)obj;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			return result;
		}

		/// <summary>Searches for a resource object with the specified name.</summary>
		/// <param name="name">Case-sensitive name of the resource to search for.</param>
		/// <returns>The requested resource.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The object has been closed or disposed.</exception>
		// Token: 0x06002C57 RID: 11351 RVA: 0x000A8CE4 File Offset: 0x000A6EE4
		public virtual object GetObject(string name)
		{
			return this.GetObjectInternal(name);
		}

		/// <summary>Searches for a resource object with the specified name in a case-insensitive manner, if requested.</summary>
		/// <param name="name">Name of the resource to search for.</param>
		/// <param name="ignoreCase">Indicates whether the case of the specified name should be ignored.</param>
		/// <returns>The requested resource.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The object has been closed or disposed.</exception>
		// Token: 0x06002C58 RID: 11352 RVA: 0x000A8CF0 File Offset: 0x000A6EF0
		public virtual object GetObject(string name, bool ignoreCase)
		{
			object objectInternal = this.GetObjectInternal(name);
			if (objectInternal != null || !ignoreCase)
			{
				return objectInternal;
			}
			return this.GetCaseInsensitiveObjectInternal(name);
		}

		/// <summary>Reads all the resources and stores them in a <see cref="T:System.Collections.Hashtable" /> indicated in the <see cref="F:System.Resources.ResourceSet.Table" /> property.</summary>
		// Token: 0x06002C59 RID: 11353 RVA: 0x000A8D14 File Offset: 0x000A6F14
		protected virtual void ReadResources()
		{
			IDictionaryEnumerator enumerator = this.Reader.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object value = enumerator.Value;
				this.Table.Add(enumerator.Key, value);
			}
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x000A8D50 File Offset: 0x000A6F50
		private object GetObjectInternal(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			return table[name];
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x000A8D90 File Offset: 0x000A6F90
		private object GetCaseInsensitiveObjectInternal(string name)
		{
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			Hashtable hashtable = this._caseInsensitiveTable;
			if (hashtable == null)
			{
				hashtable = new Hashtable(StringComparer.OrdinalIgnoreCase);
				IDictionaryEnumerator enumerator = table.GetEnumerator();
				while (enumerator.MoveNext())
				{
					hashtable.Add(enumerator.Key, enumerator.Value);
				}
				this._caseInsensitiveTable = hashtable;
			}
			return hashtable[name];
		}

		/// <summary>Indicates the <see cref="T:System.Resources.IResourceReader" /> used to read the resources.</summary>
		// Token: 0x040011B0 RID: 4528
		[NonSerialized]
		protected IResourceReader Reader;

		/// <summary>The <see cref="T:System.Collections.Hashtable" /> in which the resources are stored.</summary>
		// Token: 0x040011B1 RID: 4529
		protected Hashtable Table;

		// Token: 0x040011B2 RID: 4530
		private Hashtable _caseInsensitiveTable;
	}
}
