### 3.3.1 Processo 6 Gerenciamento de Serviços Internos

A solicitação é criada e imediatamente adicionada à lista de pendências do sistema. Em seguida, o serviço é executado e atribuído a um funcionário responsável. Após a conclusão, a solicitação é marcada como finalizada e arquivada para controle e registro. 

**Modelo de processo (BPMN) - :**



![Modelo BPMN do PROCESSO 6](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20processo%206%20-%20Gerenciamento%20de%20Servi%C3%A7os%20Internos.png)

**Solicitação criada no sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Tipo de serviço | Seleção única  |  obrigatório |                   |
| Descrição da tarefa  | Texto longo  | obrigatório  |                   |
| Prioridade         | Seleção única  | baixa/média/alta | média |
| Data de criação  | Data e hora  |automático | agora  |

| **Comandos**         |  **Destino**                   | **Tipo** |
| ---                  | ---                            | ---               |
| registrar | Adicionada à lista de pendência | default |

**Adicionada à lista de pendência**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Tarefa | Somente leitura |                |  da atividade anterior |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| disponibilizar | Funcionário seleciona e realiza  | default |

**Funcionário seleciona e realiza a tarefa**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Lista de tarefas | Tabela  | seleção obrigatória|                   |
| Observações | Texto | opcional|                   |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| concluir tarefa| Funcionário conclui e atribui ao nome  | default |

**Funcionário conclui e atribui ao seu nome**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Nome do funcionário | Texto | automático | login do usuário |
| Data de conclusão | Data e hora | automático | agora  |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| arquivar | Tarefa concluída e arquivada no sistema  | default |

**Tarefa concluída e arquivada no sistema**

| **Campo**       | **Tipo**         | **Restrições** | **Valor default** |
| ---             | ---              | ---            | ---               |
| Registro da tarefa | Somente leitura  | histórico |  preenchido |
| Status | Texto | automático |  concluída |

| **Comandos**         |  **Destino**                   | **Tipo**          |
| ---                  | ---                            | ---               |
| fim | Encerrar  | default |

