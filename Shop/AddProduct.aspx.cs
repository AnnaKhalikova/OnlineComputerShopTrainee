using Shop.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	public partial class AddProduct : System.Web.UI.Page
	{
		public static ConnectionClass connection = new ConnectionClass();
		LogicClass logic = new LogicClass(connection);

		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
			// can't view this page if not admin
			if (Session["type"] == null || !Session["type"].Equals("admin"))
				Response.Redirect("/Default.aspx");
			string selectedvalue = drpImage.SelectedValue;
			ShomImages();
			drpImage.SelectedValue = selectedvalue;
		}

		// show avaible computer images for product in dropdown menu
		private void ShomImages()
		{
			string[] images = Directory.GetFiles(Server.MapPath("~/Images/comp_imgs/"));	// images are in this directory
			ArrayList imgList = new ArrayList();
			foreach (string img in images)
			{
				string imageName = img.Substring(img.LastIndexOf(@"\") + 1);
				imgList.Add(imageName);
			}
			drpImage.DataSource = imgList;
			drpImage.DataBind();
		}

		// clear all fields
		private void ClearAllFields()
		{
			txtDescription.Text = "";
			txtName.Text = "";
			txtPrice.Text = "";
			txtType.Text = "";
			txtQuant.Text = "";
		}

		// upload image of product from computer
		protected void cmdUploadimage_Click(object sender, EventArgs e)
		{
			try
			{
				string fileName = Path.GetFileName(FileUpload1.FileName);
				// need to check if this is an image, if not do not save
				FileUpload1.SaveAs(Server.MapPath("~/Images/comp_imgs/"+fileName));
				lblResult.Text = "File " + fileName + "uploaded";
				Page_Load(sender, e);
			}
			catch (Exception)
			{
				
				lblResult.Text = "Upload failed";
			}
		}

		// check ll fields and if everything is ok store information about new product to database
		protected void cmdSave_Click(object sender, EventArgs e)
		{
			lblResult.Text = logic.AddProduct(drpProductType.SelectedValue.ToString(), drpImage.SelectedValue,
							txtType.Text, txtPrice.Text, txtName.Text, txtDescription.Text, txtQuant.Text);
			ClearAllFields();
			/*
			if (drpImage.SelectedValue == null || txtType.Text == "" || txtPrice.Text == "" || txtName.Text == "" ||
											txtDescription.Text == "" || txtQuant.Text == "")
			{
				lblResult.Text = "One of fields is empty";
				return;
			}
			string name = txtName.Text;
			string des = txtDescription.Text;
			//int price = ConvertToNumber(txtPrice.Text);
			int price = LogicClass.ConvertToNumber(txtPrice.Text);
			if (price <= 0)
			{
				lblResult.Text = "Price can't be negative or zero";
				return;
			}
			string date = DateTime.Now.ToString("d.M.yyyy");
			string type = txtType.Text;
			string img = "Images/" + drpImage.SelectedValue;
			int quant = ConvertToNumber(txtQuant.Text);
			if(quant < 0)
			{
				lblResult.Text = "Quantity must be zero or more";
				return;
			}
			string category = drpProductType.SelectedValue.ToString();
			Item pr = new Item(1, category, name, quant, img, des, date, price, type);
			ConnectionClass.AddProduct(pr);
			lblResult.Text = "";
			 */
		}



	}
}