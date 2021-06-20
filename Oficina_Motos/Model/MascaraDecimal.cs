using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public static class MascaraDecimal
    {
        public static string mascara(string valor)
        {
            //adicionei o try catch pois qndo ele adiciona o ponto de milhar e se vc precisar apagar todos os caracteres
            //acontece um erro. Então o catch deixa passar mesmo ocorrendo o erro.
            try
            {

                //formata com o ponto de milhar

                string virgula = ",";
        //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
        //por isso na proxima linha conto quantos caractes tem no textbox
        string dinheiro = valor;
        int cont = valor.Length;
                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                switch (cont)
                {
                    case 3:
                        string posicao1 = dinheiro.Substring(0, 1);
                        string posicao2 = dinheiro.Substring(1, 1);
                        string posicao3 = dinheiro.Substring(2, 1);
                        valor = posicao1 + virgula + posicao2 + posicao3;
                        break;

                    case 5:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(2, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        string posicao4 = dinheiro.Substring(4, 1);
        valor = posicao1 + posicao2 + virgula + posicao3 + posicao4;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 6:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        string posicao5 = dinheiro.Substring(5, 1);

        valor = posicao1 + posicao2 + posicao3 + virgula + posicao4 + posicao5;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 7:
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(2, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        posicao5 = dinheiro.Substring(5, 1);
                        string posicao6 = dinheiro.Substring(6, 1);
        valor = posicao1 + posicao2 + posicao3 + posicao4 + virgula + posicao5 + posicao6;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 8:
                        posicao1 = dinheiro.Substring(0, 1);//1
                        posicao2 = dinheiro.Substring(1, 1);//2
                        posicao3 = dinheiro.Substring(2, 1);//3
                        posicao4 = dinheiro.Substring(3, 1);//4
                        posicao5 = dinheiro.Substring(5, 1);//5
                        posicao6 = dinheiro.Substring(6, 1);//6
                        string posicao7 = dinheiro.Substring(7, 1);//7

        valor = posicao1 + posicao2 + posicao3 + posicao4 + posicao5 + virgula + posicao6 + posicao7;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;

                }
}
            catch (Exception)
            {
            }
   
            return valor;
        }
    }
}
