using C_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AccesoSQL
{
    public class CD_Medida
    {
        public static CD_Medida _instancia = null;

        private CD_Medida()
        {

        }

        public static CD_Medida Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Medida();
                }
                return _instancia;
            }
        }

        public List<Medida> ObtenerMedida()
        {
            List<Medida> rptListaMedida = new List<Medida>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMedidas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMedida.Add(new Medida()
                        {
                            IdMedida = Convert.ToInt32(dr["IdMedida"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Siglas = dr["Siglas"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMedida;

                }
                catch (Exception ex)
                {
                    rptListaMedida = null;
                    return rptListaMedida;
                }
            }
        }


    }
}
