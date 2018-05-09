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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Customer already exists. Please ensure details are correct.');</script>");
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Customer already exists. Please ensure details are correct.');</script>");
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a client first.');</script>");
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select a client first.');</script>");
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
    }
}