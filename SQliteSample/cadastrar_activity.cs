using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using SQLite;

namespace SQliteSample
{
    [Activity(Label = "Cadastrar", Theme = "@style/AppTheme.NoActionBar")]
    public class cadastrar_activity:AppCompatActivity
    {
        [Export("cadastrar_click")]
        public void cadastrar_button_Click(View v)
        {
            EditText _text1 = this.FindViewById<EditText>(Resource.Id.editText1);
            EditText _text2 = this.FindViewById<EditText>(Resource.Id.editText2);

            var db = new SQLiteConnection(Settings.Db_path);
            db.CreateTable<Usuario>();

            var usuario = new Usuario
            {
                Login = _text1.Text,
                Senha = _text2.Text
            };

            db.Insert(usuario);

            var usuarioCadastradoNome = "";
            if(db.Table<Usuario>().Count() > 0)
                usuarioCadastradoNome = db.Table<Usuario>().Where(usu => usu.Login == usuario.Login).FirstOrDefault()?.Login;
            
             if(usuarioCadastradoNome != "")   
                Toast.MakeText(this, "Usuario " + usuarioCadastradoNome + " foi cadastrado com sucesso!", ToastLength.Short).Show();
             else
                Toast.MakeText(this, "Usuario não foi cadastrado!", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_cadastrar);
        }
    }
}
