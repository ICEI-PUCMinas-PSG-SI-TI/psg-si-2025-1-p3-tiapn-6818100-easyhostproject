### 3.3.2 Processo 2 – CHECK IN

Oportunidades de melhoria na automatização do cadastro e integração com reservas


![CHECK IN](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Processo%202%20-%20Check%20in%20revisado.png)

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

