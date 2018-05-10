using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework9Final.fonts
{
    public partial class Graph : System.Web.UI.Page
    {
        Homework9Final.Mini_ProjectEntities myCollection = new Homework9Final.Mini_ProjectEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //List
            List<int> repartitions = new List<int>();
            var cTypes = myCollection.Clients.Select(x => x.ClientTypeID).Distinct();

            foreach (var item in cTypes)
            {
            //    repartitions.Add()
            }
           // var Collection = myCollection.
        }
    }
}