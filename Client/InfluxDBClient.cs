using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Core;
using InfluxDB.Client.Core.Exceptions;
using InfluxDB.Client.Core.Internal;
using InfluxDB.Client.Domain;
using InfluxDB.Client.Generated.Client;
using InfluxDB.Client.Generated.Domain;
using InfluxDB.Client.Generated.Service;
using InfluxDB.Client.Internal;
using RestSharp;
using Ready = InfluxDB.Client.Domain.Ready;

namespace InfluxDB.Client.Generated.Client
{
    //TODO move to separate file
    public partial class ApiClient
    {
        private readonly InfluxDBClientOptions _options;

        private readonly List<string> NO_AUTH_ROUTE = new List<string>
            {"/api/v2/signin", "/api/v2/signout", "/api/v2/setup"};

        private char[] _sessionToken;
        private bool _signout;

        public ApiClient(InfluxDBClientOptions options)
        {
            _options = options;

            Configuration = new Configuration
            {
                BasePath = options.Url,
                Timeout = 10_000,
                ApiClient = this
            };

            RestClient = new RestClient(options.Url);
        }

        partial void InterceptRequest(IRestRequest request)
        {
            if (_signout || NO_AUTH_ROUTE.Any(requestPath => requestPath.EndsWith(request.Resource))) return;

            if (InfluxDBClientOptions.AuthenticationScheme.Token.Equals(_options.AuthScheme))
            {
                request.AddHeader("Authorization", "Token " + new string(_options.Token));
            }
            else if (InfluxDBClientOptions.AuthenticationScheme.Session.Equals(_options.AuthScheme))
            {
                InitToken();

                if (_sessionToken != null) request.AddHeader("Cookie", "session=" + new string(_sessionToken));
            }
        }

        private void InitToken()
        {
            if (!InfluxDBClientOptions.AuthenticationScheme.Session.Equals(_options.AuthScheme) || _signout) return;

            if (_sessionToken == null)
            {
                IRestResponse authResponse;
                try
                {
                    var header = "Basic " + Convert.ToBase64String(
                                     Encoding.Default.GetBytes(_options.Username + ":" + _options.Password));

                    var request = new RestRequest(_options.Url + "/api/v2/signin", Method.POST)
                        .AddHeader("Authorization", header);

                    authResponse = RestClient.Execute(request);
                }
                catch (IOException e)
                {
                    Trace.WriteLine("Cannot retrieve the Session token!");
                    Trace.WriteLine(e);
                    return;
                }

                if (authResponse.Cookies != null)
                    _sessionToken = authResponse.Cookies
                        .ToList().First(cookie => cookie.Name.ToString().Equals("session")).Value.ToCharArray();
            }
        }

        protected internal void Signout()
        {
            if (!InfluxDBClientOptions.AuthenticationScheme.Session.Equals(_options.AuthScheme) || _signout)
            {
                _signout = true;

                return;
            }

            _signout = true;
            _sessionToken = null;

            var request = new RestRequest(_options.Url + "/api/v2/signout", Method.POST);
            RestClient.Execute(request);
        }
    }
}

namespace InfluxDB.Client
{
    public class InfluxDBClient : AbstractInfluxDBClient, IDisposable
    {
        private readonly ApiClient _apiClient;
        private readonly AuthenticateDelegatingHandler _authenticateDelegatingHandler;
        private readonly ExceptionFactory _exceptionFactory;
        private readonly LoggingHandler _loggingHandler;
        private readonly SetupService _setupService;

        protected internal InfluxDBClient(InfluxDBClientOptions options)
        {
            Arguments.CheckNotNull(options, nameof(options));

            _loggingHandler = new LoggingHandler(LogLevel.None);
            _authenticateDelegatingHandler = new AuthenticateDelegatingHandler(options)
            {
                InnerHandler = _loggingHandler
            };

            Client.HttpClient = new HttpClient(_authenticateDelegatingHandler);
            Client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client.HttpClient.BaseAddress = new Uri(options.Url);
            Client.HttpClient.Timeout = options.Timeout;

            _apiClient = new ApiClient(options);
            _exceptionFactory = (methodName, response) =>
                !response.IsSuccessful ? HttpException.Create(response) : null;

            _setupService = new SetupService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };
        }

        public void Dispose()
        {
            //
            // signout
            //
            try
            {
                var signout = _authenticateDelegatingHandler.Signout();

                signout.Wait();

                _apiClient.Signout();
            }
            catch (Exception e)
            {
                Trace.WriteLine("The signout exception");
                Trace.WriteLine(e);
            }
        }

        /// <summary>
        ///     Get the Query client.
        /// </summary>
        /// <returns>the new client instance for the Query API</returns>
        public QueryApi GetQueryApi()
        {
            return new QueryApi(Client);
        }

