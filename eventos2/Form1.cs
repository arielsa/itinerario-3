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

namespace eventos2
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
            button2_Click(null, null);


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
        private void FuncionSuscriptaTemperaturaPeligrosa(object sender, TemperaturaPeligrosaEventArg e)
        {
            MessageBox.Show
                (
                $"temp peligrosa{Environment.NewLine}"+
                $"temperatura ingresada: {e.ValorIngresado}"+
                $"delta: {e.Delta}"
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.TemperaturaPeligrosa += FuncionSuscriptaTemperaturaPeligrosa; // suscribo el eventop
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t.TemperaturaPeligrosa -= FuncionSuscriptaTemperaturaPeligrosa;

            if (int.Parse(label1.Text) > 0) 
            { 
                label1.Text = (int.Parse(label1.Text) - 1).ToString();
            }

            
        }
    }

    public class Termostato
    {
        private int temperatura;

        //declaracion del evento
        public event EventHandler<TemperaturaPeligrosaEventArg> TemperaturaPeligrosa;
        //metodo
        public int Temperatura
        {
            get { return temperatura; }
            //desencadenamiento del evento
            set { temperatura = value; if (value > 100) TemperaturaPeligrosa?.Invoke(this, new TemperaturaPeligrosaEventArg(100, value)); } // le envio el objeto que desencadena el evento y una clase que herede de eventarg para pasarle la informacion respecto de la temperatura
            // if (TEmperaturaPeligrosa!=null){temperaturaPeligrosa(null,null);}
        }

    }

    public class TemperaturaPeligrosaEventArg : EventArgs
    {
        int temperaturaCorte, temperaturaIngresada;
        public TemperaturaPeligrosaEventArg(int pTemperaturaCorte, int pTemperaturaIngresada)
            {
                temperaturaCorte = pTemperaturaCorte;
                temperaturaIngresada = pTemperaturaIngresada;
            }
        public int ValorIngresado { get { return temperaturaIngresada; } }
        public int Delta { get { return temperaturaIngresada - temperaturaCorte; } }
    }

}
