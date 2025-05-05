### 3.3.1 Processo 

O processo 

**Modelo de processo (BPMN) - :**



![Exemplo de um Modelo BPMN do PROCESSO 1](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/dispesa.jpg)


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


**Registrar Despesas**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Nome do hóspede | Caixa de texto  | obrigatório  |                   |
| Nº da reserva | Número  | obrigatório  |                   |
| Tipo de despesa  | Seleção única |  alimentação, lavanderia, etc. |                   |
| Valor da despesa | Número   | maior que 0 |                |
| Data da despesa          | Data  | mínimo de 8 caracteres |  data atual  |

| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| salvar | Verificar Conformidade  | default |

**Verificar Conformidade das Despesas**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Lista de despesas | Tabela  | somente leitura |  preenchida pelo sistema  |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| continuar| Decisão: Já pagou?  | default |

**Cobrar as Despesas**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Valor total | Número | somente leitura  |                   |
| Forma de pagamento | Seleção única | crédito, débito, pix |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| pagar | Confirmar Pagamento  | default |

**Somar Hospedagem + Despesas**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Valor da hospedagem | Número | somente leitura |                   |
| Valor das despesas | Número  |somente leitura  |                   |
| Total a pagar |  Número  |somente leitura  |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| cobrar total | Confirmar Pagamento  | default |

**Confirmar Pagamento**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Confirmação | Seleção única  |  sim, não   |                   |
| Data e hora   |Data e Hora   |  automática  | data atual  |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| finalizar | Finalizar Processo  | default |

