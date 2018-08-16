using ConsoleTester.Common;
using System;
using System.Collections;
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

        public bool ShowWarnings { get; set; }

        public void Validate()
        {
            logger.Log($"Launch {XmlFile} validation ... ");
            XmlReaderSettings settings = new XmlReaderSettings
            {
                //Message:Impossible de résoudre l'attribut 'schemaLocation'.
                //Error while XML validation: Pour des raisons de sécurité, DTD interdite dans ce document XML. Pour activer le traitement DTD, définissez sur Parse la propriété DtdProcessing sur XmlReaderSettings et transmettez les paramètres à la méthode XmlReader.Create. * ***
                DtdProcessing = DtdProcessing.Parse,
                MaxCharactersFromEntities = 1024,
                ValidationType = ValidationType.Schema
            };

            try
            {

                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.AllowXmlAttributes;
                // settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                // settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                if (ShowWarnings)
                {
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                }

                foreach (var xsd_file in XsdFiles)
                {
                    if (File.Exists(xsd_file))
                    {
                        settings.Schemas.Add(null, new XmlTextReader(xsd_file));
                    }
                    else
                    {
                        logger.Log($"{xsd_file} doesn't exist");
                    }
                }
                settings.Schemas.Compile();
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
                using (XmlTextReader xmltextReader = new XmlTextReader(this.XmlFile) { DtdProcessing = DtdProcessing.Parse })
                {
                    using (XmlReader reader = XmlReader.Create(xmltextReader, settings))
                    {
                        reader.MoveToContent();
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
            finally
            {
                ArrayList a = new ArrayList();
                foreach (var item in settings.Schemas.Schemas())
                {
                    XmlSchema xmlSchema = item as XmlSchema;
                    if (xmlSchema != null)
                        a.Add(xmlSchema);       
                }
                for (int i = 0; i < a.Count; i++)
                {
                    settings.Schemas.Remove(a[i] as XmlSchema);
                }

                settings.Schemas = null;
                settings.CloseInput = true;
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