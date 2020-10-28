using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Arbol_Binario
{
    public partial class FrmArbol : Form
    {
        public FrmArbol()
        {
            InitializeComponent();
        }
        string r = "";
        string[] arreglo;
        int Dato = 0;
        int massimo = 0;
        int minino = 0;
        Arbol_Binario mi_Arbol = new Arbol_Binario(null); 
        Graphics g; 
        int enc = 0;
        int multiplo = 0;
        bool iden = false;
        bool enor = false;
        bool preor=false;
        bool posor = false;
        bool alt = false;
       
        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;
            if (enor == true || posor == true || preor == true)
            {
                mi_Arbol.colorear(g, this.Font, Brushes.LightBlue, Brushes.White, Pens.White, mi_Arbol.rais(), enor, preor, posor);
            }
            else if (iden==true)
            {
                
                mi_Arbol.DibujarArbol(g, this.Font, Brushes.LightBlue, Brushes.White, Pens.Black, Brushes.Black, enc, multiplo, massimo, minino);
            }
            else if (alt == true)
            {
                MessageBox.Show("Altura: " + (mi_Arbol.altura));
            }
            else
            {
                mi_Arbol.DibujarArbol(g, this.Font, Brushes.LightBlue, Brushes.White, Pens.Black, Brushes.Black, enc, multiplo, 0, 0);
            }
            preor = false;
            enor = false;
            posor = false;
            iden = false;
            alt = false;
        }
        
       
        private void btnInsertar_Click(object sender, EventArgs e)
        {
           
            if (txtDato.Text == "")
            {
                MessageBox.Show("ingresa un valor :)");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                r += Dato.ToString() + " ";
                if (massimo == 0)
                {
                    massimo = Dato;
                    minino = Dato;
                }
                else
                {
                    if (massimo < Dato)
                    {
                        massimo = Dato;
                    }
                    if (minino > Dato)
                    {
                        minino = Dato;
                    }
                }
                //MessageBox.Show("MAX= "+massimo+", MIN= "+minino);
                if (Dato <= 0 || Dato >= 100)
                    MessageBox.Show("nomas numeros del 1 al 99 amigo.");
                else
                {

                    mi_Arbol.Insertar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();
              
                    enc = 0;
                    Refresh();
                    Refresh();
                 
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("ingresa un valor :)");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                mi_Arbol.Eliminar(Dato);
                txtDato.Clear();
                txtDato.Focus();             
               
                enc = 0;
                Refresh();
                Refresh();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                enc = Dato;
                mi_Arbol.Buscar(Dato);
                txtDato.Clear();
                txtDato.Focus();
                Refresh();
                Refresh();
            }
        }

        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            int tamano = (r.Length) / 2;
            
            arreglo = r.Split(' ');

            ArbolBinarioOrdenado abo = new ArbolBinarioOrdenado();

            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                abo.Insertar(Int32.Parse(arreglo[i]));
            }
         
            if (radioButton1.Checked==true)//En orden
            {
                preor = true;
                abo.PreOrden();
                


            }
            
            else if (radioButton2.Checked == true)//PreOrden
            {
                posor = true;
                abo.PostOrden();

               
 
            }
            else if (radioButton3.Checked == true)//Post-Orden
            {
                enor = true;
                abo.EnOrden();
 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbttn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName + ".txt", r);

            }

        }

        private void CargarBttn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                          
                string DatosGuardados = File.ReadAllText(openFileDialog1.FileName);
                string[] arreglo = DatosGuardados.Split();
                string[] arregloborrar = r.Split();


                for (int i = 0; i <= arregloborrar.Length - 2; i++)
                {
                    mi_Arbol.Eliminar(Convert.ToInt32(arregloborrar[i]));
                    Refresh();
                    Refresh();

                }

                
                for (int i =0; i <= arreglo.Length-2; i++)
                {
                    r += arreglo[i].ToString();
                    mi_Arbol.Insertar(Convert.ToInt32(arreglo[i]));
                    
                    Refresh();
                    Refresh();

                }

            }

        }
    }
}
