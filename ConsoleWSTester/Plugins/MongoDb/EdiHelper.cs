using ConsoleTester.Common;
using ConsoleTester.UI;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.MongoDb
{
    public class EdiHelper
    {
        public Logger Logger { get; } = new Logger(MainForm.LogControl);
        public string MongoServer { get; }
        public string MongoDatabase { get; }

        public int LastItems = 100;

        public EdiHelper(string mongoServer, string mongoDatabase)
        {
            MongoServer = mongoServer;
            MongoDatabase = mongoDatabase;
        }


        private IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(MongoServer);// "mongodb://localhost/?safe=true";
            return client?.GetDatabase(MongoDatabase); // "syracuse");
        }

        public async Task<List<GridFSFileInfo>> SearchAsync(string fieldName, string searchType, string fieldvalue, int xLastItems)
        {
            List<GridFSFileInfo> fileInfos = null;
            try
            {
                IMongoDatabase database = GetDatabase();

                IMongoCollection<GridFSFileInfo> filesCollection = database.GetCollection<GridFSFileInfo>("fs.files");
                if (string.IsNullOrEmpty(fieldvalue))
                    fileInfos = await GetLastFilesAsync(filesCollection, xLastItems);
                else
                    fileInfos = await FindFilesAsync(filesCollection, fieldName, searchType, fieldvalue);

                Logger.Log($"Search fieldName: {fieldName}, value: {fieldvalue}  result(s): {fileInfos?.Count}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return fileInfos;
        }

        public async Task<List<GridFSFileInfo>> GetLastFilesAsync(IMongoCollection<GridFSFileInfo> filesCollection, int lastXItems)
        {
            FilterDefinitionBuilder<GridFSFileInfo> builder = Builders<GridFSFileInfo>.Filter;
            return await filesCollection.Find(builder.Empty).Limit(lastXItems).SortByDescending(item => item.UploadDateTime).ToListAsync();
        }


        public async Task<List<GridFSFileInfo>> FindFilesAsync(IMongoCollection<GridFSFileInfo> filesCollection, string fieldName, string searchType, string fieldvalue)
        {
            FilterDefinitionBuilder<GridFSFileInfo> builder = Builders<GridFSFileInfo>.Filter;
            FilterDefinition<GridFSFileInfo> filter = builder.Eq(fieldName, fieldvalue);
            if (fieldName.IndexOf("fileName", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                if (!string.IsNullOrEmpty(searchType) && searchType.Equals("Equals", StringComparison.CurrentCultureIgnoreCase))
                {
                    filter = builder.Eq(item => item.Metadata["fileName"], fieldvalue);
                }
                else
                {
                    filter = builder.Eq(item => item.Metadata["fileName"], fieldvalue);
                    // filter = builder.Where(item => item.Metadata["fileName"]..IndexOf( fieldvalue)>=0) ;

                    //return filesCollection.AsQueryable()
                    //    .Where(item => item.Metadata != null && item.Metadata.ContainsValue("fileName") 
                    //    && item.Metadata["fileName"].AsBsonValue.ToString().IndexOf(fieldvalue, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    //    .OrderByDescending(item => item.UploadDateTime).ToList();
                }
            }
            return await filesCollection.Find(filter).SortByDescending(item => item.UploadDateTime).ToListAsync();
        }

    }
}
