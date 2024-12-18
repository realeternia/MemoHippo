﻿using HttpLib;
using HttpLib.Handlers;
using HttpLib.Listeners;
using HttpLib.RequestProviders;
using System.Net;
using System.Net.Sockets;

namespace MemoHippo.Utils
{
    class MemoHttpServer
    {
        public static void Run()
        {
            StartRun();
        }

        public static void StartRun()
        {
            var httpRouter = new HttpRouter();
            var port = 8081;
            if (System.Diagnostics.Debugger.IsAttached)
                port = 8082;
            var httpServer = new HttpServer(new HttpRequestProvider(), port, 1024 * 1024 * 2, 1024 * 1024 * 2);
            {
                httpServer.Use(new TcpListenerAdapter(new TcpListener(IPAddress.Any, port)));
                httpServer.Use(new ExceptionHandler(true));
                //httpServer.Use(new CompressionHandler(DeflateCompressor.Default, GZipCompressor.Default));
                //httpServer.Use(new ControllerHandler(new BaseController(), new JsonModelBinder(), new JsonView()));

                httpRouter.With("file", new MemoFileHandler());
                httpRouter.With(string.Empty, new IndexHandler());
            }

            var services = httpRouter.GetServices();
            HLog.Info("services init count=" + services.Count);

            httpServer.Use(httpRouter);
            httpServer.Use(new ErrorHandler());
            httpServer.Start();
        }
    }
}
