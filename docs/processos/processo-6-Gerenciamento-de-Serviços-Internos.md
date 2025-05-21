### 3.3.6 Processo 6 - Gerenciamento de Serviços Internos

A solicitação é criada e imediatamente adicionada à lista de pendências do sistema. Em seguida, o serviço é executado e atribuído a um funcionário responsável. Após a conclusão, a solicitação é marcada como finalizada e arquivada para controle e registro. 

**Modelo de processo (BPMN) - Gerenciamento de Serviços:**

![Serviço - Gerenciamento de Serviços](<../images/Diagrama processo 6 - Gerenciamento de Serviços Internos.png>)

## Tela 1 – Solicitação criada no sistema

| **Campo**            | **Tipo**        | **Restrições**   | **Valor default** |
|----------------------|-----------------|------------------|-------------------|
| Tipo de serviço      | Seleção única   | obrigatório      |                   |
| Descrição da tarefa  | Texto longo     | obrigatório      |                   |
| Prioridade           | Seleção única   | baixa/média/alta | média             |
| Data de criação      | Data e Hora     | automático       | agora             |

| **Comandos**   | **Destino**                         | **Tipo** |
|----------------|-------------------------------------|----------|
| registrar      | Adicionada à lista de pendência     | default  |

---

## Tela 2 – Adicionada à lista de pendência

| **Campo**   | **Tipo**       | **Restrições**      | **Valor default**                |
|-------------|----------------|---------------------|----------------------------------|
| Tarefa      | Somente leitura| —                   | conteúdo da atividade anterior   |

| **Comandos**     | **Destino**                                    | **Tipo** |
|------------------|------------------------------------------------|----------|
| disponibilizar   | Funcionário seleciona e realiza a tarefa        | default  |

---

## Tela 3 – Funcionário seleciona e realiza a tarefa

| **Campo**        | **Tipo**   | **Restrições**       | **Valor default** |
|------------------|------------|----------------------|-------------------|
| Lista de tarefas | Tabela     | seleção obrigatória  |                   |
| Observações      | Texto      | opcional             |                   |

| **Comandos**        | **Destino**                                       | **Tipo** |
|---------------------|---------------------------------------------------|----------|
| concluir tarefa     | Funcionário conclui e atribui ao seu nome         | default  |

---

## Tela 4 – Funcionário conclui e atribui ao seu nome

| **Campo**             | **Tipo**     | **Restrições** | **Valor default**       |
|-----------------------|--------------|----------------|-------------------------|
| Nome do funcionário   | Texto        | automático     | login do usuário        |
| Data de conclusão     | Data e Hora  | automático     | agora                   |

| **Comandos**   | **Destino**                                    | **Tipo** |
|----------------|------------------------------------------------|----------|
| arquivar       | Tarefa concluída e arquivada no sistema        | default  |

---

## Tela 5 – Tarefa concluída e arquivada no sistema

| **Campo**             | **Tipo**         | **Restrições** | **Valor default** |
|-----------------------|------------------|----------------|-------------------|
| Registro da tarefa    | Somente leitura  | histórico      | preenchido        |
| Status                | Texto            | automático     | concluída         |

| **Comandos**   | **Destino**    | **Tipo** |
|----------------|----------------|----------|
| fim            | Encerrar       | default  |

