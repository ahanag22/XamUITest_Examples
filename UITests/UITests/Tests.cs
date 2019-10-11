﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

        //[Test]
        //public void repl()
        //{
        //    app.Repl();
        //}

		[Test]
		public void Enter_Creds_And_Tap_Ok ()
		{
			var isHybridApp = app.Query (c => c.WebView ()).Any ();
            app.Repl();

            if (isHybridApp) {
				app.EnterText (c => c.Css ("#username"), "PaulP");
				app.EnterText (c => c.Css ("#password"), "test password");
				app.DismissKeyboard ();

				app.Tap (c => c.Css("#loginButton"));

				app.WaitForElement (c => c.Marked ("Logged In"), "Timed out waiting for Logged In popup");

				app.Tap (c => c.Marked ("OK"));
			} else {
				app.EnterText (c => c.Marked ("username"), "PaulP");
				app.EnterText (c => c.Marked ("password"), "test password");
				app.DismissKeyboard ();

				app.Tap (c => c.Marked ("loginButton"));

				app.WaitForElement (c => c.Marked ("Logged In"), "Timed out waiting for Logged In popup");

				app.Tap (c => c.Marked ("OK"));
			}

		
		}
	}
}

