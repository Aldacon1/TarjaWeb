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
    public class PersonasBLL
    {
        public DataTable sp_sel_personasBLL(string terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_sel_personasDAL(terminal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_tarjadorBLL(string terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_sel_tarjadorDAL(terminal);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_del_personasBLL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_del_personasDAL(persona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_personasBLL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_ins_personasDAL(persona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_personasBLL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_updt_personasDAL(persona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_personasIDBLL(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_sel_personasIDDAL(rut_cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_sel_personasTarjaBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_sel_personasTarjaDAL(nroTarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_sel_personasExpoBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasDAL().sp_sel_personasTarjaExpoDAL(nroTarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
