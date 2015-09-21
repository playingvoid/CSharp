using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.IO;

namespace EmployeeService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeServiceImpl" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeServiceImpl.svc or EmployeeServiceImpl.svc.cs at the Solution Explorer and start debugging.
	[ServiceBehavior(Namespace = "http://schemas.datacontract.org/2004/07/Domain.Model")]
	public class EmployeeServiceImpl : IEmployeeServiceImpl
	{
		public string XMLData(string id)
		{
			return "You requested: " + id;
		}

		public List<ActiveEmployee> ActiveEmployees(string id)
		{
			ServiceSecurityContext securityCtx = OperationContext.Current.ServiceSecurityContext;
			
			return EmployeeCreator.ReadActiveEmloyees();
		}

		public List<ActiveEmployee> ActiveEmployees2(string id)
		{
			ServiceSecurityContext securityCtx = OperationContext.Current.ServiceSecurityContext;

			return EmployeeCreator.ReadActiveEmloyees2();
		}

		public string JSONData(string id)
		{
			return "You requested: " + id;
		}
	}
}
