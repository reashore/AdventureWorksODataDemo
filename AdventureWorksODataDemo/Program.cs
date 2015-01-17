
using System;
using System.Data.Services.Client;
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

			IQueryable<vProductCatalog> query1 = from p in adventureWorksEntities.ProductCatalog select p;

			foreach (vProductCatalog p in query1)
			{
				Console.WriteLine("{0} {1}",p.ID, p.ProductName);
			}

			Console.WriteLine("End of query1");

			DataServiceQuery<vProductCatalog> query2 = adventureWorksEntities.ProductCatalog;
			QueryOperationResponse<vProductCatalog> response = (QueryOperationResponse<vProductCatalog>)query2.Execute();

			//long totalCount = response.TotalCount;
			int statusCode = response.StatusCode;

			foreach (vProductCatalog p in response)
			{
				Console.WriteLine("{0} {1}", p.ID, p.ProductName);
			}

			Console.WriteLine("End of query2");

			Console.ReadKey();
		}
	}
}
