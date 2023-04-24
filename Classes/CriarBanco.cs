using Conversor_OFX.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversor_OFX.Classes
{
    public class CriarBanco
    {
        public SqlConnection Con = new SqlConnection();
        public string Banco { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public void CriaBancoConversor()
        {
            string[] config = new string[3];
            config = File.ReadAllLines("C:\\Config.txt");

            Banco = "master";
            Usuario = config[1];
            Senha = config[2];

            Con.ConnectionString = $"Data Source=(local);Initial Catalog={Banco};User ID={Usuario};Password={Senha}";
            SqlCommand comando = new SqlCommand("CREATE DATABASE CONVERSOR");
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Banco de dados CONVERSOR criado com sucesso", "Sucesso", MessageBoxButtons.OK);
        }

        public void CriaTabelaTransacoes()
        {
            string[] config = new string[3];
            config = File.ReadAllLines("C:\\Config.txt");

            Banco = config[0];
            Usuario = config[1];
            Senha = config[2];

            Con.ConnectionString = $"Data Source=(local);Initial Catalog={Banco};User ID={Usuario};Password={Senha}";
            SqlCommand comando = new SqlCommand("use CONVERSOR;CREATE TABLE Transacoes(Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,TRNTYPE VARCHAR(10),DTPOSTED  VARCHAR(30),TRNAMT NVARCHAR(50),FITID NVARCHAR(50),CHECKNUM NVARCHAR(50),NAME VARCHAR(50),MEMO VARCHAR(100),SHA1 VARCHAR(40))");
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Tabela Transações criada com sucesso", "Sucesso", MessageBoxButtons.OK);
        }

        public SqlConnection Conectar()
        {


            if (Con.State == System.Data.ConnectionState.Closed)
            {
                string[] config = new string[3];
                config = File.ReadAllLines("C:\\Config.txt");


                string Usuario = config[1];
                string Senha = config[2];

                Con.ConnectionString = $"Data Source=(local);Initial Catalog=master;User ID={Usuario};Password={Senha}";
                Con.Open();
            }
            return Con;

        }
    }
}
