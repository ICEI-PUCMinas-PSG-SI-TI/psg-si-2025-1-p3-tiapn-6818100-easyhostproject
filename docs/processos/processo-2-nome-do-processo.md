### 3.3.2 Processo 2 – CHECK IN

Oportunidades de melhoria na automatização do cadastro e integração com reservas


![CHECK IN](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Processo%202%20-%20Check%20in%20revisado.png)



#### Detalhamento das atividades

_Descreva aqui cada uma das propriedades das atividades do processo 2. 
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

**Verificar reserva no sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| CPF do cliente | Caixa de texto  |formato: 000.000.000-00|                   |
| Nome completo  |Caixa de texto |obrigatório|                   |


| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| continuar | Entrega chave / Verif. quartos  | default |
| cancelar       | Fim do processo |  cancel |



**Verificação de disponibilidade de quartos**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Tipo de quarto desejado | Seleção única  | obrigatório | Standard |
| Data de entrada | Data             | >= data atual  |                   |
| Data de saída   | Data             | > data de entrada  |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| verificar | Confirmação dos dados  | default |
| voltar          | Verificar reserva    |  cancel |

**Confirmação dos dados do cliente**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Nome completo | Caixa de texto  | obrigatório |        |
| CPF | Caixa de texto    | formato válido  |                   |
| Telefone   | Caixa de texto        | obrigatório  |                   |
| Documento com foto   | Arquivo       | formato .jpg/.pdf  |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| confirmar | Alocação do cliente  | default |
| cancelar         | Fim do processo    |  cancel |

**Alocação do cliente**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Número do quarto | Número  | quarto disponível |        |
| Andar | Número    | >= 1  |                   |


| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| concluir | Entrega chave  | default |

