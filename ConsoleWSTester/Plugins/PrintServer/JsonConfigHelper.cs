using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.PrintServer
{
    internal class JsonConfigHelper
    {

        internal static string GetAdxEditionServerConfigXml(JObject configObject)
        {
            string result = string.Empty;
            JObject serverConfigObject = configObject["serverConfig"]?.Value<JObject>();
            if (serverConfigObject != null)
            {
                JObject adxSrvImpObject = serverConfigObject["adxSrvImp"]?.Value<JObject>();
                if (adxSrvImpObject != null)
                {
                    JArray arrayConfigs = adxSrvImpObject["config"]?.Value<JArray>();
                    foreach (JToken configItem in arrayConfigs)
                    {
                        result += $"Profile '{configItem["id"]}' : {configItem["cap"]}  \r\n";
                        JObject general = configItem["general"]?.Value<JObject>();
                        if (general != null)
                        {
                            result += $" General: lang: {general["lang"]}   Port: {general["port"]}  Recovery mode: {general["restartrpts"]} \r\n";
                        }
                        JObject jobs = configItem["jobs"]?.Value<JObject>();
                        if (jobs != null)
                        {
                            result += $" Jobs : Time before purging job : {jobs["purgetime"]} minutes     Max. running print processes : {jobs["max"]}    vpalloc: {jobs["vpalloc"]} \r\n";
                        }
                        JObject log = configItem["log"]?.Value<JObject>();
                        if (log != null)
                        {
                            result += $" Logs : number : {log["number"]}   size : {log["size"]} \r\n";
                        }
                        JObject processes = configItem["processes"]?.Value<JObject>();
                        if (log != null)
                        {
                            result += $" Processes : killtime : {processes["killtime"]} min,  max : {processes["max"]},   min : {processes["min"]},  maxjobsbyprocess : {processes["maxjobsbyprocess"] } jobs before reborn \r\n";
                        }
                    }
                }
            }

            return result;
        }


        internal static string GetAdxServerSolutionsXml(JObject configObject)
        {
            string result = string.Empty;

            JObject serverSolutionObject = configObject["serverSolutions"]?.Value<JObject>();
            if (serverSolutionObject != null)
            {
                JObject adonixObject = serverSolutionObject["adonix"]?.Value<JObject>();
                if (adonixObject != null)
                {
                    JArray arrayProfiles = adonixObject["profile"]?.Value<JArray>();
                    foreach (JToken profileItem in arrayProfiles)
                    {
                        result += $"profile: {profileItem["id"]} \r\n";

                        JObject grpsolsObject = profileItem["grpsols"]?.Value<JObject>();
                        if (grpsolsObject != null)
                        {
                            JArray arraySol = grpsolsObject["sol"]?.Value<JArray>();
                            foreach (JToken sol in arraySol)
                            {
                                result += $"solution id: {sol["id"]} \r\n";
                                JObject grpapps = sol["grpapps"]?.Value<JObject>();
                                if (grpapps != null)
                                {
                                    JObject app = grpapps["app"]?.Value<JObject>();
                                    if (app != null)
                                        result += $"folder: {app["folder"]}   host: {app["host"]}   port: {app["port"]} \r\n";
                                }

                                JObject odbc = sol["odbc"]?.Value<JObject>();
                                if (odbc != null)
                                {
                                    result += $"base: {odbc["base"]}\\{odbc["instance"]}   host: {odbc["host"]}   id: {odbc["id"]} \r\n";
                                }
                            }
                        }
                        result += $" \r\n";
                    }
                }
            }
            return result;
        }


        internal static string GetAdxOdbcConfigXml(JObject configObject)
        {
            string result = string.Empty;
            JObject serverSolutionObject = configObject["odbcConfig"]?.Value<JObject>();
            if (serverSolutionObject != null)
            {
                JObject adxodbcObject = serverSolutionObject["adxodbc"]?.Value<JObject>();
                JArray arraydbms = adxodbcObject["dbms"]?.Value<JArray>();
                foreach (JToken dbms in arraydbms)
                {
                    result += $"id = {dbms["id"]} cap = {dbms["cap"]}";
                    result += $"\r\n";
                    JArray drivers = dbms["driver"]?.Value<JArray>();
                    if (drivers != null)
                    {
                        foreach (JToken driver in drivers)
                        {
                            result += $"{ (driver["id"] != null ? $"id = {driver["id"]}" : string.Empty)} ";
                            result += $"{ (driver["default"] != null ? $"default = {driver["default"]}" : string.Empty)} ";
                            result += $"{ (driver["substitution"] != null ? $"substitution = {driver["substitution"]}" : string.Empty)} ";
                            result += $"{ (driver["wireprotocol"] != null ? $"wireprotocol = {driver["wireprotocol"]}" : string.Empty)} ";
                            result += $"{ (driver["wireprotocolmode"] != null ? $"wireprotocolmode = {driver["wireprotocolmode"]}" : string.Empty)} ";
                            result += $"\r\n";
                        }
                    }
                    result += $"\r\n";
                }

            }

            return result;
        }
    }
}
