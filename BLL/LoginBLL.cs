using CapaBO;
using CapaDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBLL
{
    public class LoginBLL
    {
        public LoginBO sp_sel_loginBLL(int usuario, string pass)
        {
            DataTable dt = new DataTable();
            LoginBO log = new LoginBO();

            try
            {
                dt = new LoginDAL().sp_sel_loginDAL(usuario, pass);

                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {
                    log.EsValido = "0";
                }
                else
                {
                    log.EsValido = "1";
                    log.Rut_persona = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                    log.Dv_persona = dt.Rows[0].ItemArray[1].ToString();
                    log.Nom_persona = dt.Rows[0].ItemArray[3].ToString();
                    log.Funcion = dt.Rows[0].ItemArray[4].ToString();
                    log.DesTerminal = dt.Rows[0].ItemArray[5].ToString();
                    log.CodTerminal = dt.Rows[0].ItemArray[6].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return log;
        }

        public LoginBO sp_login_clienteBLL(int rut, string pass)
        {
            DataTable dt = new DataTable();
            LoginBO fw = new LoginBO();

            try
            {
                dt = new ForwardersDAL().sp_login_clienteDAL(rut, pass);

                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {
                    fw.EsValido = "0";
                }
                else
                {
                    fw.EsValido = "1";
                    fw.Rut_persona = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                    fw.Dv_persona = dt.Rows[0].ItemArray[1].ToString();
                    fw.Nom_persona = dt.Rows[0].ItemArray[3].ToString();
                    fw.Funcion = "Cliente";
                    fw.DesTerminal = "";
                    fw.CodTerminal = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fw;
        }
    }
}
