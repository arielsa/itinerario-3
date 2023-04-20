using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itinerario_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public abstract class Mamifero 
    {
        #region metodos
        public abstract string Comer();
        public virtual string QuienSoy() { return "soy un mamifero"; }
        // los metodos virtuales aceptan implementacion en el metodo abstracto
        // tambien se pueden sobreecribir
        #endregion
    }

    public class Vaca : Mamifero
    {
        public override string Comer()
        {
            return "como como un rumiante";
        }

        public override string QuienSoy()
        {
            return "soy una vaca";
        }
    }

    public class Persona : Mamifero
    {
        public override string Comer()
        {
            return "como como una persona";
        }
    }

    public sealed class Perro : Mamifero
    {
        public override string Comer()
        {
            return "come como un perro";
        }
    }

    public abstract class Cetaceo: Mamifero
    {

    }
}
