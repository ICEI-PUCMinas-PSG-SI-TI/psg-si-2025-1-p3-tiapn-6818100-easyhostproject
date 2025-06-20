### 3.3.1 Processo 1 – Configuração Inicial e Cadastro de Quartos

O processo tem início quando o hotel entra em contato com a EasyHost para solicitar a utilização do sistema. A equipe da EasyHost realiza o cadastro inicial do hotel diretamente no banco de dados, inserindo as informações essenciais para habilitar o acesso à plataforma. Após a configuração inicial, o acesso ao sistema é liberado para o hotel, permitindo que seus funcionários realizem o cadastro dos administradores e demais colaboradores. Com os usuários devidamente cadastrados, o administrador do hotel acessa o sistema, navega até a página de gestão de quartos e cadastra todas as acomodações disponíveis, concluindo a etapa de configuração e preparação para o uso completo da plataforma.

**Modelo de processo (BPMN) - Configuração Inicial e Cadastro de Quartos:**

![Diagrama – Configuração Inicial e Cadastro de Quartos](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20processo%201%20-%20Configura%C3%A7%C3%A3o%20inicial%20do%20sistema.png)

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
