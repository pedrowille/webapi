using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace webapi.Models
{
    public class Produtos
    {
        public int CodeProduto { get; set; }
        public string? Nome { get; set; }
        public double Valor { get; set; }
        public double Quantidade { get; set; }

        public List<Produtos> SelecionarProdutos()
        {
            List<Produtos> listaProdutos = new();
            MySqlConnection conn = new("server=localhost;user=root;password=mysql;database=bd_csharp;port=3306");
            try
            {
                conn.Open();
                MySqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = "select * from produtos;  ";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Produtos novoObjeto = new();
                    novoObjeto.CodeProduto = Convert.ToInt32(dr["CodeProduto"]);
                    novoObjeto.Nome = Convert.ToString(dr["Nome"]);
                    novoObjeto.Valor = Convert.ToDouble(dr["Valor"]);
                    novoObjeto.Quantidade = Convert.ToDouble(dr["Quantidade"]);
                    listaProdutos.Add(novoObjeto);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conn.Close();
            return listaProdutos;
        }
    }
}