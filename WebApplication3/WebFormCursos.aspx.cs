using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3 {
	public partial class WebFormCursos:System.Web.UI.Page {
		protected void Page_Load(object sender,EventArgs e) {

			if(!IsPostBack) {
				Session["posicion"] = "0";
				Session["nuevo"] = false;
				using(ModeloOcupacional contexto = new ModeloOcupacional()) {
					var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).First();
					if(curso != null) {
						this.tbox1.Text = curso.COD_CUR.ToString();
						tbox2.Text = curso.DESCRIPCION.ToString();
						tbox3.Text = curso.HORAS.ToString();
						tbox4.Text = curso.TUTOR.ToString();
					}
				}
			}
		}

		protected void next_Click(object sender,EventArgs e) {
			int pos = Convert.ToInt32(Session["posicion"]);
			pos++;

			using(ModeloOcupacional context = new  ModeloOcupacional()) {
				try {
					var curso = (from p in context.CURSOS orderby p.COD_CUR ascending select p).Skip(pos).First();
					tbox1.Text = curso.COD_CUR.ToString();
					tbox2.Text = curso.DESCRIPCION.ToString();
					tbox3.Text = curso.HORAS.ToString();
					tbox4.Text = curso.TUTOR.ToString();
				}
				catch(Exception) {
					ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Fin de la lista de cursos')",true);
					pos--;
				}
			}
			Session["posicion"] = pos.ToString();
		}

		protected void prev_Click(object sender,EventArgs e) {
			int pos = Convert.ToInt32(Session["posicion"]);
			pos--;
			using(ModeloOcupacional context = new  ModeloOcupacional()) {
				try {
					var curso = (from p in context.CURSOS orderby p.COD_CUR ascending select p).Skip(pos).First();
					tbox1.Text = curso.COD_CUR.ToString();
					tbox2.Text = curso.DESCRIPCION.ToString();
					tbox3.Text = curso.HORAS.ToString();
					tbox4.Text = curso.TUTOR.ToString();
				}
				catch(Exception) {
					ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Principio de la lista de cursos')",true);
					pos++;
				}
			}
			Session["posicion"] = pos.ToString();
		}

		protected void last_Click(object sender,EventArgs e) {
			int pos = Convert.ToInt32(Session["posicion"]);
			using(ModeloOcupacional context = new ModeloOcupacional()) {
				try {
					pos = context.CURSOS.Count() - 1;
					var curso = (from p in context.CURSOS orderby p.COD_CUR ascending select p).Skip(pos).First();
					tbox1.Text = curso.COD_CUR.ToString();
					tbox2.Text = curso.DESCRIPCION.ToString();
					tbox3.Text = curso.HORAS.ToString();
					tbox4.Text = curso.TUTOR.ToString();
				}
				catch(Exception) {
					ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al acceder al ultimo elemento el curso')",true);
					pos = 0;
				}
			}
			Session["posicion"] = pos.ToString();
		}

		protected void first_Click(object sender,EventArgs e) {
			int pos = Convert.ToInt32(Session["posicion"]);
			pos = 0;
			using(ModeloOcupacional context = new ModeloOcupacional()) {
				try {
					var curso = (from p in context.CURSOS orderby p.COD_CUR ascending select p).Skip(pos).First();
					tbox1.Text = curso.COD_CUR.ToString();
					tbox2.Text = curso.DESCRIPCION.ToString();
					tbox3.Text = curso.HORAS.ToString();
					tbox4.Text = curso.TUTOR.ToString();
				}
				catch(Exception) {
					ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al acceder al primer curso')",true);
					pos = 0;
				}
			}
			Session["posicion"] = pos.ToString();
		}

		protected void nuevo_Click(object sender,EventArgs e) {
			tbox1.Text = "";
			tbox2.Text = "";
			tbox3.Text = "";
			tbox4.Text = "";
			Session["nuevo"] = true;
		}

		protected void graba_Click(object sender,EventArgs e) {
			if((bool)Session["nuevo"] == true) {

				CURSOS aux = new CURSOS();
				aux.COD_CUR = tbox1.Text;
				aux.DESCRIPCION = tbox2.Text;
				aux.HORAS = Convert.ToInt32(tbox3.Text);
				aux.TUTOR = tbox4.Text;

				using(ModeloOcupacional context = new ModeloOcupacional()) {
					try {
						
						
						context.CURSOS.Add(aux);
						context.SaveChanges();
					}
					catch(Exception) {
						ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al guardar el curso')",true);
					}
				}
				Session["nuevo"] = false;
				last_Click(sender,e);
			}
		}

		protected void borra_Click(object sender,EventArgs e) {
			int pos = Convert.ToInt32(Session["posicion"]);

			string cod = tbox1.Text;
			using(ModeloOcupacional context = new ModeloOcupacional()) {
				try {
					var curso = (from p in context.CURSOS where cod == p.COD_CUR orderby p.COD_CUR ascending select p).Single();
					context.CURSOS.Remove(curso);
					context.SaveChanges();
					}
				catch(Exception) {
					ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al borrar el curso')",true);
				}
			}
			mostrar_actual();
			Session["posicion"] = pos.ToString();
		}

		protected void cancelar_Click(object sender,EventArgs e) {
			Session["nuevo"] = false;
			mostrar_actual();
		}

		protected void mostrar_actual() {
			int pos = Convert.ToInt32(Session["posicion"]);

			using(ModeloOcupacional contexto = new ModeloOcupacional()) {
				var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).Skip(pos).First();
				if(curso != null) {
					tbox1.Text = curso.COD_CUR.ToString();
					tbox2.Text = curso.DESCRIPCION.ToString();
					tbox3.Text = curso.HORAS.ToString();
					tbox4.Text = curso.TUTOR.ToString();
				}
			}
		}
	}
}