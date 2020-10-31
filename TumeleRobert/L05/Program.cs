using System;

namespace L05
{
    class Program
    {
        private static CloudTableClient tableClient;
        private static CloudTable studentsTable;
        static void Main(string[] args)
        {
            Task.Run(async()=>{await Initialize();})
            .GetAwaiter();
            .GetResult();
        }

        static async Task Initialize(){
            string storageConnectionString = "";

            var account = CloudStorageAccount.Parse(storageConnectionString);
            tableClient = account.CreateTableClient();

            studentsTable = tableClient.GetTableReference("studenti");

            await studentsTable.CreateIfNotExistsAsync();

            await AddNewStudent();
        }
    }
}
