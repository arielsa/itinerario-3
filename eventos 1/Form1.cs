using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace eventos_1
{
    public partial class Form1 : Form
    {
        Termostato t;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Termostato();
            t.TemperaturaPeligrosa += FuncionSuscriptaTemperaturaPeligrosa; // suscribo el eventop
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = Interaction.InputBox("ingrese temp");
            try
            {
                t.Temperatura = int.Parse(temp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }
        private void FuncionSuscriptaTemperaturaPeligrosa(object sender, EventArgs e)
        {
            MessageBox.Show("temp peligrosa");
        } 
    }

    public class Termostato 
    {
        private int temperatura;

        //declaracion del evento
        public event EventHandler TemperaturaPeligrosa;
        //metodo
        public int Temperatura
        {
            get { return temperatura; }
            //desencadenamiento del evento
            set { temperatura = value; if (value > 100) TemperaturaPeligrosa?.Invoke(null, null); }
            // if (TEmperaturaPeligrosa!=null){temperaturaPeligrosa(null,null);}
        }

    }


}
