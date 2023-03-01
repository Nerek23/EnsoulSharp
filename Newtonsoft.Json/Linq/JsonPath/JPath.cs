﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D2 RID: 210
	[NullableContext(1)]
	[Nullable(0)]
	internal class JPath
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0002F096 File Offset: 0x0002D296
		public List<PathFilter> Filters { get; }

		// Token: 0x06000BE7 RID: 3047 RVA: 0x0002F09E File Offset: 0x0002D29E
		public JPath(string expression)
		{
			ValidationUtils.ArgumentNotNull(expression, "expression");
			this._expression = expression;
			this.Filters = new List<PathFilter>();
			this.ParseMain();
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0002F0CC File Offset: 0x0002D2CC
		private void ParseMain()
		{
			int currentIndex = this._currentIndex;
			this.EatWhitespace();
			if (this._expression.Length == this._currentIndex)
			{
				return;
			}
			if (this._expression[this._currentIndex] == '$')
			{
				if (this._expression.Length == 1)
				{
					return;
				}
				char c = this._expression[this._currentIndex + 1];
				if (c == '.' || c == '[')
				{
					this._currentIndex++;
					currentIndex = this._currentIndex;
				}
			}
			if (!this.ParsePath(this.Filters, currentIndex, false))
			{
				int currentIndex2 = this._currentIndex;
				this.EatWhitespace();
				if (this._currentIndex < this._expression.Length)
				{
					throw new JsonException("Unexpected character while parsing path: " + this._expression[currentIndex2].ToString());
				}
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0002F1A8 File Offset: 0x0002D3A8
		private bool ParsePath(List<PathFilter> filters, int currentPartStartIndex, bool query)
		{
			bool scan = false;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			while (this._currentIndex < this._expression.Length && !flag3)
			{
				char c = this._expression[this._currentIndex];
				if (c <= ')')
				{
					if (c != ' ')
					{
						if (c != '(')
						{
							if (c != ')')
							{
								goto IL_189;
							}
							goto IL_CD;
						}
					}
					else
					{
						if (this._currentIndex < this._expression.Length)
						{
							flag3 = true;
							continue;
						}
						continue;
					}
				}
				else
				{
					if (c == '.')
					{
						if (this._currentIndex > currentPartStartIndex)
						{
							string text = this._expression.Substring(currentPartStartIndex, this._currentIndex - currentPartStartIndex);
							if (text == "*")
							{
								text = null;
							}
							filters.Add(JPath.CreatePathFilter(text, scan));
							scan = false;
						}
						if (this._currentIndex + 1 < this._expression.Length && this._expression[this._currentIndex + 1] == '.')
						{
							scan = true;
							this._currentIndex++;
						}
						this._currentIndex++;
						currentPartStartIndex = this._currentIndex;
						flag = false;
						flag2 = true;
						continue;
					}
					if (c != '[')
					{
						if (c != ']')
						{
							goto IL_189;
						}
						goto IL_CD;
					}
				}
				if (this._currentIndex > currentPartStartIndex)
				{
					string text2 = this._expression.Substring(currentPartStartIndex, this._currentIndex - currentPartStartIndex);
					if (text2 == "*")
					{
						text2 = null;
					}
					filters.Add(JPath.CreatePathFilter(text2, scan));
					scan = false;
				}
				filters.Add(this.ParseIndexer(c, scan));
				scan = false;
				this._currentIndex++;
				currentPartStartIndex = this._currentIndex;
				flag = true;
				flag2 = false;
				continue;
				IL_CD:
				flag3 = true;
				continue;
				IL_189:
				if (query && (c == '=' || c == '<' || c == '!' || c == '>' || c == '|' || c == '&'))
				{
					flag3 = true;
				}
				else
				{
					if (flag)
					{
						throw new JsonException("Unexpected character following indexer: " + c.ToString());
					}
					this._currentIndex++;
				}
			}
			bool flag4 = this._currentIndex == this._expression.Length;
			if (this._currentIndex > currentPartStartIndex)
			{
				string text3 = this._expression.Substring(currentPartStartIndex, this._currentIndex - currentPartStartIndex).TrimEnd(new char[0]);
				if (text3 == "*")
				{
					text3 = null;
				}
				filters.Add(JPath.CreatePathFilter(text3, scan));
			}
			else if (flag2 && (flag4 || query))
			{
				throw new JsonException("Unexpected end while parsing path.");
			}
			return flag4;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0002F420 File Offset: 0x0002D620
		private static PathFilter CreatePathFilter([Nullable(2)] string member, bool scan)
		{
			if (!scan)
			{
				return new FieldFilter(member);
			}
			return new ScanFilter(member);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0002F434 File Offset: 0x0002D634
		private PathFilter ParseIndexer(char indexerOpenChar, bool scan)
		{
			this._currentIndex++;
			char indexerCloseChar = (indexerOpenChar == '[') ? ']' : ')';
			this.EnsureLength("Path ended with open indexer.");
			this.EatWhitespace();
			if (this._expression[this._currentIndex] == '\'')
			{
				return this.ParseQuotedField(indexerCloseChar, scan);
			}
			if (this._expression[this._currentIndex] == '?')
			{
				return this.ParseQuery(indexerCloseChar, scan);
			}
			return this.ParseArrayIndexer(indexerCloseChar);
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0002F4B0 File Offset: 0x0002D6B0
		private PathFilter ParseArrayIndexer(char indexerCloseChar)
		{
			int currentIndex = this._currentIndex;
			int? num = null;
			List<int> list = null;
			int num2 = 0;
			int? start = null;
			int? end = null;
			int? step = null;
			while (this._currentIndex < this._expression.Length)
			{
				char c = this._expression[this._currentIndex];
				if (c == ' ')
				{
					num = new int?(this._currentIndex);
					this.EatWhitespace();
				}
				else if (c == indexerCloseChar)
				{
					int num3 = (num ?? this._currentIndex) - currentIndex;
					if (list != null)
					{
						if (num3 == 0)
						{
							throw new JsonException("Array index expected.");
						}
						int item = Convert.ToInt32(this._expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
						list.Add(item);
						return new ArrayMultipleIndexFilter(list);
					}
					else
					{
						if (num2 > 0)
						{
							if (num3 > 0)
							{
								int value = Convert.ToInt32(this._expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
								if (num2 == 1)
								{
									end = new int?(value);
								}
								else
								{
									step = new int?(value);
								}
							}
							return new ArraySliceFilter
							{
								Start = start,
								End = end,
								Step = step
							};
						}
						if (num3 == 0)
						{
							throw new JsonException("Array index expected.");
						}
						int value2 = Convert.ToInt32(this._expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
						return new ArrayIndexFilter
						{
							Index = new int?(value2)
						};
					}
				}
				else if (c == ',')
				{
					int num4 = (num ?? this._currentIndex) - currentIndex;
					if (num4 == 0)
					{
						throw new JsonException("Array index expected.");
					}
					if (list == null)
					{
						list = new List<int>();
					}
					string value3 = this._expression.Substring(currentIndex, num4);
					list.Add(Convert.ToInt32(value3, CultureInfo.InvariantCulture));
					this._currentIndex++;
					this.EatWhitespace();
					currentIndex = this._currentIndex;
					num = null;
				}
				else if (c == '*')
				{
					this._currentIndex++;
					this.EnsureLength("Path ended with open indexer.");
					this.EatWhitespace();
					if (this._expression[this._currentIndex] != indexerCloseChar)
					{
						throw new JsonException("Unexpected character while parsing path indexer: " + c.ToString());
					}
					return new ArrayIndexFilter();
				}
				else if (c == ':')
				{
					int num5 = (num ?? this._currentIndex) - currentIndex;
					if (num5 > 0)
					{
						int value4 = Convert.ToInt32(this._expression.Substring(currentIndex, num5), CultureInfo.InvariantCulture);
						if (num2 == 0)
						{
							start = new int?(value4);
						}
						else if (num2 == 1)
						{
							end = new int?(value4);
						}
						else
						{
							step = new int?(value4);
						}
					}
					num2++;
					this._currentIndex++;
					this.EatWhitespace();
					currentIndex = this._currentIndex;
					num = null;
				}
				else
				{
					if (!char.IsDigit(c) && c != '-')
					{
						throw new JsonException("Unexpected character while parsing path indexer: " + c.ToString());
					}
					if (num != null)
					{
						throw new JsonException("Unexpected character while parsing path indexer: " + c.ToString());
					}
					this._currentIndex++;
				}
			}
			throw new JsonException("Path ended with open indexer.");
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0002F7FF File Offset: 0x0002D9FF
		private void EatWhitespace()
		{
			while (this._currentIndex < this._expression.Length && this._expression[this._currentIndex] == ' ')
			{
				this._currentIndex++;
			}
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0002F83C File Offset: 0x0002DA3C
		private PathFilter ParseQuery(char indexerCloseChar, bool scan)
		{
			this._currentIndex++;
			this.EnsureLength("Path ended with open indexer.");
			if (this._expression[this._currentIndex] != '(')
			{
				throw new JsonException("Unexpected character while parsing path indexer: " + this._expression[this._currentIndex].ToString());
			}
			this._currentIndex++;
			QueryExpression expression = this.ParseExpression();
			this._currentIndex++;
			this.EnsureLength("Path ended with open indexer.");
			this.EatWhitespace();
			if (this._expression[this._currentIndex] != indexerCloseChar)
			{
				throw new JsonException("Unexpected character while parsing path indexer: " + this._expression[this._currentIndex].ToString());
			}
			if (!scan)
			{
				return new QueryFilter(expression);
			}
			return new QueryScanFilter(expression);
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0002F924 File Offset: 0x0002DB24
		private bool TryParseExpression([Nullable(new byte[]
		{
			2,
			1
		})] out List<PathFilter> expressionPath)
		{
			if (this._expression[this._currentIndex] == '$')
			{
				expressionPath = new List<PathFilter>
				{
					RootFilter.Instance
				};
			}
			else
			{
				if (this._expression[this._currentIndex] != '@')
				{
					expressionPath = null;
					return false;
				}
				expressionPath = new List<PathFilter>();
			}
			this._currentIndex++;
			if (this.ParsePath(expressionPath, this._currentIndex, true))
			{
				throw new JsonException("Path ended with open query.");
			}
			return true;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0002F9A8 File Offset: 0x0002DBA8
		private JsonException CreateUnexpectedCharacterException()
		{
			return new JsonException("Unexpected character while parsing path query: " + this._expression[this._currentIndex].ToString());
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0002F9E0 File Offset: 0x0002DBE0
		private object ParseSide()
		{
			this.EatWhitespace();
			List<PathFilter> result;
			if (this.TryParseExpression(out result))
			{
				this.EatWhitespace();
				this.EnsureLength("Path ended with open query.");
				return result;
			}
			object value;
			if (this.TryParseValue(out value))
			{
				this.EatWhitespace();
				this.EnsureLength("Path ended with open query.");
				return new JValue(value);
			}
			throw this.CreateUnexpectedCharacterException();
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0002FA38 File Offset: 0x0002DC38
		private QueryExpression ParseExpression()
		{
			QueryExpression queryExpression = null;
			CompositeExpression compositeExpression = null;
			while (this._currentIndex < this._expression.Length)
			{
				object left = this.ParseSide();
				object right = null;
				QueryOperator @operator;
				if (this._expression[this._currentIndex] == ')' || this._expression[this._currentIndex] == '|' || this._expression[this._currentIndex] == '&')
				{
					@operator = QueryOperator.Exists;
				}
				else
				{
					@operator = this.ParseOperator();
					right = this.ParseSide();
				}
				BooleanQueryExpression booleanQueryExpression = new BooleanQueryExpression(@operator, left, right);
				if (this._expression[this._currentIndex] == ')')
				{
					if (compositeExpression != null)
					{
						compositeExpression.Expressions.Add(booleanQueryExpression);
						return queryExpression;
					}
					return booleanQueryExpression;
				}
				else
				{
					if (this._expression[this._currentIndex] == '&')
					{
						if (!this.Match("&&"))
						{
							throw this.CreateUnexpectedCharacterException();
						}
						if (compositeExpression == null || compositeExpression.Operator != QueryOperator.And)
						{
							CompositeExpression compositeExpression2 = new CompositeExpression(QueryOperator.And);
							if (compositeExpression != null)
							{
								compositeExpression.Expressions.Add(compositeExpression2);
							}
							compositeExpression = compositeExpression2;
							if (queryExpression == null)
							{
								queryExpression = compositeExpression;
							}
						}
						compositeExpression.Expressions.Add(booleanQueryExpression);
					}
					if (this._expression[this._currentIndex] == '|')
					{
						if (!this.Match("||"))
						{
							throw this.CreateUnexpectedCharacterException();
						}
						if (compositeExpression == null || compositeExpression.Operator != QueryOperator.Or)
						{
							CompositeExpression compositeExpression3 = new CompositeExpression(QueryOperator.Or);
							if (compositeExpression != null)
							{
								compositeExpression.Expressions.Add(compositeExpression3);
							}
							compositeExpression = compositeExpression3;
							if (queryExpression == null)
							{
								queryExpression = compositeExpression;
							}
						}
						compositeExpression.Expressions.Add(booleanQueryExpression);
					}
				}
			}
			throw new JsonException("Path ended with open query.");
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0002FBC8 File Offset: 0x0002DDC8
		[NullableContext(2)]
		private bool TryParseValue(out object value)
		{
			char c = this._expression[this._currentIndex];
			if (c == '\'')
			{
				value = this.ReadQuotedString();
				return true;
			}
			if (char.IsDigit(c) || c == '-')
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(c);
				this._currentIndex++;
				while (this._currentIndex < this._expression.Length)
				{
					c = this._expression[this._currentIndex];
					if (c == ' ' || c == ')')
					{
						string text = stringBuilder.ToString();
						if (text.IndexOfAny(JPath.FloatCharacters) != -1)
						{
							double num;
							bool result = double.TryParse(text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out num);
							value = num;
							return result;
						}
						long num2;
						bool result2 = long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out num2);
						value = num2;
						return result2;
					}
					else
					{
						stringBuilder.Append(c);
						this._currentIndex++;
					}
				}
			}
			else if (c == 't')
			{
				if (this.Match("true"))
				{
					value = true;
					return true;
				}
			}
			else if (c == 'f')
			{
				if (this.Match("false"))
				{
					value = false;
					return true;
				}
			}
			else if (c == 'n')
			{
				if (this.Match("null"))
				{
					value = null;
					return true;
				}
			}
			else if (c == '/')
			{
				value = this.ReadRegexString();
				return true;
			}
			value = null;
			return false;
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0002FD18 File Offset: 0x0002DF18
		private string ReadQuotedString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this._currentIndex++;
			while (this._currentIndex < this._expression.Length)
			{
				char c = this._expression[this._currentIndex];
				if (c == '\\' && this._currentIndex + 1 < this._expression.Length)
				{
					this._currentIndex++;
					c = this._expression[this._currentIndex];
					char value;
					if (c <= '\\')
					{
						if (c <= '\'')
						{
							if (c != '"' && c != '\'')
							{
								goto IL_CB;
							}
						}
						else if (c != '/' && c != '\\')
						{
							goto IL_CB;
						}
						value = c;
					}
					else if (c <= 'f')
					{
						if (c != 'b')
						{
							if (c != 'f')
							{
								goto IL_CB;
							}
							value = '\f';
						}
						else
						{
							value = '\b';
						}
					}
					else if (c != 'n')
					{
						if (c != 'r')
						{
							if (c != 't')
							{
								goto IL_CB;
							}
							value = '\t';
						}
						else
						{
							value = '\r';
						}
					}
					else
					{
						value = '\n';
					}
					stringBuilder.Append(value);
					this._currentIndex++;
					continue;
					IL_CB:
					throw new JsonException("Unknown escape character: \\" + c.ToString());
				}
				if (c == '\'')
				{
					this._currentIndex++;
					return stringBuilder.ToString();
				}
				this._currentIndex++;
				stringBuilder.Append(c);
			}
			throw new JsonException("Path ended with an open string.");
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0002FE70 File Offset: 0x0002E070
		private string ReadRegexString()
		{
			int currentIndex = this._currentIndex;
			this._currentIndex++;
			while (this._currentIndex < this._expression.Length)
			{
				char c = this._expression[this._currentIndex];
				if (c == '\\' && this._currentIndex + 1 < this._expression.Length)
				{
					this._currentIndex += 2;
				}
				else
				{
					if (c == '/')
					{
						this._currentIndex++;
						while (this._currentIndex < this._expression.Length)
						{
							c = this._expression[this._currentIndex];
							if (!char.IsLetter(c))
							{
								break;
							}
							this._currentIndex++;
						}
						return this._expression.Substring(currentIndex, this._currentIndex - currentIndex);
					}
					this._currentIndex++;
				}
			}
			throw new JsonException("Path ended with an open regex.");
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0002FF68 File Offset: 0x0002E168
		private bool Match(string s)
		{
			int num = this._currentIndex;
			for (int i = 0; i < s.Length; i++)
			{
				if (num >= this._expression.Length || this._expression[num] != s[i])
				{
					return false;
				}
				num++;
			}
			this._currentIndex = num;
			return true;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0002FFC0 File Offset: 0x0002E1C0
		private QueryOperator ParseOperator()
		{
			if (this._currentIndex + 1 >= this._expression.Length)
			{
				throw new JsonException("Path ended with open query.");
			}
			if (this.Match("==="))
			{
				return QueryOperator.StrictEquals;
			}
			if (this.Match("=="))
			{
				return QueryOperator.Equals;
			}
			if (this.Match("=~"))
			{
				return QueryOperator.RegexEquals;
			}
			if (this.Match("!=="))
			{
				return QueryOperator.StrictNotEquals;
			}
			if (this.Match("!=") || this.Match("<>"))
			{
				return QueryOperator.NotEquals;
			}
			if (this.Match("<="))
			{
				return QueryOperator.LessThanOrEquals;
			}
			if (this.Match("<"))
			{
				return QueryOperator.LessThan;
			}
			if (this.Match(">="))
			{
				return QueryOperator.GreaterThanOrEquals;
			}
			if (this.Match(">"))
			{
				return QueryOperator.GreaterThan;
			}
			throw new JsonException("Could not read query operator.");
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00030090 File Offset: 0x0002E290
		private PathFilter ParseQuotedField(char indexerCloseChar, bool scan)
		{
			List<string> list = null;
			while (this._currentIndex < this._expression.Length)
			{
				string text = this.ReadQuotedString();
				this.EatWhitespace();
				this.EnsureLength("Path ended with open indexer.");
				if (this._expression[this._currentIndex] == indexerCloseChar)
				{
					if (list == null)
					{
						return JPath.CreatePathFilter(text, scan);
					}
					list.Add(text);
					if (!scan)
					{
						return new FieldMultipleFilter(list);
					}
					return new ScanMultipleFilter(list);
				}
				else
				{
					if (this._expression[this._currentIndex] != ',')
					{
						throw new JsonException("Unexpected character while parsing path indexer: " + this._expression[this._currentIndex].ToString());
					}
					this._currentIndex++;
					this.EatWhitespace();
					if (list == null)
					{
						list = new List<string>();
					}
					list.Add(text);
				}
			}
			throw new JsonException("Path ended with open indexer.");
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00030177 File Offset: 0x0002E377
		private void EnsureLength(string message)
		{
			if (this._currentIndex >= this._expression.Length)
			{
				throw new JsonException(message);
			}
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00030193 File Offset: 0x0002E393
		internal IEnumerable<JToken> Evaluate(JToken root, JToken t, bool errorWhenNoMatch)
		{
			return JPath.Evaluate(this.Filters, root, t, errorWhenNoMatch);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x000301A4 File Offset: 0x0002E3A4
		internal static IEnumerable<JToken> Evaluate(List<PathFilter> filters, JToken root, JToken t, bool errorWhenNoMatch)
		{
			IEnumerable<JToken> enumerable = new JToken[]
			{
				t
			};
			foreach (PathFilter pathFilter in filters)
			{
				enumerable = pathFilter.ExecuteFilter(root, enumerable, errorWhenNoMatch);
			}
			return enumerable;
		}

		// Token: 0x040003B2 RID: 946
		private static readonly char[] FloatCharacters = new char[]
		{
			'.',
			'E',
			'e'
		};

		// Token: 0x040003B3 RID: 947
		private readonly string _expression;

		// Token: 0x040003B5 RID: 949
		private int _currentIndex;
	}
}
