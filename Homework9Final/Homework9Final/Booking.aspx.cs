using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework9Final
{
    public partial class Booking : System.Web.UI.Page
    {
        Homework9Final.Mini_ProjectEntities myCollection = new Homework9Final.Mini_ProjectEntities();
        private static string selectedClientID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            FillClientsTable();
            FillVehiclesTable();
            FillBookingsTable();
        }

        protected void btnCreateBooking_Click(object sender, EventArgs e)
        {
            dbxClientIDs.Enabled = false;
            btnStartBooking.Enabled = false;
            btnCancelBooking.Enabled = true;
            dbxVehicleIDs.Enabled = true;
            calDate.Enabled = true;
            btnPlaceBooking.Enabled = true;

            selectedClientID = dbxClientIDs.SelectedValue;
        }

        protected void btnPlaceBooking_Click(object sender, EventArgs e)
        {
            if (selectedClientID != "" && dbxVehicleIDs.SelectedValue != "" && calDate.SelectedDate.Date != DateTime.MinValue)
            {
                Client_Vehicle_Line temp = new Client_Vehicle_Line();

                temp.ClientID = Int32.Parse(selectedClientID);
                temp.VehicleID = Int32.Parse(dbxVehicleIDs.SelectedValue);
                temp.Client_Vehicle_Booking = calDate.SelectedDate;

                myCollection.Client_Vehicle_Line.AddObject(temp);

                myCollection.SaveChanges();
                FillBookingsTable();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select the Date during which the booking of the Vehicle will begin');</script>");
            }
        }

        protected void btnCancelBooking_Click(object sender, EventArgs e)
        {
            dbxClientIDs.Enabled = true;
            btnStartBooking.Enabled = true;
            btnCancelBooking.Enabled = false;
            dbxVehicleIDs.Enabled = false;
            calDate.Enabled = false;
            btnPlaceBooking.Enabled = false;

            selectedClientID = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var selectedVehicleID = Int32.Parse(dbxVehicleIDsforClients.SelectedValue);
            var collection = myCollection.Client_Vehicle_Line.Where(Client_Vehicle_Line => Client_Vehicle_Line.VehicleID == selectedVehicleID);

            dgvBookings.DataSource = collection;
            dgvBookings.DataBind();
        }

        protected void btnDisplayVehicleTypesofClient_Click(object sender, EventArgs e)
        {
            var selectedClientID = Int32.Parse(dbxClientIDforQuery.SelectedValue);
            var collection = myCollection.Client_Vehicle_Line.Join(
                myCollection.Vehicles,
                Client_Vehicle_Line => Client_Vehicle_Line.VehicleID,
                Vehicle => Vehicle.VehicleID,
                (Vehicle, Client_Vehicle_Line) => new
                {
                    Vehicle.Line_ID,
                    Vehicle.ClientID,
                    Vehicle.VehicleID,
                    Vehicle.Client_Vehicle_Booking,
                    Client_Vehicle_Line.VehicleTypeID
                }).
                Where(x => x.ClientID == selectedClientID &&
                x.Client_Vehicle_Booking == calDateQueryVehicleType.SelectedDate);

            var getVehicleTypeNames = collection.Join(
                myCollection.VehicleTypes,
                VehicleType => VehicleType.VehicleTypeID,
                Client_Vehicle_Line => Client_Vehicle_Line.VehicleTypeID,
                (VehicleType, Client_Vehicle_Line) => new
                {
                    VehicleType.Line_ID,
                    VehicleType.ClientID,
                    VehicleType.VehicleID,
                    Client_Vehicle_Line.VehicleTypeName
                });

            dgvVehicleTypesviaClient.DataSource = getVehicleTypeNames;
            dgvVehicleTypesviaClient.DataBind();
        }

        public void FillClientsTable()
        {
            foreach (var item in myCollection.Clients)
            {
                if (!IsPostBack)
                {
                    dbxClientIDs.Items.Add(item.ClientID.ToString());
                    dbxClientIDforQuery.Items.Add(item.ClientID.ToString());
                }
            }

            dgvClients.DataSource = myCollection.Clients;
            dgvClients.DataBind();
        }

        public void FillVehiclesTable()
        {
            foreach (var item in myCollection.Vehicles)
            {
                if (!IsPostBack)
                {
                    dbxVehicleIDs.Items.Add(item.VehicleID.ToString());
                    dbxVehicleIDsforClients.Items.Add(item.VehicleID.ToString());
                }
            }

            dgvVehicles.DataSource = myCollection.Vehicles;
            dgvVehicles.DataBind();
        }

        public void FillBookingsTable()
        {
            dgvBookings.DataSource = myCollection.Client_Vehicle_Line;
            dgvBookings.DataBind();
        }
    }
}