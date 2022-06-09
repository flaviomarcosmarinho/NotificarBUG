using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace NotificarBUG
{
    public class ConexaoBancoDados
    {
		private string RetornarConnectionStringGR()
		{
			string connectionProtocol = "";
			string named_pipes = string.Empty;

			if ((!string.IsNullOrEmpty(connectionProtocol)) && (!string.IsNullOrWhiteSpace(connectionProtocol)))
			{
				if (connectionProtocol.Trim().ToUpperInvariant().Equals("NAMED_PIPES"))
				{
					named_pipes = "; Network Library=dbnmpntw";
				}
			}

			string conectionString = @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}{4}";

			//Dados da conexão com o banco de dados são carregados do arquivo environment ".env"
			string servidor = Environment.GetEnvironmentVariable("DATA_SOURCE");
			string bancoDados = Environment.GetEnvironmentVariable("INITIAL_CATALOG");
			string usuario = Environment.GetEnvironmentVariable("USER_ID");
			string senha = Environment.GetEnvironmentVariable("PASSWORD");
			conectionString = string.Format(conectionString, servidor, bancoDados, usuario, senha, named_pipes);

			return conectionString;
		}

		private string RetornarConnectionStringSQLCompact()
		{
			//Dados da conexão com o banco de dados SQLCompact são carregados do arquivo environment ".env"
			string nomeBancoSQLCompact = Environment.GetEnvironmentVariable("SQLCOMPACT_FILE_NAME");
			string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string datalogicFilePath = Path.Combine(StartupPath, nomeBancoSQLCompact);
			AppDomain.CurrentDomain.SetData("DataDirectory", datalogicFilePath);
			string connectionString = string.Format("DataSource={0}", datalogicFilePath);

			return connectionString;
		}

		private DataSet SelecionarDadosSql(string comando)
		{
			DataSet resultado = new DataSet();
			string conectionString = RetornarConnectionStringGR(); //Método utilizado para retornar a string de conexão

			SqlConnection cn = new SqlConnection(conectionString);
			SqlDataAdapter sqlDatAdap = new SqlDataAdapter();
			SqlTransaction sqlTr = null;
			try
			{
				cn.Open();
				sqlTr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

				SqlCommand cmd = new SqlCommand(string.Empty, cn, sqlTr);
				cmd.CommandTimeout = 0;
				sqlDatAdap.SelectCommand = cmd;
				cmd.CommandText = comando;
				try
				{
					sqlDatAdap.Fill(resultado);
					sqlTr.Commit();
					return resultado;
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
			}
			catch (SqlException e)
			{
				if (sqlTr != null)
				{
					sqlTr.Rollback();
				}
				throw e;
			}
			finally
			{
				cn.Close();
			}
		}

		
		public int mExecutarNonQuery(string cDesComa)
		{
			string conectionString = RetornarConnectionStringGR(); //Método utilizado para retornar a string de conexão

			SqlConnection cn = new SqlConnection(conectionString);

			cDesComa = string.Format("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED{0}{1}", Environment.NewLine, cDesComa);
						
			using (IDbCommand lCmdBase = new SqlCommand())
			{
				lCmdBase.Connection = cn;
				lCmdBase.CommandText = cDesComa;

				try
				{
					cn.Open();
					int lIntQuaRegi = lCmdBase.ExecuteNonQuery();					
					
					if (lCmdBase.Transaction != null)
					{
						lCmdBase.Transaction.Commit();
					}					
					return lIntQuaRegi;
				}
				catch (SqlException e)
				{					
					if (lCmdBase.Transaction != null)
					{
						lCmdBase.Transaction.Rollback();
					}					
					throw e;
				}
				finally
				{
					cn.Close();
				}
			}
		}

		public DataSet SelecionarDadosSqlCompact(string comando)
		{
			DataSet resultado = new DataSet();
			string conectionString = RetornarConnectionStringSQLCompact();

			SqlCeConnection cn = new SqlCeConnection(conectionString);			
			SqlCeDataAdapter sqlDatAdap = new SqlCeDataAdapter(comando, cn);
			SqlCeTransaction sqlTr = null;

			try
			{
				cn.Open();
				sqlTr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

				SqlCeCommand cmd = new SqlCeCommand(string.Empty, cn, sqlTr);
				cmd.CommandTimeout = 0;
				sqlDatAdap.SelectCommand = cmd;
				cmd.CommandText = comando;
				try
				{
					sqlDatAdap.Fill(resultado);
					sqlTr.Commit();
					return resultado;
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
			}
			catch
			{
				if (sqlTr != null)
				{
					sqlTr.Rollback();
				}
				throw;
			}
			finally
			{
				cn.Close();
			}
		}

		public int mExecutarNonQuerySqlCompact(string comando)
		{
			string conectionString = RetornarConnectionStringSQLCompact(); //Método utilizado para retornar a string de conexão
			SqlCeConnection cn = new SqlCeConnection(conectionString);

			using (SqlCeCommand lCmdBase = new SqlCeCommand())
			{
				lCmdBase.Connection = cn;
				lCmdBase.CommandText = comando;

				try
				{
					cn.Open();
					int lIntQuaRegi = lCmdBase.ExecuteNonQuery();

					if (lCmdBase.Transaction != null)
					{
						lCmdBase.Transaction.Commit();
					}
					return lIntQuaRegi;
				}
				catch (SqlException e)
				{
					if (lCmdBase.Transaction != null)
					{
						lCmdBase.Transaction.Rollback();
					}
					throw e;
				}
				finally
				{
					cn.Close();
				}
			}
		}

		public DataSet SelecionarDadosSqlGR(string comando)
        {
			return SelecionarDadosSql(comando);
		}

		public DataSet SelecionarDadosSqlLocal(string comando)
		{
			return SelecionarDadosSqlCompact(comando);
		}
	}
}
