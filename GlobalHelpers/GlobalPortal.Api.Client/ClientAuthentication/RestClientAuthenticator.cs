using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.ClientAuthentication;
using Newtonsoft.Json;

namespace GlobalPortal.Api.Client.ClientAuthentication
{
    internal class RestClientAuthenticator : IServerAuthentication
    {
        #region Thread safe singleton

        private RestClientAuthenticator()
        {
        }

        public static RestClientAuthenticator Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly RestClientAuthenticator instance = new RestClientAuthenticator();
        }

        #endregion

        #region Base address

        private string _baseAddress;

        public string GetBaseAddress()
        {
            if (!string.IsNullOrWhiteSpace(_baseAddress))
            {
                return _baseAddress;
            }
            else
            {
                _baseAddress = ConfigurationManager.AppSettings["WebApiAddress"];

                return _baseAddress;
            }
        }

        #endregion

        #region Authentication token

        private string _token;
        private string _username;
        private string _password;

        public void SetCredentials(string username, string password)
        {
            if (username != _username || password != _password)
            {
                _username = username;
                _password = password;
                _token = "";
            }
        }

        public void SetCredentials(string username, string password, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(RestClientAuthenticatorResources.ExpectedUrl);
            }
            else
            {
                _baseAddress = url;
            }

            if (username != _username || password != _password)
            {
                _username = username;
                _password = password;
                _token = "";
            }
        }

        /// <summary>
        /// Returns or refreshes the existent token.
        /// </summary>
        /// <param name="tokenExpired"></param>
        /// <returns></returns>
        /// <remarks>
        /// If this object already has a token, that token will be returned.
        /// If there is no token or if the calling code knows that the existent token is expired, a new token is generated.
        /// </remarks>
        public string GetToken(bool tokenExpired = false)
        {
            if (string.IsNullOrWhiteSpace(_token) || tokenExpired)
            {
                var tries = 0;
                var keepTrying = true;

                using (var restClient = new HttpClient())
                {
                    restClient.BaseAddress = new Uri(GetBaseAddress());
                    restClient.DefaultRequestHeaders.Accept.Clear();
                    restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var form = new Dictionary<string, string>
                    {
                        { "grant_type", "password"},
                        { "username", _username},
                        { "password", _password},
                    };

                    while (keepTrying)
                    {
                        HttpResponseMessage response = restClient.PostAsync("token", new FormUrlEncodedContent(form)).Result;

                        tries++;

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonMessage;

                            using (Stream responseStream = response.Content.ReadAsStreamAsync().Result)
                            {
                                jsonMessage = new StreamReader(responseStream).ReadToEnd();
                            }

                            TokenResponseModel tokenResponse = (TokenResponseModel)JsonConvert.DeserializeObject(jsonMessage, typeof(TokenResponseModel));

                            _token = string.Format("{0} {1}", "Bearer", tokenResponse.AccessToken);

                            return _token;
                        }
                        else
                        {
                            keepTrying = tries < 4;
                        }
                    }
                    throw new HttpRequestException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
                }
            }
            return _token;
        }

        #endregion
    }
}
