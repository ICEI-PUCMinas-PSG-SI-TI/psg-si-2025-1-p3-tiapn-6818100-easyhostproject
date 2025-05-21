### 3.3.4 Processo 4 - Registro de Despesas

O módulo de Registro de Despesas centraliza todos os lançamentos de consumo — alimentação, lavanderia, minibar e serviços adicionais — em um único ponto de entrada. Desde a captura dos dados do hóspede até a classificação automática por tipo de despesa e valor, o sistema assegura precisão e consistência nos lançamentos, eliminando retrabalho e erros de digitação.

**Modelo de processo (BPMN) - Processo Pagamento:**

![Diagrama - Processo Pagamento](<../images/Diagrama processo 4 - processo de pagamento>)

## Tela 1 – Registrar despesas

| **Campo**          | **Tipo**         | **Restrições**                         | **Valor default** |
|--------------------|------------------|----------------------------------------|-------------------|
| Nome do hóspede    | Caixa de texto   | obrigatório                            |                   |
| Nº da reserva      | Número           | obrigatório                            |                   |
| Tipo de despesa    | Seleção única    | alimentação, lavanderia, etc.          |                   |
| Valor da despesa   | Número           | > 0                                    |                   |
| Data da despesa    | Data             | ≥ data mínima do sistema               | data atual        |

| **Comandos** | **Destino**                   | **Tipo** |
|--------------|-------------------------------|----------|
| salvar       | Verificar conformidade        | default  |

---

## Tela 2 – Verificar conformidade das despesas

| **Campo**         | **Tipo**   | **Restrições**   | **Valor default**          |
|-------------------|------------|------------------|----------------------------|
| Lista de despesas | Tabela     | somente leitura  | preenchida pelo sistema    |

| **Comandos** | **Destino**    | **Tipo** |
|--------------|----------------|----------|
| continuar    | Decisão: Já pagou? | default  |

---

## Tela 3 – Cobrar as despesas

| **Campo**            | **Tipo**         | **Restrições**    | **Valor default** |
|----------------------|------------------|-------------------|-------------------|
| Valor total          | Número           | somente leitura   |                   |
| Forma de pagamento   | Seleção única    | crédito, débito, pix |                |

| **Comandos** | **Destino**          | **Tipo** |
|--------------|----------------------|----------|
| pagar        | Confirmar pagamento  | default  |

---

## Tela 4 – Somar hospedagem + despesas

| **Campo**             | **Tipo**   | **Restrições**   | **Valor default** |
|-----------------------|------------|------------------|-------------------|
| Valor da hospedagem   | Número     | somente leitura  |                   |
| Valor das despesas    | Número     | somente leitura  |                   |
| Total a pagar         | Número     | somente leitura  |                   |

| **Comandos**   | **Destino**          | **Tipo** |
|----------------|----------------------|----------|
| cobrar total   | Confirmar pagamento  | default  |

---

## Tela 5 – Confirmar pagamento

| **Campo**        | **Tipo**         | **Restrições**       | **Valor default** |
|------------------|------------------|----------------------|-------------------|
| Confirmação      | Seleção única    | sim, não             |                   |
| Data e hora      | Data e Hora      | automática            | data atual        |

| **Comandos** | **Destino**          | **Tipo** |
|--------------|----------------------|----------|
| finalizar    | Fim do processo      | default  |

