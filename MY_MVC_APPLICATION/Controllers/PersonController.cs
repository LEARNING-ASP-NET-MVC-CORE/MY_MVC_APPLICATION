namespace MY_MVC_APPLICATION.Controllers
{
	// Note: Just For All Actions of Controller
	//[Microsoft.AspNetCore.Cors.EnableCors(policyName: "AllowSpecificOrigin")]
	public class PersonController : Infrastructure.BaseController
	{
		public PersonController() : base()
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		// Note: Just For Action
		//[Microsoft.AspNetCore.Cors.EnableCors(policyName: "AllowSpecificOrigin")]
		public Microsoft.AspNetCore.Mvc.IActionResult GetAll()
		{
			System.Collections.Generic.List<Models.Person>
				people = new System.Collections.Generic.List<Models.Person>();

			for (int intIndex = 1; intIndex <= 10; intIndex++)
			{
				Models.Person person =
					new Models.Person()
					{
						Age = 20 + intIndex,
						FullName = "Full Name " + intIndex,
					};

				people.Add(person);
			}

			return (Json(data: people));
			//return (Json(data: people,
			//	serializerSettings: Infrastructure.JsonSerializerSettings.Instance));
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]

		// Note: دستور ذیل کار نمی‌کند
		//public Microsoft.AspNetCore.Mvc.IActionResult Create(Models.Person person)

		// Note: دستور ذیل کار نمی‌کند
		//public Microsoft.AspNetCore.Mvc.IActionResult Create(string fullName, int age)

		// Note: دستور ذیل کار نمی‌کند
		//public Microsoft.AspNetCore.Mvc.IActionResult Create
		//	([Microsoft.AspNetCore.Mvc.FromBody] string fullName, [Microsoft.AspNetCore.Mvc.FromBody] int age)

		public Microsoft.AspNetCore.Mvc.IActionResult Create
			([Microsoft.AspNetCore.Mvc.FromBody] Models.Person person)
		{
			return (Json(data: person,
				serializerSettings: Infrastructure.JsonSerializerSettings.Instance));

			//Models.Person newPerson =
			//	new Models.Person()
			//	{
			//		Age = age,
			//		FullName = fullName,
			//	};

			//return (Json(data: newPerson,
			//	serializerSettings: Infrastructure.JsonSerializerSettings.Instance));
		}
	}
}