        /// <summary>
        ///     Get the Write client.
        /// </summary>
        /// <returns>the new client instance for the Write API</returns>
        public WriteApi GetWriteApi()
        {
            return new WriteApi(Client, WriteOptions.CreateNew().Build());
        }

        /// <summary>
        ///     Get the Write client.
        /// </summary>
        /// <param name="writeOptions">the configuration for a write client</param>
        /// <returns>the new client instance for the Write API</returns>
        public WriteApi GetWriteApi(WriteOptions writeOptions)
        {
            return new WriteApi(Client, writeOptions);
        }

        /// <summary>
        ///     Get the <see cref="Domain.Organization" /> client.
        /// </summary>
        /// <returns>the new client instance for Organization API</returns>
        public OrganizationsApi GetOrganizationsApi()
        {
            return new OrganizationsApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.User" /> client.
        /// </summary>
        /// <returns>the new client instance for User API</returns>
        public UsersApi GetUsersApi()
        {
            return new UsersApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.Bucket" /> client.
        /// </summary>
        /// <returns>the new client instance for Bucket API</returns>
        public BucketsApi GetBucketsApi()
        {
            return new BucketsApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.Source" /> client.
        /// </summary>
        /// <returns>the new client instance for Source API</returns>
        public SourcesApi GetSourcesApi()
        {
            return new SourcesApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.Authorization" /> client.
        /// </summary>
        /// <returns>the new client instance for Authorization API</returns>
        public AuthorizationsApi GetAuthorizationsApi()
        {
            return new AuthorizationsApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.Task" /> client.
        /// </summary>
        /// <returns>the new client instance for Task API</returns>
        public TasksApi GetTasksApi()
        {
            return new TasksApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.ScraperTarget" /> client.
        /// </summary>
        /// <returns>the new client instance for Scraper API</returns>
        public ScraperTargetsApi GetScraperTargetsApi()
        {
            return new ScraperTargetsApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="Domain.TelegrafConfig" /> client.
        /// </summary>
        /// <returns>the new client instance for Telegrafs API</returns>
        public TelegrafsApi GetTelegrafsApi()
        {
            return new TelegrafsApi(Client);
        }

        /// <summary>
        ///     Get the <see cref="InfluxDB.Client.Generated.Domain.Label" /> client.
        /// </summary>
        /// <returns>the new client instance for Label API</returns>
        public LabelsApi GetLabelsApi()
        {
            var labelsService = new LabelsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new LabelsApi(Client, labelsService);
        }

        /// <summary>
        ///     Set the log level for the request and response information.
        /// </summary>
        /// <param name="logLevel">the log level to set</param>
        public void SetLogLevel(LogLevel logLevel)
        {
            Arguments.CheckNotNull(logLevel, nameof(logLevel));

            _loggingHandler.Level = logLevel;
        }

        /// <summary>
        ///     Set the <see cref="LogLevel" /> that is used for logging requests and responses.
        /// </summary>
        /// <returns>Log Level</returns>
        public LogLevel GetLogLevel()
        {
            return _loggingHandler.Level;
        }

        /// <summary>
        ///     Get the health of an instance.
        /// </summary>
        /// <returns>health of an instance</returns>
        public async Task<Health> Health()
        {
            return await GetHealth("/health");
        }

        /// <summary>
        ///     The readiness of the InfluxDB 2.0.
        /// </summary>
        /// <returns>return null if the InfluxDB is not ready</returns>
        public async Task<Ready> Ready()
        {
            try
            {
                var request = await Get("/ready");

                return Call<Ready>(request);
            }
            catch (Exception e)
            {
                Trace.TraceError($"The exception: '{e.Message}' occurs during check instance readiness.");

                return null;
            }
        }

        /// <summary>
        ///     Post onboarding request, to setup initial user, org and bucket.
        /// </summary>
        /// <param name="onboarding">to setup defaults</param>
        /// <exception cref="HttpException">With status code 422 when an onboarding has already been completed</exception>
        /// <returns>defaults for first run</returns>
        public OnboardingResponse Onboarding(OnboardingRequest onboarding)
        {
            Arguments.CheckNotNull(onboarding, nameof(onboarding));

            return _setupService.SetupPost(onboarding);
        }

        /// <summary>
        ///     Check if database has default user, org, bucket created, returns true if not.
        /// </summary>
        /// <returns>True if onboarding has already been completed otherwise false</returns>
        public bool IsOnboardingAllowed()
        {
            var isOnboardingAllowed = _setupService.SetupGet().Allowed;

            return true == isOnboardingAllowed;
        }
    }
}