using System;
using System.IO;
using System.Net;
using System.Text;

using SAFE.AgentFramework;

namespace SAFE.ODBC.ODBCRestAgent
{
	class RESTClient
	{
		public enum HttpAction
		{
			GET,
			POST,
			PUT,
			DELETE
		}

		public string EndPoint { get; set; }
		public HttpAction Method { get; set; }
		public string ContentType { get; set; }
		public string PostData { get; set; }
		private string _username;
		private string _password;
		private Context _context;

		#region constructors

		public RESTClient(Context context, string username = null, string password = null)
		{
			_context = context;
			_username = username;
			_password = password;
			EndPoint = "";
			Method = HttpAction.GET;
			ContentType = "text/xml";
			PostData = "";
		}

		public RESTClient(string endpoint, Context context, string username = null, string password = null)
			: this(context, username, password)
		{
			EndPoint = endpoint;
		}

		public RESTClient(string endpoint, HttpAction method, Context context, string username = null, string password = null)
			: this(endpoint, context, username, password)
		{
			Method = method;
		}

		public RESTClient(string endpoint, HttpAction method, string postData, Context context, string username = null, string password = null)
			: this(endpoint, method, context, username, password)
		{
			PostData = postData;
		}

		#endregion

		#region public functions

		public string Request()
		{
			return Request("");
		}

		public string Request(string parameters)
		{
			_context.Logger.LogTrace("Making REST request");
			//Create a request object for the content asked for
			//append any request parameter if asked for
			var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
			request.Method = Method.ToString();	//GET or POST or PUT or DELETE
			request.ContentLength = 0;			//
			request.ContentType = ContentType;	//"text/xml"

			_context.Logger.LogTrace(string.Format("Request Endpoint: {0}", (EndPoint + parameters)));
			_context.Logger.LogTrace(string.Format("Request Method: {0}", Method.ToString()));
			_context.Logger.LogTrace(string.Format("Request Content Type: {0}", ContentType));

			
			if (null != _username && null != _password)
			{
				//request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(_username + ":" + _password)));
				//request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(_username + ":" + _password)));
				string[] domainUsername = _username.Split('\\');
				if (domainUsername.Length > 1)
				{
					request.Credentials = new NetworkCredential(domainUsername [ 1 ], _password, domainUsername [ 0 ]);
					_context.Logger.LogTrace("Request Credentials: *****\\*****:*****");
				}
				else
				{
					_context.Logger.LogTrace("Request Credentials: *****:*****");
					request.Credentials = new NetworkCredential(_username, _password);
				}
			}

			//For post request write the post body to the content 
			if (!string.IsNullOrEmpty(PostData) && Method == HttpAction.POST)
			{
				var encoding = new UTF8Encoding();
				var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
				request.ContentLength = bytes.Length;

				//Write the post data to the byte stream
				using (var writeStream = request.GetRequestStream())
				{
					writeStream.Write(bytes, 0, bytes.Length);
				}
			}
			try
			{
				_context.Logger.LogTrace(string.Format("Request Content Length: {0}", request.ContentLength.ToString()));

				using (var response = (HttpWebResponse)request.GetResponse())
				{
					var responseValue = string.Empty;

					if (response.StatusCode != HttpStatusCode.OK)
					{
						var message = String.Format("ERROR: REST Request failed. Received HTTP {0}", response.StatusCode);
						throw new ApplicationException(message);
					}

					// grab the response
					using (var responseStream = response.GetResponseStream())
					{
						if (responseStream != null)
							using (var reader = new StreamReader(responseStream))
							{
								responseValue = reader.ReadToEnd();
							}
					}
					_context.Logger.LogTrace("REST request Successful");
					return responseValue;
				}
			}
			catch (WebException e)
			{
				StringBuilder exceptionMessage = new StringBuilder("ERROR in making the REST Call");
				exceptionMessage.AppendFormat(": [status:{0}, {1}]", e.Status, e.Message);
				if (e.Response != null)
				{
					using (WebResponse errResponse = e.Response)
					{
						HttpWebResponse httpResponse = (HttpWebResponse)errResponse;

						exceptionMessage.Append(", StatusCode = " + httpResponse.StatusCode);

						using (Stream data = httpResponse.GetResponseStream())
						using (var reader = new StreamReader(data))
						{
							string text = reader.ReadToEnd();
							exceptionMessage.Append(", description:" + text);
						}
					}
				}
				_context.Logger.LogError("{0}", exceptionMessage.ToString());
				throw e;
			}
			catch(Exception e)
			{
				_context.Logger.LogError("ERROR in making the REST Call, error description: {0}",e.Message);
				throw e;
			}
		}
		
		#endregion
	}
}
