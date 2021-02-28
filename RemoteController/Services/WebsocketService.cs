using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace RemoteController.Services
{
    public class WebsocketService
    {
        protected WebSocketServer wsServer;
        protected List<IWebSocketConnection> wsConnections;

        public delegate void LogCallback(string message);

        protected LogCallback logger;

        public WebsocketService(string address, LogCallback logger) {
            string serviceUrl = String.Format("ws://{0}", address);
            this.wsServer = new WebSocketServer(serviceUrl); ;
            this.logger = logger;
            logger("Creating websocket service at " + serviceUrl);

            FleckLog.LogAction = (level, message, ex) => {
                if (ex != null)
                {
                    logger(String.Format("FleckLog: Level: {0} Message: {1} Error: {2}", level, message, ex.ToString()));
                } else
                {
                    logger(String.Format("FleckLog: Level: {0} Message: {1}", level, message));
                }
                
            };

            this.wsConnections = new List<IWebSocketConnection>();
        }


        public void Start()
        {
            logger("Starting new websocket server");
            wsServer.Start(socket => {
                socket.OnOpen = () =>
                {
                    logger("New conncetion received");
                    wsConnections.Add(socket);
                };

                socket.OnClose = () =>
                {
                    logger("Connection closed");
                    wsConnections.Remove(socket);
                };

                socket.OnMessage = (message) => {
                    try
                    {
                        socket.Send(
                            Parser.Command.Decode(message).Execute().Serialized()
                        );
                    } catch (Exception e)
                    {
                        logger(String.Format("Exception ocurrend during parsing of command {0}. Exception: {1}", message, e.ToString()));
                        socket.Send(
                            Parser.ExecutedCommand.Error(e.ToString()).Serialized()
                        );
                    }
                };

            });
        }

        public void Stop()
        {
            foreach (IWebSocketConnection con in wsConnections)
            {
                con.Close();
            }

            wsServer.Dispose();
            logger("Stoping websocket server");
        }
    }
}
