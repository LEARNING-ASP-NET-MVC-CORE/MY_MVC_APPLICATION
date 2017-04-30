namespace Infrastructure
{
	public class JsonSerializerSettings : Newtonsoft.Json.JsonSerializerSettings
	{
		private static JsonSerializerSettings _instance;

		public static JsonSerializerSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance =
						new JsonSerializerSettings();
				}

				return (_instance);
			}
		}

		public JsonSerializerSettings() : base()
		{
			Formatting = Newtonsoft.Json.Formatting.Indented; // Default: [None]
			TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None; // Default: [None]

			ContractResolver =
				new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(); // Default: [None]

			//this.CheckAdditionalContent = true;
			//this.ConstructorHandling = Newtonsoft.Json.ConstructorHandling.AllowNonPublicDefaultConstructor;
			//this.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
			//this.DateParseHandling = Newtonsoft.Json.DateParseHandling.None;
			//this.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
			//this.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
			//this.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.DefaultValue;
			//this.FloatParseHandling = Newtonsoft.Json.FloatParseHandling.Double;
			//this.MaxDepth = 5;
			//this.MetadataPropertyHandling = Newtonsoft.Json.MetadataPropertyHandling.Default;
			//this.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
			//this.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
			//this.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Auto;
			//this.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
			//this.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			//this.StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.Default;
			//this.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full;
		}
	}
}
