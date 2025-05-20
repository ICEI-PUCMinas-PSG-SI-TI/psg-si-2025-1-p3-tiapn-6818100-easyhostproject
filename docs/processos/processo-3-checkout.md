### 3.3.1 Processo 3 - CHECKOUT

O processo de checkout tem como objetivo tornar a finalização da estadia mais dinâmica, rápida e confiável, reduzindo o tempo de espera e evitando inconsistências nos registros de consumo e pagamentos. Ao automatizar etapas como a conferência de consumos e a geração de relatórios, o sistema garante mais precisão nas informações e melhora a experiência do hóspede, ao mesmo tempo em que facilita o trabalho da equipe de recepção.

**Modelo de processo (BPMN) - :**



![Exemplo de um Modelo BPMN do PROCESSO 1](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20processo%203%20-%20CHECKOUT.png)

**Acessar sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| login           | Caixa de Texto   | formato de e-mail |                |
| senha           | Caixa de Texto   | mínimo de 8 caracteres |           |

| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| entrar               | Fim do Processo 1              | default           |
| cancelar            | Fim do processo                 | cancel            |


**Verificar consumo pelo sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Nome do hóspede | Caixa de texto  | obrigatório |                   |
| Número da reserva |Número         | obrigatório |                   |
| Itens consumidos |Tabela        | preenchido pelo sistema |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| continuar            | Devolver/Pagar                 | default           |
| sair                | Fim do processo                | cancel            |

**Pagar consumíveis**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Valor total | Número  |somente leitura    |                   |
| Método de pagamento| Seleção única | débito, crédito, pix |                   |
| Comprovante | Arquivo | opcional |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| pagar | Devolver as chaves  | default|



**Encerramento da estadia no sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Data e hora saída | Data e Hora  | automático | data atual |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| concluir | Agendamento limpeza  | default |


**Agendamento da limpeza**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Número do quarto | Número  |  obrigatório  |                   |
| Data da limpeza | Data             | >= data atual  |                   |
| Observações   |  Área de texto  |  opcional |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| salvar |Fim do processo  | default |


