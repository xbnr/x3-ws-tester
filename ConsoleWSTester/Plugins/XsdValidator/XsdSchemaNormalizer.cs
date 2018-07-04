using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Collections;

namespace ConsoleTester.Plugins.XsdValidator
{

    /// <summary>
    /// XSD Schema Include Normalizer  
    ///
    /// Example:  filename.exe schema.xsd  
    /// https://docs.microsoft.com/en-us/sql/relational-databases/xml/preprocess-a-schema-to-merge-included-schemas?view=sql-server-2017
    /// </summary>
    public class XsdSchemaNormalizer
    {

        public void Merge(string xsdFileName, string xsdOutputFilename)
        {
            StreamWriter output = new StreamWriter(new FileStream(xsdOutputFilename, FileMode.Create));
            NormalizeXmlSchema(xsdFileName, output);
        }

        private static bool NormalizeXmlSchema(String url, TextWriter writer)
        {
            try
            {
                XmlTextReader txtRead = new XmlTextReader(url);
                XmlSchema sch = XmlSchema.Read(txtRead, null);

                // Compiling Schema  
                sch.Compile(null);

                XmlSchema outSch = XmlSchemaIncludeNormalizer.BuildIncludeFreeXmlSchema(sch);

                outSch.Write(writer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }


        // A class to remove all <include> from a Xml Schema  
        //  
        public class XmlSchemaIncludeNormalizer
        {
            // Takes as input a XmlSchema which has includes in it   
            // and the schema location uri of that XmlSchema  
            //   
            // Returns a "preprocessed" form of XmlSchema without any   
            // includes. It still retains imports though. Also, it does  
            // not propagate unhandled attributes  
            //  
            // It can throw any exception  
            public static XmlSchema BuildIncludeFreeXmlSchema(XmlSchema inSch)
            {
                XmlSchema outSch = new XmlSchema();

                AddSchema(outSch, inSch);

                return outSch;
            }

            /// Adds everything in the second schema minus includes to the first schema  
            private static void AddSchema(XmlSchema outSch, XmlSchema add)
            {
                outSch.AttributeFormDefault = add.AttributeFormDefault;
                outSch.BlockDefault = add.BlockDefault;
                outSch.ElementFormDefault = add.ElementFormDefault;
                outSch.FinalDefault = add.FinalDefault;
                outSch.Id = add.Id;
                outSch.TargetNamespace = add.TargetNamespace;
                outSch.Version = add.Version;

                AddTableToSchema(outSch, add.AttributeGroups);
                AddTableToSchema(outSch, add.Attributes);
                AddTableToSchema(outSch, add.Elements);
                AddTableToSchema(outSch, add.Groups);
                AddTableToSchema(outSch, add.Notations);
                AddTableToSchema(outSch, add.SchemaTypes);

                // Handle includes as a special case  
                for (int i = 0; i < add.Includes.Count; i++)
                {
                    if (!(add.Includes[i] is XmlSchemaInclude))
                        outSch.Includes.Add(add.Includes[i]);
                }
            }

            // Adds all items in the XmlSchemaObjectTable to the specified XmlSchema  
            //  
            private static void AddTableToSchema(XmlSchema outSch, XmlSchemaObjectTable table)
            {
                IDictionaryEnumerator e = table.GetEnumerator();

                while (e.MoveNext())
                {
                    outSch.Items.Add((XmlSchemaObject)e.Value);
                }
            }
        }
    }
}
