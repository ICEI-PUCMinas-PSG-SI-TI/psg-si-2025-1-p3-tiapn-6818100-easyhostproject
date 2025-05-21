### 3.3.5 Processo 5 - Gerenciamento do serviço para Hóspedes

O atendimento começa com o cliente solicitando um serviço por telefone. O atendente registra todas as informações no sistema, associando o pedido ao nome do cliente. Após o registro, o pedido é formalizado e automaticamente direcionado para os setores responsáveis pela execução do serviço, dando início ao processo interno de atendimento. 

**Modelo de processo (BPMN) - Serviço para Hóspedes:**

![Diagrama - Serviço para Hóspedes](<../images/Diagrama processo 5 - Gerenciamento do serviço para Hóspedes.png>)

## Tela 1 – Atendente registra pedido no sistema

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Nome do cliente | caixa de texto  |       obrigatório         |                   |
| Número do quarto | Número  |         somente números inteiros       |                   |
| Tipo de serviço | Seleção única  |        opções de serviços       |                   |
| Descrição do pedido | Área de texto  |        mínimo de 10 caracteres        |                   |
| Data e hora do pedido | Data e Hora  |      formato dd-mm-aaaa, hh:mm:ss          |         data/hora: atual          |

| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| registrar | Pedido enviado a central  | default |
| cancelar | fim do processo  | cancel |

## Tela 2 – Pedido enviado à central de serviços internos

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| ID do pedido | Número  |        gerado automaticamente        |        auto           |
|         Departamento destino        |         Seleção única         |        baseado no tipo de serviço        |                   |
| Observações internas | Área de texto  |                |                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| encaminhar | Fim do processo  | default |
