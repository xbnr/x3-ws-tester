using ConsoleTester.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ConsoleTester.Plugins.XsdValidator
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/wc8csdkz(v=vs.71).aspx
    /// </summary>
    public class Validation
    {
        private ILogger logger;

        public Validation(ILogger log)
        {
            logger = log;
        }

        private string XmlFile;
        private List<string> XsdFiles = new List<string>();

        public void SetXML(string xmlfile)
        {
            XmlFile = xmlfile;
        }
        public void AddXsd(string xsdfile)
        {
            XsdFiles.Add(xsdfile);
        }
        public void AddXsd(IList<string> xsdfiles)
        {
            XsdFiles.AddRange(xsdfiles);
        }

        public void Validate()
        {
            try
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
                foreach (var xsd_file in XsdFiles)
                {
                    schemaSet.Add(null, xsd_file);
                    // ss.Add(null, new XmlTextReader(xsd_file));
                }
                if (schemaSet.Count > 0)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;

                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;


                    settings.Schemas.Add(schemaSet);
                    settings.Schemas.Compile();
                    settings.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
                    XmlTextReader r = new XmlTextReader(this.XmlFile);
                    using (XmlReader reader = XmlReader.Create(r, settings))
                    {
                        while (reader.Read())
                        {
                        }
                    }
                }
                logger.Log($"{XmlFile} Validation finished successfully");
            }
            catch (Exception e)
            {
                logger.Log($"Error while XML validation: {e.Message}", true);
                logger.Log($"{XmlFile} Validation FAILED");
            }
        }


        public void ValidationHandler(object sender, ValidationEventArgs args)
        {
            logger.Log("Validation error", true);
            logger.Log($"\tSeverity:{args.Severity}");
            logger.Log($"\tMessage:{args.Message}");
        }
    }
}