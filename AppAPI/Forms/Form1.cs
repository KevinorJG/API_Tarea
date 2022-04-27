using AppCore.IServices;
using Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Globalization;

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
            //var root = services.GetLocal_Location();
            //var getIcon = services.GetIconLocal(); 
            //REST(root, getIcon);
        }

        public void REST(Task<API.Root> root, Task<string> getIcon)
        {
            Task.WaitAll(root, getIcon);

            pictureBox1.ImageLocation = getIcon.Result;
            labelCondicion.Text = root.Result.weather[0].main;
            labelDetalles.Text = root.Result.weather[0].description;
            labelViento.Text = root.Result.hourly[0].wind_speed + " m/s";
            labelPresion.Text = root.Result.hourly[0].pressure + "hPa";
            labelTem.Text = ((int)(double.Parse(root.Result.hourly[0].temp) - 273.15)).ToString() + "°C";
            labelCiudad.Text = root.Result.name + " / " + root.Result.name.country;
            
        }

        private void CityTexBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    String lat = CityTexBox.Text;
                    String lon = textBoxLong.Text;
                    Task<API.Root> clima = services.GetWather(lat, lon);
                    Task<string> icon = services.GetIcon();
                    if (clima.IsFaulted)
                    {
                        MessageBox.Show("Pais no existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        REST(clima, icon);
                    }

                }
                catch (Exception)
                {

                    throw ;
                }
            }
        }

        private void textBoxLong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
