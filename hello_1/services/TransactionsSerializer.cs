using System.Text.Json;

namespace hello_1.services;

public class TransactionsSerializer
{
    public JsonSerializerOptions option = new JsonSerializerOptions
    {
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },

        WriteIndented = true
    };

    public string pathToSave =
        "C:\\Users\\sasha\\RiderProjects\\hello_1\\hello_1\\jsons\\transaction.json";
}