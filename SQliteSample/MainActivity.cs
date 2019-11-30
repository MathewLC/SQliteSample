
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using s = System;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Android.Content;
using System.IO;
using System;

namespace SQliteSample
{

    public static class Settings
    {
        public static readonly string Db_path = Path.Combine(
        s.Environment.GetFolderPath(s.Environment.SpecialFolder.Personal),
        "database.db3");
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        [Export("add_click")] //Usado para declarar a funcao de click so colocando no axml
        public void add_button_Click(View v)
        {
            //Mostra uma mensagem curta na tela
            Toast.MakeText(this, "Navegando para cadastrar", ToastLength.Short).Show();

            /*Intent é algo que deverá ser aberto. Neste caso a ìntençao é uma nova acitivty a ser mostrada,
             * mas poderia ser um servico em background ou a abertura de visualizador de um arquivo especifico,
             * ou abrir uma tela de dialogo para o usuario compartilhar um arquivo, e por ai vai.
             */
            var intent = new Intent(this, typeof(cadastrar_activity));

            //Coloca nossa activity 'por cima' da atual
            StartActivity(intent);
        }

        [Export("login_click")]
        public void login_button_Click(View v)
        {
            Toast.MakeText(this, "Evento Click", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            

            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

