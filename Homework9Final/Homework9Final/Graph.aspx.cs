using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
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
            List<string> ClientTypeNames = new List<string>();
            var cTypes = myCollection.Clients.Join(myCollection.ClientTypes,
                Client => Client.ClientTypeID,
                ClientType => ClientType.ClientTypeID,
                ( Client, ClientType ) => new
                {
                    Client.ClientID,
                    Client.ClientTypeID,
                    ClientType.ClientTypeName
                });

            foreach (var item in cTypes)
            {
                ClientTypeNames.Add(item.ClientTypeName);
                //repartitions.Add()
            }

            /*var cBookings = myCollection.Client_Vehicle_Line.Join(cTypes,
                Client_Vehicle_Line => Client_Vehicle_Line.ClientID,
                cType => cType.ClientID,
                (Client_Vehicle_Line, cType) => new
                {
                    Client_Vehicle_Line.VehicleID
                });
            */


            List<string> VehicleTypeNames = new List<string>();
            var cVehicleTypes = myCollection.Vehicles.Join(myCollection.VehicleTypes,
                Vehicle => Vehicle.VehicleTypeID,
                VehicleType => VehicleType.VehicleTypeID,
                (Vehicle, VehicleType) => new
                {
                    Vehicle.VehicleID,
                    Vehicle.VehicleTypeID,
                    VehicleType.VehicleTypeName
                });

            foreach (var item in cVehicleTypes)
            {
                VehicleTypeNames.Add(item.VehicleTypeName);
            }

            using (myCollection)
            {
                var cBookings = (
                    from d in cVehicleTypes
                    join c in myCollection.Client_Vehicle_Line on d.VehicleID equals c.VehicleID
                    join s in cTypes on c.ClientID equals s.ClientID
                    select new
                    {
                        VehicleID = c.VehicleID,
                        d.VehicleTypeID,
                        c.ClientID,
                        s.ClientTypeID,
                        c.Client_Vehicle_Booking
                    });

               // object[] count = new object[]();

                foreach (var item1 in cTypes.Select(x=>x.ClientTypeID))
                {
                    foreach (var item2 in cVehicleTypes.Select(x=>x.VehicleTypeID))
                    {
                         //cBookings.Where(x => x.ClientTypeID == item1.Value && x.VehicleTypeID == Int32.Parse(item2.ToString()));
                    }
                }

               // int count1 = 1;

                DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart").SetXAxis(new XAxis
                {
                    Categories = ClientTypeNames.ToArray()
                })
                .SetYAxis(new YAxis
                {
                    Categories = VehicleTypeNames.ToArray()
                })
                .SetSeries(new Series
                {

                    Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                });

                ltrChart.Text = chart.ToHtmlString();
            }
                

            /*var cVehicleTypeNames = myCollection.VehicleTypes.Join(cVehicles,
                VehicleType => VehicleType)
            */
            

            
            // var Collection = myCollection.

            

            /*List<int> numberofTypes = new List<int>();
            List<int> numberofVehicleTypes = new List<int>();
            foreach (var item in cBookings)
            {

            }*/

            
        }
    }
}