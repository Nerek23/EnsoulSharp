﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000105 RID: 261
	[Obsolete("BSON reading and writing has been moved to its own package. See https://www.nuget.org/packages/Newtonsoft.Json.Bson for more details.")]
	public class BsonReader : JsonReader
	{
		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x00035AC2 File Offset: 0x00033CC2
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x00035ACA File Offset: 0x00033CCA
		[Obsolete("JsonNet35BinaryCompatibility will be removed in a future version of Json.NET.")]
		public bool JsonNet35BinaryCompatibility
		{
			get
			{
				return this._jsonNet35BinaryCompatibility;
			}
			set
			{
				this._jsonNet35BinaryCompatibility = value;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x00035AD3 File Offset: 0x00033CD3
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x00035ADB File Offset: 0x00033CDB
		public bool ReadRootValueAsArray
		{
			get
			{
				return this._readRootValueAsArray;
			}
			set
			{
				this._readRootValueAsArray = value;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00035AE4 File Offset: 0x00033CE4
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x00035AEC File Offset: 0x00033CEC
		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return this._dateTimeKindHandling;
			}
			set
			{
				this._dateTimeKindHandling = value;
			}
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00035AF5 File Offset: 0x00033CF5
		public BsonReader(Stream stream) : this(stream, false, DateTimeKind.Local)
		{
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00035B00 File Offset: 0x00033D00
		public BsonReader(BinaryReader reader) : this(reader, false, DateTimeKind.Local)
		{
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00035B0B File Offset: 0x00033D0B
		public BsonReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(stream, "stream");
			this._reader = new BinaryReader(stream);
			this._stack = new List<BsonReader.ContainerContext>();
			this._readRootValueAsArray = readRootValueAsArray;
			this._dateTimeKindHandling = dateTimeKindHandling;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00035B43 File Offset: 0x00033D43
		public BsonReader(BinaryReader reader, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			this._reader = reader;
			this._stack = new List<BsonReader.ContainerContext>();
			this._readRootValueAsArray = readRootValueAsArray;
			this._dateTimeKindHandling = dateTimeKindHandling;
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00035B76 File Offset: 0x00033D76
		private string ReadElement()
		{
			this._currentElementType = this.ReadType();
			return this.ReadString();
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x00035B8C File Offset: 0x00033D8C
		public override bool Read()
		{
			bool result;
			try
			{
				bool flag;
				switch (this._bsonReaderState)
				{
				case BsonReader.BsonReaderState.Normal:
					flag = this.ReadNormal();
					break;
				case BsonReader.BsonReaderState.ReferenceStart:
				case BsonReader.BsonReaderState.ReferenceRef:
				case BsonReader.BsonReaderState.ReferenceId:
					flag = this.ReadReference();
					break;
				case BsonReader.BsonReaderState.CodeWScopeStart:
				case BsonReader.BsonReaderState.CodeWScopeCode:
				case BsonReader.BsonReaderState.CodeWScopeScope:
				case BsonReader.BsonReaderState.CodeWScopeScopeObject:
				case BsonReader.BsonReaderState.CodeWScopeScopeEnd:
					flag = this.ReadCodeWScope();
					break;
				default:
					throw JsonReaderException.Create(this, "Unexpected state: {0}".FormatWith(CultureInfo.InvariantCulture, this._bsonReaderState));
				}
				if (!flag)
				{
					base.SetToken(JsonToken.None);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (EndOfStreamException)
			{
				base.SetToken(JsonToken.None);
				result = false;
			}
			return result;
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x00035C38 File Offset: 0x00033E38
		public override void Close()
		{
			base.Close();
			if (base.CloseInput)
			{
				BinaryReader reader = this._reader;
				if (reader == null)
				{
					return;
				}
				reader.Close();
			}
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x00035C58 File Offset: 0x00033E58
		private bool ReadCodeWScope()
		{
			switch (this._bsonReaderState)
			{
			case BsonReader.BsonReaderState.CodeWScopeStart:
				base.SetToken(JsonToken.PropertyName, "$code");
				this._bsonReaderState = BsonReader.BsonReaderState.CodeWScopeCode;
				return true;
			case BsonReader.BsonReaderState.CodeWScopeCode:
				this.ReadInt32();
				base.SetToken(JsonToken.String, this.ReadLengthString());
				this._bsonReaderState = BsonReader.BsonReaderState.CodeWScopeScope;
				return true;
			case BsonReader.BsonReaderState.CodeWScopeScope:
			{
				if (base.CurrentState == JsonReader.State.PostValue)
				{
					base.SetToken(JsonToken.PropertyName, "$scope");
					return true;
				}
				base.SetToken(JsonToken.StartObject);
				this._bsonReaderState = BsonReader.BsonReaderState.CodeWScopeScopeObject;
				BsonReader.ContainerContext containerContext = new BsonReader.ContainerContext(BsonType.Object);
				this.PushContext(containerContext);
				containerContext.Length = this.ReadInt32();
				return true;
			}
			case BsonReader.BsonReaderState.CodeWScopeScopeObject:
			{
				bool flag = this.ReadNormal();
				if (flag && this.TokenType == JsonToken.EndObject)
				{
					this._bsonReaderState = BsonReader.BsonReaderState.CodeWScopeScopeEnd;
				}
				return flag;
			}
			case BsonReader.BsonReaderState.CodeWScopeScopeEnd:
				base.SetToken(JsonToken.EndObject);
				this._bsonReaderState = BsonReader.BsonReaderState.Normal;
				return true;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x00035D34 File Offset: 0x00033F34
		private bool ReadReference()
		{
			JsonReader.State currentState = base.CurrentState;
			if (currentState != JsonReader.State.Property)
			{
				if (currentState == JsonReader.State.ObjectStart)
				{
					base.SetToken(JsonToken.PropertyName, "$ref");
					this._bsonReaderState = BsonReader.BsonReaderState.ReferenceRef;
					return true;
				}
				if (currentState != JsonReader.State.PostValue)
				{
					throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + base.CurrentState.ToString());
				}
				if (this._bsonReaderState == BsonReader.BsonReaderState.ReferenceRef)
				{
					base.SetToken(JsonToken.PropertyName, "$id");
					this._bsonReaderState = BsonReader.BsonReaderState.ReferenceId;
					return true;
				}
				if (this._bsonReaderState == BsonReader.BsonReaderState.ReferenceId)
				{
					base.SetToken(JsonToken.EndObject);
					this._bsonReaderState = BsonReader.BsonReaderState.Normal;
					return true;
				}
				throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + this._bsonReaderState.ToString());
			}
			else
			{
				if (this._bsonReaderState == BsonReader.BsonReaderState.ReferenceRef)
				{
					base.SetToken(JsonToken.String, this.ReadLengthString());
					return true;
				}
				if (this._bsonReaderState == BsonReader.BsonReaderState.ReferenceId)
				{
					base.SetToken(JsonToken.Bytes, this.ReadBytes(12));
					return true;
				}
				throw JsonReaderException.Create(this, "Unexpected state when reading BSON reference: " + this._bsonReaderState.ToString());
			}
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00035E44 File Offset: 0x00034044
		private bool ReadNormal()
		{
			switch (base.CurrentState)
			{
			case JsonReader.State.Start:
				break;
			case JsonReader.State.Complete:
			case JsonReader.State.Closed:
				return false;
			case JsonReader.State.Property:
				this.ReadType(this._currentElementType);
				return true;
			case JsonReader.State.ObjectStart:
			case JsonReader.State.ArrayStart:
			case JsonReader.State.PostValue:
			{
				BsonReader.ContainerContext currentContext = this._currentContext;
				if (currentContext == null)
				{
					if (!base.SupportMultipleContent)
					{
						return false;
					}
				}
				else
				{
					int num = currentContext.Length - 1;
					if (currentContext.Position < num)
					{
						if (currentContext.Type == BsonType.Array)
						{
							this.ReadElement();
							this.ReadType(this._currentElementType);
							return true;
						}
						base.SetToken(JsonToken.PropertyName, this.ReadElement());
						return true;
					}
					else
					{
						if (currentContext.Position != num)
						{
							throw JsonReaderException.Create(this, "Read past end of current container context.");
						}
						if (this.ReadByte() != 0)
						{
							throw JsonReaderException.Create(this, "Unexpected end of object byte value.");
						}
						this.PopContext();
						if (this._currentContext != null)
						{
							this.MovePosition(currentContext.Length);
						}
						JsonToken token = (currentContext.Type == BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray;
						base.SetToken(token);
						return true;
					}
				}
				break;
			}
			case JsonReader.State.Object:
			case JsonReader.State.Array:
				goto IL_145;
			case JsonReader.State.ConstructorStart:
			case JsonReader.State.Constructor:
			case JsonReader.State.Error:
			case JsonReader.State.Finished:
				return false;
			default:
				goto IL_145;
			}
			JsonToken token2 = (!this._readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray;
			BsonType type = (!this._readRootValueAsArray) ? BsonType.Object : BsonType.Array;
			base.SetToken(token2);
			BsonReader.ContainerContext containerContext = new BsonReader.ContainerContext(type);
			this.PushContext(containerContext);
			containerContext.Length = this.ReadInt32();
			return true;
			IL_145:
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00035FA0 File Offset: 0x000341A0
		private void PopContext()
		{
			this._stack.RemoveAt(this._stack.Count - 1);
			if (this._stack.Count == 0)
			{
				this._currentContext = null;
				return;
			}
			this._currentContext = this._stack[this._stack.Count - 1];
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00035FF8 File Offset: 0x000341F8
		private void PushContext(BsonReader.ContainerContext newContext)
		{
			this._stack.Add(newContext);
			this._currentContext = newContext;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0003600D File Offset: 0x0003420D
		private byte ReadByte()
		{
			this.MovePosition(1);
			return this._reader.ReadByte();
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x00036024 File Offset: 0x00034224
		private void ReadType(BsonType type)
		{
			switch (type)
			{
			case BsonType.Number:
			{
				double num = this.ReadDouble();
				if (this._floatParseHandling == FloatParseHandling.Decimal)
				{
					base.SetToken(JsonToken.Float, Convert.ToDecimal(num, CultureInfo.InvariantCulture));
					return;
				}
				base.SetToken(JsonToken.Float, num);
				return;
			}
			case BsonType.String:
			case BsonType.Symbol:
				base.SetToken(JsonToken.String, this.ReadLengthString());
				return;
			case BsonType.Object:
			{
				base.SetToken(JsonToken.StartObject);
				BsonReader.ContainerContext containerContext = new BsonReader.ContainerContext(BsonType.Object);
				this.PushContext(containerContext);
				containerContext.Length = this.ReadInt32();
				return;
			}
			case BsonType.Array:
			{
				base.SetToken(JsonToken.StartArray);
				BsonReader.ContainerContext containerContext2 = new BsonReader.ContainerContext(BsonType.Array);
				this.PushContext(containerContext2);
				containerContext2.Length = this.ReadInt32();
				return;
			}
			case BsonType.Binary:
			{
				BsonBinaryType bsonBinaryType;
				byte[] array = this.ReadBinary(out bsonBinaryType);
				object value = (bsonBinaryType != BsonBinaryType.Uuid) ? array : new Guid(array);
				base.SetToken(JsonToken.Bytes, value);
				return;
			}
			case BsonType.Undefined:
				base.SetToken(JsonToken.Undefined);
				return;
			case BsonType.Oid:
			{
				byte[] value2 = this.ReadBytes(12);
				base.SetToken(JsonToken.Bytes, value2);
				return;
			}
			case BsonType.Boolean:
			{
				bool flag = Convert.ToBoolean(this.ReadByte());
				base.SetToken(JsonToken.Boolean, flag);
				return;
			}
			case BsonType.Date:
			{
				DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(this.ReadInt64());
				DateTimeKind dateTimeKindHandling = this.DateTimeKindHandling;
				DateTime dateTime2;
				if (dateTimeKindHandling != DateTimeKind.Unspecified)
				{
					if (dateTimeKindHandling != DateTimeKind.Local)
					{
						dateTime2 = dateTime;
					}
					else
					{
						dateTime2 = dateTime.ToLocalTime();
					}
				}
				else
				{
					dateTime2 = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
				}
				base.SetToken(JsonToken.Date, dateTime2);
				return;
			}
			case BsonType.Null:
				base.SetToken(JsonToken.Null);
				return;
			case BsonType.Regex:
			{
				string str = this.ReadString();
				string str2 = this.ReadString();
				string value3 = "/" + str + "/" + str2;
				base.SetToken(JsonToken.String, value3);
				return;
			}
			case BsonType.Reference:
				base.SetToken(JsonToken.StartObject);
				this._bsonReaderState = BsonReader.BsonReaderState.ReferenceStart;
				return;
			case BsonType.Code:
				base.SetToken(JsonToken.String, this.ReadLengthString());
				return;
			case BsonType.CodeWScope:
				base.SetToken(JsonToken.StartObject);
				this._bsonReaderState = BsonReader.BsonReaderState.CodeWScopeStart;
				return;
			case BsonType.Integer:
				base.SetToken(JsonToken.Integer, (long)this.ReadInt32());
				return;
			case BsonType.TimeStamp:
			case BsonType.Long:
				base.SetToken(JsonToken.Integer, this.ReadInt64());
				return;
			default:
				throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type.ToString());
			}
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00036274 File Offset: 0x00034474
		private byte[] ReadBinary(out BsonBinaryType binaryType)
		{
			int count = this.ReadInt32();
			binaryType = (BsonBinaryType)this.ReadByte();
			if (binaryType == BsonBinaryType.BinaryOld && !this._jsonNet35BinaryCompatibility)
			{
				count = this.ReadInt32();
			}
			return this.ReadBytes(count);
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x000362AC File Offset: 0x000344AC
		private string ReadString()
		{
			this.EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			int num4;
			for (;;)
			{
				int num3 = num2;
				byte b;
				while (num3 < 128 && (b = this._reader.ReadByte()) > 0)
				{
					this._byteBuffer[num3++] = b;
				}
				num4 = num3 - num2;
				num += num4;
				if (num3 < 128 && stringBuilder == null)
				{
					break;
				}
				int lastFullCharStop = this.GetLastFullCharStop(num3 - 1);
				int chars = Encoding.UTF8.GetChars(this._byteBuffer, 0, lastFullCharStop + 1, this._charBuffer, 0);
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(256);
				}
				stringBuilder.Append(this._charBuffer, 0, chars);
				if (lastFullCharStop < num4 - 1)
				{
					num2 = num4 - lastFullCharStop - 1;
					Array.Copy(this._byteBuffer, lastFullCharStop + 1, this._byteBuffer, 0, num2);
				}
				else
				{
					if (num3 < 128)
					{
						goto Block_6;
					}
					num2 = 0;
				}
			}
			int chars2 = Encoding.UTF8.GetChars(this._byteBuffer, 0, num4, this._charBuffer, 0);
			this.MovePosition(num + 1);
			return new string(this._charBuffer, 0, chars2);
			Block_6:
			this.MovePosition(num + 1);
			return stringBuilder.ToString();
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x000363CC File Offset: 0x000345CC
		private string ReadLengthString()
		{
			int num = this.ReadInt32();
			this.MovePosition(num);
			string @string = this.GetString(num - 1);
			this._reader.ReadByte();
			return @string;
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x000363FC File Offset: 0x000345FC
		private string GetString(int length)
		{
			if (length == 0)
			{
				return string.Empty;
			}
			this.EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			int num3;
			for (;;)
			{
				int count = (length - num > 128 - num2) ? (128 - num2) : (length - num);
				num3 = this._reader.Read(this._byteBuffer, num2, count);
				if (num3 == 0)
				{
					break;
				}
				num += num3;
				num3 += num2;
				if (num3 == length)
				{
					goto Block_4;
				}
				int lastFullCharStop = this.GetLastFullCharStop(num3 - 1);
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				int chars = Encoding.UTF8.GetChars(this._byteBuffer, 0, lastFullCharStop + 1, this._charBuffer, 0);
				stringBuilder.Append(this._charBuffer, 0, chars);
				if (lastFullCharStop < num3 - 1)
				{
					num2 = num3 - lastFullCharStop - 1;
					Array.Copy(this._byteBuffer, lastFullCharStop + 1, this._byteBuffer, 0, num2);
				}
				else
				{
					num2 = 0;
				}
				if (num >= length)
				{
					goto Block_7;
				}
			}
			throw new EndOfStreamException("Unable to read beyond the end of the stream.");
			Block_4:
			int chars2 = Encoding.UTF8.GetChars(this._byteBuffer, 0, num3, this._charBuffer, 0);
			return new string(this._charBuffer, 0, chars2);
			Block_7:
			return stringBuilder.ToString();
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00036514 File Offset: 0x00034714
		private int GetLastFullCharStop(int start)
		{
			int i = start;
			int num = 0;
			while (i >= 0)
			{
				num = this.BytesInSequence(this._byteBuffer[i]);
				if (num == 0)
				{
					i--;
				}
				else
				{
					if (num != 1)
					{
						i--;
						break;
					}
					break;
				}
			}
			if (num == start - i)
			{
				return start;
			}
			return i;
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00036558 File Offset: 0x00034758
		private int BytesInSequence(byte b)
		{
			if (b <= BsonReader.SeqRange1[1])
			{
				return 1;
			}
			if (b >= BsonReader.SeqRange2[0] && b <= BsonReader.SeqRange2[1])
			{
				return 2;
			}
			if (b >= BsonReader.SeqRange3[0] && b <= BsonReader.SeqRange3[1])
			{
				return 3;
			}
			if (b >= BsonReader.SeqRange4[0] && b <= BsonReader.SeqRange4[1])
			{
				return 4;
			}
			return 0;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x000365B4 File Offset: 0x000347B4
		private void EnsureBuffers()
		{
			if (this._byteBuffer == null)
			{
				this._byteBuffer = new byte[128];
			}
			if (this._charBuffer == null)
			{
				int maxCharCount = Encoding.UTF8.GetMaxCharCount(128);
				this._charBuffer = new char[maxCharCount];
			}
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x000365FD File Offset: 0x000347FD
		private double ReadDouble()
		{
			this.MovePosition(8);
			return this._reader.ReadDouble();
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00036611 File Offset: 0x00034811
		private int ReadInt32()
		{
			this.MovePosition(4);
			return this._reader.ReadInt32();
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00036625 File Offset: 0x00034825
		private long ReadInt64()
		{
			this.MovePosition(8);
			return this._reader.ReadInt64();
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x00036639 File Offset: 0x00034839
		private BsonType ReadType()
		{
			this.MovePosition(1);
			return (BsonType)this._reader.ReadSByte();
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0003664D File Offset: 0x0003484D
		private void MovePosition(int count)
		{
			this._currentContext.Position += count;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00036662 File Offset: 0x00034862
		private byte[] ReadBytes(int count)
		{
			this.MovePosition(count);
			return this._reader.ReadBytes(count);
		}

		// Token: 0x0400040A RID: 1034
		private const int MaxCharBytesSize = 128;

		// Token: 0x0400040B RID: 1035
		private static readonly byte[] SeqRange1 = new byte[]
		{
			0,
			127
		};

		// Token: 0x0400040C RID: 1036
		private static readonly byte[] SeqRange2 = new byte[]
		{
			194,
			223
		};

		// Token: 0x0400040D RID: 1037
		private static readonly byte[] SeqRange3 = new byte[]
		{
			224,
			239
		};

		// Token: 0x0400040E RID: 1038
		private static readonly byte[] SeqRange4 = new byte[]
		{
			240,
			244
		};

		// Token: 0x0400040F RID: 1039
		private readonly BinaryReader _reader;

		// Token: 0x04000410 RID: 1040
		private readonly List<BsonReader.ContainerContext> _stack;

		// Token: 0x04000411 RID: 1041
		private byte[] _byteBuffer;

		// Token: 0x04000412 RID: 1042
		private char[] _charBuffer;

		// Token: 0x04000413 RID: 1043
		private BsonType _currentElementType;

		// Token: 0x04000414 RID: 1044
		private BsonReader.BsonReaderState _bsonReaderState;

		// Token: 0x04000415 RID: 1045
		private BsonReader.ContainerContext _currentContext;

		// Token: 0x04000416 RID: 1046
		private bool _readRootValueAsArray;

		// Token: 0x04000417 RID: 1047
		private bool _jsonNet35BinaryCompatibility;

		// Token: 0x04000418 RID: 1048
		private DateTimeKind _dateTimeKindHandling;

		// Token: 0x020001E1 RID: 481
		private enum BsonReaderState
		{
			// Token: 0x04000856 RID: 2134
			Normal,
			// Token: 0x04000857 RID: 2135
			ReferenceStart,
			// Token: 0x04000858 RID: 2136
			ReferenceRef,
			// Token: 0x04000859 RID: 2137
			ReferenceId,
			// Token: 0x0400085A RID: 2138
			CodeWScopeStart,
			// Token: 0x0400085B RID: 2139
			CodeWScopeCode,
			// Token: 0x0400085C RID: 2140
			CodeWScopeScope,
			// Token: 0x0400085D RID: 2141
			CodeWScopeScopeObject,
			// Token: 0x0400085E RID: 2142
			CodeWScopeScopeEnd
		}

		// Token: 0x020001E2 RID: 482
		private class ContainerContext
		{
			// Token: 0x06001039 RID: 4153 RVA: 0x000477DD File Offset: 0x000459DD
			public ContainerContext(BsonType type)
			{
				this.Type = type;
			}

			// Token: 0x0400085F RID: 2143
			public readonly BsonType Type;

			// Token: 0x04000860 RID: 2144
			public int Length;

			// Token: 0x04000861 RID: 2145
			public int Position;
		}
	}
}
