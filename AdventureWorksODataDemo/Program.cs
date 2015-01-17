
using System;
using System.Linq;
using AdventureWorksODataDemo.AdventureWorksService;

namespace AdventureWorksODataDemo
{
	class Program
	{
		static void Main()
		{
			Uri adventureWorksServiceUri = new Uri("http://services.odata.org/AdventureWorksV3/AdventureWorks.svc/");
			AdventureWorksEntities adventureWorksEntities = new AdventureWorksEntities(adventureWorksServiceUri);

			var query = from p in adventureWorksEntities.ProductCatalog select p;

			foreach (vProductCatalog p in query)
			{
				Console.WriteLine("{0} {1}",p.ID, p.ProductName);
			}

			Console.ReadKey();
		}
	}
}
