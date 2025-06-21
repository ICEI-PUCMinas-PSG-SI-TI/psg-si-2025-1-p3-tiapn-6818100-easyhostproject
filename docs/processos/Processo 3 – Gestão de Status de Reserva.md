### 3.3.3 Processo 3 – Gestão de Status de Reserva

Após a criação da reserva, o sistema realiza o acompanhamento de todo o ciclo de vida da reserva, que pode assumir diferentes status: Reservada, Em andamento, Concluída ou Cancelada. Cada alteração na situação da estadia deve ser registrada manualmente pelo usuário, que é responsável por atualizar o status da reserva no sistema conforme o progresso real da hospedagem. Essa atualização garante o controle preciso e atualizado das reservas em operação.

**Modelo de processo (BPMN) - Gestão de Status de Reserva:**

![Diagrama - Gestão de Status de Reserva](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20Processo%203%20%E2%80%93%20Gest%C3%A3o%20de%20Status%20de%20Reserva.png)

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

