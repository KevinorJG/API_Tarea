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
            string city = comboBox1.SelectedItem.ToString();
            API.Root clima = services.GetWather(city);
            REST(clima);
        }

        public void REST(API.Root root)
        {

            labelCondicion.Text = root.weather[0].main;
            pictureBox1.ImageLocation = services.GetIcon();
            labelDetalles.Text = root.weather[0].description;
            labelViento.Text = root.wind.speed;
            labelPresion.Text = root.main.pressure;
            labelTem.Text = root.main.temp;
        }


    }
}
