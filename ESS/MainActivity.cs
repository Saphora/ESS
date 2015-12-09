using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Runtime;
using Android.Text;
using Providers;
using System.Linq;
using Android.Views;
using System.Collections.Generic;
using System;

namespace ESS
{
	[Activity (Label = "ESS", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		DateTimeProvider p = new DateTimeProvider();
		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button> (Resource.Id.button1);
            //button.Click += delegate {
            //	button.Text = string.Format ("{0} clicks!", count++);
            //};
        }

        protected override void OnStart()
        {
            try {
                var r = p.GetWeeks();
                ListView WeekView = FindViewById<ListView>(Resource.Id.WeekList);
                List<string> Weeks = (from w in r.Keys select string.Format("Week {0}", w)).ToList();
                ArrayAdapter<string> WeekAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Weeks);
                WeekView.SetAdapter(WeekAdapter);
                base.OnStart();
            } catch(Exception ex)
            {
                base.OnStart();
            }
        }
    }
}
