using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14
{
    class Core
    {
        public static KinohallEntities Db = new KinohallEntities();

        public static bool IsProfile = false;

        public static string kino;

        public static Users CurrentUser;

        public static Session SelectedSession;

        public static Movie SelectedKino { get; set; }
    }
}
