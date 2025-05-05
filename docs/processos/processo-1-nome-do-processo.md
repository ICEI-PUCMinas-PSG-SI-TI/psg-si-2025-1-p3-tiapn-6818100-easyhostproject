### 3.3.1 Processo 1 – Gestão de reservas


O processo de gerenciamento de reservas tem como objetivo tornar as operações mais dinâmicas e precisas, minimizando erros e garantindo maior eficiência. Para isso, busca-se a automação de etapas-chave, integrando diferentes setores do hotel para otimizar o fluxo de informações e garantir uma experiência mais ágil e confiável tanto para os hóspedes quanto para a equipe de atendimento.

**Modelo de processo (BPMN) - Gerência de reservas:**



![Exemplo de um Modelo BPMN do PROCESSO 1](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Gest%C3%A3o%20de%20reservas%20BPMN.jpeg)


#### Detalhamento das atividades

_Descreva aqui cada uma das propriedades das atividades do processo 1. 
Devem estar relacionadas com o modelo de processo apresentado anteriormente._

_Os tipos de dados a serem utilizados são:_

_* **Área de texto** - campo texto de múltiplas linhas_

_* **Caixa de texto** - campo texto de uma linha_

_* **Número** - campo numérico_

_* **Data** - campo do tipo data (dd-mm-aaaa)_

_* **Hora** - campo do tipo hora (hh:mm:ss)_

_* **Data e Hora** - campo do tipo data e hora (dd-mm-aaaa, hh:mm:ss)_

_* **Imagem** - campo contendo uma imagem_

_* **Seleção única** - campo com várias opções de valores que são mutuamente exclusivas (tradicional radio button ou combobox)_

_* **Seleção múltipla** - campo com várias opções que podem ser selecionadas mutuamente (tradicional checkbox ou listbox)_

_* **Arquivo** - campo de upload de documento_

_* **Link** - campo que armazena uma URL_

_* **Tabela** - campo formado por uma matriz de valores_


**Requisição de reserva**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| nome | Caixa de texto  |       obrigatório         |                   |
| e-mail | Caixa de texto  |        formato xxxxxxx@xmail.com       |                   |
| telefone | Número  |       formato(xx)xxxxx-xxxx         |                   |
| data_checkin | Data  |      formato dd-mm-aaaa          |                   |
| data_checkout | Data  |       formato dd-mm-aaaa         |                   |
| tipo_quarto | Seleção única  |       opção: solteiro,casal         |                   |
| quantidade_pessoas | Número  |        mínimo 1        |                   |

| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| enviar | Recebimento de pedido de reserva  | default |
| cancelar | Fim do processo  | cancel |

**Avisar cliente sobre indisponibilidade**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| e-mail_cliente | Caixa de texto  |        formato de e-mail       |                   |
|          mensagem      |        Área de texto          |       texto automático informando a indisponibilidade         |                   |

**Fornecimento de dados**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| dados_cliente | Tabela  |       dados preenchido na reserva         |                   |
|         valor total       |        Número          |        calculado com base nas datas de checkin e checkout        |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| prosseguir | pagamento da reservar  | default  |

**Confirmar reserva para o cliente**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| e-mail_cliente | Caixa de texto  |        formato de e-mail        |                   |
|        mensagem        |         Área de texto         |       texto automático de confirmação         |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| encerrar | fim do processo  | default |

