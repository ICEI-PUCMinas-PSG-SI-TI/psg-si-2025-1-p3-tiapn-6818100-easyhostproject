## 3. Modelagem dos Processos de Negócio

### 3.1. Modelagem da situação atual (Modelagem AS IS)

Os sistemas atuais de gerenciamento hoteleiro são amplamente utilizados por grandes redes de hotéis, oferecendo soluções completas que integram reservas, gestão financeira, controle de estoque, atendimento ao cliente e outras funcionalidades. No entanto, essas plataformas costumam ser complexas, exigem alto investimento e necessitam de infraestrutura robusta para operar, o que as torna inacessíveis para pequenos hotéis e pousadas situados em locais remotos.
A implementação do Easy Host eliminará muitas dessas ineficiências ao oferecer um sistema acessível, leve e fácil de usar. O software permitirá que pequenos hotéis centralizem suas operações, automatizem processos e reduzam erros.

1. **Gestão de Reserva**  
    - **Contato inicial por telefone ou e-mail:** O cliente entra em contato para verificar disponibilidade de quartos. Todas as anotações são feitas em formulários de papel ou em planilhas dispersas.  
    - **Confirmação da reserva:** Após o cliente confirmar, o funcionário preenche um formulário e arquiva em uma pasta específica. Em alguns casos, a reserva pode ser perdida ou duplicada, pois não há um sistema centralizado que controle a ocupação.  

2. **Check-in**    
   - **Recepção do hóspede:** No check-in, o cliente preenche novamente seus dados em um livro físico, que pode conter rasuras ou dados ilegíveis.
   - **Recepção do hóspede:** Depois disso, o cliente recebe a chave do seu quarto e é direcinado.

3. **Gerenciamento do serviço para Hóspedes**  
   - **Solicitações de serviços:** As solicitações dos serviços de quarto são feitas por meio de telefone e anotadas em papel, é um processo sejeito a esquecimentos.  
   - **Distribuição de tarefas:** Os responsáveis pela realização desses serviços são avisados e vão até os quartos entregar o que foi solicitado.

4. **Gerenciamento de Serviços Internos**  
   - **Solicitações de serviços:** As solicitações de serviços (manutenção, limpeza especial, refeições extras) são comunicadas diretamente ao funcionário de plantão ou anotadas em notas adesivas, sem um procedimento claro de acompanhamento.  
   - **Distribuição de tarefas:** Os responsáveis pela limpeza e manutenção recebem instruções verbalmente ou em recados pouco organizados, ocasionando atrasos ou execução de serviços em duplicidade.

5. **Faturamento e Pagamentos**  
   - **Registro de despesas e pagamentos:** Despesas do hóspede são registradas em planilhas ou cadernos. Falhas humanas são frequentes, gerando inconsistências e dificuldade para conferência.  
   - **Pagamento ao final da estadia:** O hóspede efetua o pagamento em dinheiro ou cartão, que muitas vezes não é registrado de forma imediata e sistemática, comprometendo o controle financeiro.

6. **Checkout**  
   - **Conferência manual de consumos:** O checkout é realizado no balcão onde a chave é entregue e os processos são encerrados, os consumiveis são verificados e o pagamanto se consumido é feito.  
   - **Feedback do hóspede:** Não há processo estruturado para coleta de avaliação. Em geral, é solicitada verbalmente uma opinião, sem registro formal que permita análise posterior.


---

## Ineficiências e Retrabalho

- **Falta de integração das informações:** Como tudo é feito em papel ou em planilhas esparsas, o retrabalho é frequente.  
- **Alto risco de erros:** Dados incorretos ou duplicados sobre reservas, check-in e gastos, causando divergências nos registros.  
- **Dificuldade de acompanhamento:** Sem um sistema atualizado em tempo real, a tomada de decisão é atrasada ou baseada em informações incompletas.  
- **Retrabalho nos processos manuais:** Vários formulários, notas e cadernos circulam entre setores, prolongando o tempo de resposta e a chance de falhas.

### 3.2. Descrição geral da proposta (Modelagem TO BE)

Tendo identificado os gargalos dos modelos AS IS, apresentem uma descrição da proposta de solução, buscando maior eficiência com a introdução da tecnologia. Abordem também os limites dessa solução e o seu alinhamento com as estratégias e objetivos do contexto de negócio escolhido. 
Colem aqui os modelos da solução proposta (modelo TO BE) elaborados com o apoio da ferramenta baseada em BPMN utilizada na disciplina.
Cada processo identificado deve ter seu modelo TO-BE específico. Descrevam as oportunidades de melhoria de cada processo da solução proposta.

Nossa proposta é desenvolver uma aplicação que irá ajudar pequenos hotéis a se organizarem melhor por meio dos sistemas de informação. O nosso sistema auxiliará no gerenciamento de hóspedes, serviços internos, serviços de quarto, funcionários e estoque (uso e consumo). Ao oferecer uma solução intuitiva e acessível, eliminamos a dependência de processos manuais e descentralizados, reduzindo erros e melhorando a eficiência operacional. Além disso, a plataforma será otimizada para dispositivos móveis, garantindo praticidade para os gestores acompanharem as operações em tempo real.

A proposta está alinhada com a estratégia de modernização e otimização dos pequenos negócios hoteleiros, permitindo que acompanhem melhor seus custos e aumentem a satisfação dos hóspedes. Entre as oportunidades de melhoria, destacamos a possibilidade de automação de tarefas repetitivas, integração entre setores do hotel e geração de relatórios detalhados para análise de desempenho. Essas funcionalidades contribuirão para a tomada de decisões mais assertivas e para o crescimento sustentável dos estabelecimentos.

### 3.3. Modelagem dos processos

[Processo 1 – Configuração Inicial e Cadastro de Quartos](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%201%20%E2%80%93%20Configura%C3%A7%C3%A3o%20Inicial%20e%20Cadastro%20de%20Quartos.md)

[Processo 2 – Reserva de Hóspedes](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%202%20%E2%80%93%20Reserva%20de%20H%C3%B3spedes.md)

[Processo 3 – Gestão de Status de Reserva](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%203%20%E2%80%93%20Gest%C3%A3o%20de%20Status%20de%20Reserva.md)

[Processo 4 – Controle de Consumos e Despesas](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%204%20%E2%80%93%20Controle%20de%20Consumos%20e%20Despesas.md)

[Processo 5 – Check-out](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%205%20%E2%80%93%20Check-out.md)

[Processo 6 – Relatórios e Análises](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/processos/Processo%206%20%E2%80%93%20Relat%C3%B3rios%20e%20An%C3%A1lises.md)

