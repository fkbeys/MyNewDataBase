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
using Java.IO;
using Notes.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetDBFile))]
namespace Notes.Droid
{
    public class GetDBFile : CopyDB
    {
        public void copy()
        {
            string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Notes3.db-wal");
        //    string path1 = "/data/user/0/com.companyname.Notes/files/Notes3.db";
            File f = new File(path);
     //       var fileex=f.Exists();
            FileInputStream fis = null;
            FileOutputStream fos = null;
           
            fis = new FileInputStream(f);
            fos = new FileOutputStream("/mnt/sdcard/db_dump.db");
            while (true)
            {
                int i = fis.Read();
                if (i != -1)
                { fos.Write(i); }
                else
                { break; }
            }
            fos.Flush();
            
            Toast.MakeText(Android.App.Application.Context, "DB dump OK", ToastLength.Short).Show();
            fos.Close();
            fis.Close();
        }

       
 
    }

}
      
