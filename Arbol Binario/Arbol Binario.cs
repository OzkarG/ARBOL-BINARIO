using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Arbol_Binario
{
    class Arbol_Binario
    {
        private string valor = "";

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Nodo_Arbol Raiz;
        public Nodo_Arbol aux;
      
        public Arbol_Binario()
        {
            aux = new Nodo_Arbol();
        }

        
        public Arbol_Binario(Nodo_Arbol nueva_raiz)
        {
            Raiz = nueva_raiz;
        }
        public int altura = 0;
       
        public void Insertar(int x)
        {
            // string antonio="";
            if (Raiz == null)
            {
                Raiz = new Nodo_Arbol(x, null, null, null);
                Raiz.nivel = 0;
            }
            else
            {
                Raiz = Raiz.Insertar(x, Raiz, ref Raiz.nivel);
                altura = Raiz.nivel;

            }

        }
        
        public void Eliminar(int x)
        {
            if (Raiz == null)
                Raiz = new Nodo_Arbol(x, null, null, null);
            else
                Raiz.Eliminar(x, ref Raiz);
        }
        public Nodo_Arbol rais()
        {
            Nodo_Arbol t = new Nodo_Arbol();

            return Raiz;
        }

        
        public Nodo_Arbol Buscar(int x)
        {
            Nodo_Arbol n = new Nodo_Arbol();
            if (Raiz == null)
            { Raiz = new Nodo_Arbol(x, null, null, null); }
            else
            {
                n = Raiz.buscar(x, ref Raiz);

            }
            return n;
        }

     
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro, int i, int m, int max, int min)
        {
            int x = 400; 
            int y = 75;
            if (Raiz == null) return;
            Raiz.PosicionNodo(ref x, y); 
            Raiz.DibujarRamas(grafo, Lapiz); 
            
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro, i, m, max, min);

        }
        public int x1 = 400; 
        public int y2 = 75;

        
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente,
        Pen Lapiz, Nodo_Arbol Raiz, bool post, bool inor, bool preor)
        {


            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor,
                    preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000); 
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor,
                    preor);
                }
            }
            else if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000); 
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post,
                    inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post,
                    inor, preor);
                }
            }
            else if (post == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post,
                    inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post,
                    inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000); 
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                }
            }
            else
            {
              
                Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                valor += Raiz.Info + "";
                Thread.Sleep(1000); 
                Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
               

            }
        }
    }
  }
