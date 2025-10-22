using System;
using MongoSandbox;

namespace Avid.PaymentService.DigitalWallet.MongoDB;

public class MongoDbFixture : IDisposable
{
    public static readonly IMongoRunner MongoDbRunner;

    static MongoDbFixture()
    {
        MongoDbRunner = MongoRunner.Run(new MongoRunnerOptions { UseSingleNodeReplicaSet = true });
    }

    public void Dispose()
    {
        MongoDbRunner?.Dispose();
    }

    public static string GetRandomConnectionString()
    {
        return GetConnectionString("Db_" + Guid.NewGuid().ToString("N"));
    }

    public static string GetConnectionString(string databaseName)
    {
        var stringArray = MongoDbRunner.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') + databaseName + "/?" + stringArray[1];
        return connectionString;
    }
}