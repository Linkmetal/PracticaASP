using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3 {
	public partial class WebFormNotas:System.Web.UI.Page {
		int num_alu = -1;
		string cod_alu = "";
		protected void Page_Load(object sender,EventArgs e) {
			if(!IsPostBack) {
				using(ModeloOcupacional contexto = new ModeloOcupacional()) {
					var cursos = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).ToList();
					if(cursos != null) {
						listacursos.DataSource = cursos.ToList();
						listacursos.DataTextField = "DESCRIPCION";
						listacursos.DataValueField = "COD_CUR";
						listacursos.DataBind();
					}
				}
			}
		}

		protected void index_changed(object sender,EventArgs e) {
			if(IsPostBack) {
				using(ModeloOcupacional contexto = new ModeloOcupacional()) {
					var notas = (from a in contexto.ALUMNOS orderby a.APELLIDOS where a.COD_CUR == listacursos.SelectedValue join p in contexto.NOTAS on a.COD_ALU equals p.COD_ALU select new {a.APELLIDOS, a.NOMBRE, p.NOTA1, p.NOTA2, p.NOTA3, p.MEDIA, p.COD_ALU });
					if(notas != null) {
						gridnotas.DataSource = notas.ToList();
						gridnotas.DataBind();
						ModNotas.Visible = false;
					}
				}
			}
		}

		protected void gridnotas_ItemCommand(object source, GridViewCommandEventArgs e) {
			num_alu = Convert.ToInt32(e.CommandArgument);
			n1.Text = gridnotas.Rows[num_alu].Cells[3].Text.ToString();
			n2.Text = gridnotas.Rows[num_alu].Cells[4].Text.ToString();
			n3.Text = gridnotas.Rows[num_alu].Cells[5].Text.ToString();
			med.Text = gridnotas.Rows[num_alu].Cells[6].Text.ToString();
			cod_alu = gridnotas.Rows[num_alu].Cells[0].Text.ToString();
			Session["cod_alu"] = gridnotas.Rows[num_alu].Cells[0].Text.ToString();
			ModNotas.Visible = true;

		}

		protected void GuardarNotas(object sender,EventArgs e) {
			cod_alu = Session["cod_alu"].ToString();
			using(ModeloOcupacional contexto = new ModeloOcupacional()) {
				var notas = (from p in contexto.NOTAS where p.COD_ALU == cod_alu select p).First();
				if(notas != null) {
					try {
						notas.NOTA1 = Convert.ToInt32(n1.Text);
						notas.NOTA2 = Convert.ToInt32(n2.Text);
						notas.NOTA3 = Convert.ToInt32(n3.Text);
						notas.MEDIA = (notas.NOTA1 + notas.NOTA2 + notas.NOTA3) / 3;
					}
					catch(Exception) {
						ClientScript.RegisterStartupScript(this.GetType(),"Aviso","alert('Error al guardar las notas, compruebe que los valores introducidos son numeros.')",true);
						throw;
					}
					contexto.SaveChanges();
					index_changed(sender,e);
				}
			}
		}
		protected void CalculaMedia(object sender, EventArgs e) {
			int res = 0;
			try {
				int num1 = Convert.ToInt32(n1.Text);
				int num2 = Convert.ToInt32(n2.Text);
				int num3 = Convert.ToInt32(n3.Text);
				res = (num1 + num2 + num3) / 3;
			}
			catch(Exception) {
				if(n1.Text == "") n1.Text = "0";
				if(n2.Text == "") n2.Text = "0";
				if(n3.Text == "") n3.Text = "0";
			}
			med.Text = res.ToString();
		}
	}
}