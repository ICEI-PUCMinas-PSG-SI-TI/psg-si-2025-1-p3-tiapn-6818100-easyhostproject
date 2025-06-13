### 3.3.2 Processo 2 – CHECK IN

O processo de Check-In visa agilizar a recepção de hóspedes, garantindo rapidez na confirmação de reservas e na organização dos quartos disponíveis. Ao unificar automaticamente a verificação de reservas com a checagem de disponibilidade em tempo real, reduzimos falhas de comunicação entre a recepção e o sistema de gestão, permitindo que o atendente 
imediatamente libere a chave do quarto ou redirecione para alocação alternativa.

**Modelo de processo (BPMN) - Check In:**

![Diagrama - Check In](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Diagrama%20processo%202%20-%20CHECK-IN.png)

## Tela 1 – Fornecimento dos dados

| Campo               | Tipo           | Restrições               | Valor default |
|---------------------|----------------|--------------------------|---------------|
| Número da reserva   | Texto          | obrigatório              |               |
| CPF do cliente      | Caixa de texto | formato: 000.000.000-00  |               |
| Nome completo       | Caixa de texto | obrigatório              |               |

| **Comandos** | **Destino**                      | **Tipo** |
|--------------|----------------------------------|----------|
| continuar    | Verificar reserva no sistema     | default  |
| cancelar     | Fim do processo                  | cancel   |

---

## Tela 2 – Verificar reserva no sistema

| Campo           | Tipo           | Restrições                   | Valor default |
|-----------------|----------------|------------------------------|---------------|
| CPF do cliente  | Caixa de texto | formato: 000.000.000-00      |               |
| Nome completo   | Caixa de texto | obrigatório                  |               |

| **Comandos** | **Destino**                        | **Tipo** |
|--------------|------------------------------------|----------|
| continuar    | Entrega chave / Verif. quartos	    | default  |
| cancelar     | Fim do processo                    | cancel   |

---

## Tela 3 – Verificação de disponibilidade de quartos

| Campo                    | Tipo           | Restrições          | Valor default |
|--------------------------|----------------|---------------------|---------------|
| Tipo de quarto desejado  | Seleção única  | obrigatório         | Standard      |
| Data de entrada          | Data           | ≥ data atual        |               |
| Data de saída            | Data           | > data de entrada   |               |

| **Comandos** | **Destino**                         | **Tipo** |
|--------------|-------------------------------------|----------|
| verificar    | Confirmação dos dados               | default  |
| voltar       | Verificar reserva no sistema        | cancel   |

---

## Tela 4 – Confirmação dos dados do cliente

| Campo               | Tipo              | Restrições          | Valor default    |
|---------------------|-------------------|---------------------|------------------|
| Nome completo       | Caixa de texto    | obrigatório         |                  |
| CPF                 | Caixa de texto    | formato válido      |                  |
| Telefone            | Caixa de texto    | obrigatório         |                  |
| Documento com foto  | Arquivo           | formato .jpg / .pdf |                  |

| **Comandos** | **Destino**               | **Tipo** |
|--------------|---------------------------|----------|
| confirmar    | Alocação do cliente       | default  |
| cancelar     | Fim do processo           | cancel   |

---

## Tela 5 – Alocação do cliente

| Campo             | Tipo   | Restrições         | Valor default |
|-------------------|--------|--------------------|---------------|
| Número do quarto  | Número | quarto disponível  |               |
| Andar             | Número | ≥ 1                |               |

| **Comandos** | **Destino**                 | **Tipo** |
|--------------|-----------------------------|----------|
| concluir     | Entrega chave ao cliente    | default  |

## Tela 6 – Enviar aviso de indisponibilidade

| Campo                 | Tipo              | Restrições        | Valor default                             |
|-----------------------|-------------------|-------------------|-------------------------------------------|
| e-mail do cliente     | Caixa de texto    | formato de e-mail |                                           |
| mensagem              | Área de texto     | automático        | Texto informando indisponibilidade de quartos |

| **Comandos** | **Destino**          | **Tipo** |
|--------------|----------------------|----------|
| enviar       | Fim do processo      | default  |

---

## Tela 7 – Orientações gerais ao cliente

| Campo   | Tipo         | Restrições | Valor default |
|---------|--------------|------------|---------------|
| —       | Texto estático | —          | —             |

| **Comandos** | **Destino**          | **Tipo** |
|--------------|----------------------|----------|
| concluir     | Fim do processo      | default  |
