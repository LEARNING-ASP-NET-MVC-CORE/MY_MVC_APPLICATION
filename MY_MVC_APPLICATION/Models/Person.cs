namespace Models
{
	public class Person : BaseEntity
	{
		public Person() : base()
		{
		}

		// **********
		public int Age { get; set; }
		// **********

		// **********
		public string FullName { get; set; }
		// **********
	}
}
