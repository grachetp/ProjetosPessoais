from quiz import Questao
from random import randint
import os

banco_de_questoes = [
    "Qual das alternativas abaixo não correspondem a uma das funções da camada física?\n\n[A] Tranmissão de bits\n[B] Estabelecimento de conexões físicas\n[C] Comunicação entre modem's\n[D] Multiplexação física\n[E] Modulação\n",
    "Qual das camadas do modelo OSI é responsavel pela compressão de dados?\n\n[A] Apresentação\n[B] Sessão\n[C] Transporte\n[D] Rede\n[E] Física\n",
    "Qual é a função da camada de Sessão?\n\n[A] Tranportar pacotes\n[B] Aplicar regras ao sistema\n[C] Administrar e sinconizar diálogos entre dois processos de aplicação\n[D]Fornecer Informações\n[E]Fazer café\n",
    "Em uma rede de computadores, com o ambiente Windows, para que as estações recebam um número de IP automaticamente ao serem ‘logadas’, deve-se instalar um:\n\n[A] servidor DHCP\n[B] Servidor HTTP\n[C] Servidor TCP/IP\n[D] Servidor DNS\n[E] Servidor FTP\n",
    "Na arquitetura TCP/IP de protocolos, o gerenciamento da rede pode ser realizado por meio do uso do protocolo SNMP, que pertence à camada de\n\n[A] Aplicação\n[B] Enlace\n[C] Transporte\n[D] Inter-rede\n[E] Rede\n",
    "Porta TCP usada por norma para o protocolo HTTPS é:\n\n[A] 123\n[B] 883\n[C] 533\n[D] 443\n[E] 356\n",
    "Qual dos protocolos abaixo usa apenas UDP para o transporte de suas mensagens?\n\n[A] FTP\n[B] SSH\n[C] HTTP\n[D] SNMP\n[E] DNS\n",
    "O protocolo IP é responsavel por:\n\n[A]Pelo envio e endereçamento dos pacotes TCP\n[B] Endereçar joysticks\n[C] Datagrama em Dados\n[D] Flexibilização\n[E] Escalonamento\n",
    "O Desenvolvimento inicial do modelo TCP/IP começou em:\n[A] 2001\n[B] 1980\n[C] 1876\n[D] 1969\n[E] 1966\n",
    "Quantas camadas tem o modelo OSI e TCP/IP respectivamente:\n[A] 3,2\n[B] 7,4\n[C] 4,7\n[D] 7,5\n[E] 9,9\n",
    "O modelo TCP/IP foi financiando pela:\n[A] DARPA\n[B] ARPA\n[C] BNDS\n[D] PIS\n[E] DDOS\n",
    "São protocolos da camada de aplicações: \n[A] FTP, IP e IGMP\n[B] SMTP, HTTP e FTP\n[C] DNS, FTP e TCP\n[D] DDOS e IP\n[E] DOS e DDOS\n",
    "Entre os diversos protocolos que formam o Protocolo TCP/IP, aquele que é orientado à conexão e fornece um serviço confiável de tranferencias de dados fim-a-fim é:\n[A] ARP\n[B] IP\n[C] RARP\n[D] TCP\n[E] UDP\n",
    "Os dados recebidos da camada de transporte são chamados de:\n[A] Datagramas x\n[B] Telegramas \n[C] Mensagem de conexão\n[D] Enlace",
    "A última camada é de:\n(A) Rede x\n(B) Transporte\n(C) Aplicação\n(D) Física",
    "O modelo que compacta as 7 camadas é:\n(A) TCP\n(B) TCP/IP \n(C) IP\n(D) OSI",
    "No modelo TCP/IP a comunicação é feita através de:\n(A) Datagramas \n(B) MSN\n(C) Rede\n(D) Conexão",
    "O protocolo não orientado a conexão é:\n(A) Ethernet\n(B) Internet\n(C) HTTP\n(D) IP ",
    "A função da camada internet é:\n(A) Endereçar e rotear pacotes \n(B) Receber pacotes\n(C) Transportar\n(D) Comunicar",
    "A camada que faz comunicação entre os progamas é:\n(A) Rede\n(B) Transporte\n(C) Aplicação \n(D) Ethernet\n",
    "No endereçamento existe alguns protocolos, dentre eles o mais atual é:\n(A) IPV4\n(B) IPv10\n(C) IPv5\n(D) IPv6 \n",
    "Dentre as camadas, qual delas possui um canal específico ou porta?\n(A) Rede\n(B) Transporte \n(C) Prototipação\n(D) Endereçamento\n",
    "O formato Datagrama UDP é dividido em duas partes quais são elas?\n(A) cabeçalho e rodapé\n(B) rodapé e informação\n(C) cabeçalho e dados \n(D) dados e rodapé",
    "O protocolo UDP é interessante por não necessitar de:\n(A) controle \n(B) conexão\n(C) senha\n(D) dados\n",
    "A sigla do protocolo TCP significa:\n(A) Treinamento de controle de protocolo.\n(B) Protocolo de Controle de Transmissão. \n(C) Protocolo de Transmissão controlada.\n(D) Centro de Tratamento de Protocolos.\n",
    "Com o TCP é garantido que:\n(A) não tem conexão.\n(B) o cabeçalho é pequeno.\n(C) não foi entregue.\n(D) foi entregue. \n",
    "O que não faz parte da camada de aplicação é:(A) híbrido de cliente-servidor.\n(B) controle de rede. \n(C) peer-to-peer.\n(D) cliente-servidor\n",
    "A camada de aplicação possui muitas características, qual delas abaixo não faz parte?\n(A) Não possui perca de dados.\n(B) Temporização.\n(C) Segurança.\n(D) vazão.\n",
    "O TELNET é um protocolo que não transmite:\n(A) dados\n(B) mensagem\n(C) seguramça\n(D) arquivos descriptografado\n",
    "A porta utilizada pelo protocolo SSH é:\n(A) 55\n(B) 896\n(C) 22 \n(D) 37\n",
    "A chave de autenticação utilizada pelo SSH é:\n(A) estrangeira\n(B)particular\n(C) pública\n(D) privada\n",
    "O limite de portas na camada de transporte vai até:\n(A) 1024\n(B) 1023\n(C) 255\n(D) 1000\n",
    "O protocolo que verifica o cabeçalho é:\n(A) UTP\n(B) IP\n(C) UDP\n(D) TCP\n"
    "Entre os diversos protocolos que formam o Protocolo TCP/IP, aquele que é orientado à conexão e fornece um serviço confiável de transferência de dados fim-a-fim é:\na) ARPb) IP\nc) RARP\nd) TCP\ne) UDP\n",
    "O modelo TCP/IP possui uma pilha de protocolos que atua na camada de transporte das redes de computadores. Nessa camada, a comunicação entre processos finais, por meio de uma conexão virtual, utilizada) \na.o endereçamento com classes.\nb) o endereço socket.\nc) o paradigma peer-to-peer.\nd) o protocolo confiável UDP (User Datagram Protocol).\ne) os protocolos RARP, BOOT e DHCP.\n",
    "A porta TCP/IP padrão para o protocolo de comunicação news é a \na) 80.\nb) 119.\nc) 443.\nd) 1 024.\ne) 8 088.\n",
    "Entre os vários  protocolos TCP/IP, a camada responsável pelo envio de pacotes individuais de um nó origem a um nó destino é a camada: \na) de enlace.\nb) de aplicação.\nc) de rede.\nd) de transporte.\ne) física.\n",
    "um protocolo de roteamento em redes TCP/IP que continua sendo muito utilizado é: \na) IPPR.\nb) DVMP.\nc) STP.\nd) RTCP.\ne) RIP.\n",
    "O modelo TCP/IP se divide em camadas. Assinale a opção que apresenta todas as camadas pertencentes a esse modelo : \na) transporte e rede \nb) aplicação, transporte e rede \nc) apresentação, aplicação, transporte e rede \nd) apresentação e rede \ne) aplicação, transporte, inter-rede e rede.\n",
    "As conexões TCP são do tipo:\na) Full-duplex e multidifusão.\nb) Duplex e multidifusão.\nc) Full-duplex e ponto a ponto.\nd) Duplex e difusão.\ne) Simplex e ponto a ponto.\n",
    "Assinale a alternativa que indica o protocolo responsável por atribuir IPs dinamicamente.\na) TCP.\nb) HTTP.\nc) DNS.\nd) GET IP.\ne) DHCP.\n",
    "Os protocolos IP e TCP são responsáveis, respectivamente, pela comunicação entre.\na) hosts e processos.\nb) processos e hosts.\nc) processos e nós.\nd) switches e processos.\ne) hubs e switches.\n",
    "Para conectar dois pontos através de uma rede TCP/IP, usando um protocolo com característica de entrega confiável e em sequência, deve-se utilizar o protocolo \na) ARP\nb) ICMP\nc) RTP\nd) TCP\ne) UDP.\n",
    "No modelo TCP-IP, a camada responsável pela confiabilidade e integridade dos dados e onde os pacotes são chamados de segmentos é:\na) Camada Física;\nb) Camada de Transporte;\nc) Camada de Rede;\nd) Camada de Aplicação;\ne) Camada de Acesso à Rede.\n",
    "No modelo de referência OSI (Open Systems Interconnection), o roteamento é executado pela camada de \nA.transporte.\nB.sessão.\nC.rede.\nD.elance de dados.\nE.aplicação.\n",
    "Uma função da camada de sessão do modelo OSI/ISO é: \nA. realizar transformação adequadas nos dados\nB. especificar detalhes de segurança.\nC. fornecer conectividade fim a fim.\nD. realizar controle de fluxo.\nE. Realizar o roteamento entre servidores.\n",
    "O modelo OSI é um modelo dividido em 7 camadas. É INCORRETO dizer que uma destas camadas seja a camada de\n A.sessão.\nB.aplicação.\nC.apresentação.\nD.transferência.\nE.enlace.\n",
    "OSI, detectar e corrigir erros é função da seguinte camada: \nA. Rede.\nB. Física.\nC. Enlace\nD. Sessão.\nE. Aplicação.\n",
    "São protocolos da camada Internet  do modeloTCP/IP: \na) ARP, ICMPe FTP\nb) UDP,TCPe SMTP\nc) HTTP, ICMPeRARP.\nd) RARP, ICMPe IP.\ne) TCP, IP e UDP.\n",
    "Assinale a opção que indica o número de camadas que o modelo OSI possui.\nA. 4\nB. 5\nC. 6\nD. 7\nE. 8.\n",
    "Dos protocolos abaixo relacionados, qual deles NÃO roda na camada de aplicação do modelo OSI:\n A.FTP.\nB.HTTP.\nC.SNMP.\nD.HTTPS.\nE.TCP.\n",
    "Qual camada do modelo OSI tem como função básica aceitar dados da camada superior e dividi-los em unidades menores caso necessário? \nA.Transporte.\nB.Enlace.\nC.Rede.\nD.Sessão.\nE.Apresentação.\n",
    "Os elementos de rede Hub ,Switch e Roteador operam, respectivamente, nas seguintes camadas do modelo OSI:\nA.Física, Rede eTransporte \nB.Física, Enlace e Rede.\nC.Enlace,Transporte e Sessão.\nD.Transporte, Rede e Física.\n E.Transporte, Física e Física.\n",

]

