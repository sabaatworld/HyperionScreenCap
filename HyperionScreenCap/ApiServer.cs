using System;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using log4net;
using System.Management.Automation;

namespace HyperionScreenCap
{
    class ApiServer
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ApiServer));

        private MainForm _mainForm;
        private RestServer _server;

        public ApiServer(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void StartServer(string hostname, string port)
        {
            try
            {
                if (_server == null)
                {
                    LOG.Info($"Starting API server: {hostname}:{port}");
                    _server = new RestServer
                    {
                        Host = hostname,
                        Port = port
                    };

                    var apiRoute = new Route(API);
                    _server.Router.Register(apiRoute);

                    _server.Start();

                    OpenPort(port);

                    LOG.Info("API server started");
                }
            }
            catch (Exception ex)
            {
                LOG.Error("Failed to start API server", ex);
            }
        }

        public void StopServer()
        {
            LOG.Info("Stopping API server");
            _server?.Stop();
            ClosePort();
            LOG.Info("API server stopped");
        }

        public void RestartServer(string hostname, string port)
        {
            LOG.Info("Restarting API server");
            StopServer();
            StartServer(hostname, port);
        }

        /// <summary>
        /// DO NOT RENAME THIS METHOD. The name is used in the reflection code above.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/API")]
        private IHttpContext API(IHttpContext context)
        {
            LOG.Info("API server command received");
            context.Response.ContentType = ContentType.TEXT;
            string responseText = "No valid API command received.";
            string command = context.Request.QueryString["command"] ?? "";
            string force = context.Request.QueryString["force"] ?? "false";

            if (!string.IsNullOrEmpty(command))
            {
                LOG.Info($"Processing API command: {command}");
                // Only process valid commands
                if (command == "ON" || command == "OFF")
                {

                    // Check for deactivate API between certain times
                    if (SettingsManager.ApiExcludedTimesEnabled && force.ToLower() == "false")
                    {
                        if ((DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                             DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeEnd.TimeOfDay) ||
                            ((SettingsManager.ApiExcludeTimeStart.TimeOfDay > SettingsManager.ApiExcludeTimeEnd.TimeOfDay) &&
                             ((DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                               DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeEnd.TimeOfDay) ||
                              (DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                               DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeEnd.TimeOfDay))))
                        {
                            responseText = "API exclude times enabled and within time range.";
                            LOG.Info($"Sending response: {responseText}");
                            context.Response.SendResponse(responseText);
                            return context;
                        }
                    }

                    _mainForm.ToggleCapture((MainForm.CaptureCommand)Enum.Parse(typeof(MainForm.CaptureCommand), command));
                    responseText = $"API command {command} completed successfully.";
                }

                if (command == "STATE")
                {
                    responseText = $"{_mainForm.CaptureEnabled}";
                }
            }
            else
            {
                LOG.Warn("API Command Empty / Invalid");
            }
            LOG.Info($"Sending response: {responseText}");
            context.Response.SendResponse(responseText);
            return context;
        }

        private void OpenPort(string port)
        {
            var powershell = PowerShell.Create();
            var psCommand = $"New-NetFirewallRule -DisplayName \"HyperionScreenCap API\" -Direction Inbound -LocalPort {port} -Protocol TCP -Action Allow";
            powershell.Commands.AddScript(psCommand);
            powershell.Invoke();
        }

        private void ClosePort()
        {
            var powershell = PowerShell.Create();
            var psCommand = $"Remove-NetFirewallRule -DisplayName \"HyperionScreenCap API\"";
            powershell.Commands.AddScript(psCommand);
            powershell.Invoke();
        }
    }
}