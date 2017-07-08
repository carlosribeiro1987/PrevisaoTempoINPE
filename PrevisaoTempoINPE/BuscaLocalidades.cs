/*  +=====================================================================================================+
    | Obtenção de previsão do tempo à partir do Instituro Nacional de Pesquisas Espaciais (INPE)          |
    | Desenvolvido por Carlos Ribeiro (https://github.com/carlosribeiro1987)                              |
    | Distribuído sob a Licença GPLv3.0                                                                   |
    +=====================================================================================================+

    +=====================================================================================================+
    | BUSCA DE LOCALIDADES - Extraído do site do INPE (http://servicos.cptec.inpe.br/XML/)                |
    +=====================================================================================================+
    | A resposta da requisição de Busca de localidades traz informações acerca da(s) localidade(s)        |
    | desejada(s), tal como seu nome, a UF que essa(s) localidade(s) pertence(m) e o código da(s)         |
    | localidade(s). A resposta vem no formato de um arquivo em XML puro.                                 |
    +=====================================================================================================+  */

using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace PrevisaoTempoINPE {
    public class BuscaLocalidades {
        private string[] cidades, estados, codigos;
        string pathXml = string.Empty;
        private bool sucesso;
        public BuscaLocalidades(string Cidade) {
            
            //Padroniza o nome da cidade para a busca
            Cidade = Cidade.ToLower();
            Cidade = Cidade.Replace(" ", "%20");
            
            pathXml = string.Format("http://servicos.cptec.inpe.br/XML/listaCidades?city={0}", Cidade);
            try {
                WebRequest request = WebRequest.Create(pathXml);
                request.Timeout = 5000;
                WebResponse response = request.GetResponse();
                XmlReader reader = XmlReader.Create(response.GetResponseStream());
                XElement rootXML = XElement.Load(reader);
                var queryXml = from xml in rootXML.Elements("cidade")
                               select new {
                                   nomeCid = (string)xml.Element("nome"),
                                   uf = (string)xml.Element("uf"),
                                   cod = (string)xml.Element("id")
                               };
                int qtd = 0;
                foreach (var xml in queryXml) {
                    qtd++;
                }
                cidades = new string[qtd];
                estados = new string[qtd];
                codigos = new string[qtd];
                int i = 0;

                foreach (var xml in queryXml) {
                    string Cid = xml.nomeCid;
                    string Uf = xml.uf;
                    string Id = xml.cod;

                    cidades[i] = Cid;
                    estados[i] = Uf;
                    codigos[i] = Id;
                    i++;
                }
                sucesso = true;
            }
            catch {
                sucesso = false;
            }
        }
        public string[] Cidades {
            get { return cidades; }
        }
        public string[] Estados {
            get { return estados; }
        }
        public string[] Codigos {
            get { return codigos; }
        }
        public bool ObteveLista {
            get { return sucesso; }
        }
    }
}