questoes = [
    Questao(banco_de_questoes[0], "e"),
    Questao(banco_de_questoes[1], "a"),
    Questao(banco_de_questoes[2], "c"),
    Questao(banco_de_questoes[3], "a"),
    Questao(banco_de_questoes[4], "a"),
    Questao(banco_de_questoes[5], "d"),
    Questao(banco_de_questoes[6], "d"),
    Questao(banco_de_questoes[7], "a"),
    Questao(banco_de_questoes[8], "d"),
    Questao(banco_de_questoes[9], "b"),
    Questao(banco_de_questoes[10], "a"),
    Questao(banco_de_questoes[11], "b"), #ate aqui ta certo
    Questao(banco_de_questoes[12], "d"),
    Questao(banco_de_questoes[13], "a"),
    Questao(banco_de_questoes[14], "a"),
    Questao(banco_de_questoes[15], "c"),
    Questao(banco_de_questoes[16], "b"),
    Questao(banco_de_questoes[17], "a"),
    Questao(banco_de_questoes[18], "d"),
    Questao(banco_de_questoes[19], "a"),
    Questao(banco_de_questoes[20], "d"),
    Questao(banco_de_questoes[21], "a"),
    Questao(banco_de_questoes[22], "d"),
    Questao(banco_de_questoes[23], "a"),
    Questao(banco_de_questoes[24], "b"),
    Questao(banco_de_questoes[25], "b"),
    Questao(banco_de_questoes[26], "a"),
    Questao(banco_de_questoes[27], "b"),
    Questao(banco_de_questoes[28], "d"),
    Questao(banco_de_questoes[29], "c"),
    Questao(banco_de_questoes[30], "c"),
    Questao(banco_de_questoes[31], "a"),
    Questao(banco_de_questoes[32], "c"),
    Questao(banco_de_questoes[33], "c"),
    Questao(banco_de_questoes[34], "a"),
    Questao(banco_de_questoes[35], "e"),
    Questao(banco_de_questoes[36], "c"),
    Questao(banco_de_questoes[37], "d"),
    Questao(banco_de_questoes[38], "b"),
    Questao(banco_de_questoes[39], "a"),
    Questao(banco_de_questoes[40], "e"),
    Questao(banco_de_questoes[41], "d"),
    Questao(banco_de_questoes[42], "c"),
    Questao(banco_de_questoes[43], "b"),
    Questao(banco_de_questoes[44], "a"),
    Questao(banco_de_questoes[45], "e"),
    Questao(banco_de_questoes[46], "d"),
    Questao(banco_de_questoes[47], "b"),
    Questao(banco_de_questoes[48], "a"),
    Questao(banco_de_questoes[49], "c"),
    Questao(banco_de_questoes[50], "b"),
    Questao(banco_de_questoes[51], "d"),
]

def init():
    os.system('clear')
    print('\n\n=======================================\n')
    print('   Quiz de Arquitetura e Protocolos\n')
    print('=======================================\n')

def quiz(questoes):
    pontuacao = 0
    historico = []
    num_quest = 0
    while True:
        QUESTAO = randint(0,51)

        if not(QUESTAO in historico):
            init()        
            num_quest += 1
            historico.append(QUESTAO)
            print('\n')
            resposta = input(str(num_quest)+" - "+questoes[QUESTAO].questao + "\nResposta:")
            if resposta == questoes[QUESTAO].resposta:
                pontuacao += 1
        if num_quest==25:
            break
    print("\nVocê acertou " + str(pontuacao) + " /25" + " corretas")


quiz(questoes)
