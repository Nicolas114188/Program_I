using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_EF_PacientesU
{
    class Paciente
    {
        private int numeroHC;

        public int NumeroHC
        {
            get { return numeroHC; }
            set { numeroHC = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int obraSocial;

        public int ObraSocial
        {
            get { return obraSocial; }
            set { obraSocial = value; }
        }
        private int sexo;

        public int Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set {fechaNacimiento= value; }
        }
        public Paciente()
        {
            this.numeroHC = 0;
            this.nombre = string.Empty;
            this.obraSocial = 0;
            this.sexo = 0;
            this.fechaNacimiento = DateTime.Today;
        }

        public Paciente(int numeroHC, string nombre, int obraSocial, int sexo, DateTime fechaNacimiento)
        {
            this.numeroHC = numeroHC;
            this.nombre = nombre;
            this.obraSocial = obraSocial;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return numeroHC + " - " + nombre + " - " + fechaNacimiento.ToShortDateString();
        }
    }
}
