using System;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;


namespace HyperionScreenCap
{
    class ApiServer
    {
        private RestServer _server;

        public void StartServer(string hostname, string port)
        {
            try
            {
                if (_server == null)
                {
                    _server = new RestServer
                    {
                        Host = hostname,
                        Port = port
                    };

                    _server.Start();
                }
            }
            catch (Exception){
            }
        }

        public void StopServer()
        {
            _server?.Stop();
        }

        public void RestartServer(string hostname, string port)
        {
            StopServer();
            StartServer(hostname, port);
        }

        [RestResource]
        public class Resources
        {
            [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/API")]
            public IHttpContext API(IHttpContext context)
            {
                context.Response.ContentType = ContentType.TEXT;
                string responseText = "No valid API command received.";
                string command = context.Request.QueryString["command"] ?? "";
                string force = context.Request.QueryString["force"] ?? "false";

                if (!string.IsNullOrEmpty(command))
                {
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
                                context.Response.SendResponse(responseText);
                                return context;
                            }
                        }

                        MainForm.ToggleCapture(command);
                        responseText = $"API command {command} completed successfully.";
                    }

                    if (command == "STATE")
                    {
                        responseText = $"{MainForm.IsScreenCaptureRunning()}";
                    }
                }
                context.Response.SendResponse(responseText);
                return context;
            }
        }
    }
}
