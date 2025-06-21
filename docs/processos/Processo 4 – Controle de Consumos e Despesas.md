### 3.3.4 Processo 4 – Controle de Consumos e Despesas

Durante a estadia, todas as despesas adicionais do hóspede, como refeições, produtos e serviços, devem ser registradas no sistema e vinculadas ao perfil do cliente. A cada novo lançamento, o sistema atualiza automaticamente o valor total de consumos, integrando-os ao custo final da reserva. Caso sejam identificados lançamentos incorretos, o sistema permite a exclusão dos itens, realizando o recálculo imediato dos valores totais. Esse controle garante que a fatura final reflita com precisão todos os consumos efetuados durante a hospedagem.

**Modelo de processo (BPMN) - Controle de Consumos e Despesas:**

![Diagrama - Controle de Consumos e Despesas](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20Processo%204%20%E2%80%93%20Controle%20de%20Consumos%20e%20Despesas.png)

## Tela 1 – Hospedes

| **Campo**          | **Tipo**         | **Restrições**                         | **Valor default** |
|--------------------|------------------|----------------------------------------|-------------------|
| Buscar por nome    | Caixa de texto   | obrigatório                            |                   |

| **Comandos** | **Destino**                   | **Tipo** |
|--------------|-------------------------------|----------|
| AddConsumo       | Adcionar Consumo        | default  |
| Consumo       | Consumos do Hóspede        | default  |
| Excluir       | Excluir Hóspede        | default  |


---

## Tela 2 – Adicionar consumo

| **Campo**         | **Tipo**   | **Restrições**   | **Valor default**          |
|-------------------|------------|------------------|----------------------------|
| Nome consumo | Caixa de texto     |       |    |
| Preço | Dinheiro     |       |    |

| **Comandos** | **Destino**    | **Tipo** |
|--------------|----------------|----------|
| Adicionar    | Hospedes | default  |
| Cancelar    | Hospedes | default  |

---

## Tela 3 – Consumos Hóspede


| **Comandos** | **Destino**          | **Tipo** |
|--------------|----------------------|----------|
| Excluir        | Exclui consumo  | default  |
| Fechar        | Fecha janela  | default  |

---
