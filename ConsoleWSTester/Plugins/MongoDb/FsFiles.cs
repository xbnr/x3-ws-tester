using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.MongoDb
{
    class FsFiles
    {
           [BsonId]
            public string _id { get; set; }
            public string filename { get; set; } = string.Empty;
            public DateTime updatedOn { get; set; } = DateTime.Now;
            public DateTime createdOn { get; set; } = DateTime.Now;
            public int length { get; set; } = 0;

    }
}
