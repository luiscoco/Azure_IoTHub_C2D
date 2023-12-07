using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;

DeviceClient deviceClient;
string connectionString = "HostName=myIoTHubname1974.azure-devices.net;DeviceId=myDevice;SharedAccessKey=EzLbRGucSovGeSzk8WcfIvDuTqk752tpRAIoTO9Zbfk=";

await StartReceivingMessagesAsync();

Console.WriteLine("Press Enter to exit.");
Console.ReadLine();

async Task StartReceivingMessagesAsync()
{
    deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);

    while (true)
    {
        Message receivedMessage = await deviceClient.ReceiveAsync();

        if (receivedMessage == null) continue;

        string messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
        Console.WriteLine($"Received message: {messageData}");

        // Process the message as needed
        await deviceClient.CompleteAsync(receivedMessage);
    }
}


