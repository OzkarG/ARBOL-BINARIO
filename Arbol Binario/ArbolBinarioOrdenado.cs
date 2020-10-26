using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_Binario
{
    class ArbolBinarioOrdenado
    {

        public string pre_orden;
        public string post_orden;
        public string en_orden;
        class Nodo
        {
            public int info;
            public Nodo izq, der;
        }

        Nodo raiz;
        public ArbolBinarioOrdenado()
        {
            raiz = null;
        }

        public void Insertar(int info)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (info < reco.info)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (info < anterior.info)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }



        private void PostOrden(Nodo reco)
        {
            if (reco != null)
            {
               // MessageBox.Show(reco.info + " ");
                post_orden += reco.info + " ";
                PostOrden(reco.izq);
                PostOrden(reco.der);
            }
        }

        public void PostOrden()
        {
            PostOrden(raiz);

        }

        private void PreOrden(Nodo reco)
        {
            if (reco != null)
            {
                PreOrden(reco.izq);
                //MessageBox.Show(reco.info + " ");
                pre_orden += reco.info + " ";
                PreOrden(reco.der);
            }
        }

        public void PreOrden()
        {
            PreOrden(raiz);

        }


        private void EnOrden(Nodo reco)
        {
            if (reco != null)
            {
                EnOrden(reco.izq);
                EnOrden(reco.der);
                //MessageBox.Show(reco.info + " ");
                en_orden += reco.info + " ";
            }
        }

        public void EnOrden()
        {
            EnOrden(raiz);

        }
    }
}
