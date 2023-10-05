using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AziendaSpedizioniApp.Models
{
    public class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static void CreaCliente(Cliente cliente)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO CLIENTI(Nome, Cognome, CodiceFiscale, PartitaIVA)" +
                                    "VALUES(@Nome,@Cognome,@CodiceFiscale,@PartitaIVA)";
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("@CodiceFiscale",(object)cliente.CodiceFiscale ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PartitaIVA", (object)cliente.PartitaIva ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {

            }
            finally 
            {
                conn.Close();
            }
        }
        public static List<Cliente> ListaClienti()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Cliente>ClientiList = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente cliente = new Cliente(
                    Convert.ToInt32(sqlDataReader["IdCliente"]),
                    sqlDataReader["Nome"].ToString(),
                    sqlDataReader["Cognome"].ToString(),
                    sqlDataReader["CodiceFiscale"].ToString(),
                    sqlDataReader["PartitaIVA"].ToString()
                    );
                ClientiList.Add( cliente );
            }
            conn.Close();
            return ClientiList;
        }
        public static Cliente getClienteById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTI WHERE IdCliente = @Id",conn);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlDataReader;
            conn.Open();

            Cliente cliente = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                cliente.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                cliente.Nome = sqlDataReader["Nome"].ToString();
                cliente.Cognome = sqlDataReader["Cognome"].ToString();
                cliente.CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                cliente.PartitaIva = sqlDataReader["PartitaIVA"].ToString();
            }
            conn.Close();
            return cliente;
        }
        public static void UpdateCliente(int id, string nome, string cognome, string codiceFiscale, string partitaIVA) 
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE CLIENTI SET Nome=@nome,Cognome=@cognome,CodiceFiscale=@codiceFiscale,PartitaIVA=@partitaIVA WHERE IdCliente=@id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("codiceFiscale", (object)codiceFiscale ?? DBNull.Value);
                cmd.Parameters.AddWithValue("partitaIVA", (object)partitaIVA ?? DBNull.Value);
                int completato = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {

            }
            finally { conn.Close(); }
        }
        public static void DeleteCliente(int id) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM CLIENTI WHERE IdCliente=@Id";
            cmd.Parameters.AddWithValue("Id", id);
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

        }
        public static List<Spedizione> ListaSpedizioni()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SPEDIZIONI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Spedizione>SpedizioneList = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione spedizione = new Spedizione(
                Convert.ToInt32(sqlDataReader["IdSpedizione"]),
                Convert.ToInt32(sqlDataReader["IdCliente"]),
                DateTime.Parse(sqlDataReader["DataSpedizione"].ToString()),
                Convert.ToInt32(sqlDataReader["Peso"]),
                sqlDataReader["CittaDestinataria"].ToString(),
                sqlDataReader["IndirizzoDestinatario"].ToString(),
                sqlDataReader["NominativoDestinatario"].ToString(),
                Convert.ToInt32(sqlDataReader["Costo"]),
                DateTime.Parse(sqlDataReader["DataConsegnaPrevista"].ToString())
                );
                SpedizioneList.Add(spedizione);
            }
            conn.Close();
            return SpedizioneList;
        }
        public static List<AggiornamentoSpedizioni> ListaAggiornamenti()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AGGIORNAMENTOSPEDIZIONI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<AggiornamentoSpedizioni> AggSpedizioneList = new List<AggiornamentoSpedizioni>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AggiornamentoSpedizioni spedizione = new AggiornamentoSpedizioni(
                Convert.ToInt32(sqlDataReader["IdAggiornamento"]),
                Convert.ToInt32(sqlDataReader["IdSpedizione"]),
                sqlDataReader["Stato"].ToString(),
                sqlDataReader["Luogo"].ToString(),
                sqlDataReader["Descrizione"].ToString(),
                DateTime.Parse(sqlDataReader["DataAggiornamento"].ToString())
                );
                AggSpedizioneList.Add(spedizione);
            }
            conn.Close();
            return AggSpedizioneList;
        }
        public static void CreaSpedizione(Spedizione spedizione)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= conn;
                cmd.CommandText = "INSERT INTO SPEDIZIONI(IdCliente,DataSpedizione,Peso,CittaDestinataria,IndirizzoDestinatario,NominativoDestinatario,Costo,DataConsegnaPrevista)" +
                                   "VALUES(@IdCliente,@DataSpedizione,@Peso,@CittaDestinataria,@IndirizzoDestinatario,@NominativoDestinatario,@Costo,@DataConsegnaPrevista)";
                cmd.Parameters.AddWithValue("@IdCliente", spedizione.IdCliente);
                cmd.Parameters.AddWithValue("@DataSpedizione", spedizione.DataSpedizione);
                cmd.Parameters.AddWithValue("@Peso", spedizione.Peso);
                cmd.Parameters.AddWithValue("@CittaDestinataria", spedizione.CittaDestinatario);
                cmd.Parameters.AddWithValue("@IndirizzoDestinatario", spedizione.IndirizzoDestinatario);
                cmd.Parameters.AddWithValue("@NominativoDestinatario", spedizione.NominativoDestinatario);
                cmd.Parameters.AddWithValue("@Costo", spedizione.Costo);
                cmd.Parameters.AddWithValue("@DataConsegnaPrevista", spedizione.DataConsegna);
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex) 
            {

            }
            finally { conn.Close(); }
        }

     
    }
}