using FolderAppServices.FolderBPClient.BuddyPress;
using System;
using System.Threading.Tasks;
using WordPressPCL;

namespace FolderAppServices
{
    public class FolderWPClient
    {

        public WordPressClient WordPressClient { get; private set; }

        public BuddyPressClient BuddyPressClient { get; private set; }

        public FolderWPClient()
        {
            WordPressClient = new WordPressClient(Config.FolderWPEndpoint);
            BuddyPressClient = new BuddyPressClient(Config.FolderWPEndpoint);
        }

        public string GetToken()
        {
            return WordPressClient.GetToken();
        }

        public void SetJWToken(string currentToken)
        {
            WordPressClient.SetJWToken(currentToken);
            BuddyPressClient.SetJWToken(currentToken);
        }

        public Task RequestJWToken(string username, string password)
        {
            return WordPressClient.RequestJWToken(username, password);        
        }

        public Task<bool> IsValidJWToken()
        {
            return WordPressClient.IsValidJWToken();
        }
    }
}
