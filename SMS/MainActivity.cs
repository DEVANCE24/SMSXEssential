using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace SMS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editTxt1;
        EditText editTxt2;
        Button button;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);
            editTxt1 = FindViewById<EditText>(Resource.Id.editText1);
           editTxt2 = FindViewById<EditText>(Resource.Id.editText2);
            Button button = FindViewById<Button>(Resource.Id.button1);
            
            button.Click += Button_Click;

        }

        private async void Button_Click(object sender, EventArgs e)
        {
            string recipient = editTxt1.Text;
            string messageText = editTxt2.Text;
            var message = new SmsMessage(messageText, new string[] { recipient });
           await Sms.ComposeAsync(message);

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}