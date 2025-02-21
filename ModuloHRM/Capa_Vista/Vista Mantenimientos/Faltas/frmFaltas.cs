﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista.Vista_Mantenimientos.Faltas
{
    public partial class frmFaltas : Form
    {
        string UsuarioAplicacion;
        static Form FormularioPadre;
        public frmFaltas(string usuario, Form formularioPadre)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            NavegadorFaltas.Usuario = UsuarioAplicacion;
            FormularioPadre = formularioPadre;
        }
        private void funcNumero(object sender, KeyPressEventArgs e)
        {
            clsValidacion.funcNumeros(e);
        }

        private void funcLetra(object sender, KeyPressEventArgs e)
        {
            clsValidacion.funcLetras(e);
        }

        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {
            //Asignar estado en TxtEstado segun el Checked
            if (rbtnActivo.Checked == true)
            {
                txtEstado.Text = "1";
            }
        }

        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {
            //Asignar estado en TxtEstado segun el Checked
            if (rbtnInactivo.Checked == true)
            {
                txtEstado.Text = "0";
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            //Asignar estado en TxtEstado segun el Checked
            if (txtEstado.Text == "")
            {
                rbtnActivo.Checked = false;
                rbtnInactivo.Checked = false;
            }
            if (txtEstado.Text == "1")
            {
                rbtnActivo.Checked = true;
            }
        }

        private void NavegadorFaltas_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //el numero de aplicacion se debe cambiar por el numero asignado en la base de datos 
            NavegadorFaltas.aplicacion = 1;
            //banco se debe cambiar por la tabla a la que se quiere hacer el mantenimiento
            NavegadorFaltas.tbl = "falta";
            //estado_banco se debe cambiar por el estado de la tabla a la que se desea hacer mantenimiento
            NavegadorFaltas.campoEstado = "estado_falta";
            NavegadorFaltas.MDIformulario = FormularioPadre;
            foreach (Control C in this.Controls)
            {
                if ((C.Tag != null) && (!C.Tag.ToString().Equals("")))
                {
                    if (C is TextBox)
                    {
                        lista.Add(C);

                    }
                    else if (C is ComboBox)
                    {
                        lista.Add(C);

                    }
                    else if (C is DateTimePicker)
                    {
                        lista.Add(C);
                    }
                }
            }
            NavegadorFaltas.control = lista;
            NavegadorFaltas.formulario = this;
            //el dataGridView1 se debe cambiar por el que se tiene en el formulario
            NavegadorFaltas.DatosActualizar = dgvFaltas;
            NavegadorFaltas.procActualizarData();
            NavegadorFaltas.procCargar();
            //en la variable ayuda ruta debe colocar la carpeta y el archivo.chm de su proyecto de ayuda
            NavegadorFaltas.ayudaRuta = "Ayudas_HRM/Ayudas_Modulo_HRM.chm";
            //en ruta debe colocar la pagina html que quiere que se muestre cuendo se presione el boton ayuda
            NavegadorFaltas.ruta = "pg_0015.htm";
        }
    }
}
