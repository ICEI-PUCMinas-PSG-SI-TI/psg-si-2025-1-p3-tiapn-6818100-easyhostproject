### 3.3.5 Processo 5 – Check-out

No momento do check-out, o usuário acessa a lista de reservas e localiza a reserva do hóspede que está encerrando a estadia. Ao selecionar a opção “Valor da Reserva”, o sistema realiza automaticamente o cálculo do valor total, considerando o número de diárias do quarto e todos os consumos extras registrados durante a hospedagem. O valor final é exibido na tela para conferência e pagamento. Após a confirmação do pagamento, o usuário atualiza o status da reserva para “Concluída” e a chave do quarto é devolvida ao estoque, tornando-se disponível para novas reservas. 

**Modelo de processo (BPMN) - Check-out:**

![Diagrama - Check-out](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20Processo%205%20-%20CheckOut.png)

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
