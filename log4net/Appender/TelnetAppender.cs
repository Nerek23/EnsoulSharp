using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000EB RID: 235
	public class TelnetAppender : AppenderSkeleton
	{
		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00018187 File Offset: 0x00017187
		// (set) Token: 0x0600078B RID: 1931 RVA: 0x00018190 File Offset: 0x00017190
		public int Port
		{
			get
			{
				return this.m_listeningPort;
			}
			set
			{
				if (value < 0 || value > 65535)
				{
					throw SystemInfo.CreateArgumentOutOfRangeException("value", value, string.Concat(new string[]
					{
						"The value specified for Port is less than ",
						0.ToString(NumberFormatInfo.InvariantInfo),
						" or greater than ",
						65535.ToString(NumberFormatInfo.InvariantInfo),
						"."
					}));
				}
				this.m_listeningPort = value;
			}
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001820A File Offset: 0x0001720A
		protected override void OnClose()
		{
			base.OnClose();
			if (this.m_handler != null)
			{
				this.m_handler.Dispose();
				this.m_handler = null;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0001822C File Offset: 0x0001722C
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00018230 File Offset: 0x00017230
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			try
			{
				LogLog.Debug(TelnetAppender.declaringType, "Creating SocketHandler to listen on port [" + this.m_listeningPort.ToString() + "]");
				this.m_handler = new TelnetAppender.SocketHandler(this.m_listeningPort);
			}
			catch (Exception exception)
			{
				LogLog.Error(TelnetAppender.declaringType, "Failed to create SocketHandler", exception);
				throw;
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x000182A0 File Offset: 0x000172A0
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_handler != null && this.m_handler.HasConnections)
			{
				this.m_handler.Send(base.RenderLoggingEvent(loggingEvent));
			}
		}

		// Token: 0x04000242 RID: 578
		private TelnetAppender.SocketHandler m_handler;

		// Token: 0x04000243 RID: 579
		private int m_listeningPort = 23;

		// Token: 0x04000244 RID: 580
		private static readonly Type declaringType = typeof(TelnetAppender);

		// Token: 0x02000125 RID: 293
		protected class SocketHandler : IDisposable
		{
			// Token: 0x060008A4 RID: 2212 RVA: 0x00019E9C File Offset: 0x00018E9C
			public SocketHandler(int port)
			{
				this.m_serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this.m_serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
				this.m_serverSocket.Listen(5);
				this.AcceptConnection();
			}

			// Token: 0x060008A5 RID: 2213 RVA: 0x00019EF0 File Offset: 0x00018EF0
			private void AcceptConnection()
			{
				this.m_serverSocket.BeginAccept(new AsyncCallback(this.OnConnect), null);
			}

			// Token: 0x060008A6 RID: 2214 RVA: 0x00019F0C File Offset: 0x00018F0C
			public void Send(string message)
			{
				foreach (object obj in this.m_clients)
				{
					TelnetAppender.SocketHandler.SocketClient socketClient = (TelnetAppender.SocketHandler.SocketClient)obj;
					try
					{
						socketClient.Send(message);
					}
					catch (Exception)
					{
						socketClient.Dispose();
						this.RemoveClient(socketClient);
					}
				}
			}

			// Token: 0x060008A7 RID: 2215 RVA: 0x00019F84 File Offset: 0x00018F84
			private void AddClient(TelnetAppender.SocketHandler.SocketClient client)
			{
				lock (this)
				{
					ArrayList arrayList = (ArrayList)this.m_clients.Clone();
					arrayList.Add(client);
					this.m_clients = arrayList;
				}
			}

			// Token: 0x060008A8 RID: 2216 RVA: 0x00019FDC File Offset: 0x00018FDC
			private void RemoveClient(TelnetAppender.SocketHandler.SocketClient client)
			{
				lock (this)
				{
					ArrayList arrayList = (ArrayList)this.m_clients.Clone();
					arrayList.Remove(client);
					this.m_clients = arrayList;
				}
			}

			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0001A030 File Offset: 0x00019030
			public bool HasConnections
			{
				get
				{
					ArrayList clients = this.m_clients;
					return clients != null && clients.Count > 0;
				}
			}

			// Token: 0x060008AA RID: 2218 RVA: 0x0001A054 File Offset: 0x00019054
			private void OnConnect(IAsyncResult asyncResult)
			{
				try
				{
					Socket socket = this.m_serverSocket.EndAccept(asyncResult);
					LogLog.Debug(TelnetAppender.declaringType, "Accepting connection from [" + socket.RemoteEndPoint.ToString() + "]");
					TelnetAppender.SocketHandler.SocketClient socketClient = new TelnetAppender.SocketHandler.SocketClient(socket);
					int count = this.m_clients.Count;
					if (count < 20)
					{
						try
						{
							socketClient.Send("TelnetAppender v1.0 (" + (count + 1).ToString() + " active connections)\r\n\r\n");
							this.AddClient(socketClient);
							goto IL_8C;
						}
						catch
						{
							socketClient.Dispose();
							goto IL_8C;
						}
					}
					socketClient.Send("Sorry - Too many connections.\r\n");
					socketClient.Dispose();
					IL_8C:;
				}
				catch
				{
				}
				finally
				{
					if (this.m_serverSocket != null)
					{
						this.AcceptConnection();
					}
				}
			}

			// Token: 0x060008AB RID: 2219 RVA: 0x0001A12C File Offset: 0x0001912C
			public void Dispose()
			{
				foreach (object obj in this.m_clients)
				{
					((TelnetAppender.SocketHandler.SocketClient)obj).Dispose();
				}
				this.m_clients.Clear();
				Socket serverSocket = this.m_serverSocket;
				this.m_serverSocket = null;
				try
				{
					serverSocket.Shutdown(SocketShutdown.Both);
				}
				catch
				{
				}
				try
				{
					serverSocket.Close();
				}
				catch
				{
				}
			}

			// Token: 0x04000315 RID: 789
			private const int MAX_CONNECTIONS = 20;

			// Token: 0x04000316 RID: 790
			private Socket m_serverSocket;

			// Token: 0x04000317 RID: 791
			private ArrayList m_clients = new ArrayList();

			// Token: 0x02000128 RID: 296
			protected class SocketClient : IDisposable
			{
				// Token: 0x060008B0 RID: 2224 RVA: 0x0001A1F4 File Offset: 0x000191F4
				public SocketClient(Socket socket)
				{
					this.m_socket = socket;
					try
					{
						this.m_writer = new StreamWriter(new NetworkStream(socket));
					}
					catch
					{
						this.Dispose();
						throw;
					}
				}

				// Token: 0x060008B1 RID: 2225 RVA: 0x0001A23C File Offset: 0x0001923C
				public void Send(string message)
				{
					this.m_writer.Write(message);
					this.m_writer.Flush();
				}

				// Token: 0x060008B2 RID: 2226 RVA: 0x0001A258 File Offset: 0x00019258
				public void Dispose()
				{
					try
					{
						if (this.m_writer != null)
						{
							this.m_writer.Dispose();
							this.m_writer = null;
						}
					}
					catch
					{
					}
					if (this.m_socket != null)
					{
						try
						{
							this.m_socket.Shutdown(SocketShutdown.Both);
						}
						catch
						{
						}
						try
						{
							this.m_socket.Dispose();
						}
						catch
						{
						}
						this.m_socket = null;
					}
				}

				// Token: 0x04000318 RID: 792
				private Socket m_socket;

				// Token: 0x04000319 RID: 793
				private StreamWriter m_writer;
			}
		}
	}
}
