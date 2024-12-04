﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sem_Projekt_Dec_24.Data;
using Sem_Projekt_Dec_24.Tables;
using Sem_Projekt_Dec_24.Winforms;

namespace Sem_Projekt_Dec_24.Winforms
{
    public partial class StorageCRUDForm : Form
    {
        private readonly DatabaseManager _dbManager;
        public BindingList<Products> ProductList { get; set; } = new BindingList<Products>();
        public BindingList<Items> ItemList { get; set; } = new BindingList<Items>();

        // Connect and Load List
        public StorageCRUDForm()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=SemProjectDB;Trusted_Connection=True;TrustServerCertificate=True;";
            _dbManager = new DatabaseManager(connectionString);

            LoadProducts();
            dgvStorageProducts.DataSource = ProductList;

            LoadItems();
            dgvStorageItems.DataSource = ItemList;
        }
        // Loading Products Method
        private void LoadProducts()
        {
            List<Products> productsFromDB = _dbManager.GetProducts();
            foreach (var product in productsFromDB)
            {
                ProductList.Add(product);
            }
        }
        // Loading Items Method
        private void LoadItems()
        {
            List<Items> itemsFromDB = _dbManager.GetItems();
            foreach (var item in itemsFromDB)
            {
                ItemList.Add(item);
            }
        }
        // Go Back Button
        private void btnStorageGoBack_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.StartPosition = FormStartPosition.CenterScreen;
            employeeForm.Show();
            this.Hide();
        }
        // Clear Fields
        private void ClearInputFields()
        {
            txtbStorageItemsId.Clear();
            txtbStorageItemsName.Clear();
            txtbStorageItemsCategory.Clear();
        }

        // Create Item
        private void btnStorageItemsCreate_Click(object sender, EventArgs e)
        {
            string txtbStorageItemsIdString = txtbStorageItemsId.Text;
            string txtbStorageItemsNameString = txtbStorageItemsName.Text;
            string txtbStorageItemsCategoryString = txtbStorageItemsCategory.Text;

            int txtbStorageItemsIdInt = Convert.ToInt32(txtbStorageItemsIdString);
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].ItemId == txtbStorageItemsIdInt)
                {
                    txtbStorageItemsIdInt = ItemList[i].ItemId;
                    ClearInputFields();
                    return;
                }
                else
                {
                    txtbStorageItemsIdInt = ItemList.Count > 0 ? ItemList.Max(c => c.ItemId) + 1 : 1;

                    Items newItems = new Items(txtbStorageItemsIdInt, txtbStorageItemsNameString, txtbStorageItemsCategoryString, 10);

                    ItemList.Add(newItems);
                    _dbManager.AddItemsToStorage(newItems);

                    ClearInputFields();
                    return;
                }
            }
        }

        //Create Product
        private void btnStorageProductCreate_Click(object sender, EventArgs e)
        {
            string txtbStorageProductsIdString = txtbStorageProductsId.Text;
            string txtbStorageProductsNameString = txtbStorageProductsName.Text;
            string txtbStorageProductsCategoryString = txtbStorageProductsCategory.Text;

            int txtbStorageProductIdInt = Convert.ToInt32(txtbStorageProductsIdString);
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].ItemId == txtbStorageProductIdInt)
                {
                    txtbStorageProductIdInt = ProductList[i].ProductId;
                    ClearInputFields();
                    return;


                }
                else
                {
                    txtbStorageProductIdInt = ProductList.Count > 0 ? ProductList.Max(c => c.ProductId) + 1 : 1;

                    Items newItems = new Items(txtbStorageProductIdInt, txtbStorageProductsNameString, txtbStorageProductsCategoryString, 10);

                    ItemList.Add(newItems);
                    _dbManager.AddItemsToStorage(newItems);

                    ClearInputFields();
                    return;
                }
            }

        }
    }

}
