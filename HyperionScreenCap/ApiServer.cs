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
                    _server = new RestServer();
                    _server.Host = hostname;
                    _server.Port = port;
                    _server.Start();
                }
            }
            catch (Exception){
            }
        }

        public void StopServer()
        {
            if (_server != null)
            {
                _server.Stop();
                _server = null;
            }
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
