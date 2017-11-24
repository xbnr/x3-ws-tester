using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.WebService
{
    using System.Windows.Forms;
    using Newtonsoft.Json.Linq;

    namespace JsonTreeView
    {
        public static class JsonTreeViewLoader
        {
            public static void LoadJsonToTreeView(this TreeView treeView, string json, string rootTitle)
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return;
                }

                var @object = JObject.Parse(json);
                AddObjectNodes(@object, string.IsNullOrEmpty(rootTitle) ? "JSON" : rootTitle, treeView.Nodes);
            }

            public static void AddObjectNodes(JObject @object, string name, TreeNodeCollection parent)
            {
                var node = new TreeNode(name);
                parent.Add(node);

                foreach (var property in @object.Properties())
                {
                    AddTokenNodes(property.Value, property.Name, node.Nodes);
                }
            }

            private static void AddArrayNodes(JArray array, string name, TreeNodeCollection parent)
            {
                var node = new TreeNode(name);
                parent.Add(node);

                for (var i = 0; i < array.Count; i++)
                {
                    AddTokenNodes(array[i], string.Format("[{0}]", i), node.Nodes);
                }
            }

            private static void AddTokenNodes(JToken token, string name, TreeNodeCollection parent)
            {
                if (token is JValue)
                {
                    parent.Add(new TreeNode(string.Format("{0}: {1}", name, ((JValue)token).Value)));
                }
                else if (token is JArray)
                {
                    AddArrayNodes((JArray)token, name, parent);
                }
                else if (token is JObject)
                {
                    AddObjectNodes((JObject)token, name, parent);
                }
            }
        }
    }
}
