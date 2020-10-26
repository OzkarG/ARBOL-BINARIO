using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_Binario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string r = "";
        string[] arreglo;
        // Declaración de variables a utilizar
        int Dato = 0;
        int cont = 0;
        int m1=0;
        int m2 = 0;
        int m3 = 0;
        int m5 = 0;
        int max = 0;
        int min = 0;
        Arbol_Binario mi_Arbol = new Arbol_Binario(null); // Creación del objeto Árbol
        Graphics g; // Definición del objeto gráfico
        int enc = 0;
        int multiplo = 0;
        bool iden = false;
        bool enor = false;
        bool preor=false;
        bool posor = false;
        bool alt = false;
        // Evento del formulario que permitirá dibujar el Árbol Binario
        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;
            if (enor == true || posor == true || preor == true)
            {
                mi_Arbol.colorear(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, mi_Arbol.rais(), enor, preor, posor);
            }
            else if (iden==true)
            {
                //MessageBox.Show("entro");
                mi_Arbol.DibujarArbol(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, Brushes.Black, enc, multiplo, max, min);
            }
            else if (alt == true)
            {
                MessageBox.Show("La altura es: " + (mi_Arbol.altura));
            }
            else
            {
                mi_Arbol.DibujarArbol(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, Brushes.Black, enc, multiplo, 0, 0);
            }
            preor = false;
            enor = false;
            posor = false;
            iden = false;
            alt = false;
        }
        
        /* Evento que permitirá insertar un nodo al árbol*/
        private void btnInsertar_Click(object sender, EventArgs e)
        {
           
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                r += Dato.ToString() + " ";
                if (max == 0)
                {
                    max = Dato;
                    min = Dato;
                }
                else
                {
                    if (max < Dato)
                    {
                        max = Dato;
                    }
                    if (min > Dato)
                    {
                        min = Dato;
                    }
                }
                //MessageBox.Show("MAX= "+max+", MIN= "+min);
                if (Dato <= 0 || Dato >= 100)
                    MessageBox.Show("Solo Recibe Valores desde 1 hasta 99", "Error de Ingreso");
                else
                {
                    if (Dato % 1 == 0)
                    {
                        m1 = m1 + Dato;
                    }
                    if (Dato % 2 == 0)
                    {
                        m2 = m2 + Dato;
                    }
                    if (Dato % 3 == 0)
                    {
                        m3 = m3 + Dato;
                    }
                    if (Dato % 5 == 0)
                    {
                        m5 = m5 + Dato;
                    }
                    mi_Arbol.Insertar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();
                    cont++;
                    enc = 0;
                    Refresh();
                    Refresh();
                 
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtEliminar.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtEliminar.Text);
                mi_Arbol.Eliminar(Dato);
                txtEliminar.Clear();
                txtEliminar.Focus();
                if (Dato % 1 == 0)
                {
                    m1 = m1 - Dato;
                }
                if (Dato % 2 == 0)
                {
                    m2 = m2 - Dato;
                }
                if (Dato % 3 == 0)
                {
                    m3 = m3 - Dato;
                }
                if (Dato % 5 == 0)
                {
                    m5 = m5 - Dato;
                }
                cont--;
                enc = 0;
                Refresh();
                Refresh();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtBuscar.Text);
                enc = Dato;
                mi_Arbol.Buscar(Dato);
                txtBuscar.Clear();
                txtBuscar.Focus();
                Refresh();
                Refresh();
            }
        }

        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            int tamano = (r.Length) / 2;
            //MessageBox.Show(r.Length.ToString());
            arreglo = r.Split(' ');

            //foreach (string word in arreglo)
            //{
            //    MessageBox.Show(word);
            //}

            ArbolBinarioOrdenado abo = new ArbolBinarioOrdenado();

            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                abo.Insertar(Int32.Parse(arreglo[i]));
            }
         


            if (radioButton1.Checked==true)//En orden
            {
                enor = true;
                abo.EnOrden();
                label5.Text ="En orden:  "  + abo.en_orden;

            }
            
            else if (radioButton2.Checked == true)//PreOrden
            {
                preor = true;
                abo.PreOrden();
               label5.Text= "pre orden:  " + abo.pre_orden;
            }
            else if (radioButton3.Checked == true)//Post-Orden
            {
                posor = true;
                abo.PostOrden();
                label5.Text = "post orden:  " + abo.post_orden;
            }
            Refresh();
            Refresh();
        
        }

        private void btnIdentificar_Click(object sender, EventArgs e)
        {
            iden = true;
            
            Refresh();
          
            
        }

        private void btnAltura_Click(object sender, EventArgs e)
        {
            alt = true;      
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tamano = (r.Length) / 2;
            //MessageBox.Show(r.Length.ToString());
            arreglo = r.Split(' ');

            //foreach (string word in arreglo)
            //{
            //    MessageBox.Show(word);
            //}

            ArbolBinarioOrdenado abo = new ArbolBinarioOrdenado();

            for (int i = 0; i < arreglo.Length-1; i++)
            {
                abo.Insertar(Int32.Parse(arreglo[i]));
            }
            abo.EnOrden();



        }
    }
}
