using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Runtime.Hosting;
using System.Threading;

namespace Abercrombie
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void ReplTest()
		{
			app.Repl();
		}


		[Test]
		public void FirstTest()
		{
			app.Tap("SHOP WOMENS");
			app.Screenshot("Tapped on 'Shop Womens'");

			app.Tap(x => x.Id("buttonDefaultNegative"));
			app.Screenshot("Denied E-Mail Service");
			Thread.Sleep(2000);

			try
			{
				app.WaitForElement("DENY");
				app.Tap(x=>x.Marked("DENY"));
				//app.Screenshot("Denied Location service");
			}
			catch(Exception e)
			{
				
			}

			try
			{
				app.WaitForElement("DENY");
				app.Tap(x => x.Marked("DENY"));
				//app.Screenshot("Denied Location service");
			}
			catch (Exception e)
			{

			}

			app.WaitForElement("CATEGORIES");
			app.Tap("CATEGORIES");
			app.Screenshot("Tapped on 'Catagories'");

			app.ScrollDown();
			app.ScrollDown();
			app.WaitForElement("Sale");
			app.Screenshot("Scrolling down to 'Sale'");
			Thread.Sleep(2000);

			app.Tap("Sale");
			app.Screenshot("Tapped on 'Sale' button");

			app.WaitForElement("More Colors");
			app.Query(x => x.Class("RecyclerView").Invoke("smoothScrollToPosition", 20));
			app.Screenshot("Scrolling down to 'DENIM TWOFER JACKET'");
			Thread.Sleep(2000);

			app.Tap("DENIM TWOFER JACKET");
			app.Screenshot("Tapped on 'DENIM TWOFER JACKETT'");

			app.WaitForElement("ADD TO BAG");
			app.ScrollDown();
			app.Screenshot("Scrolled down to see the sizes available");
			Thread.Sleep(2000);

			app.Tap("M");
			app.Screenshot("Tapped on size 'M'");

			//app.Tap("Regular");
			//app.Screenshot("Tapped on 'Regular'");
			//Thread.Sleep(2000);

			app.Tap(x => x.Id("add_to_bag_button"));
			app.Screenshot("Added item to shopping cart");

			app.Tap("ic_shopping_cart");
			app.Screenshot("Tapped on shopping cart");
			Thread.Sleep(2000);

			app.Tap("checkout_button");
			app.Screenshot("Tapped on checkout button");
		}

	}
}
