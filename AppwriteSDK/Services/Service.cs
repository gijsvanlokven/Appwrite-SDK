namespace AppwriteSDK.Services
{
    public abstract class Service
    {
        protected readonly Client Client;

        protected Service(Client client)
        {
            Client = client;
        }
    }
}