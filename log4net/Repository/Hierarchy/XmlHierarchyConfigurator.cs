using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Xml;
using log4net.Appender;
using log4net.Core;
using log4net.ObjectRenderer;
using log4net.Util;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x0200005E RID: 94
	public class XmlHierarchyConfigurator
	{
		// Token: 0x0600031E RID: 798 RVA: 0x00009355 File Offset: 0x00008355
		public XmlHierarchyConfigurator(Hierarchy hierarchy)
		{
			this.m_hierarchy = hierarchy;
			this.m_appenderBag = new Hashtable();
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00009370 File Offset: 0x00008370
		public void Configure(XmlElement element)
		{
			if (element == null || this.m_hierarchy == null)
			{
				return;
			}
			if (element.LocalName != "log4net")
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "Xml element is - not a <log4net> element.");
				return;
			}
			if (!LogLog.EmitInternalMessages)
			{
				string attribute = element.GetAttribute("emitDebug");
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, "emitDebug attribute [" + attribute + "].");
				if (attribute.Length > 0 && attribute != "null")
				{
					LogLog.EmitInternalMessages = OptionConverter.ToBoolean(attribute, true);
				}
				else
				{
					LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Ignoring emitDebug attribute.");
				}
			}
			if (!LogLog.InternalDebugging)
			{
				string attribute2 = element.GetAttribute("debug");
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, "debug attribute [" + attribute2 + "].");
				if (attribute2.Length > 0 && attribute2 != "null")
				{
					LogLog.InternalDebugging = OptionConverter.ToBoolean(attribute2, true);
				}
				else
				{
					LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Ignoring debug attribute.");
				}
				string attribute3 = element.GetAttribute("configDebug");
				if (attribute3.Length > 0 && attribute3 != "null")
				{
					LogLog.Warn(XmlHierarchyConfigurator.declaringType, "The \"configDebug\" attribute is deprecated.");
					LogLog.Warn(XmlHierarchyConfigurator.declaringType, "Use the \"debug\" attribute instead.");
					LogLog.InternalDebugging = OptionConverter.ToBoolean(attribute3, true);
				}
			}
			XmlHierarchyConfigurator.ConfigUpdateMode configUpdateMode = XmlHierarchyConfigurator.ConfigUpdateMode.Merge;
			string attribute4 = element.GetAttribute("update");
			if (attribute4 != null && attribute4.Length > 0)
			{
				try
				{
					configUpdateMode = (XmlHierarchyConfigurator.ConfigUpdateMode)OptionConverter.ConvertStringTo(typeof(XmlHierarchyConfigurator.ConfigUpdateMode), attribute4);
				}
				catch
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, "Invalid update attribute value [" + attribute4 + "]");
				}
			}
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Configuration update mode [" + configUpdateMode.ToString() + "].");
			if (configUpdateMode == XmlHierarchyConfigurator.ConfigUpdateMode.Overwrite)
			{
				this.m_hierarchy.ResetConfiguration();
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Configuration reset before reading config.");
			}
			foreach (object obj in element.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.LocalName == "logger")
					{
						this.ParseLogger(xmlElement);
					}
					else if (xmlElement.LocalName == "category")
					{
						this.ParseLogger(xmlElement);
					}
					else if (xmlElement.LocalName == "root")
					{
						this.ParseRoot(xmlElement);
					}
					else if (xmlElement.LocalName == "renderer")
					{
						this.ParseRenderer(xmlElement);
					}
					else if (!(xmlElement.LocalName == "appender"))
					{
						this.SetParameter(xmlElement, this.m_hierarchy);
					}
				}
			}
			string attribute5 = element.GetAttribute("threshold");
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Hierarchy Threshold [" + attribute5 + "]");
			if (attribute5.Length > 0 && attribute5 != "null")
			{
				Level level = (Level)this.ConvertStringTo(typeof(Level), attribute5);
				if (level != null)
				{
					this.m_hierarchy.Threshold = level;
					return;
				}
				LogLog.Warn(XmlHierarchyConfigurator.declaringType, "Unable to set hierarchy threshold using value [" + attribute5 + "] (with acceptable conversion types)");
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000096E8 File Offset: 0x000086E8
		protected IAppender FindAppenderByReference(XmlElement appenderRef)
		{
			string attribute = appenderRef.GetAttribute("ref");
			IAppender appender = (IAppender)this.m_appenderBag[attribute];
			if (appender != null)
			{
				return appender;
			}
			XmlElement xmlElement = null;
			if (attribute != null && attribute.Length > 0)
			{
				foreach (object obj in appenderRef.OwnerDocument.GetElementsByTagName("appender"))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					if (xmlElement2.GetAttribute("name") == attribute)
					{
						xmlElement = xmlElement2;
						break;
					}
				}
			}
			if (xmlElement == null)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "XmlHierarchyConfigurator: No appender named [" + attribute + "] could be found.");
				return null;
			}
			appender = this.ParseAppender(xmlElement);
			if (appender != null)
			{
				this.m_appenderBag[attribute] = appender;
			}
			return appender;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000097CC File Offset: 0x000087CC
		protected IAppender ParseAppender(XmlElement appenderElement)
		{
			string attribute = appenderElement.GetAttribute("name");
			string attribute2 = appenderElement.GetAttribute("type");
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
			{
				"Loading Appender [",
				attribute,
				"] type: [",
				attribute2,
				"]"
			}));
			IAppender result;
			try
			{
				IAppender appender = (IAppender)Activator.CreateInstance(SystemInfo.GetTypeFromString(attribute2, true, true));
				appender.Name = attribute;
				foreach (object obj in appenderElement.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					if (xmlNode.NodeType == XmlNodeType.Element)
					{
						XmlElement xmlElement = (XmlElement)xmlNode;
						if (xmlElement.LocalName == "appender-ref")
						{
							string attribute3 = xmlElement.GetAttribute("ref");
							IAppenderAttachable appenderAttachable = appender as IAppenderAttachable;
							if (appenderAttachable != null)
							{
								LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
								{
									"Attaching appender named [",
									attribute3,
									"] to appender named [",
									appender.Name,
									"]."
								}));
								IAppender appender2 = this.FindAppenderByReference(xmlElement);
								if (appender2 != null)
								{
									appenderAttachable.AddAppender(appender2);
								}
							}
							else
							{
								LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
								{
									"Requesting attachment of appender named [",
									attribute3,
									"] to appender named [",
									appender.Name,
									"] which does not implement log4net.Core.IAppenderAttachable."
								}));
							}
						}
						else
						{
							this.SetParameter(xmlElement, appender);
						}
					}
				}
				IOptionHandler optionHandler = appender as IOptionHandler;
				if (optionHandler != null)
				{
					optionHandler.ActivateOptions();
				}
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Created Appender [" + attribute + "]");
				result = appender;
			}
			catch (Exception exception)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Could not create Appender [",
					attribute,
					"] of type [",
					attribute2,
					"]. Reported error follows."
				}), exception);
				result = null;
			}
			return result;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00009A08 File Offset: 0x00008A08
		protected void ParseLogger(XmlElement loggerElement)
		{
			string attribute = loggerElement.GetAttribute("name");
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Retrieving an instance of log4net.Repository.Logger for logger [" + attribute + "].");
			Logger logger = this.m_hierarchy.GetLogger(attribute) as Logger;
			Logger obj = logger;
			lock (obj)
			{
				bool additivity = OptionConverter.ToBoolean(loggerElement.GetAttribute("additivity"), true);
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Setting [",
					logger.Name,
					"] additivity to [",
					additivity.ToString(),
					"]."
				}));
				logger.Additivity = additivity;
				this.ParseChildrenOfLoggerElement(loggerElement, logger, false);
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00009ADC File Offset: 0x00008ADC
		protected void ParseRoot(XmlElement rootElement)
		{
			Logger root = this.m_hierarchy.Root;
			Logger obj = root;
			lock (obj)
			{
				this.ParseChildrenOfLoggerElement(rootElement, root, true);
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00009B28 File Offset: 0x00008B28
		protected void ParseChildrenOfLoggerElement(XmlElement catElement, Logger log, bool isRoot)
		{
			log.RemoveAllAppenders();
			foreach (object obj in catElement.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.LocalName == "appender-ref")
					{
						IAppender appender = this.FindAppenderByReference(xmlElement);
						string attribute = xmlElement.GetAttribute("ref");
						if (appender != null)
						{
							LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
							{
								"Adding appender named [",
								attribute,
								"] to logger [",
								log.Name,
								"]."
							}));
							log.AddAppender(appender);
						}
						else
						{
							LogLog.Error(XmlHierarchyConfigurator.declaringType, "Appender named [" + attribute + "] not found.");
						}
					}
					else if (xmlElement.LocalName == "level" || xmlElement.LocalName == "priority")
					{
						this.ParseLevel(xmlElement, log, isRoot);
					}
					else
					{
						this.SetParameter(xmlElement, log);
					}
				}
			}
			IOptionHandler optionHandler = log as IOptionHandler;
			if (optionHandler != null)
			{
				optionHandler.ActivateOptions();
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00009C74 File Offset: 0x00008C74
		protected void ParseRenderer(XmlElement element)
		{
			string attribute = element.GetAttribute("renderingClass");
			string attribute2 = element.GetAttribute("renderedClass");
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
			{
				"Rendering class [",
				attribute,
				"], Rendered class [",
				attribute2,
				"]."
			}));
			IObjectRenderer objectRenderer = (IObjectRenderer)OptionConverter.InstantiateByClassName(attribute, typeof(IObjectRenderer), null);
			if (objectRenderer == null)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "Could not instantiate renderer [" + attribute + "].");
				return;
			}
			try
			{
				this.m_hierarchy.RendererMap.Put(SystemInfo.GetTypeFromString(attribute2, true, true), objectRenderer);
			}
			catch (Exception exception)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "Could not find class [" + attribute2 + "].", exception);
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00009D50 File Offset: 0x00008D50
		protected void ParseLevel(XmlElement element, Logger log, bool isRoot)
		{
			string text = log.Name;
			if (isRoot)
			{
				text = "root";
			}
			string attribute = element.GetAttribute("value");
			LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
			{
				"Logger [",
				text,
				"] Level string is [",
				attribute,
				"]."
			}));
			if ("inherited" == attribute)
			{
				if (isRoot)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, "Root level cannot be inherited. Ignoring directive.");
					return;
				}
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Logger [" + text + "] level set to inherit from parent.");
				log.Level = null;
				return;
			}
			else
			{
				log.Level = log.Hierarchy.LevelMap[attribute];
				if (log.Level == null)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Undefined level [",
						attribute,
						"] on Logger [",
						text,
						"]."
					}));
					return;
				}
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Logger [",
					text,
					"] level set to [name=\"",
					log.Level.Name,
					"\",value=",
					log.Level.Value.ToString(),
					"]."
				}));
				return;
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00009EA8 File Offset: 0x00008EA8
		protected void SetParameter(XmlElement element, object target)
		{
			string text = element.GetAttribute("name");
			if (element.LocalName != "param" || text == null || text.Length == 0)
			{
				text = element.LocalName;
			}
			Type type = target.GetType();
			Type type2 = null;
			PropertyInfo propertyInfo = null;
			MethodInfo methodInfo = null;
			propertyInfo = type.GetProperty(text, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (propertyInfo != null && propertyInfo.CanWrite)
			{
				type2 = propertyInfo.PropertyType;
			}
			else
			{
				propertyInfo = null;
				methodInfo = this.FindMethodInfo(type, text);
				if (methodInfo != null)
				{
					type2 = methodInfo.GetParameters()[0].ParameterType;
				}
			}
			if (type2 == null)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"XmlHierarchyConfigurator: Cannot find Property [",
					text,
					"] to set object on [",
					target.ToString(),
					"]"
				}));
				return;
			}
			string text2 = null;
			if (element.GetAttributeNode("value") != null)
			{
				text2 = element.GetAttribute("value");
			}
			else if (element.HasChildNodes)
			{
				foreach (object obj in element.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					if (xmlNode.NodeType == XmlNodeType.CDATA || xmlNode.NodeType == XmlNodeType.Text)
					{
						if (text2 == null)
						{
							text2 = xmlNode.InnerText;
						}
						else
						{
							text2 += xmlNode.InnerText;
						}
					}
				}
			}
			if (text2 != null)
			{
				try
				{
					IDictionary dictionary = Environment.GetEnvironmentVariables();
					if (this.HasCaseInsensitiveEnvironment)
					{
						dictionary = this.CreateCaseInsensitiveWrapper(dictionary);
					}
					text2 = OptionConverter.SubstituteVariables(text2, dictionary);
				}
				catch (SecurityException)
				{
					LogLog.Debug(XmlHierarchyConfigurator.declaringType, "Security exception while trying to expand environment variables. Error Ignored. No Expansion.");
				}
				Type type3 = null;
				string attribute = element.GetAttribute("type");
				if (attribute != null && attribute.Length > 0)
				{
					try
					{
						Type typeFromString = SystemInfo.GetTypeFromString(attribute, true, true);
						LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
						{
							"Parameter [",
							text,
							"] specified subtype [",
							typeFromString.FullName,
							"]"
						}));
						if (!type2.IsAssignableFrom(typeFromString))
						{
							if (OptionConverter.CanConvertTypeTo(typeFromString, type2))
							{
								type3 = type2;
								type2 = typeFromString;
							}
							else
							{
								LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
								{
									"subtype [",
									typeFromString.FullName,
									"] set on [",
									text,
									"] is not a subclass of property type [",
									type2.FullName,
									"] and there are no acceptable type conversions."
								}));
							}
						}
						else
						{
							type2 = typeFromString;
						}
					}
					catch (Exception exception)
					{
						LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
						{
							"Failed to find type [",
							attribute,
							"] set on [",
							text,
							"]"
						}), exception);
					}
				}
				object obj2 = this.ConvertStringTo(type2, text2);
				if (obj2 != null && type3 != null)
				{
					LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Performing additional conversion of value from [",
						obj2.GetType().Name,
						"] to [",
						type3.Name,
						"]"
					}));
					obj2 = OptionConverter.ConvertTypeTo(obj2, type3);
				}
				if (obj2 != null)
				{
					if (propertyInfo != null)
					{
						LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
						{
							"Setting Property [",
							propertyInfo.Name,
							"] to ",
							obj2.GetType().Name,
							" value [",
							obj2.ToString(),
							"]"
						}));
						try
						{
							propertyInfo.SetValue(target, obj2, BindingFlags.SetProperty, null, null, CultureInfo.InvariantCulture);
							return;
						}
						catch (TargetInvocationException ex)
						{
							LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
							{
								"Failed to set parameter [",
								propertyInfo.Name,
								"] on object [",
								(target != null) ? target.ToString() : null,
								"] using value [",
								(obj2 != null) ? obj2.ToString() : null,
								"]"
							}), ex.InnerException);
							return;
						}
					}
					if (!(methodInfo != null))
					{
						return;
					}
					LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Setting Collection Property [",
						methodInfo.Name,
						"] to ",
						obj2.GetType().Name,
						" value [",
						obj2.ToString(),
						"]"
					}));
					try
					{
						methodInfo.Invoke(target, BindingFlags.InvokeMethod, null, new object[]
						{
							obj2
						}, CultureInfo.InvariantCulture);
						return;
					}
					catch (TargetInvocationException ex2)
					{
						LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
						{
							"Failed to set parameter [",
							text,
							"] on object [",
							(target != null) ? target.ToString() : null,
							"] using value [",
							(obj2 != null) ? obj2.ToString() : null,
							"]"
						}), ex2.InnerException);
						return;
					}
				}
				LogLog.Warn(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Unable to set property [",
					text,
					"] on object [",
					(target != null) ? target.ToString() : null,
					"] using value [",
					text2,
					"] (with acceptable conversion types)"
				}));
				return;
			}
			object obj3 = null;
			if (type2 == typeof(string) && !this.HasAttributesOrElements(element))
			{
				obj3 = "";
			}
			else
			{
				Type defaultTargetType = null;
				if (XmlHierarchyConfigurator.IsTypeConstructible(type2))
				{
					defaultTargetType = type2;
				}
				obj3 = this.CreateObjectFromXml(element, defaultTargetType, type2);
			}
			if (obj3 == null)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "Failed to create object to set param: " + text);
				return;
			}
			if (propertyInfo != null)
			{
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Setting Property [",
					propertyInfo.Name,
					"] to object [",
					(obj3 != null) ? obj3.ToString() : null,
					"]"
				}));
				try
				{
					propertyInfo.SetValue(target, obj3, BindingFlags.SetProperty, null, null, CultureInfo.InvariantCulture);
					return;
				}
				catch (TargetInvocationException ex3)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Failed to set parameter [",
						propertyInfo.Name,
						"] on object [",
						(target != null) ? target.ToString() : null,
						"] using value [",
						(obj3 != null) ? obj3.ToString() : null,
						"]"
					}), ex3.InnerException);
					return;
				}
			}
			if (methodInfo != null)
			{
				LogLog.Debug(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
				{
					"Setting Collection Property [",
					methodInfo.Name,
					"] to object [",
					(obj3 != null) ? obj3.ToString() : null,
					"]"
				}));
				try
				{
					methodInfo.Invoke(target, BindingFlags.InvokeMethod, null, new object[]
					{
						obj3
					}, CultureInfo.InvariantCulture);
				}
				catch (TargetInvocationException ex4)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Failed to set parameter [",
						methodInfo.Name,
						"] on object [",
						(target != null) ? target.ToString() : null,
						"] using value [",
						(obj3 != null) ? obj3.ToString() : null,
						"]"
					}), ex4.InnerException);
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000A670 File Offset: 0x00009670
		private bool HasAttributesOrElements(XmlElement element)
		{
			foreach (object obj in element.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.NodeType == XmlNodeType.Attribute || xmlNode.NodeType == XmlNodeType.Element)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000A6DC File Offset: 0x000096DC
		private static bool IsTypeConstructible(Type type)
		{
			if (type.IsClass && !type.IsAbstract)
			{
				ConstructorInfo constructor = type.GetConstructor(new Type[0]);
				if (constructor != null && !constructor.IsAbstract && !constructor.IsPrivate)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000A724 File Offset: 0x00009724
		private MethodInfo FindMethodInfo(Type targetType, string name)
		{
			string b = "Add" + name;
			foreach (MethodInfo methodInfo in targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (!methodInfo.IsStatic)
				{
					string name2 = methodInfo.Name;
					if ((SystemInfo.EqualsIgnoringCase(name2, name) || SystemInfo.EqualsIgnoringCase(name2, b)) && methodInfo.GetParameters().Length == 1)
					{
						return methodInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000A794 File Offset: 0x00009794
		protected object ConvertStringTo(Type type, string value)
		{
			if (typeof(Level) == type)
			{
				Level level = this.m_hierarchy.LevelMap[value];
				if (level == null)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, "XmlHierarchyConfigurator: Unknown Level Specified [" + value + "]");
				}
				return level;
			}
			return OptionConverter.ConvertStringTo(type, value);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000A7F0 File Offset: 0x000097F0
		protected object CreateObjectFromXml(XmlElement element, Type defaultTargetType, Type typeConstraint)
		{
			Type type = null;
			string attribute = element.GetAttribute("type");
			if (attribute == null || attribute.Length == 0)
			{
				if (defaultTargetType == null)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, "Object type not specified. Cannot create object of type [" + typeConstraint.FullName + "]. Missing Value or Type.");
					return null;
				}
				type = defaultTargetType;
			}
			else
			{
				try
				{
					type = SystemInfo.GetTypeFromString(attribute, true, true);
				}
				catch (Exception exception)
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, "Failed to find type [" + attribute + "]", exception);
					return null;
				}
			}
			bool flag = false;
			if (typeConstraint != null && !typeConstraint.IsAssignableFrom(type))
			{
				if (!OptionConverter.CanConvertTypeTo(type, typeConstraint))
				{
					LogLog.Error(XmlHierarchyConfigurator.declaringType, string.Concat(new string[]
					{
						"Object type [",
						type.FullName,
						"] is not assignable to type [",
						typeConstraint.FullName,
						"]. There are no acceptable type conversions."
					}));
					return null;
				}
				flag = true;
			}
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				LogLog.Error(XmlHierarchyConfigurator.declaringType, "XmlHierarchyConfigurator: Failed to construct object of type [" + type.FullName + "] Exception: " + ex.ToString());
			}
			foreach (object obj2 in element.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj2;
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					this.SetParameter((XmlElement)xmlNode, obj);
				}
			}
			IOptionHandler optionHandler = obj as IOptionHandler;
			if (optionHandler != null)
			{
				optionHandler.ActivateOptions();
			}
			if (flag)
			{
				return OptionConverter.ConvertTypeTo(obj, typeConstraint);
			}
			return obj;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000A9AC File Offset: 0x000099AC
		private bool HasCaseInsensitiveEnvironment
		{
			get
			{
				PlatformID platform = Environment.OSVersion.Platform;
				return platform != PlatformID.Unix && platform != PlatformID.MacOSX;
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000A9D4 File Offset: 0x000099D4
		private IDictionary CreateCaseInsensitiveWrapper(IDictionary dict)
		{
			if (dict == null)
			{
				return dict;
			}
			Hashtable hashtable = SystemInfo.CreateCaseInsensitiveHashtable();
			foreach (object obj in dict)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				hashtable[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
			return hashtable;
		}

		// Token: 0x040000A9 RID: 169
		private const string CONFIGURATION_TAG = "log4net";

		// Token: 0x040000AA RID: 170
		private const string RENDERER_TAG = "renderer";

		// Token: 0x040000AB RID: 171
		private const string APPENDER_TAG = "appender";

		// Token: 0x040000AC RID: 172
		private const string APPENDER_REF_TAG = "appender-ref";

		// Token: 0x040000AD RID: 173
		private const string PARAM_TAG = "param";

		// Token: 0x040000AE RID: 174
		private const string CATEGORY_TAG = "category";

		// Token: 0x040000AF RID: 175
		private const string PRIORITY_TAG = "priority";

		// Token: 0x040000B0 RID: 176
		private const string LOGGER_TAG = "logger";

		// Token: 0x040000B1 RID: 177
		private const string NAME_ATTR = "name";

		// Token: 0x040000B2 RID: 178
		private const string TYPE_ATTR = "type";

		// Token: 0x040000B3 RID: 179
		private const string VALUE_ATTR = "value";

		// Token: 0x040000B4 RID: 180
		private const string ROOT_TAG = "root";

		// Token: 0x040000B5 RID: 181
		private const string LEVEL_TAG = "level";

		// Token: 0x040000B6 RID: 182
		private const string REF_ATTR = "ref";

		// Token: 0x040000B7 RID: 183
		private const string ADDITIVITY_ATTR = "additivity";

		// Token: 0x040000B8 RID: 184
		private const string THRESHOLD_ATTR = "threshold";

		// Token: 0x040000B9 RID: 185
		private const string CONFIG_DEBUG_ATTR = "configDebug";

		// Token: 0x040000BA RID: 186
		private const string INTERNAL_DEBUG_ATTR = "debug";

		// Token: 0x040000BB RID: 187
		private const string EMIT_INTERNAL_DEBUG_ATTR = "emitDebug";

		// Token: 0x040000BC RID: 188
		private const string CONFIG_UPDATE_MODE_ATTR = "update";

		// Token: 0x040000BD RID: 189
		private const string RENDERING_TYPE_ATTR = "renderingClass";

		// Token: 0x040000BE RID: 190
		private const string RENDERED_TYPE_ATTR = "renderedClass";

		// Token: 0x040000BF RID: 191
		private const string INHERITED = "inherited";

		// Token: 0x040000C0 RID: 192
		private Hashtable m_appenderBag;

		// Token: 0x040000C1 RID: 193
		private readonly Hierarchy m_hierarchy;

		// Token: 0x040000C2 RID: 194
		private static readonly Type declaringType = typeof(XmlHierarchyConfigurator);

		// Token: 0x020000FA RID: 250
		private enum ConfigUpdateMode
		{
			// Token: 0x04000266 RID: 614
			Merge,
			// Token: 0x04000267 RID: 615
			Overwrite
		}
	}
}
