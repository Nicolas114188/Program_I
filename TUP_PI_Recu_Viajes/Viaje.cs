using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Recu_Viajes
{
    class Viaje
    {
        private int codigo;
        private string destino;
        private int transporte;
        private int tipo;
        private DateTime fecha;

        public Viaje()
        {
            this.codigo = 0;
            this.destino = "";
            this.transporte = 0;
            this.tipo = 0;
            this.fecha = DateTime.Today;
        }

        public Viaje(int codigo, string destino, int transporte, int tipo, DateTime fecha)
        {
            this.codigo = codigo;
            this.destino = destino;
            this.transporte = transporte;
            this.tipo = tipo;
            this.fecha = fecha;
        }

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string pDestino
        {
            get { return destino; }
            set { destino = value; }
        }
        public int pTransporte
        {
            get { return transporte; }
            set { transporte = value; }
        }
        public int pTipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public DateTime pFecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
