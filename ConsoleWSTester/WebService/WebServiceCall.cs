using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ConsoleTester
{
    public class WebServiceCall
    {
        private ILogger logger;
        private SOAPConfig conf;

        public enum OperationMode
        {
            Query,
            Modify,
            Read,
            Save,
            GetDescription,
            DeleteLines,
            InsertLines
        }

        public WebServiceCall(SOAPConfig config, ILogger logger)
        {
            this.conf = config;
            this.logger = logger;
        }


        public void Query()
        {
            LaunchWSCall(OperationMode.Query);
        }

        public void Modify(string xmlFileName)
        {
            this.conf.XmlObject = File.ReadAllText(xmlFileName);
            LaunchWSCall(OperationMode.Modify);
        }
        public void DeleteLines(string xmlFileName)
        {
            LaunchWSCall(OperationMode.DeleteLines);
        }
        public void Read()
        {
            LaunchWSCall(OperationMode.Read);
        }
        public void GetDescription()
        {
            LaunchWSCall(OperationMode.GetDescription);
        }
        public void Save(string xmlFileName)
        {
            conf.XmlObject = File.ReadAllText(xmlFileName);
            LaunchWSCall(OperationMode.Save);
        }


        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private void LaunchWSCall(OperationMode mode)
        {
            var caWebService = new CAWebService.CAdxWebServiceXmlCCClient();
            var context = new CAWebService.CAdxCallContext();
            context.poolAlias = conf.PoolAlias;
            context.codeUser = conf.Login;
            context.codeLang = conf.Language;
            context.requestConfig = conf.RequestConfiguration;

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
                    CAWebService.CAdxResultXml result = null;
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
                    }

                    logger.Log($"Result: ");
                    logger.Log($"{ (string.IsNullOrEmpty(result.resultXml) ? "NO result returned" : GetParsedResult(result.resultXml)) }");

                    if (result.messages.Length > 0)
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