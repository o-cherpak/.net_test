using System.Text.Json;

namespace hello_1.services;

public class BankSerializer
{
    public JsonSerializerOptions option = new JsonSerializerOptions
    {
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },

        WriteIndented = true
    };

    public readonly string pathToSaveTransactions = "hello_1/jsons/transaction.json";
}