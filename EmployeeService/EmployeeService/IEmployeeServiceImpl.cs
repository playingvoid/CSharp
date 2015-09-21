using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace EmployeeService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeServiceImpl" in both code and config file together.
	[ServiceContract(Namespace="http://schemas.datacontract.org/2004/07/Domain.Model")]
	public interface IEmployeeServiceImpl
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle= WebMessageBodyStyle.Wrapped, UriTemplate = "xml/{id}")]
		string XMLData(string id);

		[OperationContract]
		//[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "activeemp/{id}")]
		[WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "activeemp/{id}")]
		List<ActiveEmployee> ActiveEmployees(string id);

		[OperationContract]
		//[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "activeemp/{id}")]
		[WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "activeemp2/{id}")]
		List<ActiveEmployee> ActiveEmployees2(string id);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
		string JSONData(string id);

	}
}
