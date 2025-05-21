### 3.3.1 Processo 1 – Gestão de reservas

O processo de gerenciamento de reservas tem como objetivo tornar as operações mais dinâmicas e precisas, minimizando erros e garantindo maior eficiência. Para isso, busca-se a automação de etapas-chave, integrando diferentes setores do hotel para otimizar o fluxo de informações e garantir uma experiência mais ágil e confiável tanto para os hóspedes quanto para a equipe de atendimento.

**Modelo de processo (BPMN) - Gerência de reservas:**

![Diagrama – Gestão de Reservas Revisado](<../images/Diagrama processo 1 - Gestao de reservas.png>)

## Tela 1 – Requisição de reserva

| Campo                | Tipo           | Restrições               | Valor default |
|----------------------|----------------|--------------------------|---------------|
| nome                 | Caixa de texto | obrigatório               |               |
| e-mail               | Caixa de texto | formato xxxxxxx@xmail.com |               |
| telefone             | Número         | formato (xx)xxxxx-xxxx    |               |
| data_checkin         | Data           | formato dd-mm-aaaa       |               |
| data_checkout        | Data           | formato dd-mm-aaaa       |               |
| tipo_quarto          | Seleção única  | opção: solteiro, casal    |               |
| quantidade_pessoas   | Número         | mínimo 1                  |               |

| **Comandos** | **Destino**                             | **Tipo** |
|--------------|-----------------------------------------|----------|
| enviar       | Recebimento de pedido de reserva        | default  |
| cancelar     | Fim do processo                         | cancel   |

---

## Tela 2 – Avisar cliente sobre indisponibilidade

| Campo            | Tipo           | Restrições            | Valor default                                   |
|------------------|----------------|-----------------------|-------------------------------------------------|
| e-mail_cliente   | Caixa de texto | formato de e-mail     |                                                 |
| mensagem         | Área de texto  | texto automático      | texto automático informando a indisponibilidade |

| **Comandos** | **Destino**                   | **Tipo** |
|--------------|-------------------------------|----------|
| voltar       | Requisição de reserva         | default  |

---

## Tela 3 – Fornecimento de dados

| Campo            | Tipo    | Restrições                          | Valor default                                     |
|------------------|---------|-------------------------------------|---------------------------------------------------|
| dados_cliente    | Tabela  | dados preenchidos na reserva        |                                                   |
| valor total      | Número  | calculado com base nas datas        |                                                   |

| **Comandos** | **Destino**           | **Tipo** |
|--------------|-----------------------|----------|
| prosseguir   | Pagamento da reserva  | default  |

---

## Tela 4 – Confirmar reserva para o cliente

| Campo            | Tipo           | Restrições            | Valor default                              |
|------------------|----------------|-----------------------|--------------------------------------------|
| e-mail_cliente   | Caixa de texto | formato de e-mail     |                                            |
| mensagem         | Área de texto  | texto automático      | texto automático de confirmação             |

| **Comandos** | **Destino**     | **Tipo** |
|--------------|-----------------|----------|
| encerrar     | Fim do processo | default  |
