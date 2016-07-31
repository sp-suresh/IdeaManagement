using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace IdeaManagement.Presentation
{
    /// <summary>
    /// <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    public class AppHttpClient
    {

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get API response </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <param name="responseType">Type of the response.</param>
        /// <returns>
        /// task
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static async Task<T> GetApiResponse<T>(string hostUrl, string requestType, string apiUrl, T responseType)
        {
            T objTask = responseType;
            try
            {
                using (var client = new HttpClient())
                {
                    // New code:       
                    //sets the base URI for HTTP requests
                    client.BaseAddress = new Uri(hostUrl);
                    client.DefaultRequestHeaders.Accept.Clear();

                    //sets the Accept header to "application/json", which tells the server to send data in JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(requestType));

                    //HTTP GET
                    HttpResponseMessage _response = await client.GetAsync(apiUrl);

                    _response.EnsureSuccessStatusCode(); //Throw if not a success code.                    

                    if (_response.IsSuccessStatusCode)
                    {
                        if (_response.StatusCode == System.Net.HttpStatusCode.OK) //Check 200 OK Status        
                            objTask = await _response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Current.Trace.Warn("GetApiResponse", ex.Message);
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn("GetApiResponse", err.Message);
            }

            return objTask;
        }


        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Post asynchronous </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <param name="postObject">The post object.</param>
        /// <returns>
        /// task
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static async Task<T> PostAsync<T>(string hostUrl, string requestType, string apiUrl, T postObject)
        {
            T objTask = postObject;

            using (var client = new HttpClient())
            {
                // TODO - Send HTTP requests
                client.BaseAddress = new Uri(hostUrl); ;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(requestType));
                // HTTP POST

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, postObject);
                HttpContext.Current.Trace.Warn("post async :" + response.StatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {

                    return objTask;
                    //// Get the URI of the created resource.
                    //Uri gizmoUrl = response.Headers.Location;

                }
            }
            return objTask;


        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Delete synchronize </para>
        /// </summary>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool DeleteSync(string hostUrl, string requestType, string apiUrl)
        {
            //Task<bool> t = default(Task<bool>);
            bool isSuccess = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostUrl);
                HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Post synchronize </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <param name="objToPost">The object to post.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool PostSync<T>(string hostUrl, string requestType, string apiUrl, T objToPost)
        {
            bool isSuccess = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(requestType));

                HttpResponseMessage response = client.PostAsJsonAsync(apiUrl, objToPost).Result;

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get API response synchronize </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <param name="responseType">Type of the response.</param>
        /// <returns>
        /// t
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static T GetApiResponseSync<T>(string hostUrl, string requestType, string apiUrl, T responseType)
        {
            T objTask = responseType;
            try
            {
                using (var client = new HttpClient())
                {
                    // New code:       
                    //sets the base URI for HTTP requests
                    client.BaseAddress = new Uri(hostUrl);
                    client.DefaultRequestHeaders.Accept.Clear();

                    //sets the Accept header to "application/json", which tells the server to send data in JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(requestType));

                    //HTTP GET
                    HttpResponseMessage _response = client.GetAsync(apiUrl).Result;

                    _response.EnsureSuccessStatusCode(); //Throw if not a success code.                    

                    if (_response.IsSuccessStatusCode)
                    {
                        if (_response.StatusCode == System.Net.HttpStatusCode.OK) //Check 200 OK Status        
                            objTask = JsonConvert.DeserializeObject<T>(_response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Current.Trace.Warn("GetApiResponse", ex.Message);
                //ErrorClass objErr = new ErrorClass(ex, HttpContext.Current.Request.ServerVariables["URL"]);
                //objErr.SendMail();
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn("GetApiResponse", err.Message);
                //ErrorClass objErr = new ErrorClass(err, HttpContext.Current.Request.ServerVariables["URL"]);
                //objErr.SendMail();
            }

            return objTask;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Post synchronize </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="hostUrl">The host URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="apiUrl">The API URL.</param>
        /// <param name="objPostData">The object post data.</param>
        /// <param name="requestHeader">The request header.</param>
        /// <returns>
        /// t
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static T PostSync<T, U>(string hostUrl, string requestType, string apiUrl, U objPostData, NameValueCollection requestHeader = null)
        {
            T data = default(T);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(requestType));

                //If request header is to be set.
                if (requestHeader != null)
                {
                    foreach (var key in requestHeader.AllKeys)
                    {
                        client.DefaultRequestHeaders.Add(key, requestHeader[key]);
                    }
                }

                var response = client.PostAsJsonAsync(apiUrl, objPostData).Result;

                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return data;
        }
    }
}