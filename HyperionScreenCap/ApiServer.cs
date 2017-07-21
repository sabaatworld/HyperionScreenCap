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

                // Check for deactivate API between certain times
                if (Settings.ApiExcludedTimesEnabled && force == "false")
                {
                    if ((DateTime.Now.TimeOfDay >= Settings.ApiExcludeTimeStart.TimeOfDay &&
                         DateTime.Now.TimeOfDay <= Settings.ApiExcludeTimeEnd.TimeOfDay) ||
                        ((Settings.ApiExcludeTimeStart.TimeOfDay > Settings.ApiExcludeTimeEnd.TimeOfDay) &&
                         ((DateTime.Now.TimeOfDay <= Settings.ApiExcludeTimeStart.TimeOfDay &&
                           DateTime.Now.TimeOfDay <= Settings.ApiExcludeTimeEnd.TimeOfDay) ||
                          (DateTime.Now.TimeOfDay >= Settings.ApiExcludeTimeStart.TimeOfDay &&
                           DateTime.Now.TimeOfDay >= Settings.ApiExcludeTimeEnd.TimeOfDay))))
                    {
                        responseText = "API exclude times enabled and within w time range.";
                        context.Response.SendResponse(responseText);
                        return context;
                    }
                }

                if (!string.IsNullOrEmpty(command))
                {
                    // Only process valid commands
                    if (command == "ON" || command == "OFF")
                    {
                        Form1.ToggleCapture(command);
                        responseText = $"API command {command} completed successfully.";
                    }
                }
                context.Response.SendResponse(responseText);
                return context;
            }
        }
    }
}
