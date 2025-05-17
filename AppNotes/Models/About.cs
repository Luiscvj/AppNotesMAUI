using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotes.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;

        public string Version => AppInfo.VersionString;

        public string MoreInfoUrl => "https://thecodercave.com";

        public string Message => "This app is written in MAUI";
    }
}
