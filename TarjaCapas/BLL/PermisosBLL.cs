using CapaDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBLL
{
    public class PermisosBLL
    {
        public DataTable sp_sel_PermisosBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PermisosDAL().sp_sel_PermisosDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_permisoIDBLL(int per_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PermisosDAL().sp_sel_permisoIDDAL(per_cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        } 
    }
}
