using System.Dynamic;

namespace AppwriteSDK_Tests;

public class TestClient : Client{
    public TestClient()
    {
        
    }

    public new virtual void Call(string method, string path, Dictionary<string, string> headers,
        Dictionary<string, object> parameters)
    {
        // virtual method for mocking
    }
    
    
}
