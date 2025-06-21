### 3.3.2 Processo 2 – Reserva de Hóspedes

O processo de reserva se inicia quando o usuário do sistema recebe uma solicitação de hospedagem por parte do hóspede. O sistema coleta os dados pessoais informados e realiza a verificação automática no cadastro, com base no CPF fornecido. Caso o hóspede ainda não esteja registrado, o usuário acessa a página de hóspedes e realiza o cadastro do novo cliente no sistema.

Após confirmar ou realizar o cadastro, o usuário informa as datas desejadas para a reserva. O sistema valida os intervalos e consulta automaticamente a disponibilidade de quartos para o período solicitado. Em seguida, exibe as opções de quartos disponíveis.

O usuário, então, seleciona o quarto de acordo com a preferência do hóspede e confirma a reserva, momento em que a chave do quarto é disponibilizada ao cliente. Se não houver quartos disponíveis para as datas informadas, o sistema apresenta uma lista vazia e exibe uma mensagem de indisponibilidade, que deve ser comunicada ao hóspede.

**Modelo de processo (BPMN) - Reserva de Hóspedes:**

![Diagrama - Reserva de Hóspedes](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20Processo%202%20%E2%80%93%20Reserva%20de%20H%C3%B3spedes.png)

## Tela 1 – Lista de reservas

| Campo           | Tipo           | Restrições                   | Valor default |
|-----------------|----------------|------------------------------|---------------|
| Data para filtrar  | Data           | ≥ data atual        |               |
| Status  | Seleção unica: Reservado, Em andamento, Finalizada, Cancelada          | ≥ data atual        |               |



| **Comandos** | **Destino**                      | **Tipo** |
|--------------|----------------------------------|----------|
| Criar Reserva    | Criar Reserva no sistema     | default  |
| Consumo    | Calcula consumo     | default  |
| Excluir    | Exclui reserva     | default  |



---

## Tela 2 – Criar reserva

| Campo           | Tipo           | Restrições                   | Valor default |
|-----------------|----------------|------------------------------|---------------|
| CPF do Hospede  | Caixa de texto | formato: 000.000.000-00      |               |
| Nome completo   | Caixa de texto | obrigatório                  |               |
| Data de entrada  | Data           | ≥ data atual        |               |
| Data de Saída  | Data           | ≥ data atual        |               |

| **Comandos** | **Destino**                        | **Tipo** |
|--------------|------------------------------------|----------|
| Buscar Hóspede    | Procura Hóspede	    | search  |
| Criar Hóspede     | Cria Hóspede                    | create   |
| Quartos Disponíveis    | Procura quartos disponiveis	    | search  |
| Criar Reserva     | Fim do processo                    | create   |

---

## Tela 3 – Hospedes

| Campo                    | Tipo           | Restrições          | Valor default |
|--------------------------|----------------|---------------------|---------------|
| Buscar por nome  | Pesquisa  |          | Standard      |

| **Comandos** | **Destino**                         | **Tipo** |
|--------------|-------------------------------------|----------|
| Novo Hóspede    | Criação de Hóspede               | default  |


---

## Tela 4 – Novo Hóspede

| Campo               | Tipo              | Restrições          | Valor default    |
|---------------------|-------------------|---------------------|------------------|
| Nome completo       | Caixa de texto    | obrigatório         |                  |
| CPF                 | Caixa de texto    | formato válido      |                  |

| **Comandos** | **Destino**               | **Tipo** |
|--------------|---------------------------|----------|
| Cadastrar    | Criação do hospede       | default  |
| cancelar     | Fim do processo           | cancel   |

---
