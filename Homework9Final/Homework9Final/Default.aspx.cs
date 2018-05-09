using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.EntityClient;
using System.Data.Entity;

namespace Homework9Final
{
    public partial class _Default : Page
    {
        Homework9Final.Mini_ProjectEntities MyController = new Homework9Final.Mini_ProjectEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillClientsTable();
            FillClientTypesTable();
            FillVehiclesTable();
            FillVehicleTypesTable();
        }

        protected void btnAddClientType_Click(object sender, EventArgs e)
        {
            if (inputClientTypeName.Text != "" && inputClientTypeDescription.Text != "")
            {
                if (MyController.ClientTypes.Any(ClientType =>
                    ClientType.ClientTypeName == inputClientTypeName.Text &&
                    ClientType.ClientTypeDescription == inputClientTypeDescription.Text) == false)
                {
                    ClientType tempType = new ClientType();
                    tempType.ClientTypeName = inputClientTypeName.Text;
                    tempType.ClientTypeDescription = inputClientTypeDescription.Text;

                    MyController.ClientTypes.AddObject(tempType);
                    MyController.SaveChanges();

                    var tempClientTypes = MyController.ClientTypes.OrderByDescending(ClientType => ClientType.ClientTypeID);
                    var newClientTypeID = tempClientTypes.First().ClientTypeID.ToString();
                    dbxClientTypeID.Items.Add(newClientTypeID);

                    FillClientsTable();

                    inputClientTypeID.Text = "";
                    inputClientTypeName.Text = "";
                    inputClientTypeDescription.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Client Type already exists. Please ensure details are correct.');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please ensure all details are entered.');</script>");
            }
        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            if (inputName.Text != "" && inputEmail.Text != "" && inputContactNumber.Text != "")
            {
                if (MyController.Clients.Any(Client => 
                    Client.ClientName == inputName.Text &&
                    Client.ClientEmail == inputEmail.Text &&
                    Client.ClientContactNumber == inputContactNumber.Text) == false)
                {
                    Client tempClient = new Client();
                    tempClient.ClientName = inputName.Text;
                    tempClient.ClientEmail = inputEmail.Text;
                    tempClient.ClientContactNumber = inputContactNumber.Text;
                    tempClient.ClientTypeID = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeName == dbxClientTypeName.SelectedValue).ClientTypeID;

                    MyController.Clients.AddObject(tempClient);
                    MyController.SaveChanges();

                    var tempClients = MyController.Clients.OrderByDescending(Client => Client.ClientID);
                    var newClientID = tempClients.First().ClientID.ToString();
                    dbxClientID.Items.Add(newClientID);

                    FillClientsTable();

                    inputClientID.Text = "";
                    inputName.Text = "";
                    inputEmail.Text = "";
                    inputContactNumber.Text = "";
                    dbxClientTypeName.SelectedIndex = 0;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Client already exists. Please ensure details are correct.');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please ensure all details are entered.');</script>");
            }
        }

        protected void btnSelectClient_Click(object sender, EventArgs e)
        {
            var selectedClientID = int.Parse(dbxClientID.SelectedValue);
            var selectedClient = MyController.Clients.Single(Client => Client.ClientID == selectedClientID);

            inputClientID.Text = selectedClient.ClientID.ToString();
            inputName.Text = selectedClient.ClientName;
            inputEmail.Text = selectedClient.ClientEmail;
            inputContactNumber.Text = selectedClient.ClientContactNumber;

            var selectedClientType = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeID == selectedClient.ClientTypeID);
            dbxClientTypeName.SelectedValue = selectedClientType.ClientTypeName;
        }

        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (inputName.Text != "" && inputEmail.Text != "" && inputContactNumber.Text != "")
            {
                var selectedClientID = int.Parse(inputClientID.Text);
                var selectedClient = MyController.Clients.Single(Client => Client.ClientID == selectedClientID);

                selectedClient.ClientName = inputName.Text;
                selectedClient.ClientEmail = inputEmail.Text;
                selectedClient.ClientContactNumber = inputContactNumber.Text;
                selectedClient.ClientTypeID = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeName == dbxClientTypeName.Text).ClientTypeID;

                MyController.SaveChanges();
                FillClientsTable();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a client first.');</script>");
            }
        }

        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (inputName.Text != "" && inputEmail.Text != "" && inputContactNumber.Text != "")
            {
                var selectedClientID = int.Parse(inputClientID.Text);
                var selectedClient = MyController.Clients.Single(Client => Client.ClientID == selectedClientID);

                MyController.Clients.DeleteObject(selectedClient);

                MyController.Clients.Context.ExecuteStoreCommand("DBCC CHECKIDENT('Client', RESEED, " + (selectedClientID - 1) + ")");

                MyController.SaveChanges();

                dbxClientID.Items.Clear();
                foreach (var item in MyController.Clients)
                {
                    dbxClientID.Items.Add(item.ClientID.ToString());
                }

                FillClientsTable();

                inputClientID.Text = "";
                inputName.Text = "";
                inputEmail.Text = "";
                inputContactNumber.Text = "";
                dbxClientTypeName.SelectedIndex = 0;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a client first.');</script>");
            }
        }

        protected void btnUpdateClientType_Click(object sender, EventArgs e)
        {
            if (inputClientTypeName.Text != "" && inputClientTypeDescription.Text != "")
            {
                var selectedClientTypeID = int.Parse(inputClientTypeID.Text);
                var selectedClientType = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeID == selectedClientTypeID);

                selectedClientType.ClientTypeName = inputClientTypeName.Text;
                selectedClientType.ClientTypeDescription = inputClientTypeDescription.Text;

                MyController.SaveChanges();
                FillClientTypesTable();

                inputClientTypeID.Text = "";
                inputClientTypeName.Text = "";
                inputClientTypeDescription.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Client Type first.');</script>");
            }
        }

        protected void btnDeleteClientType_Click(object sender, EventArgs e)
        {
            if (inputClientTypeName.Text != "" && inputClientTypeDescription.Text != "")
            {
                var selectedClientTypeID = int.Parse(inputClientTypeID.Text);
                var selectedClientType = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeID == selectedClientTypeID);

                MyController.DeleteObject(selectedClientType);

                MyController.ClientTypes.Context.ExecuteStoreCommand("DBCC CHECKIDENT('ClientType', RESEED, " + (selectedClientTypeID - 1) + ")");

                MyController.SaveChanges();

                dbxClientTypeID.Items.Clear();
                foreach (var item in MyController.ClientTypes)
                {
                    dbxClientTypeID.Items.Add(item.ClientTypeID.ToString());
                }

                FillClientTypesTable();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Client Type first.');</script>");
            }
        }

        protected void btnSelectClientType_Click(object sender, EventArgs e)
        {
            var selectedClientTypeID = int.Parse(dbxClientTypeID.SelectedValue);
            var selectedClientType = MyController.ClientTypes.Single(ClientType => ClientType.ClientTypeID == selectedClientTypeID);

            inputClientID.Text = selectedClientType.ClientTypeID.ToString();
            inputName.Text = selectedClientType.ClientTypeName;
            inputEmail.Text = selectedClientType.ClientTypeDescription;
        }

        protected void btnAddVehicleType_Click(object sender, EventArgs e)
        {
            if (inputVehicleTypeName.Text != "" && inputVehicleTypeDescription.Text != "")
            {
                if (MyController.VehicleTypes.Any(VehicleType =>
                    VehicleType.VehicleTypeName == inputVehicleTypeName.Text &&
                    VehicleType.VehicleTypeDescription == inputVehicleTypeDescription.Text) == false)
                {
                    VehicleType tempType = new VehicleType();
                    tempType.VehicleTypeName = inputVehicleTypeName.Text;
                    tempType.VehicleTypeDescription = inputVehicleTypeDescription.Text;

                    MyController.VehicleTypes.AddObject(tempType);
                    MyController.SaveChanges();

                    var tempVehicleTypes = MyController.VehicleTypes.OrderByDescending(VehicleType => VehicleType.VehicleTypeID);
                    var newVehicleTypeID = tempVehicleTypes.First().VehicleTypeID.ToString();
                    dbxVehicleTypeID.Items.Add(newVehicleTypeID);

                    FillVehicleTypesTable();

                    inputVehicleTypeID.Text = "";
                    inputVehicleTypeName.Text = "";
                    inputVehicleTypeDescription.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Vehicle Type already exists. Please ensure details are correct.');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please ensure all details are entered.');</script>");
            }
        }

        protected void btnUpdateVehicleType_Click(object sender, EventArgs e)
        {
            if (inputVehicleTypeName.Text != "" && inputVehicleTypeDescription.Text != "")
            {
                var selectedVehicleTypeID = int.Parse(inputVehicleTypeID.Text);
                var selectedVehicleType = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeID == selectedVehicleTypeID);

                selectedVehicleType.VehicleTypeName = inputVehicleTypeName.Text;
                selectedVehicleType.VehicleTypeDescription = inputVehicleTypeDescription.Text;

                MyController.SaveChanges();
                FillVehicleTypesTable();

                inputVehicleTypeID.Text = "";
                inputVehicleTypeName.Text = "";
                inputVehicleTypeDescription.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Vehicle Type first.');</script>");
            }
        }

        protected void btnDeleteVehicleType_Click(object sender, EventArgs e)
        {
            if (inputVehicleTypeName.Text != "" && inputClientTypeDescription.Text != "")
            {
                var selectedVehicleTypeID = int.Parse(inputVehicleTypeID.Text);
                var selectedVehicleType = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeID == selectedVehicleTypeID);

                MyController.DeleteObject(selectedVehicleType);

                MyController.VehicleTypes.Context.ExecuteStoreCommand("DBCC CHECKIDENT('ClientType', RESEED, " + (selectedVehicleTypeID - 1) + ")");

                MyController.SaveChanges();

                dbxVehicleTypeID.Items.Clear();
                foreach (var item in MyController.VehicleTypes)
                {
                    dbxVehicleTypeID.Items.Add(item.VehicleTypeID.ToString());
                }

                FillVehicleTypesTable();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Vehicle Type first.');</script>");
            }
        }

        protected void btnSelectVehicleType_Click(object sender, EventArgs e)
        {
            var selectedVehicleTypeID = int.Parse(dbxVehicleTypeID.SelectedValue);
            var selectedVehicleType = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeID == selectedVehicleTypeID);

            inputVehicleID.Text = selectedVehicleType.VehicleTypeID.ToString();
            inputVehicleName.Text = selectedVehicleType.VehicleTypeName;
            inputVehicleDescription.Text = selectedVehicleType.VehicleTypeDescription;
        }

        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if (inputVehicleName.Text != "" && inputVehicleDescription.Text != "")
            {
                if (MyController.Vehicles.Any(Vehicle =>
                    Vehicle.VehicleName == inputVehicleName.Text &&
                    Vehicle.VehicleDescription == inputVehicleDescription.Text) == false)
                {
                    Vehicle tempVehicle = new Vehicle();
                    tempVehicle.VehicleName = inputVehicleName.Text;
                    tempVehicle.VehicleDescription = inputVehicleDescription.Text;
                    tempVehicle.VehicleTypeID = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeName == dbxVehicleTypeName.SelectedValue).VehicleTypeID;

                    MyController.Vehicles.AddObject(tempVehicle);
                    MyController.SaveChanges();

                    var tempVehicles = MyController.Vehicles.OrderByDescending(Vehicle => Vehicle.VehicleID);
                    var newVehicleID = tempVehicles.First().VehicleID.ToString();
                    dbxVehicleID.Items.Add(newVehicleID);

                    FillVehiclesTable();

                    inputVehicleID.Text = "";
                    inputVehicleName.Text = "";
                    inputVehicleDescription.Text = "";
                    dbxVehicleTypeName.SelectedIndex = 0;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Vehicle already exists. Please ensure details are correct.');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please ensure all details are entered.');</script>");
            }
        }

        protected void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            if (inputVehicleName.Text != "" && inputVehicleDescription.Text != "")
            {
                var selectedVehicleID = int.Parse(inputVehicleID.Text);
                var selectedVehicle = MyController.Vehicles.Single(Vehicle => Vehicle.VehicleID == selectedVehicleID);

                selectedVehicle.VehicleName = inputVehicleName.Text;
                selectedVehicle.VehicleDescription = inputVehicleDescription.Text;
                selectedVehicle.VehicleTypeID = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeName == dbxVehicleTypeName.Text).VehicleTypeID;

                MyController.SaveChanges();
                FillVehiclesTable();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Vehicle first.');</script>");
            }
        }

        protected void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            if (inputVehicleName.Text != "" && inputVehicleDescription.Text != "")
            {
                var selectedVehicleID = int.Parse(inputVehicleID.Text);
                var selectedVehicle = MyController.Vehicles.Single(Vehicle => Vehicle.VehicleID == selectedVehicleID);

                MyController.Vehicles.DeleteObject(selectedVehicle);

                MyController.Vehicles.Context.ExecuteStoreCommand("DBCC CHECKIDENT('Client', RESEED, " + (selectedVehicleID - 1) + ")");

                MyController.SaveChanges();

                dbxVehicleID.Items.Clear();
                foreach (var item in MyController.Vehicles)
                {
                    dbxVehicleID.Items.Add(item.VehicleID.ToString());
                }

                FillVehiclesTable();

                inputVehicleID.Text = "";
                inputVehicleName.Text = "";
                inputVehicleDescription.Text = "";
                dbxVehicleTypeName.SelectedIndex = 0;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a Vehicle first.');</script>");
            }
        }

        protected void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicleID = int.Parse(dbxVehicleID.SelectedValue);
            var selectedVehicle = MyController.Vehicles.Single(Vehicle => Vehicle.VehicleID == selectedVehicleID);

            inputVehicleID.Text = selectedVehicle.VehicleID.ToString();
            inputVehicleName.Text = selectedVehicle.VehicleName;
            inputVehicleDescription.Text = selectedVehicle.VehicleDescription;

            var selectedVehicleType = MyController.VehicleTypes.Single(VehicleType => VehicleType.VehicleTypeID == selectedVehicle.VehicleTypeID);
            dbxVehicleTypeName.SelectedValue = selectedVehicleType.VehicleTypeName;
        }

        public void FillClientsTable()
        {
            List<Client> temp = new List<Client>();

            foreach (var item in MyController.Clients)
            {
                if (!IsPostBack)
                {
                    dbxClientID.Items.Add(item.ClientID.ToString());
                }
                temp.Add(item);
            }

            dgvClients.DataSource = temp;
            dgvClients.DataBind();
        }

        public void FillClientTypesTable()
        {
            List<ClientType> tempTypes = new List<ClientType>();

            foreach (var item in MyController.ClientTypes)
            {
                if (!IsPostBack)
                {
                    dbxClientTypeName.Items.Add(item.ClientTypeName);
                    dbxClientTypeID.Items.Add(item.ClientTypeID.ToString());
                }
                tempTypes.Add(item);
            }

            dgvClientTypes.DataSource = tempTypes;
            dgvClientTypes.DataBind();
        }

        public void FillVehiclesTable()
        {
            List<Vehicle> temp = new List<Vehicle>();

            foreach (var item in MyController.Vehicles)
            {
                if (!IsPostBack)
                {
                    dbxVehicleID.Items.Add(item.VehicleID.ToString());
                }
                temp.Add(item);
            }

            dgvVehicles.DataSource = temp;
            dgvVehicles.DataBind();
        }

        public void FillVehicleTypesTable()
        {
            List<VehicleType> tempTypes = new List<VehicleType>();

            foreach (var item in MyController.VehicleTypes)
            {
                if (!IsPostBack)
                {
                    dbxVehicleTypeName.Items.Add(item.VehicleTypeName);
                    dbxVehicleTypeID.Items.Add(item.VehicleTypeID.ToString());
                }
                tempTypes.Add(item);
            }

            dgvVehicleTypes.DataSource = tempTypes;
            dgvVehicleTypes.DataBind();
        }

        protected void btnClientFuzzySearch_Click(object sender, EventArgs e)
        {
            var fuzzyResult = MyController.Clients.Where(Client => Client.ClientName.Contains(inputClientFuzzySearch.Text) ||
            Client.ClientEmail.Contains(inputClientFuzzySearch.Text) ||
            Client.ClientContactNumber.Contains(inputClientFuzzySearch.Text)).OrderBy(Client => Client.ClientName);

            dgvClients.DataSource = fuzzyResult;
            dgvClients.DataBind();
        }

        protected void btnVehicleFuzzySearch_Click(object sender, EventArgs e)
        {
            var fuzzyResult = MyController.Vehicles.Where(Vehicle => Vehicle.VehicleName.Contains(inputVehicleFuzzySearch.Text) ||
            Vehicle.VehicleDescription.Contains(inputVehicleFuzzySearch.Text)).OrderBy(Vehicle => Vehicle.VehicleName);

            dgvVehicles.DataSource = fuzzyResult;
            dgvVehicles.DataBind();
        }
    }
}