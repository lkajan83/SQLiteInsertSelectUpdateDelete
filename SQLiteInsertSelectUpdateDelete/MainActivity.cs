using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using SQLiteInsertSelectUpdateDelete.Model;
using SQLiteInsertSelectUpdateDelete.Resources.ModelView;


namespace SQLiteInsertSelectUpdateDelete
{
    [Activity(Label = "SQLiteInsertSelectUpdateDelete", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btninsert;
        Button btnselect;
        Button btnupdate;
        Button btndelete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            btninsert = FindViewById<Button>(Resource.Id.btninsert);
            btnselect = FindViewById<Button>(Resource.Id.btnselect);
            btnupdate = FindViewById<Button>(Resource.Id.btnupdate);
            btndelete = FindViewById<Button>(Resource.Id.btndelete);
            CreateDB(); //Calling DB Creation method  
            btninsert.Click += delegate { StartActivity(typeof(InsertActivity)); };
            btnselect.Click += delegate { StartActivity(typeof(SelectActivity)); };
            btnupdate.Click += delegate { StartActivity(typeof(UpdateActivity)); };
            btndelete.Click += delegate { StartActivity(typeof(DeleteActivity)); };
        }
        public string CreateDB()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }
    }
}