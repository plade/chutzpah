﻿using Nancy;

namespace Chutzpah.Server
{
    public class WebServerModule : Nancy.NancyModule
    {
        public WebServerModule()
        {
            Get["/{uri*}"] = parameters =>
            {
//this.Context.CurrentUser
                string path = parameters["uri"].Value;
                return Response.AsFile(path);
            };

            Get["/"] = parameters =>
            {
                return "Chutzpah Web Server";
            };
        }
    }
}
