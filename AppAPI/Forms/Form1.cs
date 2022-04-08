using AppCore.IServices;
using Domain.Entities;
using System;
using System.Windows.Forms;

namespace AppAPI
{
    public partial class Form1 : Form
    {

        private IServices<API.Root> services;

        public Form1(IServices<API.Root> services)
        {
            this.services = services;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String city = comboBox1.SelectedItem.ToString();
            API.Root clima = services.GetWather(city);
            String icon = services.GetIcon();
            REST(clima,icon);
        }

        public void REST(API.Root root, string getIcon)
        {

            labelCondicion.Text = root.weather[0].main;
            pictureBox1.ImageLocation = getIcon;
            labelDetalles.Text = root.weather[0].description;
            labelViento.Text = root.wind.speed;
            labelPresion.Text = root.main.pressure;
            labelTem.Text = root.main.temp;
        }


    }
}
