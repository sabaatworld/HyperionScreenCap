using System;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using log4net;

namespace HyperionScreenCap
{
    class ApiServer
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ApiServer));

        private RestServer _server;

        public void StartServer(string hostname, string port)
        {
            try
            {
                if ( _server == null )
                {
                    LOG.Info($"Starting API server: {hostname}:{port}");
                    _server = new RestServer
                    {
                        Host = hostname,
                        Port = port
                    };

                    _server.Start();
                    LOG.Info("API server started");
                }
            }
            catch ( Exception ex )
            {
                LOG.Error("Failed to start API server", ex);
            }
        }

        public void StopServer()
        {
            LOG.Info("Stopping API server");
            _server?.Stop();
            LOG.Info("API server stopped");
        }

        public void RestartServer(string hostname, string port)
        {
            LOG.Info("Restarting API server");
            StopServer();
            StartServer(hostname, port);
        }

        [RestResource]
        public class Resources
        {
            [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/API")]
            public IHttpContext API(IHttpContext context)
            {
                LOG.Info("API server command received");
                context.Response.ContentType = ContentType.TEXT;
                string responseText = "No valid API command received.";
                string command = context.Request.QueryString["command"] ?? "";
                string force = context.Request.QueryString["force"] ?? "false";

                if ( !string.IsNullOrEmpty(command) )
                {
                    LOG.Info($"Processing API command: {command}");
                    // Only process valid commands
                    if ( command == "ON" || command == "OFF" )
                    {

                        // Check for deactivate API between certain times
                        if ( SettingsManager.ApiExcludedTimesEnabled && force.ToLower() == "false" )
                        {
                            if ( (DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                                 DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeEnd.TimeOfDay) ||
                                ((SettingsManager.ApiExcludeTimeStart.TimeOfDay > SettingsManager.ApiExcludeTimeEnd.TimeOfDay) &&
                                 ((DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                                   DateTime.Now.TimeOfDay <= SettingsManager.ApiExcludeTimeEnd.TimeOfDay) ||
                                  (DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeStart.TimeOfDay &&
                                   DateTime.Now.TimeOfDay >= SettingsManager.ApiExcludeTimeEnd.TimeOfDay))) )
                            {
                                responseText = "API exclude times enabled and within time range.";
                                LOG.Info($"Sending response: {responseText}");
                                context.Response.SendResponse(responseText);
                                return context;
                            }
                        }

                        MainForm.ToggleCapture((MainForm.CaptureCommand) Enum.Parse(typeof(MainForm.CaptureCommand), command));
                        responseText = $"API command {command} completed successfully.";
                    }

                    if ( command == "STATE" )
                    {
                        responseText = $"{MainForm.IsScreenCaptureRunning()}";
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
        }
    }
}