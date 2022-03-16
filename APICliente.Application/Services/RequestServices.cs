using APICliente.Application.IServices;
using APICliente.Domain.DTOs.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace APICliente.Application.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly string url = @"https://localhost:44304/api/";

        public void AlterarStatusApiCurso(string tipoEUsuario, int codigo)
        {
            try
            {
                string urlPreLogin = url + "LimiteCliente/AlterarStatusCliente?codigo=" + codigo+"&usuario=" + tipoEUsuario;

                WebRequest tRequest = WebRequest.Create(urlPreLogin);
                tRequest.Method = "GET";
                tRequest.Timeout = 30000;
                tRequest.Headers.Add("accept: application/json");
                tRequest.ContentType = "application/json";

                WebResponse reposta = tRequest.GetResponse();
            }
            catch (Exception ex)
            {
                //return new Clientes { erro = ex.Message}
            }
        }

        public List<Clientes> ListaClientesAPICurso(string tipo)
        {
            List<Clientes> result = new List<Clientes>();
            try
            {
                string urlPreLogin = url + "LimiteCliente/ListarClientes?usuario="+tipo;

                WebRequest tRequest = WebRequest.Create(urlPreLogin);
                tRequest.Method = "GET";
                tRequest.Timeout = 30000;
                tRequest.Headers.Add("accept: application/json");
                tRequest.ContentType = "application/json";

                WebResponse reposta = tRequest.GetResponse();
                using (Stream stream = reposta.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    result = JsonConvert.DeserializeObject<List<Clientes>>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                //return new Clientes { erro = ex.Message}
            }
            return result;
        }

        public ObterLimite ObterLimiteClienteApiCurso(int codigo)
        {
            ObterLimite result = new ObterLimite();
            try
            {
                string urlPreLogin = url + "LimiteCliente/ObterLimiteCliente?id=" + codigo;

                WebRequest tRequest = WebRequest.Create(urlPreLogin);
                tRequest.Method = "GET";
                tRequest.Timeout = 30000;
                tRequest.Headers.Add("accept: application/json");
                tRequest.ContentType = "application/json";

                WebResponse reposta = tRequest.GetResponse();
                using (Stream stream = reposta.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    result = JsonConvert.DeserializeObject<ObterLimite>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                //return new Clientes { erro = ex.Message}
            }
            return result;
        }
    }
}
