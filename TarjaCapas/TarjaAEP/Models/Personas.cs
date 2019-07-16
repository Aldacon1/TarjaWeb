namespace TarjaAEP.Models
{
    #region Usings
    using CapaBO;
    using CapaBLL;
    using Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using Newtonsoft.Json;
    #endregion
    public class Personas
    {
        public List<PersonasBO> ObtTarjador(ref GlobalResponse globalResponse, string terminal)
        {
            var personas = new List<PersonasBO>();

            try
            {
                var resultados = new PersonasBLL().sp_sel_tarjadorBLL(terminal);
                personas.AddRange(from DataRow row in resultados.Rows select new PersonasBO { Rut_persona = Convert.ToInt32(row[0].ToString()), Nom_persona = row[1].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return personas;
        }

        public List<PersonasBO> ObtPersonas(ref GlobalResponse globalResponse, string terminal)
        {
            var personas = new List<PersonasBO>();

            try
            {
                var resultados = new PersonasBLL().sp_sel_personasBLL(terminal);
                personas.AddRange(from DataRow row in resultados.Rows select new PersonasBO { Rut_persona = Convert.ToInt32(row[0].ToString()), Dv_persona = row[1].ToString(), Nom_persona = row[2].ToString(), Fun_cod = row[3].ToString(), Age_cod = row[4].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return personas;
        }

        public string EditarPersona(ref GlobalResponse globalResponse, string rut_persona)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasBLL().sp_sel_personasIDBLL(Convert.ToInt32(rut_persona));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return JsonConvert.SerializeObject(dt);
        }

        public static void EliminarPersona(ref GlobalResponse globalResponse, string rut)
        {
            PersonasBO persona = new PersonasBO();

            string rut_persona = rut.Remove(rut.Length - 2, 2);

            persona.Rut_persona = Convert.ToInt32(rut_persona);

            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasBLL().sp_del_personasBLL(persona);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarPersona(ref GlobalResponse globalresponse, string rut, string nombre, string password, string terminal, string funcion)
        {
            PersonasBO persona = new PersonasBO();

            persona.Rut_persona = Convert.ToInt32(rut);
            persona.Nom_persona = nombre;
            persona.Pass_persona = password;
            persona.Age_cod = terminal;
            persona.Fun_cod = funcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasBLL().sp_ins_personasBLL(persona);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }

        public static void GuardarEditPersona(ref GlobalResponse globalresponse, string rut, string nombre, string password, string terminal, string funcion)
        {
            PersonasBO persona = new PersonasBO();

            persona.Rut_persona = Convert.ToInt32(rut);
            persona.Nom_persona = nombre;
            persona.Pass_persona = password;
            persona.Age_cod = terminal;
            persona.Fun_cod = funcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new PersonasBLL().sp_updt_personasBLL(persona);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }
    }
}
