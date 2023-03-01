using System;
using System.Collections.Generic;

namespace SharpDX
{
	// Token: 0x0200001A RID: 26
	public class DisposeCollector : DisposeBase
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003AB7 File Offset: 0x00001CB7
		public int Count
		{
			get
			{
				return this.disposables.Count;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003AC4 File Offset: 0x00001CC4
		public void DisposeAndClear(bool disposeManagedResources = true)
		{
			if (this.disposables == null)
			{
				return;
			}
			for (int i = this.disposables.Count - 1; i >= 0; i--)
			{
				object obj = this.disposables[i];
				IDisposable disposable;
				if ((disposable = (obj as IDisposable)) != null)
				{
					if (disposeManagedResources)
					{
						disposable.Dispose();
					}
				}
				else
				{
					Utilities.FreeMemory((IntPtr)obj);
				}
				this.disposables.RemoveAt(i);
			}
			this.disposables.Clear();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003B36 File Offset: 0x00001D36
		protected override void Dispose(bool disposeManagedResources)
		{
			this.DisposeAndClear(disposeManagedResources);
			this.disposables = null;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003B48 File Offset: 0x00001D48
		public T Collect<T>(T toDispose)
		{
			if (!(toDispose is IDisposable) && !(toDispose is IntPtr))
			{
				throw new ArgumentException("Argument must be IDisposable or IntPtr");
			}
			if (toDispose is IntPtr && !Utilities.IsMemoryAligned((IntPtr)((object)toDispose), 16))
			{
				throw new ArgumentException("Memory pointer is invalid. Memory must have been allocated with Utilties.AllocateMemory");
			}
			if (!object.Equals(toDispose, default(T)))
			{
				if (this.disposables == null)
				{
					this.disposables = new List<object>();
				}
				if (!this.disposables.Contains(toDispose))
				{
					this.disposables.Add(toDispose);
				}
			}
			return toDispose;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003BFC File Offset: 0x00001DFC
		public void RemoveAndDispose<T>(ref T objectToDispose)
		{
			if (this.disposables != null)
			{
				this.Remove<T>(objectToDispose);
				IDisposable disposable = objectToDispose as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
				else
				{
					Utilities.FreeMemory((IntPtr)((object)objectToDispose));
				}
				objectToDispose = default(T);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003C55 File Offset: 0x00001E55
		public void Remove<T>(T toDisposeArg)
		{
			if (this.disposables != null && this.disposables.Contains(toDisposeArg))
			{
				this.disposables.Remove(toDisposeArg);
			}
		}

		// Token: 0x0400002E RID: 46
		private List<object> disposables;
	}
}
