using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3 {
	public partial class WebFormAlumnos:System.Web.UI.Page {
		// Método asociado al evento OnRowCommand del GridView
		protected void Page_Load(object sender,EventArgs e) {
			using(ModeloOcupacional contexto = new ModeloOcupacional()) {
				var alumnos = (from p in contexto.ALUMNOS orderby p.COD_CUR ascending select p).ToList();
				if(alumnos != null) {
					gridAlumnos.DataSource = alumnos;
					gridAlumnos.DataBind();
				}
			}
			ImageButton botonaso = new ImageButton();
			botonaso.CommandName = "Nuevo";
			botonaso.ImageUrl = "~/male-user-add_25347.ico";
			gridAlumnos.HeaderRow.Cells[gridAlumnos.HeaderRow.Cells.Count - 2].ColumnSpan=2;
			gridAlumnos.HeaderRow.Cells[gridAlumnos.HeaderRow.Cells.Count - 1].Visible = false;
			gridAlumnos.HeaderRow.Cells[gridAlumnos.HeaderRow.Cells.Count - 2].Controls.Add(botonaso);
		}



		protected void gridAlumnos_ItemCommand(object source,GridViewCommandEventArgs e) {
			// e.CommandName me dice el botón que he pulsado
			int n = -1;
			if(e.CommandName == "Modifica") {
				Session["comando"] = "M";
				n = Convert.ToInt32(e.CommandArgument);  // me da la fila sobre la que he hecho click
				Session["cod_alu"] = gridAlumnos.Rows[n].Cells[1].Text.ToString();
			}
			if(e.CommandName == "Borra") {
				Session["comando"] = "B";
				n = Convert.ToInt32(e.CommandArgument);  // me da la fila sobre la que he hecho click
				Session["cod_alu"] = gridAlumnos.Rows[n].Cells[1].Text.ToString();
			}
			if(e.CommandName == "Nuevo") {
				Session["comando"] = "N";
				Session["cod_alu"] = "NULL";
			}
			Response.Redirect("WebFormModificaAlumno.aspx");
			// Este formulario puede leer Session["comando"] para saber si debe modificar o borrar
			//		y puede obtener el COD_ALU para el Linq  de la variable Session["COD_ALU"]
		}
	}
}
