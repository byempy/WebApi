using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDB.SQLServer
{
    /// <summary>
    /// Clase SQL que aporta las diferentes funciones necesarias para
    /// trabajar con una base de datos SQL Server.
    /// </summary>
    public class SQLHelper : IDataHelper
    {
        const string conexionString = "Data Source=WIN-FIM5D2FXUQ\\SQLEXPRESS; Initial Catalog=EmpleadosAvanade;Integrated Security=true;";

        private SqlConnection cn;

        public SQLHelper()
        {
            cn = new SqlConnection(conexionString);
        }

        /// <summary>
        /// Función que devuelve una lista de personas que coincidan 
        /// con los parámetros de busqueda indicados.(Nombre y/o Apellido)
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Lista Personas</returns>
        public List<Person> GetListaPersonas(Person persona)
        {

            List<Person> resultadoConsulta = new List<Person>();
            SqlCommand cmd = new SqlCommand("getEmpleados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = persona.firstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = persona.lastName;

            try {

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.id = Int32.Parse(reader["Id"].ToString());
                    person.firstName = reader["FirstName"].ToString();
                    person.lastName = reader["LastName"].ToString();

                    resultadoConsulta.Add(person);
                };

            }
            catch(SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            
            return resultadoConsulta;
        }

        /// <summary>
        /// Función que devuelve una persona con una mayor cantidad de información.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Persona detallada</returns>
        public Person GetPersonaDetallada(string id)
        {
            Person persona = new Person();
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("getDetallesEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    persona.id = Int32.Parse(reader["Id"].ToString());
                    persona.firstName = reader["FirstName"].ToString();
                    persona.lastName = reader["LastName"].ToString();
                    persona.middleName= reader["MiddleName"].ToString();
                    persona.title = reader["Title"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return persona;

        }

        public void AddPerson(Person person)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("addEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.lastName;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = person.middleName;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = person.title;

                cmd.ExecuteNonQuery();

            }catch(SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void UpdatePerson(Person person)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("updateEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = person.id;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.lastName;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = person.middleName;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = person.title;

                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        public void DelPerson(int id)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("deleteEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        /*
        private SqlCommand generarConsulta(string firstName, string lastName)
        {
            SqlCommand cmd = null;
            string query = "Select BusinessEntityID, FirstName, LastName from Person.Person where 1=1 ";

             if (firstName != "")
            {
                query += " and FirstName = @NAME";    
            }

             if(lastName != "")
            {
                query += " and LastName = @LNAME";
            }

            cmd = new SqlCommand(query, cn);
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar);
            cmd.Parameters["@NAME"].Value = firstName;
            cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar);
            cmd.Parameters["@LNAME"].Value = lastName;

            return cmd;
        }
        */
    }
}
