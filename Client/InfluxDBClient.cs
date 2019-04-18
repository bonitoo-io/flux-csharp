using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Api.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Api.Service;
using InfluxDB.Client.Core;
using InfluxDB.Client.Core.Exceptions;
using InfluxDB.Client.Core.Internal;

namespace InfluxDB.Client
{
    public class InfluxDBClient : IDisposable
    {
        private readonly ApiClient _apiClient;
        private readonly ExceptionFactory _exceptionFactory;
        private readonly HealthService _healthService;
        //TODO
        private readonly LoggingHandler _loggingHandler;
        private readonly ReadyService _readyService;

        private readonly SetupService _setupService;

        protected internal InfluxDBClient(InfluxDBClientOptions options)
        {
            Arguments.CheckNotNull(options, nameof(options));

            _loggingHandler = new LoggingHandler(LogLevel.None);

            _apiClient = new ApiClient(options);
                
            _exceptionFactory = (methodName, response) =>
                !response.IsSuccessful ? HttpException.Create(response) : null;

            _setupService = new SetupService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };
            _healthService = new HealthService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };
            _readyService = new ReadyService((Configuration) _apiClient.Configuration)
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
                _apiClient.Signout();
            }
            catch (Exception e)
            {
                Trace.WriteLine("The signout exception");
                Trace.WriteLine(e);
            }
        }

        /// <summary>
        /// Get the Query client.
        /// </summary>
        /// <returns>the new client instance for the Query API</returns>
        public QueryApi GetQueryApi()
        {
            var service = new QueryService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };
            
            return new QueryApi(service);
        }

        /// <summary>
        /// Get the Write client.
        /// </summary>
        /// <returns>the new client instance for the Write API</returns>
        public WriteApi GetWriteApi()
        {
            return GetWriteApi(WriteOptions.CreateNew().Build());
        }

        /// <summary>
        /// Get the Write client.
        /// </summary>
        /// <param name="writeOptions">the configuration for a write client</param>
        /// <returns>the new client instance for the Write API</returns>
        public WriteApi GetWriteApi(WriteOptions writeOptions)
        {
            var service = new WriteService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };
            
            return new WriteApi(service, writeOptions);
        }

        /// <summary>
        /// Get the <see cref="Organization" /> client.
        /// </summary>
        /// <returns>the new client instance for Organization API</returns>
        public OrganizationsApi GetOrganizationsApi()
        {
            var service = new OrganizationsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new OrganizationsApi(service);
        }

        /// <summary>
        /// Get the <see cref="InfluxDB.Client.Api.Domain.User" /> client.
        /// </summary>
        /// <returns>the new client instance for User API</returns>
        public UsersApi GetUsersApi()
        {
            var service = new UsersService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new UsersApi(service);
        }

        /// <summary>
        /// Get the <see cref="Bucket" /> client.
        /// </summary>
        /// <returns>the new client instance for Bucket API</returns>
        public BucketsApi GetBucketsApi()
        {
            var service = new BucketsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new BucketsApi(service);
        }

        /// <summary>
        /// Get the <see cref="Source" /> client.
        /// </summary>
        /// <returns>the new client instance for Source API</returns>
        public SourcesApi GetSourcesApi()
        {
            var service = new SourcesService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new SourcesApi(service);
        }

        /// <summary>
        /// Get the <see cref="Domain.Authorization" /> client.
        /// </summary>
        /// <returns>the new client instance for Authorization API</returns>
        public AuthorizationsApi GetAuthorizationsApi()
        {
            var service = new AuthorizationsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new AuthorizationsApi(service);
        }

        /// <summary>
        /// Get the <see cref="Domain.Task" /> client.
        /// </summary>
        /// <returns>the new client instance for Task API</returns>
        public TasksApi GetTasksApi()
        {
            var service = new TasksService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new TasksApi(service);
        }

        /// <summary>
        /// Get the <see cref="InfluxDB.Client.Api.Domain.ScraperTargetResponse" /> client.
        /// </summary>
        /// <returns>the new client instance for Scraper API</returns>
        public ScraperTargetsApi GetScraperTargetsApi()
        {
            var service = new ScraperTargetsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new ScraperTargetsApi(service);
        }

        /// <summary>
        /// Get the <see cref="InfluxDB.Client.Api.Domain.Telegraf" /> client.
        /// </summary>
        /// <returns>the new client instance for Telegrafs API</returns>
        public TelegrafsApi GetTelegrafsApi()
        {
            var service = new TelegrafsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new TelegrafsApi(service);
        }

        /// <summary>
        /// Get the <see cref="InfluxDB.Client.Api.Domain.Label" /> client.
        /// </summary>
        /// <returns>the new client instance for Label API</returns>
        public LabelsApi GetLabelsApi()
        {
            var service = new LabelsService((Configuration) _apiClient.Configuration)
            {
                ExceptionFactory = _exceptionFactory
            };

            return new LabelsApi(service);
        }

        /// <summary>
        /// Set the log level for the request and response information.
        /// </summary>
        /// <param name="logLevel">the log level to set</param>
        public void SetLogLevel(LogLevel logLevel)
        {
            Arguments.CheckNotNull(logLevel, nameof(logLevel));

            _loggingHandler.Level = logLevel;
        }

        /// <summary>
        /// Set the <see cref="LogLevel" /> that is used for logging requests and responses.
        /// </summary>
        /// <returns>Log Level</returns>
        public LogLevel GetLogLevel()
        {
            return _loggingHandler.Level;
        }

        /// <summary>
        /// Get the health of an instance.
        /// </summary>
        /// <returns>health of an instance</returns>
        public Check Health()
        {
            return GetHealth(_healthService.HealthGetAsync());
        }

        /// <summary>
        /// The readiness of the InfluxDB 2.0.
        /// </summary>
        /// <returns>return null if the InfluxDB is not ready</returns>
        public Ready Ready()
        {
            try
            {
                return _readyService.ReadyGet();
            }
            catch (Exception e)
            {
                Trace.TraceError($"The exception: '{e.Message}' occurs during check instance readiness.");

                return null;
            }
        }

        /// <summary>
        /// Post onboarding request, to setup initial user, org and bucket.
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
        /// Check if database has default user, org, bucket created, returns true if not.
        /// </summary>
        /// <returns>True if onboarding has already been completed otherwise false</returns>
        public bool IsOnboardingAllowed()
        {
            var isOnboardingAllowed = _setupService.SetupGet().Allowed;

            return true == isOnboardingAllowed;
        }
        
        internal static Check GetHealth(Task<Check> task)
        {
            Arguments.CheckNotNull(task, nameof(task));

            try
            {
                return task.Result;
            }
            catch (Exception e)
            {
                return new Check("influxdb", e.GetBaseException().Message, default(List<Check>), Check.StatusEnum.Fail);
            }
        }
        
        internal static string AuthorizationHeader(string username, string password)
        {
            return "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
        }

    }
}