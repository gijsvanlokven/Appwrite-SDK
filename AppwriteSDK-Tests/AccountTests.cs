using AppwriteSDK.Services;

namespace AppwriteSDK_Tests;

public class AccountTests
{

    [Test]
    public async Task AccountGetAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "GET";
        const string path = "/account";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.GetAsync();

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task AccountUpdateEmailAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PATCH";
        const string path = "/account/email";
        var parameters = new Dictionary<string, object>() { { "email", "test@test.com" }, { "password", "test" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdateEmailAsync("test@test.com", "test");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task AccountGetLogsAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "GET";
        const string path = "/account/logs";
        var parameters = new Dictionary<string, object>()
        {
            { "limit", 25 },
            { "offset", 75 }
        };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.GetLogsAsync(25, 75);

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task UpdateAccountPasswordAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PATCH";
        const string path = "/account/password";
        var parameters = new Dictionary<string, object>()
            { { "password", "newpassword" }, { "oldPassword", "password" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdatePasswordAsync("newpassword", "password");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task UpdateNameAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PATCH";
        const string path = "/account/name";
        var parameters = new Dictionary<string, object>() { { "name", "newname" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdateNameAsync("newname");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task GetAccountPreferencesAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "GET";
        const string path = "/account/prefs";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.GetPrefsAsync();

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task UpdatePrefsAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        var testObject = new object();
        const string method = "PATCH";
        const string path = "/account/prefs";
        var parameters = new Dictionary<string, object>() { { "prefs", testObject } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };



        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdatePrefsAsync(testObject);

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task CreateRecoveryAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "POST";
        const string path = "/account/recovery";
        var parameters = new Dictionary<string, object>()
            { { "email", "test@test.com" }, { "url", "thisisaredirectback" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.CreateRecoveryAsync("test@test.com", "thisisaredirectback");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task CompleteRecoveryAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PUT";
        const string path = "/account/recovery";
        var parameters = new Dictionary<string, object>()
        {
            { "userId", "1234" },
            { "secret", "mysecret" },
            { "password", "mypassword" },
            { "passwordAgain", "mypasswordAgain" }
        };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdateRecoveryAsync("1234", "mysecret", "mypassword", "mypasswordAgain");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task GetAccountSessionsAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "GET";
        const string path = "/account/sessions";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.GetSessionsAsync();

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task DeleteSessionsAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "DELETE";
        const string path = "/account/sessions";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.DeleteSessionsAsync();

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task GetSessionAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "GET";
        const string path = "/account/sessions/1234";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.GetSessionAsync("1234");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task DeleteSessionAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "DELETE";
        const string path = "/account/sessions/9876";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.DeleteSessionAsync("9876");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task UpdateAccountSessionAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PATCH";
        const string path = "/account/status";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdateAccountStatusAsync();

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task CreateVerificationAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "POST";
        const string path = "/account/verification";
        var parameters = new Dictionary<string, object>() { { "url", "redirecturl" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.CreateVerificationAsync("redirecturl");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }

    [Test]
    public async Task UpdateVerificationAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PUT";
        const string path = "/account/verification";
        var parameters = new Dictionary<string, object>() { { "userId", "1234" }, { "secret", "mysecret" } };
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdateVerificationAsync("1234", "mysecret");

        // ASSERT
        mock.Verify(p => p.Call(method, path, headers, parameters), Times.Once);
    }
    
    [Test]
    public async Task CreatePhoneVerificationAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "POST";
        const string path = "/account/verification/phone";
        var parameters = new Dictionary<string, object>();
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.CreatePhoneVerificationAsync();

        // ASSERT
        mock.Verify(p => p.Call(method,path,headers,parameters), Times.Once);
    }
    
    [Test]
    public async Task UpdatePhoneVerificationAsync_ThenTestInputAgainstSpec()
    {
        // ARRANGE
        const string method = "PUT";
        const string path = "/account/verification/phone";
        var parameters = new Dictionary<string, object>(){{"userId", "5678"}, {"secret","mysecret"}};
        var headers = new Dictionary<string, string>() { { "content-type", "application/json" } };


        var mock = new Mock<Client>();
        mock.Setup(p => p.Call(It.Is<string>(x => x.Equals(method)), It.Is<string>(x => x.Equals(path)),
            It.Is<Dictionary<string, string>>(x => x.Equals(headers)),
            It.Is<Dictionary<string, object>>(x => x.Equals(parameters))));

        var mocked = new Account(mock.Object);
        // ACT
        await mocked.UpdatePhoneVerificationAsync("5678", "mysecret");

        // ASSERT
        mock.Verify(p => p.Call(method,path,headers,parameters), Times.Once);
    }
}