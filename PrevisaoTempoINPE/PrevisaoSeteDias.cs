using System;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace PrevisaoTempoINPE {
    public class PrevisaoSeteDias {
        private DateTime[] dataPrev;
        private DateTime atualizacao;
        private int[] maxima, minima;
        private decimal[] indUV;
        private string[] tempoPrev;
        private string estado, cidade;
        private bool sucesso;
        private string pathXml;

        /// <summary>
        /// Obtém dados da previsão do tempo no site do Instituto Nacional de Pesquisas Eespaciais (INPE)
        /// </summary>
        /// <param name="codLocalidade">Um valor inteiro representando o código de localidade</param>
        public PrevisaoSeteDias(int codLocalidade) {
            pathXml = string.Format("http://servicos.cptec.inpe.br/XML/cidade/7dias/{0}/previsao.xml", codLocalidade);
            try {
                WebRequest request = WebRequest.Create(pathXml);
                request.Timeout = 5000;
                WebResponse response = request.GetResponse();
                XmlReader readerXml = XmlReader.Create(response.GetResponseStream());
                XElement rootXML = XElement.Load(readerXml);
                estado = (string)rootXML.Element("uf");
                cidade = (string)rootXML.Element("nome");
                string atualizaTmp = (string)rootXML.Element("atualizacao");
                atualizaTmp = string.Format("{0}/{1}/{2}", atualizaTmp.Substring(8, 2), atualizaTmp.Substring(5, 2), atualizaTmp.Substring(0, 4));
                atualizacao = Convert.ToDateTime(atualizaTmp);
                var previsoes = from xml in rootXML.Elements("previsao")
                                select new {
                                    dia = (string)xml.Element("dia"),
                                    tempo = (string)xml.Element("tempo"),
                                    max = (string)xml.Element("maxima"),
                                    min = (string)xml.Element("minima"),
                                    iuv = (string)xml.Element("iuv")
                                };
                int qtd = 0;
                foreach (var xml in previsoes) {
                    qtd++;
                }
                dataPrev = new DateTime[qtd];
                tempoPrev = new string[qtd];
                maxima = new int[qtd];
                minima = new int[qtd];
                indUV = new decimal[qtd];

                int i = 0;
                foreach (var xml in previsoes) {
                    dataPrev[i] = Convert.ToDateTime(string.Format("{0}/{1}/{2}", xml.dia.Substring(8, 2), xml.dia.Substring(5, 2), xml.dia.Substring(0, 4)));
                    indUV[i] = Convert.ToDecimal(xml.iuv.Replace('.',','));
                    maxima[i] = Convert.ToInt16(xml.max);
                    minima[i] = Convert.ToInt16(xml.min);
                    switch (xml.tempo) {
                        case "ec":  tempoPrev[i] = "Encoberto com Chuvas Isoladas"; break;
                        case "ci":  tempoPrev[i] = "Chuvas Isoladas"; break;
                        case "c":   tempoPrev[i] = "Chuva"; break;
                        case "in":  tempoPrev[i] = "Instável"; break;
                        case "pp":  tempoPrev[i] = "Possibilidade de Pancadas de Chuva"; break;
                        case "cm":  tempoPrev[i] = "Chuva pela Manhã"; break;
                        case "cn":  tempoPrev[i] = "Chuva a Noite"; break;
                        case "pt":  tempoPrev[i] = "Pancadas de Chuva a Tarde"; break;
                        case "pm":  tempoPrev[i] = "Pancadas de Chuva pela Manhã"; break;
                        case "np":  tempoPrev[i] = "Nublado e Pancadas de Chuva"; break;
                        case "pc":  tempoPrev[i] = "Pancadas de Chuva"; break;
                        case "pn":  tempoPrev[i] = "Parcialmente Nublado"; break;
                        case "cv":  tempoPrev[i] = "Chuvisco"; break;
                        case "ch":  tempoPrev[i] = "Chuvoso"; break;
                        case "t":   tempoPrev[i] = "Tempestade"; break;
                        case "ps":  tempoPrev[i] = "Predomínio de Sol"; break;
                        case "e":   tempoPrev[i] = "Encoberto"; break;
                        case "n":   tempoPrev[i] = "Nublado"; break;
                        case "cl":  tempoPrev[i] = "Céu Claro"; break;
                        case "nv":  tempoPrev[i] = "Nevoeiro"; break;
                        case "g":   tempoPrev[i] = "Geada"; break;
                        case "ne":  tempoPrev[i] = "Neve"; break;
                        case "nd":  tempoPrev[i] = "Não Definido"; break;
                        case "pnt": tempoPrev[i] = "Pancadas de Chuva a Noite"; break;
                        case "psc": tempoPrev[i] = "Possibilidade de Chuva"; break;
                        case "pcm": tempoPrev[i] = "Possibilidade de Chuva pela Manhã"; break;
                        case "pct": tempoPrev[i] = "Possibilidade de Chuva a Tarde"; break;
                        case "pcn": tempoPrev[i] = "Possibilidade de Chuva a Noite"; break;
                        case "npt": tempoPrev[i] = "Nublado com Pancadas a Tarde"; break;
                        case "npn": tempoPrev[i] = "Nublado com Pancadas a Noite"; break;
                        case "ncn": tempoPrev[i] = "Nublado com Possibilidade de Chuva a Noite"; break;
                        case "nct": tempoPrev[i] = "Nublado com Possibilidade de Chuva a Tarde"; break;
                        case "ncm": tempoPrev[i] = "Nublado com Possibilidade de Chuva pela Manhã"; break;
                        case "npm": tempoPrev[i] = "Nublado com Pancadas pela Manhã"; break;
                        case "npp": tempoPrev[i] = "Nublado com Possibilidade de Chuva"; break;
                        case "vn":  tempoPrev[i] = "Variação de Nebulosidade"; break;
                        case "ct":  tempoPrev[i] = "Chuva a Tarde"; break;
                        case "ppn": tempoPrev[i] = "Possibilidade de Pancadas de Chuva a Noite"; break;
                        case "ppt": tempoPrev[i] = "Possibilidade de Pancadas de Chuva a Tarde"; break;
                        case "ppm": tempoPrev[i] = "Possibilidade de Pancadas de Chuva pela Manhã"; break;
                        default: tempoPrev[i] = "Não Definido"; break;
                    }
                    i++;
                }
                sucesso = true;
            }
            catch(Exception e) {
                string a = e.Message;
                sucesso = false;
            }
        }
        /// <summary>
        /// Indica se a obtenção dos dados foi bem sucedida ou não
        /// </summary>
        bool ObtevePrevisao {
            get { return sucesso; }
        }
        /// <summary>
        /// Nome da cidade à qual os dados correspondem
        /// </summary>
        string Cidade {
            get { return cidade; }
        }
        /// <summary>
        /// Estado onde a cidade está localizada
        /// </summary>
        string Estado {
            get { return estado; }
        }
        /// <summary>
        /// Data da última atualização da previsão do tempo
        /// </summary>
        DateTime DataAtualizacao {
            get { return atualizacao; }
        }
        /// <summary>
        /// Array com os valores máximos de temperatura
        /// </summary>
        int[] TemperaturaMaxima {
            get { return maxima; }
        }
        /// <summary>
        /// Array com os valores mínimos de temperatura
        /// </summary>
        int[] TemperaturaMinima {
            get { return minima; }
        }
        /// <summary>
        /// Array com os valores dos índices Ultra-Violeta
        /// </summary>
        decimal[] IndiceUV {
            get { return indUV; }
        }
        /// <summary>
        /// Array com o tempo previsto
        /// </summary>
        string[] TempoPrevisto {
            get { return tempoPrev; }
        }
    }
}
