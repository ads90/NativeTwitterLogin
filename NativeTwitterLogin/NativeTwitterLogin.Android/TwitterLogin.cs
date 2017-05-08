using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Twitter = Com.Twitter.Sdk.Android.Core;
using Android.Accounts;

[assembly: Xamarin.Forms.Dependency(typeof(NativeTwitterLogin.Droid.TwitterLogin))]

namespace NativeTwitterLogin.Droid
{
    class TwitterLogin : Twitter.Callback, IAuthTwitter
    {
        public static readonly string TwitterConsumerKey = " ";
        public static readonly string TwitterConsumerSecret = " ";

        public static readonly string TwitterRequestUrl = "https://api.twitter.com/oauth/request_token";
        public static readonly string TwitterAuth = "https://api.twitter.com/oauth/authorize";
        public static readonly string TwitterAccessToken = "https://api.twitter.com/oauth/access_token";

        public TwitterLogin()
        {
            Twitter.TwitterAuthConfig authConfig = new Twitter.TwitterAuthConfig(TwitterConsumerKey, TwitterConsumerSecret);
            Twitter.TwitterCore twitterKit = new Twitter.TwitterCore(authConfig);
            IO.Fabric.Sdk.Android.Fabric.With(MainActivity.Instance, twitterKit);
        }


        public void Login()
        {
            MainActivity.Instance.twitterClient = new Twitter.Identity.TwitterAuthClient();
            MainActivity.Instance.twitterClient.Authorize(MainActivity.Instance, this);
        }

        public override void Success(Twitter.Result p0)
        {
            Twitter.TwitterSession account = p0.Data as Twitter.TwitterSession;
            Twitter.TwitterAuthToken accountToken = account.AuthToken as Twitter.TwitterAuthToken;
        }
        public override void Failure(Twitter.TwitterException p0)
        {

        }

    }
}