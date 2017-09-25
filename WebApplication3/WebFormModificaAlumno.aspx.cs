using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3 {
	public partial class WebFormModificaAlumno:System.Web.UI.Page {
		string cod_alu;
		string[] result = new string[5];


		protected void Page_Load(object sender,EventArgs e) {
			cod_alu = Session["cod_alu"].ToString();
			if(!IsPostBack) {
				using(ModeloOcupacional contexto = new ModeloOcupacional()) {
					var cursos = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).ToList();
					if(cursos != null) {
						listacursos.DataSource = cursos.ToList();
						listacursos.DataTextField = "DESCRIPCION";
						listacursos.DataValueField = "COD_CUR";
						listacursos.DataBind();
					}
					if((string)Session["comando"] != "N") {
						var alumno = (from p in contexto.ALUMNOS orderby p.COD_ALU ascending where p.COD_ALU == cod_alu select p).First();
						if(alumno != null) {
							// cargo los textbox del formulario y ya trabajo como en cursos
							listacursos.Text = alumno.COD_CUR.ToString();
							tboxCod_Alu.Text = alumno.COD_ALU.ToString();
							tboxDni.Text = alumno.DNI.ToString();
							tboxApellidos.Text = alumno.APELLIDOS.ToString();
							tboxNombre.Text = alumno.NOMBRE.ToString();
						}
					}
				}
			}
		}

		protected void button_click(object sender, EventArgs e) {
			var alumno = new ALUMNOS();
			var nota = new NOTAS();
			using(ModeloOcupacional contexto = new ModeloOcupacional()) {
				if((string)Session["comando"] != "N") {
					alumno = (from p in contexto.ALUMNOS orderby p.COD_ALU ascending where p.COD_ALU == cod_alu select p).First();
					nota = (from n in contexto.NOTAS orderby n.COD_ALU ascending where n.COD_ALU == cod_alu select n).First();
				}
				if(alumno != null) {
					if((string)Session["comando"] == "M") {
						// cargo los textbox del formulario y ya trabajo como en cursos
						try {
							alumno.DNI = tboxDni.Text;
							alumno.APELLIDOS = tboxApellidos.Text;
							alumno.NOMBRE = tboxNombre.Text;
							alumno.COD_CUR = listacursos.SelectedValue.ToString();
							contexto.SaveChanges();

						}
						catch(Exception) {
							ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al acceder al intentar modificar el alumno')",true);
							throw;
						}
					}
					if((string)Session["comando"] == "B") {
						try {
							contexto.NOTAS.Remove(nota);
							contexto.ALUMNOS.Remove(alumno);
							ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al acceder al intentar modificar el alumno')",true);
							contexto.SaveChanges();

						}
						catch(Exception) {

							throw;
						}
					}
					if((string)Session["comando"] == "N") {
						// cargo los textbox del formulario y ya trabajo como en cursos
						NOTAS nuevaNota = new NOTAS();
						ALUMNOS nuevoAlumno = new ALUMNOS();
						try {
							
							nuevaNota.NOTA1 = -1;
							nuevaNota.NOTA2 = -1;
							nuevaNota.NOTA3 = -1;
							nuevaNota.MEDIA = -1;
							nuevaNota.COD_ALU = tboxCod_Alu.Text;
							nuevaNota.COD_CUR = listacursos.SelectedValue.ToString();
							
							nuevoAlumno.DNI = tboxDni.Text;
							nuevoAlumno.APELLIDOS = tboxApellidos.Text;
							nuevoAlumno.NOMBRE = tboxNombre.Text;
							nuevoAlumno.COD_ALU = tboxCod_Alu.Text;
							nuevoAlumno.COD_CUR = listacursos.SelectedValue.ToString();

							contexto.ALUMNOS.Add(nuevoAlumno);
							contexto.NOTAS.Add(nuevaNota);
							contexto.SaveChanges();

						}
						catch(Exception) {
							ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al crear el alumno, todos los campos deben de tener un valor válido.')",true);
							contexto.NOTAS.Remove(nuevaNota);
							contexto.ALUMNOS.Remove(nuevoAlumno);
						}
					}
				}
			}
			if(tboxApellidos.Text != "" && tboxCod_Alu.Text != "" && tboxDni.Text != "" && tboxNombre.Text != "" && listacursos.SelectedValue != "-1") Response.Redirect("WebFormAlumnos.aspx");
			else ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al crear el alumno, todos los campos deben de tener un valor válido.')",true);
		}
	}
}