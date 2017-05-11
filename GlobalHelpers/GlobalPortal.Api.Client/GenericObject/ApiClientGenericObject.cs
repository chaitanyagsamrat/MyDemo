using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.GenericObject
{
    internal abstract class ApiClientGenericObject<T> where T : class
    {
        /// <summary>
        /// Gets a list of T objects from the server.
        /// </summary>
        /// <param name="restClientAuthenticator"></param>
        /// <param name="controllerName"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public static ListModel<T> Search(IServerAuthentication restClientAuthenticator, string controllerName, IUrlParameters criteria)
        {
            var baseAddress = restClientAuthenticator.GetBaseAddress();
            var authorizationToken = restClientAuthenticator.GetToken();

            var tries = 0;
            var keepTrying = true;

            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(baseAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (keepTrying)
                {
                    restClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    HttpResponseMessage response = restClient.GetAsync(string.Format(ApiClientGenericObjectResources.SearchRequestUri, controllerName, "/search?", criteria.GetAsUrlParameters())).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authorizationToken = restClientAuthenticator.GetToken(true);

                        tries++;
                        keepTrying = tries < 4;
                    }
                    else
                    {
                        keepTrying = false;

                        if (response.IsSuccessStatusCode)
                        {
                            ListModel<T> genericList = response.Content.ReadAsAsync<ListModel<T>>().Result;

                            return genericList;
                        }
                        else
                        {
                            throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }

        /// <summary>
        /// Gets a T object from the server.
        /// </summary>
        /// <param name="restClientAuthenticator"></param>
        /// <param name="controllerName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static T Get(IServerAuthentication restClientAuthenticator, string controllerName, string ID, string externalIdParameterName = "externalId")
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                var additionalInformation = string.Format(ApiClientGenericObjectResources.AdditionalInformation, ApiClientGenericObjectResources.IdNotNullable);
                throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.BadRequest.ToString()), additionalInformation));
            }

            var baseAddress = restClientAuthenticator.GetBaseAddress();
            var authorizationToken = restClientAuthenticator.GetToken();

            var tries = 0;
            var keepTrying = true;

            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(baseAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (keepTrying)
                {
                    restClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    HttpResponseMessage response = restClient.GetAsync
                        (string.Format(
                            ApiClientGenericObjectResources.GetRequestUri,
                            controllerName,
                            "?",
                            externalIdParameterName,
                            "=",
                            ID
                            )
                            ).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authorizationToken = restClientAuthenticator.GetToken(true);

                        tries++;
                        keepTrying = tries < 4;
                    }
                    else
                    {
                        keepTrying = false;

                        if (response.IsSuccessStatusCode)
                        {
                            T genericObject = response.Content.ReadAsAsync<T>().Result;

                            return genericObject;
                        }
                        else
                        {
                            throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }

        /// <summary>
        /// Post a T object to be updated or inserted in the server database.
        /// </summary>
        /// <param name="restClientAuthenticator"></param>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Save(IServerAuthentication restClientAuthenticator, string controllerName, T model)
        {
            var baseAddress = restClientAuthenticator.GetBaseAddress();
            var authorizationToken = restClientAuthenticator.GetToken();

            var tries = 0;
            var keepTrying = true;

            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(baseAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (keepTrying)
                {
                    restClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    var response = restClient.PostAsJsonAsync<T>(string.Format(ApiClientGenericObjectResources.PostRequestUri, controllerName), model).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authorizationToken = restClientAuthenticator.GetToken(true);

                        tries++;
                        keepTrying = tries < 4;
                    }
                    else
                    {
                        keepTrying = false;

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            var additionalInformation = response.Content.ReadAsStringAsync().Result;

                            throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()), additionalInformation));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }

        /// <summary>
        /// Delete a T object from the server database.
        /// </summary>
        /// <param name="restClientAuthenticator"></param>
        /// <param name="controllerName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Delete(IServerAuthentication restClientAuthenticator, string controllerName, string ID, string externalIdParameterName = "externalId")
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                var additionalInformation = string.Format(ApiClientGenericObjectResources.AdditionalInformation, ApiClientGenericObjectResources.IdNotNullable);

                throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.BadRequest.ToString()), additionalInformation));
            }

            var baseAddress = restClientAuthenticator.GetBaseAddress();
            var authorizationToken = restClientAuthenticator.GetToken();

            var tries = 0;
            var keepTrying = true;

            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(baseAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (keepTrying)
                {
                    restClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    HttpResponseMessage response = restClient.DeleteAsync(
                        string.Format
                        (
                            ApiClientGenericObjectResources.DeleteRequestUri,
                            controllerName,
                            "?",
                            externalIdParameterName,
                            "=",
                            ID
                            )
                            ).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authorizationToken = restClientAuthenticator.GetToken(true);

                        tries++;
                        keepTrying = tries < 4;
                    }
                    else
                    {
                        keepTrying = false;

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }
    }
}