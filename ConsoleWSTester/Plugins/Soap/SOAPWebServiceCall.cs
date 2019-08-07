using ConsoleTester.Common;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.Soap
{
    public class SOAPWebServiceCall
    {
        private ILogger logger;
        private SOAPConfig conf;

        public enum OperationMode
        {
            Run,
            Query,
            Modify,
            Read,
            Save,
            GetDescription,
            DeleteLines,
            InsertLines
        }

        public SOAPWebServiceCall(SOAPConfig config, ILogger logger)
        {
            this.conf = config;
            this.logger = logger;
        }


        public Task<CAWebService.CAdxResultXml> Query()
        {
            return LaunchWSCallInBackGround(OperationMode.Query);
        }

        public Task<CAWebService.CAdxResultXml> Modify(string xml)
        {
            this.conf.XmlObject = xml;
            return LaunchWSCall(OperationMode.Modify);
        }
        public Task<CAWebService.CAdxResultXml> DeleteLines(string xmlFileName)
        {
            return LaunchWSCall(OperationMode.DeleteLines);
        }
        public Task<CAWebService.CAdxResultXml> Read()
        {
            return LaunchWSCallInBackGround(OperationMode.Read);
        }
        public Task<CAWebService.CAdxResultXml> GetDescription()
        {
            return LaunchWSCallInBackGround(OperationMode.GetDescription);
        }
        public Task<CAWebService.CAdxResultXml> Save(string xmlContains)
        {
            this.conf.XmlObject = xmlContains;
            return LaunchWSCall(OperationMode.Save);
        }
        public Task<CAWebService.CAdxResultXml> Run(string xmlContains)
        {
            this.conf.XmlObject = xmlContains;
            return LaunchWSCallInBackGround(OperationMode.Run);
        }


        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        // int waitInMilliseconds
        private Task<CAWebService.CAdxResultXml> LaunchWSCallInBackGround(OperationMode mode)
        {
            var result = Task.Run(() => LaunchWSCall(mode));
            return result;
            //Thread t = new Thread(new ParameterizedThreadStart(LaunchWSCall));
            //t.Start(mode);
        }

        private async Task<CAWebService.CAdxResultXml> LaunchWSCall(object modeOp)
        {
            CAWebService.CAdxResultXml result = null;

            OperationMode mode = (OperationMode)modeOp;

            var caWebService = new CAWebService.CAdxWebServiceXmlCCClient();
            var context = new CAWebService.CAdxCallContext
            {
                poolAlias = conf.PoolAlias,
                codeUser = conf.Login,
                codeLang = conf.Language,
                requestConfig = conf.RequestConfiguration
            };

            string absUrl = conf.HostUrl + conf.Path;
            caWebService.Endpoint.ListenUri = new Uri(absUrl);
            caWebService.Endpoint.Address = new EndpointAddress(absUrl);


            using (new OperationContextScope(caWebService.InnerChannel))
            {
                // Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                // requestMessage.Headers["Authorization"] = "Basic YWRtaW46YWRtaW4=";
                requestMessage.Headers["Authorization"] = $"Basic {Base64Encode(conf.Login + ":" + conf.Password)}";
                requestMessage.Headers["Accept"] = "application/soap+xml, application/dime, multipart/related, text/*";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                try
                {
                    logger.Log("");
                    logger.Log($"Calling: {caWebService.Endpoint.ListenUri.AbsoluteUri}  "
                        + $"Operation mode: {mode}  "
                        + $"Pool: {conf.PoolAlias}   PublicName: {conf.PublicName}   "
                        + $"RequestConfiguration: { conf.RequestConfiguration }  ... ");
                    if (mode == OperationMode.Read || mode == OperationMode.Modify)
                    {
                        string keysStrings = $"ObjectKeys: ";
                        foreach (var item in conf.ObjectKeys)
                        {
                            keysStrings += $"{item.key}: {item.value}, ";
                        }
                        logger.Log(keysStrings);

                    }
                    if (mode == OperationMode.Modify && !string.IsNullOrEmpty(this.conf.XmlFilename))
                    {
                        logger.Log($"Read filename: {Path.GetFileName(this.conf.XmlFilename)}");
                    }

                    logger.Log($" ");
                    switch (mode)
                    {
                        default:
                        case OperationMode.Query:
                            result = caWebService.query(context, conf.PublicName, null, conf.ListSize);
                            break;
                        case OperationMode.Modify:
                            result = caWebService.modify(context, conf.PublicName, conf.ObjectKeys, conf.XmlObject);
                            break;
                        case OperationMode.Read:
                            result = caWebService.read(context, conf.PublicName, conf.ObjectKeys);
                            break;
                        case OperationMode.Save:
                            result = caWebService.save(context, conf.PublicName, conf.XmlObject);
                            break;
                        case OperationMode.GetDescription:
                            result = caWebService.getDescription(context, conf.PublicName);
                            break;
                        case OperationMode.DeleteLines:
                            result = caWebService.deleteLines(context, conf.PublicName, conf.ObjectKeys, conf.BlocKey, conf.LineKeys);
                            break;
                        case OperationMode.Run:
                            result = caWebService.run(context, conf.PublicName, conf.XmlObject);
                            break;
                    }



                    logger.Log($"Result: ");
                    logger.Log($"{ (string.IsNullOrEmpty(result.resultXml) ? "NO result returned" : GetParsedResult(result.resultXml)) }");

                    if (result.messages?.Length > 0)
                    {
                        logger.Log("Messages:");
                        foreach (var item in result.messages)
                        {
                            logger.Log(item?.message);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Log("Error while calling WebService:");
                    logger.Log(e.Message);
                    logger.Log(e.StackTrace);
                }
            }
            return result;
        }

        private string GetParsedResult(string s)
        {
            string result = s;
            bool ok = false;
            try
            {
                result = System.Xml.Linq.XDocument.Parse(s).ToString();
                ok = true;
            }
            catch (Exception)
            {
                // JSON ?
            }
            if (!ok)
            {
                try
                {
                    result = JToken.Parse(s).ToString();
                    ok = true;
                }
                catch (Exception)
                {
                    // nothing to do
                }
            }

            return result;
        }
    }
}