using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ConsoleWSTester
{
    internal class WebServiceCall
    {

        private const string CAdxWebServiceXmlCC = "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC";
        //string endPointUrl = "http://localhost:8126/soap-wsdl/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC?wsdl";
        private const int MaxListSize = 4;

        private string hostUrl;
        private string poolAlias;
        private string language;
        private string publicName;
        private ILogger logger;
        private string xmlObject;
        private CAWebService.CAdxParamKeyValue[] objectKeys;

        public enum OperationMode
        {
            Query,
            Modify,
            Read,
            Save
        }

        public WebServiceCall(string hostUrl, string poolAlias, string lang, string publicName, CAWebService.CAdxParamKeyValue[] objectKeys, ILogger logger)
        {
            this.hostUrl = hostUrl;
            this.poolAlias = poolAlias;
            this.language = lang;
            this.publicName = publicName;
            this.objectKeys = objectKeys;
            this.logger = logger;
        }

        public void Query()
        {
            LaunchWSCall(OperationMode.Query);
        }

        public void Modify(string xmlFileName)
        {
            this.xmlObject = File.ReadAllText(xmlFileName);
            LaunchWSCall(OperationMode.Modify);
        }
        public void Read(string xmlFileName)
        {
            LaunchWSCall(OperationMode.Read);
        }

        public void Save(string xmlFileName)
        {
            this.xmlObject = File.ReadAllText(xmlFileName);
            LaunchWSCall(OperationMode.Save);
        }

        private void LaunchWSCall(OperationMode mode)
        {
            var caWebService = new CAWebService.CAdxWebServiceXmlCCClient();
            var context = new CAWebService.CAdxCallContext();
            context.poolAlias = this.poolAlias;
            context.codeLang = this.language;

            string absUrl = hostUrl + CAdxWebServiceXmlCC;
            caWebService.Endpoint.ListenUri = new Uri(absUrl);
            caWebService.Endpoint.Address = new EndpointAddress(absUrl);


            using (new OperationContextScope(caWebService.InnerChannel))
            {
                // Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Authorization"] = "Basic YWRtaW46YWRtaW4=";
                requestMessage.Headers["Accept"] = "application/soap+xml, application/dime, multipart/related, text/*";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                try
                {
                    logger.Log("");
                    logger.Log($"Calling: {caWebService.Endpoint.ListenUri.AbsoluteUri} Operation mode: {mode}    Pool: {poolAlias}   PublicName: {publicName} ... ");
                    //caWebService.ClientCredentials.Windows.ClientCredential.UserName = "admin";
                    //caWebService.ClientCredentials.Windows.ClientCredential.Password = "admin";

                    logger.Log($" ");
                    CAWebService.CAdxResultXml result = null;
                    switch (mode)
                    {
                        default:
                        case OperationMode.Query:
                            result = caWebService.query(context, publicName, null, MaxListSize);
                            break;
                        case OperationMode.Modify:
                            result = caWebService.modify(context, publicName, objectKeys, this.xmlObject);
                            break;
                        case OperationMode.Read:
                            result = caWebService.read(context, publicName, objectKeys);
                            break;
                        case OperationMode.Save:
                            result = caWebService.save(context, publicName, this.xmlObject);
                            break;
                    }

                    logger.Log($"Result: ");
                    logger.Log($"{ (string.IsNullOrEmpty(result.resultXml) ? "NO result returned" : result.resultXml) }");

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
    }
}