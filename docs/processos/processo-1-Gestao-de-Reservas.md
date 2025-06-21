### 3.3.1 Processo 1 – Configuração Inicial e Cadastro de Quartos

O processo tem início quando o hotel entra em contato com a EasyHost para solicitar a utilização do sistema. A equipe da EasyHost realiza o cadastro inicial do hotel diretamente no banco de dados, inserindo as informações essenciais para habilitar o acesso à plataforma. Após a configuração inicial, o acesso ao sistema é liberado para o hotel, permitindo que seus funcionários realizem o cadastro dos administradores e demais colaboradores. Com os usuários devidamente cadastrados, o administrador do hotel acessa o sistema, navega até a página de gestão de quartos e cadastra todas as acomodações disponíveis, concluindo a etapa de configuração e preparação para o uso completo da plataforma.

**Modelo de processo (BPMN) - Configuração Inicial e Cadastro de Quartos:**

![Diagrama – Configuração Inicial e Cadastro de Quartos](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20processo%201%20-%20Configura%C3%A7%C3%A3o%20inicial%20do%20sistema.png)

## Tela 1 – Cadastro de usuário

| Campo                | Tipo           | Restrições               | Valor default |
|----------------------|----------------|--------------------------|---------------|
| nome                 | Caixa de texto | obrigatório               |               |
| cpf               | Caixa de texto | XXX.XXX.XXX-XX |               |
| salário             | Número         | formato dinheiro    |               |
| tipo_funcionário       | Seleção única   | opção: funcionário, administrador       |               |
| e-mail               | Caixa de texto | formato xxxxxxx@xmail.com |               |
| Senha         | Caixa de texto  |     |               |
| Confirmar Senha         | Caixa de texto  |         |               |

| **Comandos** | **Destino**                             | **Tipo** |
|--------------|-----------------------------------------|----------|
| Cadastrar       | Cadastra usuário        | default  |


---

## Tela 2 – Gerenciamento de Quartos

| **Comandos** | **Destino**                   | **Tipo** |
|--------------|-------------------------------|----------|
| Novo Quarto     | Criação de quarto         | default  |
| Editar     | Editar quarto         | default  |
| Excluir     | Exclusão de quarto         | default  |

---

## Tela 3 – Novo Quarto
| Campo            | Tipo    | Restrições                          | Valor default                                     |
|------------------|---------|-------------------------------------|---------------------------------------------------|
| Número do quarto    | Número   |         |                                                   |
| Camas Solteiro      | Número  |         |                                                   |
| Camas Casal     | Tabela  |        |                                                   |
| Máximo Pessoas      | Número  |         |                                                   |
| Preço diária      | Dinheiro  |        |                                                   |

| **Comandos** | **Destino**           | **Tipo** |
|--------------|-----------------------|----------|
| Cadastrar   | Gerenciamento de quartos  | default  |
| Ferchar   | Gerenciamento de quartos  | default  |

---

## Tela 4 – Editar Quarto

| Campo            | Tipo    | Restrições                          | Valor default                                     |
|------------------|---------|-------------------------------------|---------------------------------------------------|
| Camas Solteiro      | Número  |         |                                                   |
| Camas Casal     | Tabela  |        |                                                   |
| Máximo Pessoas      | Número  |         |                                                   |
| Preço diária      | Dinheiro  |        |                                                   |

| **Comandos** | **Destino**           | **Tipo** |
|--------------|-----------------------|----------|
| Salvar   | Gerenciamento de quartos  | default  |
| Ferchar   | Gerenciamento de quartos  | default  |
