﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_Inventario
{
    public partial class moduloFactura : Form
    {
        mysql sql = new mysql();

        public double importe;

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        public moduloFactura()
        {
            InitializeComponent();
        }

        public void actualizarCajas()
        {
            cajaImporte.Text = importe.ToString();
        }

        private void moduloFactura_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string fechaActual = date.Day + "/" + date.Month + "/" + date.Year;
            cajaFecha.Text = fechaActual;
        }

        private void ejecutarFactura_Click(object sender, EventArgs e)
        {
            if (cajaNombre.Text != "")
            {
                sql.open();

                string dia = "";
                string mes = "";
                string ano = "";
                string[] preformato;

                preformato = cajaFecha.Text.Split('/');
                dia = preformato[0];
                mes = preformato[1];
                ano = preformato[2];
                string fechaFormato = ano + "-" + mes + "-" + dia;

                sql.crearFactura(cajaNombre.Text, double.Parse(cajaImporte.Text), fechaFormato);
                sql.close();
                this.Close();
            }
        }

        private void txCambiarImporte_Click(object sender, EventArgs e)
        {
            cajaImporte.Enabled = true;
        }

        private void txCambiarFecha_Click(object sender, EventArgs e)
        {
            cajaFecha.Enabled = true;
        }

        private void cajaFecha_MouseClick(object sender, MouseEventArgs e)
        {
            seleccionadorFecha fecha = new seleccionadorFecha();
            fecha.ShowDialog();
            cajaFecha.Text = fecha.fecha;
            fecha.Dispose();
        }
        
    }
}
