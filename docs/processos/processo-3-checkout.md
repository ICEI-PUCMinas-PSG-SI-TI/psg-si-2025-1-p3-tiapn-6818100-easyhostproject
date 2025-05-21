### 3.3.3 Processo 3 - CHECKOUT

O processo de checkout tem como objetivo tornar a finalização da estadia mais dinâmica, rápida e confiável, reduzindo o tempo de espera e evitando inconsistências nos registros de consumo e pagamentos. Ao automatizar etapas como a conferência de consumos e a geração de relatórios, o sistema garante mais precisão nas informações e melhora a experiência do hóspede, ao mesmo tempo em que facilita o trabalho da equipe de recepção.

**Modelo de processo (BPMN) - Check Out:**

![Diagrama - Ckeck Out](<../images/Diagrama processo 3 - Check out.png>)

## Tela 1 – Acessar Sistema

| Campo | Tipo           | Restrições             | Valor default |
|-------|----------------|------------------------|---------------|
| login | Caixa de texto | formato de e-mail      |               |
| senha | Caixa de texto | mínimo de 8 caracteres |               |

| **Comandos** | **Destino**                       | **Tipo** |
|--------------|------------------------------------|----------|
| entrar       | Verificar consumo pelo sistema     | default  |
| cancelar     | Fim do processo                    | cancel   |

---

## Tela 2 – Verificar consumo pelo sistema

| Campo             | Tipo           | Restrições              | Valor default                |
|-------------------|----------------|-------------------------|------------------------------|
| Nome do hóspede   | Caixa de texto | obrigatório             |                              |
| Número da reserva | Número         | obrigatório             |                              |
| Itens consumidos  | Tabela         | preenchido pelo sistema |                              |

| **Comandos** | **Destino**                                          | **Tipo** |
|--------------|------------------------------------------------------|----------|
| continuar    | Pagar (se houver) / Devolver chaves (se não houver)  | default  |
| sair         | Fim do processo                                      | cancel   |

---

## Tela 3 – Pagar consumíveis

| Campo               | Tipo             | Restrições      | Valor default |
|---------------------|------------------|-----------------|---------------|
| Valor total         | Número           | somente leitura |               |
| Método de pagamento | Seleção única    | débito, crédito, pix |         |
| Comprovante         | Upload de arquivo | opcional      |               |

| **Comandos** | **Destino**         | **Tipo** |
|--------------|---------------------|----------|
| pagar        | Devolver as chaves  | default  |

---

## Tela 4 – Devolver as chaves

| Campo                    | Tipo          | Restrições       | Valor default |
|--------------------------|---------------|------------------|---------------|
| Data e hora de devolução | Data e Hora   | automático       | data atual    |
| Observações              | Área de texto | opcional         |               |

| **Comandos**        | **Destino**                           | **Tipo** |
|---------------------|----------------------------------------|----------|
| confirmar devolução | Encerramento da estadia no sistema     | default  |

---

## Tela 5 – Encerramento da estadia no sistema

| Campo             | Tipo        | Restrições    | Valor default |
|-------------------|-------------|---------------|---------------|
| Data e hora saída | Data e Hora | automático    | data atual    |

| **Comandos** | **Destino**            | **Tipo** |
|--------------|------------------------|----------|
| concluir     | Agendamento da limpeza | default  |

---

## Tela 6 – Agendamento da limpeza

| Campo            | Tipo           | Restrições    | Valor default |
|------------------|----------------|---------------|---------------|
| Número do quarto | Número         | obrigatório   |               |
| Data da limpeza  | Data           | ≥ data atual  |               |
| Observações      | Área de texto  | opcional      |               |

| **Comandos** | **Destino**      | **Tipo** |
|--------------|------------------|----------|
| salvar       | Fim do processo  | default  |
