using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoEstacionamento.Estacionamento
{
    public class Estacionar
    {
        private  int _taxaEntradaDoEstacionamento;
        private int _horaEstacionamento;

        List<String> placaDoCarro = new List<String>();
        
        public int horaEstacionamento
        {
            get => _horaEstacionamento;
            set 
            {
               while(value <= 0)
               {
                    Console.WriteLine("Não é permitido este valor!\n Informe um valor maior");
                    value = Convert.ToInt32(Console.ReadLine());
               }
               _horaEstacionamento = value;
            }
        }
        public int taxaEntradaDoEstacionamento
        {
            get => _taxaEntradaDoEstacionamento;
            set 
            {
               while(value <= 0)
               {
                    Console.WriteLine("\nNão é permitido este valor!\n Informe um valor maior");
                    value = Convert.ToInt32(Console.ReadLine());
               }
               _taxaEntradaDoEstacionamento = value;
            }
        }
        public int escolha = 0;

        
        public void Estacionamento()
        {
                Console.WriteLine("Bem vindo ao estacionamento");
                Console.WriteLine("Digite o valor da entrada do estacionamento:");
                taxaEntradaDoEstacionamento = Convert.ToInt32(Console.ReadLine());            
                //Console.WriteLine($"O valor da entrada do estacionamento é de: {taxaEntradaDoEstacionamento:C}\n");
            
                Console.WriteLine("Digite o valor gasto por hora no estacionamento:");
                horaEstacionamento = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine($"O valor gasto por hora no estacionamento é de: {horaEstacionamento:C}\n");
                int contador = 2;
                int cadastro = 0;

            while(escolha >= 0)
            {
                int i = 0;

                Console.WriteLine("\nO que você deseja fazer? \n 1 - Estacionar veículo\n 2 - Remover veículos\n 3 - Mostrar veículos\n 4 - Encerrar ");
                escolha = Convert.ToInt32(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Informe os digitos da placa");
                        string nomeDaPlaca = Console.ReadLine();
                        if(placaDoCarro.Contains(nomeDaPlaca))
                        {
                            Console.WriteLine("O digíto da placa não pode ser o mesmo");
                        }
                        else
                        {
                            placaDoCarro.Add(nomeDaPlaca);
                            if(placaDoCarro.Count >= cadastro)
                            {
                                cadastro++;
                                Console.WriteLine($"{cadastro}º Veículo estacionado com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Ouve erro ao estacionar o veículo");
                            }
                        }
                        break;


                    case 2:
                        Console.WriteLine("Informe os digitos da placa");
                        string removerPlaca = Console.ReadLine();

                            if(placaDoCarro.Contains(removerPlaca))
                            {
                                Console.WriteLine("Antes de remover o veículo, quantas horas ele ficou estacionado?");
                                int horasEstacionadas = Convert.ToInt32(Console.ReadLine());
                                int pagarEstacionamento = taxaEntradaDoEstacionamento + (horaEstacionamento * horasEstacionadas) ;
                                Console.WriteLine($"Valor a ser pago é de {pagarEstacionamento:C}");
                                Console.WriteLine($"O Veículo com a plca {removerPlaca} foi removido com sucesso");
                                placaDoCarro.Remove(removerPlaca);

                            }
                            else
                            {
                                 Console.WriteLine("O nome informado não coincide");
                            }
                    break;


                    case 3:
                        if(placaDoCarro.Count > 0)
                        {
                            Console.WriteLine("Essa é a placa dos veículos estacionados:");
                            foreach (string veiculos in placaDoCarro)
                            {
                                i++;
                                Console.WriteLine($"Veículo - {i}º placa = {veiculos}" );
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum veículo foi estacionado");
                        }
                    break;


                    case 4:
                    if(placaDoCarro.Count > 0)
                    {
                        Console.WriteLine("Que pena que já vai embora \nAntes de ir, me informe quantas horas ficou estacionado por favor");
                        int horasEstacionadasEmbora = Convert.ToInt32(Console.ReadLine());
                        int pagarEstacionamentoEmbora = (cadastro * taxaEntradaDoEstacionamento) + (horasEstacionadasEmbora * horaEstacionamento);
                        Console.WriteLine($"O valor a ser pago é de {pagarEstacionamentoEmbora:C}");
                        Console.WriteLine("Thau até breve");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("O senhor não tem nada a pagar\nThau até breve");
                        Environment.Exit(0);
                    }                       
                    break;


                    default:
                    while(escolha != 1 || escolha != 2 ||escolha != 3 ||escolha != 4)
                    {
                        Console.WriteLine("Digite uma dessas opções: \n 1 - Estacionar veículo\n 2 - Remover veículos\n 3 - Mostrar veículos\n 4 - Encerrar ");
                        escolha = Convert.ToInt32(Console.ReadLine());
                        contador+=1;
                        if (contador > 3)
                        {
                            Console.WriteLine("Você teve 3 chances, infelizmente iremos ter que expulsa-lo e muta-lo");
                            int multa = taxaEntradaDoEstacionamento * horaEstacionamento * 5;
                            Console.WriteLine($"O valor que deve ser pago é de {multa:C}");
                            Environment.Exit(0);
                        }
                    }
                    break;
                }
            }
        }      
    }
}